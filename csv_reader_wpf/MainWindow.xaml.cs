using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace csv_reader_wpf
{
    static class DataGridEx
    {

    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int ROWSCOUNT = 1000;
        int rowscount;
        Window1 addrowwindow;
        public string currentpath;
        OpenFileDialog dialog;
        public List<Cinema> Cinemas = new List<Cinema>();
        List<Region> regions = new List<Region>();
        public List<GridViewModel> content = new List<GridViewModel>();
        public List<GridViewModel> edited = null;
        const string header = "ROWNUM;CommonName;FullName;ShortName;ChiefOrg;AdmArea;District;" +
            "Address;ChiefName;ChiefPosition;PublicPhone;Fax;Email;WorkingHours;" +
            "ClarificationOfWorkingHours;WebSite;OKPO;INN;NumberOfHalls;TotalSeatsAmount;X_WGS;Y_WGS;GLOBALID;";
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                dataGridView1.ItemsSource = content;
                rowscount = int.Parse(RowsCount.Text);
            }
            catch (Exception er)
            {
                RowsCount.Text = "200";
                rowscount = 200;
                MessageBox.Show($"Incorrect value for rows count." + er.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Open_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                dataGridView1.ItemsSource = null;
                content.Clear();

                List<List<string>> data = new List<List<string>>();
                dialog = new OpenFileDialog();
                dialog.Filter = "CSV Files|*.csv";
                dialog.ShowDialog();

                var stRows = new List<string>(File.ReadAllLines(dialog.FileName));
                Cinema.IsValid(File.ReadAllText(dialog.FileName)); // проверка на количество ';'


                for (int i = 1; i < stRows.Count; i++)
                    data.Add(new List<string>(stRows[i].Split(';')));


                for (var i = 0; i < data.Count; i++)
                {
                    var region = new Region(data[i][5], data[i][6]);
                    data[i].RemoveRange(5, 2);
                    if (regions.IndexOf(region) == -1)
                        regions.Add(region);
                    if (content.Count == rowscount)
                        break;
                    Cinemas.Add(new Cinema(data[i], region));
                    content.Add(Cinemas[Cinemas.Count - 1].ToGridView);
                }
                currentpath = dialog.FileName;
                dataGridView1.ItemsSource = content;
            }
            catch (Exception er)
            {
                MessageBox.Show($"Can't open file." + er.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Save_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                string res = GridToString();
                Cinema.IsValid(res);
                File.WriteAllText(currentpath, res, Encoding.Unicode);
                MessageBox.Show("File Saved.", $"Succesfull", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Can't save file." + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Save_As_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                string res = GridToString();
                Cinema.IsValid(res);
                SaveFileDialog s = new SaveFileDialog();
                s.DefaultExt = ".csv";
                s.AddExtension = true;
                //s.Filter = "|*.csv";

                bool? result = s.ShowDialog();
                if (result == true)
                {
                    File.WriteAllText(s.FileName, res, Encoding.Unicode);
                    currentpath = s.FileName;
                    MessageBox.Show("File Saved.", $"Succesfull", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Can't save file." + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public string GridToString()
        {
            try
            {
                dataGridView1.ItemsSource = null;
                if (edited != null)
                    content = edited;
                edited = null;
                dataGridView1.ItemsSource = content;
                string res = header+ "\r\n";

                for (int i = 0; i < content.Count; i++)
                {
                    for (int j = 0; j < 23; j++)
                    {
                        res += content[i][j] + ";";
                    }
                    res += "\r\n";
                }
                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Can't convert grid to csv.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
        private void AddRow_Clicked(object sender, RoutedEventArgs e)
        {
            if (content.Count == int.Parse(RowsCount.Text))
            {
                MessageBox.Show($"Max value of rows reached.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            addrowwindow = new Window1(this);
            addrowwindow.Show();
        }

        private void DataGridView1_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var texbox = (TextBox)e.EditingElement;
            var grid = (DataGrid)sender;
            int row = e.Row.GetIndex();
            int column = e.Column.DisplayIndex;
            string s = (dataGridView1.Items[row] as GridViewModel)[column];
            if (texbox.Text.IndexOf(';') != -1 || column == 0)
            {
                texbox.Text = s;
                MessageBox.Show("Incorrect Data in Cell", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void Sort_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (ToSortComboBox.Text)
                {
                    case "District":
                        content.Sort((a, b) => a.District.CompareTo(b.District));
                        dataGridView1.ItemsSource = null;
                        dataGridView1.ItemsSource = content;
                        break;
                    case "FullName":
                        content.Sort((a, b) => a.FullName.CompareTo(b.FullName));
                        dataGridView1.ItemsSource = null;
                        dataGridView1.ItemsSource = content;
                        break;
                    default:
                        MessageBox.Show("Choose column in Combo box", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't sort this.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Filter_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(FILTEr.Text))
                {
                    MessageBox.Show("Filter is empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                switch (ToFilterComboBox.Text)
                {
                    
                    case "District":
                        edited = content
                            .AsQueryable()
                            .Where(x => x.District.Contains(FILTEr.Text))
                            .ToList();
                        dataGridView1.ItemsSource = null;
                        dataGridView1.ItemsSource = edited;

                        break;
                    case "AdmArea":
                        edited = content
                            .AsQueryable()
                            .Where(x => x.AdmArea.Contains(FILTEr.Text))
                            .ToList();
                        dataGridView1.ItemsSource = null;
                        dataGridView1.ItemsSource = edited;
                        break;
                    default:
                        MessageBox.Show("Choose column in combo box", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't filter this.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RowsCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                rowscount = int.Parse(RowsCount.Text);
                if (rowscount > ROWSCOUNT)
                    throw new Exception("Rows Count cant be more than 1000");
            }

            catch (Exception er)
            {
                RowsCount.Text = "200";
                rowscount = 200;
                MessageBox.Show($"Incorrect value for rows count." + er.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
