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
        
            string localVar = "4";
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            if (selectedItem.Content != null)
            {
                localVar = selectedItem.Content.ToString();
                i = Convert.ToInt32(localVar);
                TextBoxMass = new TextBox[i];
                ResultCountColumns = i;
                if (i==3)
                {
                    TB4.Visibility = Visibility.Collapsed;
                    TB5.Visibility = Visibility.Collapsed;                    
                    TB6.Visibility = Visibility.Collapsed;
                    TB7.Visibility = Visibility.Collapsed;
                }
                if (i==4)
                {
                    TB4.Visibility = Visibility.Visible;
                    TB5.Visibility = Visibility.Collapsed;
                    TB6.Visibility = Visibility.Collapsed;
                    TB7.Visibility = Visibility.Collapsed;
                }
                if (i==5)
                {
                    TB4.Visibility = Visibility.Visible;
                    TB5.Visibility = Visibility.Visible;
                    TB6.Visibility = Visibility.Collapsed;
                    TB7.Visibility = Visibility.Collapsed;
                }
                if (i==6)
                {
                    TB4.Visibility = Visibility.Visible;
                    TB5.Visibility = Visibility.Visible;
                    TB6.Visibility = Visibility.Visible;
                    TB7.Visibility = Visibility.Collapsed;
                }
                if (i==7)
                {
                    TB4.Visibility = Visibility.Visible;
                    TB5.Visibility = Visibility.Visible;
                    TB6.Visibility = Visibility.Visible;
                    TB7.Visibility = Visibility.Visible;
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
            DataResult.ResultCountColumns = ResultCountColumns;
            ComboBoxColumsChecked(sender, e);
            this.Close();
        }

    }
}
