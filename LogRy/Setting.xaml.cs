using System;
using System.Windows;
using System.Windows.Controls;

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



        private string RadioButtonSplitChecked(object sender, RoutedEventArgs e)
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
      
        int ResultCountColumns;


        private void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = 0;
            if (StackPanelColName != null)
                StackPanelColName.Children.Clear();
            
            string localVar="4";
            ComboBoxItem selectedItem = (ComboBoxItem)ComboBox.SelectedItem;
            if (selectedItem.Content != null)
            {
                localVar = selectedItem.Content.ToString();
                i = Convert.ToInt32(localVar);
                TextBox[] TextBoxMass = new TextBox[i];
                ResultCountColumns = i;


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

        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            string result;
            result = RadioButtonSplitChecked(sender, e);
            if (result == null)
            {
                result = ";";
            }
            DataResult.ResultSplitSetting = Convert.ToString(result);
            if (ResultCountColumns == 0)
                DataResult.ResultCountColumns = 4;
            else
            DataResult.ResultCountColumns = ResultCountColumns;
           

            ComboBoxColumsChecked(sender, e);
            this.Close();
        }
    }
}
