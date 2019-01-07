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



        private string RadioButtonChecked(object sender, RoutedEventArgs e)
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
       

        private void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i=0;
            if (StackPanelColName != null)
                StackPanelColName.Children.Clear();
            if (StackPanelDataType != null)
                StackPanelDataType.Children.Clear();
            string localVar="4";
            ComboBoxItem selectedItem = (ComboBoxItem)ComboBox.SelectedItem;
            if (selectedItem.Content != null)
            {
                localVar = selectedItem.Content.ToString();
                i = Convert.ToInt32(localVar);
                TextBox[] TextBoxMass = new TextBox[i];
                ComboBox[] ComboBoxMass = new ComboBox[i];

                for (int j = 0; j < i; j++)
                {
                    TextBox TextBoxN = new TextBox();
                    TextBoxN.Name = $"TextBoxName{j+1}";
                    TextBoxN.Text = "";
                    TextBoxN.Height = 25;
                    StackPanelColName.Children.Add(TextBoxN);
                    //StackPanelColName.RegisterName(TextBoxN.Name, TextBoxN);
                    ComboBox ComboBoxN = new ComboBox();
                    ComboBoxN.Height = 25;
                    ComboBoxN.Name = $"DataTypeCombpBox{j+1}";
                    ComboBoxN.Items.Add("DateTime");
                    ComboBoxN.Items.Add("String");
                    ComboBoxN.Items.Add("Int");
                    StackPanelDataType.Children.Add(ComboBoxN);
                    TextBoxMass[j] = TextBoxN;
                    ComboBoxMass[j] = ComboBoxN;
                }
            }
          
        }

        private void ClClick(object sender, RoutedEventArgs e)
        {

        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            string result;
            result = RadioButtonChecked(sender, e);
            DataResult.ResultSplitSetting = Convert.ToString(result);
            this.Close();
        }
    }
}
