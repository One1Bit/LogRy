using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogRy.Test
{
    [TestClass]
    public class LogRyTest
    {

        [TestMethod]
        public void OpenNewLogClickTest()
        {
            //arrange
            //act
            LogRy.MainWindow c = new MainWindow();
            //c.OpenNewLogClick(null, new System.Windows.RoutedEventArgs());

            //assert
            
        }
        [TestMethod]
        public void RadioButtonSplitCheckedTest()
        {
            
            Setting c = new Setting();
            string Resl = c.RadioButtonSplitChecked(null, new System.Windows.RoutedEventArgs());
            Assert.AreNotEqual(null, Resl);
        }
    }
}
