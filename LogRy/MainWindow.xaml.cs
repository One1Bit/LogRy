﻿
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System;
using Xunit;
using System.Windows.Data;
using System.Windows.Input;

namespace YourProject.Tests
{
    public static class MyAssert
    {
        public static void Throws<T>(Action func) where T : Exception
        {
            var exceptionThrown = false;
            try
            {
                func.Invoke();
            }
            catch (T)
            {
                exceptionThrown = true;
            }

            if (!exceptionThrown)
            {
                throw new AssertFailedException(
                String.Format("An exception of type {0} was expected, but not thrown", typeof(T))
                );
            }
        }
    }

}
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
        public MainWindow(){ InitializeComponent(); }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


    public void OpenNewLogClick(object sender, RoutedEventArgs e)
        {
            string Split = DataResult.ResultSplitSetting;
            if (Split == null)
                Split = ";";
            int i= DataResult.ResultCountColumns;
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

        private void OpenBuildInLogClick(object sender, RoutedEventArgs e)
        {
            List<DataTable> list = new List<DataTable>();
            if (System.IO.File.Exists("LogBuild.txt"))
            {
                try
                {
                    using (StreamReader sr = new StreamReader("LogBuild.txt", System.Text.Encoding.Default))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            var parsed = line.Split(';'); //Делим строку по символу 
                            list.Add(new DataTable(parsed[0], parsed[1], parsed[2], parsed[3]));
                        }
                    }
                    DataGrid.ItemsSource = list;
                    this.Title = $"LogRy LogBuild.txt ";
                
                }
                catch (Exception a)
                {
                    MessageBox.Show("The file could not be read!");
                    MessageBox.Show($"{a}");
                }
            }
            else
                MessageBox.Show("File LogBuild.txt not exist!");
   

        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = null;
            this.Title = "LogRy";
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
            e.Row.Header = (e.Row.GetIndex()+1).ToString();
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
            if(DataGrid.Columns.Count > 0)
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

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    class DataTable
    {
        public DataTable(string col1, string col2, string col3, string col4)
        {
            this.DateTime = col1;
            this.Level = col2;
            this.Content = col3;
            this.Message = col4;
        }
        public string DateTime { get; set; }
        public string Level { get; set; }
        public string Content { get; set; }
        public string Message { get; set; }

    }
    class DataTabRes
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
}
