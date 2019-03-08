using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace csv_reader_wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        MainWindow main;
        public Window1(MainWindow main)
        {
            this.main = main;
            InitializeComponent();
            for (int i = 1; i < 23; i++)
            {
                this[i].Text = "";
                this[i].MinWidth = 50;
                this[i].MaxWidth = 200;
            }
        }

        public TextBox this[int index]
        {
            get
            {
                switch (index)
                {
                    case 1:
                        return CommonNameT;
                    case 2:
                        return FullNameT;
                    case 3:
                        return ShortNameT;
                    case 4:
                        return ChiefOrgT;
                    case 5:
                        return AdmAreaT;
                    case 6:
                        return DistrictT;
                    case 7:
                        return AddressT;
                    case 8:
                        return ChiefNAmeT;
                    case 9:
                        return ChiefPositionT;
                    case 10:
                        return PublicPhoneT;
                    case 11:
                        return FaxT;
                    case 12:
                        return EmailT;
                    case 13:
                        return WorkingHoursT;
                    case 14:
                        return ClarificationOfWorkingHoursT;
                    case 15:
                        return WebSiteT;
                    case 16:
                        return OKPOT;
                    case 17:
                        return INNT;
                    case 18:
                        return NumberOfHallsT;
                    case 19:
                        return TotalSeatsAmountT;
                    case 20:
                        return X_WGST;
                    case 21:
                        return Y_WGST;
                    case 22:
                        return GLOBALIDT;

                    default:
                        throw new ArgumentOutOfRangeException("Index of column was out of range.");
                }
            }
            set
            {
                switch (index)
                {

                    case 1:
                        CommonNameT = value;
                        break;
                    case 2:
                        FullNameT = value;
                        break;
                    case 3:
                        ShortNameT = value;
                        break;
                    case 4:
                        ChiefOrgT = value;
                        break;
                    case 5:
                        AdmAreaT = value;
                        break;
                    case 6:
                        DistrictT = value;
                        break;
                    case 7:
                        AddressT = value;
                        break;
                    case 8:
                        ChiefNAmeT = value;
                        break;
                    case 9:
                        ChiefPositionT = value;
                        break;
                    case 10:
                        PublicPhoneT = value;
                        break;
                    case 11:
                        FaxT = value;
                        break;
                    case 12:
                        EmailT = value;
                        break;
                    case 13:
                        WorkingHoursT = value;
                        break;
                    case 14:
                        ClarificationOfWorkingHoursT = value;
                        break;
                    case 15:
                        WebSiteT = value;
                        break;
                    case 16:
                        OKPOT = value;
                        break;
                    case 17:
                        INNT = value;
                        break;
                    case 18:
                        NumberOfHallsT = value;
                        break;
                    case 19:
                        TotalSeatsAmountT = value;
                        break;
                    case 20:
                        X_WGST = value;
                        break;
                    case 21:
                        Y_WGST = value;
                        break;
                    case 22:
                        GLOBALIDT = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Index of column was out of range.");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var str = new List<string>();
                str.Add(main.content.Count.ToString());
                for (int i = 1; i < 23; i++)
                {
                    if (this[i].Text.IndexOf(';') != -1)
                    {
                        MessageBox.Show($"Incorrect values.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    str.Add(this[i].Text);
                }
                Region reg;
                if (this[5].Text.IndexOf(';') == -1 && this[6].Text.IndexOf(';') == -1)
                {
                    reg = new Region(this[6].Text, this[5].Text);
                    str.RemoveRange(5, 2);
                }
                else
                {
                    MessageBox.Show($"Incorrect values.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var cin = new Cinema(str,reg);
                var obj = new GridViewModel(cin);
                main.dataGridView1.ItemsSource = null;
                if (main.content.Count == int.Parse(main.RowsCount.Text))
                {
                    MessageBox.Show($"Max value of rows reached.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                main.content.Add(obj);
                main.dataGridView1.ItemsSource = main.content;
            }
            catch
            {
                MessageBox.Show($"Incorrect values.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Burfdsf(object sender, RoutedEventArgs e)
        {

            try
            {
                var str = new List<string>();
                str.Add(main.content.Count.ToString());
                for (int i = 1; i < 23; i++)
                {
                    if (this[i].Text.IndexOf(';') != -1)
                    {
                        MessageBox.Show($"Incorrect values.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    str.Add(this[i].Text);
                }
                Region reg;
                if (this[5].Text.IndexOf(';') == -1 && this[6].Text.IndexOf(';') == -1)
                {
                    reg = new Region(this[6].Text, this[5].Text);
                    str.RemoveRange(5, 2);
                }
                else
                {
                    MessageBox.Show($"Incorrect values.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var cin = new Cinema(str, reg);
                var obj = new GridViewModel(cin);
                main.dataGridView1.ItemsSource = null;
                if (main.content.Count == int.Parse(main.RowsCount.Text))
                {
                    MessageBox.Show($"Max value of rows reached.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                main.content.Add(obj);
                main.dataGridView1.ItemsSource = main.content;
                if(String.IsNullOrEmpty(main.currentpath))
                {
                    MessageBox.Show($"Open or create file before save.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                string str2 = $"{main.content.Count};";
                for (int i = 1; i < 23; i++)
                {
                    if (this[i].Text.IndexOf(';') != -1)
                    {
                        MessageBox.Show($"Incorrect values.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    str2 += this[i].Text + ";";
                }
                str2 += "\r\n";
                File.AppendAllText(main.currentpath, str2, Encoding.Unicode);
            }
            catch
            {
                MessageBox.Show($"Incorrect values.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
