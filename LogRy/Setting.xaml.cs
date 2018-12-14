using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Automation;
using System.Windows.Controls.Primitives;
using System.Windows.Ink;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shell;
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

        private void clClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void okClick(object sender, RoutedEventArgs e)
        {
            string result;
            result = RadioButtonChecked(sender, e);

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
                return TextBoxOther.ToString();
            else
            MessageBox.Show("Error in Setting Split!");
            return null;
        }
    }
}
