
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;

namespace LogRy
{

    public partial class MainWindow : Window
    {
        /* public void SearchButtonClkick(object sender, RoutedEventArgs e)
             {
             int rows = DataGridView.Rows.Count;
             for (int i=0; i< rows; i++)
             {

             }

         }*/
        public MainWindow()
        {
            InitializeComponent();
            Properties.Settings.Default.open_sum++;
            OpenSum.Text = $"Number of application launches: {Properties.Settings.Default.open_sum.ToString()}";
            Properties.Settings.Default.Save();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        public void OpenNewLogClick(object sender, RoutedEventArgs e)
        {
            string Split = DataResult.ResultSplitSetting;
            if (Split == null)
                Split = ";";
            int i = DataResult.ResultCountColumns;
            if (i == 0)
                i = 4;
            var fileDialog = new System.Windows.Forms.OpenFileDialog();
            List<DataTabRes> list = new List<DataTabRes>();
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(fileDialog.FileName, System.Text.Encoding.Default))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] parsed = new string[i];
                            parsed = line.Split(Convert.ToChar(Split)); //Делим строку по символу
                            list.Add(new DataTabRes(parsed, i));
                        }
                    }
                    this.Title = $"LogRy {fileDialog.FileName} ";
                }
                catch (Exception a)
                {
                    MessageBox.Show("The file could not be read!");
                    MessageBox.Show($"{a}");
                }
                DataGrid.ItemsSource = list;
                DataGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
                DataGrid.VerticalAlignment = VerticalAlignment.Stretch;
                int count_row = DataGrid.Items.Count;

                for (int o = i; o < 7; o++)
                    DataGrid.Columns[o].Visibility = Visibility.Collapsed;
                if (DataResult.ResultColumns != null)
                {
                    for (int u = 0; u < i; u++)
                        DataGrid.Columns[u].Header = DataResult.ResultColumns[u];
                }
                PathToFile.Text = $"Path: {fileDialog.FileName}";
                NumOfLines.Text = $"Number of Lines: {DataGrid.Items.Count}";
                Properties.Settings.Default.Path = fileDialog.FileName;
                Properties.Settings.Default.Save();

            }

        }

        private void ExitClick(object sender, RoutedEventArgs e) => this.Close();

        private void MinimizeClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeClick(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }



        private void ClearClick(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = null;
            PathToFile.Text = null;
            NumOfLines.Text = null;
        }

        private void SettingClick(object sender, RoutedEventArgs e)
        {
            Setting SettingAll = new Setting
            {
                Owner = this
            };
            SettingAll.Show();

        }
        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();

        }

        private void CheckBox1_Checked(object sender, RoutedEventArgs e)
        {
            if (DataGrid.Columns.Count > 0)
            {

                DataGrid.Columns[0].Visibility = Visibility.Collapsed;

            }
        }

        private void CheckBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            if (DataGrid.Columns.Count > 0)
            {

                DataGrid.Columns[0].Visibility = Visibility.Visible;

            }
        }

        private void CheckBox2_Checked(object sender, RoutedEventArgs e)
        {
            if (DataGrid.Columns.Count > 0)
            {

                DataGrid.Columns[1].Visibility = Visibility.Collapsed;

            }
        }

        private void CheckBox2_Unchecked(object sender, RoutedEventArgs e)
        {
            if (DataGrid.Columns.Count > 0)
            {

                DataGrid.Columns[1].Visibility = Visibility.Visible;

            }
        }

        private void CheckBox3_Checked(object sender, RoutedEventArgs e)
        {
            if (DataGrid.Columns.Count > 0)
            {

                DataGrid.Columns[2].Visibility = Visibility.Collapsed;

            }
        }

        private void CheckBox3_Unchecked(object sender, RoutedEventArgs e)
        {
            if (DataGrid.Columns.Count > 0)
            {

                DataGrid.Columns[2].Visibility = Visibility.Visible;

            }
        }

        private void CheckBox4_Checked(object sender, RoutedEventArgs e)
        {
            if (DataGrid.Columns.Count > 0)
            {

                DataGrid.Columns[3].Visibility = Visibility.Collapsed;

            }
        }

        private void CheckBox4_Unchecked(object sender, RoutedEventArgs e)
        {
            if (DataGrid.Columns.Count > 0)
            {

                DataGrid.Columns[3].Visibility = Visibility.Visible;

            }
        }

        private void CheckBox5_Checked(object sender, RoutedEventArgs e)
        {
            if (DataGrid.Columns.Count > 0)
            {

                DataGrid.Columns[4].Visibility = Visibility.Collapsed;

            }
        }

        private void CheckBox5_Unchecked(object sender, RoutedEventArgs e)
        {
            if (DataGrid.Columns.Count > 0)
            {

                DataGrid.Columns[4].Visibility = Visibility.Visible;

            }
        }

        private void CheckBox6_Checked(object sender, RoutedEventArgs e)
        {
            if (DataGrid.Columns.Count > 0)
            {

                DataGrid.Columns[5].Visibility = Visibility.Collapsed;

            }
        }

        private void CheckBox6_Unchecked(object sender, RoutedEventArgs e)
        {
            if (DataGrid.Columns.Count > 0)
            {

                DataGrid.Columns[5].Visibility = Visibility.Visible;

            }
        }

        private void CheckBox7_Checked(object sender, RoutedEventArgs e)
        {
            if (DataGrid.Columns.Count > 0)
            {

                DataGrid.Columns[6].Visibility = Visibility.Collapsed;

            }
        }

        private void CheckBox7_Unchecked(object sender, RoutedEventArgs e)
        {
            if (DataGrid.Columns.Count > 0)
            {
                DataGrid.Columns[6].Visibility = Visibility.Visible;

            }
        }





        private void DataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataTabRes path = (DataTabRes)DataGrid.SelectedItem;
            if (DataGrid.CurrentColumn != null)
            {
                int column = DataGrid.CurrentColumn.DisplayIndex;


                if (path != null && column == 1)
                {
                    Random rand = new Random();
                    Brush brush = new SolidColorBrush(Color.FromRgb((byte)rand.Next(0, 256), (byte)rand.Next(0, 256), (byte)rand.Next(0, 256)));
                    string s = path.Level;
                    int columnIndex = DataGrid.CurrentColumn.DisplayIndex;
                    for (int i = 0; i < DataGrid.Items.Count; i++)
                    {
                        DataGridCell Cell = new DataGridCell();
                        DataTabRes p = DataGrid.Items[i] as DataTabRes;

                        if (p.Level == s)
                        {
                            DataGridRow Row = GetRow(DataGrid, i);

                            var cell = GetCell(DataGrid, Row, 1);
                            if (cell == null) return;
                            var item = Row.Item as DataTabRes;
                            if (item == null) return;

                            var value = item.Level;

                            cell.Background = brush;

                        }

                    }
                }
                if (path != null && column == 2)
                {
                    string s = path.Content;
                    for (int i = 0; i < DataGrid.Items.Count; i++)
                    {
                        int columnIndex = DataGrid.CurrentColumn.DisplayIndex;
                        DataGridCell Cell = new DataGridCell();
                        DataTabRes p = DataGrid.Items[i] as DataTabRes;

                        if (p.Content == s)
                        {
                            DataGridRow Row = GetRow(DataGrid, i);

                            var cell = GetCell(DataGrid, Row, 2);
                            if (cell == null) return;
                            var item = Row.Item as DataTabRes;
                            if (item == null) return;

                            var value = item.Content;
                            Random rand = new Random();
                            Brush brush = new SolidColorBrush(Color.FromRgb((byte)rand.Next(0, 256), (byte)rand.Next(0, 256), (byte)rand.Next(0, 256)));
                            cell.Background = brush;

                        }

                    }
                }
            }
        }

        public static DataGridRow GetRow(DataGrid grid, int index)
        {
            var row = grid.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;

            if (row == null)
            {
                grid.ScrollIntoView(grid.Items[index]);
                row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(index);
            }
            return row;
        }

        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                var v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T ?? GetVisualChild<T>(v);
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

        public DataGridCell GetCell(DataGrid host, DataGridRow row, int columnIndex)
        {
            if (row == null) return null;

            var presenter = GetVisualChild<DataGridCellsPresenter>(row);
            if (presenter == null) return null;

            var cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex);
            if (cell == null)
            {
                host.ScrollIntoView(row, host.Columns[columnIndex]);
                cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex);
            }
            return cell;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.Path != null)
                MI.Header = Properties.Settings.Default.Path;

        }

        private void MI_MouseLeave(object sender, MouseEventArgs e)
        {
            MI.Header = "Open last file ->";

        }

        private void MI_Click(object sender, RoutedEventArgs e)
        {
            string Split = DataResult.ResultSplitSetting;
            if (Split == null)
                Split = ";";
            int i = DataResult.ResultCountColumns;
            if (i == 0)
                i = 4;
            string file = Properties.Settings.Default.Path;
            List<DataTabRes> list = new List<DataTabRes>();

            try
            {
                using (StreamReader sr = new StreamReader(file, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parsed = new string[i];
                        parsed = line.Split(Convert.ToChar(Split)); //Делим строку по символу
                        list.Add(new DataTabRes(parsed, i));
                    }
                }
                this.Title = $"LogRy {file} ";
            }
            catch (Exception a)
            {
                MessageBox.Show("The file could not be read!");
                MessageBox.Show($"{a}");
            }
            DataGrid.ItemsSource = list;
            DataGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            DataGrid.VerticalAlignment = VerticalAlignment.Stretch;
            int count_row = DataGrid.Items.Count;

            for (int o = i; o < 7; o++)
                DataGrid.Columns[o].Visibility = Visibility.Collapsed;
            if (DataResult.ResultColumns != null)
            {
                for (int u = 0; u < i; u++)
                    DataGrid.Columns[u].Header = DataResult.ResultColumns[u];
            }
            PathToFile.Text = $"Path: {file}";
            NumOfLines.Text = $"Number of Lines: {DataGrid.Items.Count}";
            Properties.Settings.Default.Path = file;
            Properties.Settings.Default.Save();


        }
    }
}
       
        public partial class DataTabRes
        {
            public DataTabRes(string[] par, int i)
            {
                for (int j = 0; j < i; j++)
                {

                    switch (j)
                    {
                        case 0:
                            this.DateTime = par[j];
                            break;
                        case 1:
                            this.Level = par[j];
                            break;
                        case 2:
                            this.Content = par[j];
                            break;
                        case 3:
                            this.Message = par[j];
                            break;
                        case 4:
                            this.Comment = par[j];
                            break;
                        case 5:
                            this.Name = par[j];
                            break;
                        case 6:
                            this.Data = par[j];
                            break;
                        default:
                            break;
                    }


                }

            }
            public string DateTime { get; set; }
            public string Level { get; set; }
            public string Content { get; set; }
            public string Message { get; set; }
            public string Comment { get; set; }
            public string Name { get; set; }
            public string Data { get; set; }
        }
        class DataResult
        {
            public static string ResultSplitSetting { get; set; }
            public static int ResultCountColumns { get; set; }
            public static string[] ResultColumns { get; set; }
            public static string[] ResultColumnsTypeData { get; set; }
        }
        class Constats
        {
            public static string ColorationF { get; set; }
        }
    
