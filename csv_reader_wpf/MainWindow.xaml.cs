using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        public const int MAXROWSCOUNT = 100000;
        public int rowsFrom = 1, rowsTo = 1;

        public Window1 addrowwindow;
        public string currentpath;

        public List<Cinema> Cinemas = new List<Cinema>();
        List<Region> regions = new List<Region>();
        public List<GridViewModel> content = new List<GridViewModel>();
        public List<GridViewModel> edited = null;

        const string header = "ROWNUM;CommonName;FullName;ShortName;ChiefOrg;AdmArea;District;" +
            "Address;ChiefName;ChiefPosition;PublicPhone;Fax;Email;WorkingHours;" +
            "ClarificationOfWorkingHours;WebSite;OKPO;INN;NumberOfHalls;TotalSeatsAmount;X_WGS;Y_WGS;GLOBALID;" + "\r\n";
        public MainWindow()
        {
            InitializeComponent();
            dataGridView1.ItemsSource = content;
        }
        public void UpdateGrid()
        {
            dataGridView1.ItemsSource = null;
            content.Clear();
            
            for (int i = rowsFrom  - 1; i < rowsTo; i++)
            {
                content.Add(Cinemas[i].ToGridView);
            }
            RowsTo.Text = rowsTo.ToString();
            dataGridView1.ItemsSource = content;
        }

        private void Open_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                Cinemas.Clear();

                List<List<string>> data = new List<List<string>>();
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "CSV Files|*.csv";
                dialog.ShowDialog();
                if (String.IsNullOrEmpty(dialog.FileName))
                    return;
                else
                {
                    var stRows = new List<string>(File.ReadAllLines(dialog.FileName));

                    Cinema.IsValid(File.ReadAllText(dialog.FileName)); // проверка на количество ';'


                    for (int i = 1; i < stRows.Count; i++)
                        data.Add(new List<string>(stRows[i].Split(';')));

                }
                for (var i = 0; i < data.Count; i++)
                {
                    var region = new Region(data[i][5], data[i][6]);
                    data[i].RemoveRange(5, 2);
                    if (regions.IndexOf(region) == -1)
                        regions.Add(region);
                    Cinemas.Add(new Cinema(data[i], region));
                }
                currentpath = dialog.FileName;
                rowsTo = Cinemas.Count();
                UpdateGrid();
            }
            catch (Exception er)
            {
                MessageBox.Show($"Can't open file." + er.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void Save_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                File.WriteAllText(currentpath, header, Encoding.Unicode);
                using (var wrt = new StreamWriter(currentpath, append: true, encoding: Encoding.Unicode))
                {
                    for (int i = 0; i < content.Count; i++)
                    {
                        await wrt.WriteAsync(content[i].ToString());
                    }
                    MessageBox.Show("File Saved.", $"Succesfull", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show($"Incorrect values.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private async void Save_As_Clicked(object sender, RoutedEventArgs e)
        {

            try
            {
                SaveFileDialog s = new SaveFileDialog();
                s.DefaultExt = ".csv";
                s.AddExtension = true;
                //s.Filter = "|*.csv";

                bool? result = s.ShowDialog();
                if (result == true)
                {
                    File.WriteAllText(s.FileName, header, Encoding.Unicode);
                    using (var wrt = new StreamWriter(s.FileName, append: true, encoding: Encoding.Unicode))
                    {
                        for (int i = 0; i < content.Count; i++)
                        {
                            await wrt.WriteAsync(content[i].ToString());
                        }
                        MessageBox.Show("File Saved.", $"Succesfull", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Can't save file." + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

       
        private void AddRow_Clicked(object sender, RoutedEventArgs e)
        {
            if (content.Count == MAXROWSCOUNT)
            {
                MessageBox.Show($"Max value of rows reached.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (addrowwindow == null)
            {
                addrowwindow = new Window1(this);
                addrowwindow.Show();
            }
            else
            {
                addrowwindow.Close();
                addrowwindow = null;
                addrowwindow = new Window1(this);
                addrowwindow.Show();
            }
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

            GridViewModel[] temp = new GridViewModel[content.Count];
            try
            {
                switch (ToSortComboBox.Text)
                {
                    case "District":
                        content.CopyTo(temp);
                        edited = temp.ToList();
                        edited.Sort((a, b) => a.District.CompareTo(b.District));
                        dataGridView1.ItemsSource = null;
                        dataGridView1.ItemsSource = edited;
                        break;
                    case "FullName":
                        content.CopyTo(temp);
                        edited = temp.ToList();
                        edited.Sort((a, b) => a.FullName.CompareTo(b.FullName));
                        dataGridView1.ItemsSource = null;
                        dataGridView1.ItemsSource = edited;
                        break;
                    default:
                        MessageBox.Show("Choose column in the Combo box", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
            GridViewModel[] temp = new GridViewModel[content.Count];
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
                        content.CopyTo(temp);
                        edited = temp.ToList()
                            .AsQueryable()
                            .Where(x => x.District.Contains(FILTEr.Text))
                            .ToList();
                        dataGridView1.ItemsSource = null;
                        dataGridView1.ItemsSource = edited;

                        break;
                    case "AdmArea":
                        content.CopyTo(temp);
                        edited = temp.ToList()
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

        private void RowsCount_TextChanged1(object sender, TextChangedEventArgs e)
        {
            if (IsLoaded)
            {
                TextBox tb;
                try
                {
                    tb = (sender as TextBox);
                    if (!int.TryParse(tb.Text, out rowsFrom))
                        throw new IncorrectCinemaDataException("Value should be number");
                    if (rowsTo - rowsFrom > MAXROWSCOUNT)
                        throw new IncorrectCinemaDataException($"Max rows count is {MAXROWSCOUNT}");
                    if (rowsTo > Cinemas.Count || rowsFrom < 1)
                        throw new IncorrectCinemaDataException($"Rows count out of range");
                    if (rowsTo < rowsFrom)
                        throw new IncorrectCinemaDataException($"Left value less than right value");
                    UpdateGrid();
                }

                catch (Exception er)
                {
                    tb = (sender as TextBox);
                    tb.Text = "1";
                    rowsFrom = 1;
                    MessageBox.Show($"Incorrect value for rows count. " + er.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void RowsCount_TextChanged2(object sender, TextChangedEventArgs e)
        {
            if (IsLoaded)
            {
                TextBox tb;
                try
                {
                    tb = (sender as TextBox);
                    if (!int.TryParse(tb.Text, out rowsTo))
                        throw new IncorrectCinemaDataException("Value should be number");
                    if (rowsTo - rowsFrom > MAXROWSCOUNT)
                        throw new IncorrectCinemaDataException($"Max rows count is {MAXROWSCOUNT}");
                    if (rowsTo > Cinemas.Count || rowsFrom < 1)
                        throw new IncorrectCinemaDataException($"Rows count out of range");
                    if (rowsTo < rowsFrom)
                        throw new IncorrectCinemaDataException($"Left value less than right value");
                    UpdateGrid();
                }

                catch (Exception er)
                {
                    tb = (sender as TextBox);
                    tb.Text = Cinemas.Count.ToString();
                    rowsTo = Cinemas.Count;
                    MessageBox.Show($"Incorrect data in range. " + er.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

    }
}
