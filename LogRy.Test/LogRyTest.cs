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

            // assert

        }
        [TestMethod]
        public void RadioButtonSplitCheckedTest()
        {
            Setting c = new Setting();
            string Resl = c.RadioButtonSplitChecked(null, new System.Windows.RoutedEventArgs());
            Assert.AreNotEqual(null, Resl);
        }
        [TestMethod]
        public void GetCellNullTest()
        {
            MainWindow cl = new MainWindow();
            DataGrid host = new DataGrid();
            DataGridRow row = new DataGridRow();
            DataGridCell res = cl.GetCell(host, row, 1);
            Assert.AreEqual(res, null);

        }
        //Тест на пердачу имени колонки
        [TestMethod]
        public void DataTabResTest()
        {
            string[] par = { "DateT", "Lvl" };
            int i = 2;
            DataTabRes test = new DataTabRes(par, i);
            Assert.AreEqual(test.DateTime, "DateT");
            Assert.AreEqual(test.Level, "Lvl");
        }

    }
}