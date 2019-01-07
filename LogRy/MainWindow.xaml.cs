
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System;
using Xunit;


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
        public MainWindow()
        {
            InitializeComponent();
        }


    private void OpenNewLogClick(object sender, RoutedEventArgs e)
        {
            string Split = DataResult.ResultSplitSetting;
            if (Split == null)
            {
                MessageBox.Show("Error! Split = ;");
                Split = ";";
            }
            var fileDialog = new System.Windows.Forms.OpenFileDialog();
            List<DataTable> list = new List<DataTable>();
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(fileDialog.FileName, System.Text.Encoding.Default))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            var parsed = line.Split(Convert.ToChar(Split)); //Делим строку по символу ;
                            list.Add(new DataTable(parsed[0], parsed[1], parsed[2], parsed[3]));
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
            }

        }

        private void ExitClick(object sender, RoutedEventArgs e) => this.Close();
        

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
                            var parsed = line.Split(';'); //Делим строку по символу &, например
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

        private void ClearClick(object sender, RoutedEventArgs e) =>  DataGrid.ItemsSource = null;

        private void SettingClick(object sender, RoutedEventArgs e)
        {
            Setting SettingAll = new Setting
            {
                Owner = this
            };
            SettingAll.Show();

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
    class DataResult
    {
        public static string ResultSplitSetting { get; set; }
    }
}
