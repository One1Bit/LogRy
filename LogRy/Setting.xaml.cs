using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace LogRy
{
    /// <summary>
    /// Логика взаимодействия для SettingColumns.xaml
    /// </summary>
    public partial class Setting : Window
    {
        public Setting()
        {
            InitializeComponent();
        }

        public string RadioButtonSplitChecked(object sender, RoutedEventArgs e)
        {
            
            if (tab.IsChecked == true)
                return "    ";
            else if (semicolon.IsChecked == true)
                return ";";
            else if(colon.IsChecked == true)
                return ":";
            else if (other.IsChecked == true)
                return Convert.ToString(TextBoxOther.Text);
            else
            MessageBox.Show("Error in Setting Split!");
            return null;
        }
       private void ComboBoxColumsChecked(object sender, RoutedEventArgs e)
        {
            DataResult.ResultColumns = new string[7];
                DataResult.ResultColumns[0] = Convert.ToString(TB1.Text);
                DataResult.ResultColumns[1] = Convert.ToString(TB2.Text);
                DataResult.ResultColumns[2] = Convert.ToString(TB3.Text);
                DataResult.ResultColumns[3] = Convert.ToString(TB4.Text);
                DataResult.ResultColumns[4] = Convert.ToString(TB5.Text);
                DataResult.ResultColumns[5] = Convert.ToString(TB6.Text);
                DataResult.ResultColumns[6] = Convert.ToString(TB7.Text);
        }   
       
         private string RadioButtonColorationChecked(object sender, RoutedEventArgs e)
        {
            if (RedC.IsChecked == true)
                return "WARN";
            else if (YellowC.IsChecked == true)
                return "INFO";
            else if (BlueC.IsChecked == true)
                return "WORK";
            else
                return "";
        }
        int ResultCountColumns;
        TextBox[] TextBoxMass;
        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = 0;
            if (StackPanelColName != null)
                StackPanelColName.Children.Clear();
            string localVar="4";
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)ComboBox.SelectedItem;
            if (selectedItem.Content != null)
            {
                localVar = selectedItem.Content.ToString();
                i = Convert.ToInt32(localVar);
                TextBoxMass = new TextBox[i] ;
                ResultCountColumns = i;

                Binding binding = new Binding();



                for (int j = 0; j < i; j++)
                {
                    TextBoxMass[j] = new TextBox
                    {
                        Name = "fr",
                        Text = "",
                        Height = 25
                    };
                    StackPanelColName.Children.Add(TextBoxMass[j]);
                }
            }
        }
        private void ClClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            string result;
            string result1;
            result = RadioButtonSplitChecked(sender, e);
            result1 = RadioButtonColorationChecked(sender, e);
            Constats.ColorationF = result1;
            if (result == null)
            {
                result = ";";
            }
            DataResult.ResultSplitSetting = Convert.ToString(result);
            this.Close();
        }
    }
}
