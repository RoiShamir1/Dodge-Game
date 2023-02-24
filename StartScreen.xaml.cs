using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GAME3
{
    /// <summary>
    /// Interaction logic for StartScreen.xaml
    /// </summary>
    public partial class StartScreen : Page
    {
        public StartScreen()
        {
            InitializeComponent();
            //loadSaves();
        }

        //private void loadSaves()
        //{
        //    var saves = Directory.GetFiles(@"C:\Users\Roi Shamir\Desktop\project\GAME3\bin\Debug", "*.save*");
        //    foreach (var save in saves)
        //    {
        //        string[] parts = save.Split('\\');
        //        ComboBoxItem item = new ComboBoxItem();

        //        item.Content = parts[parts.Length - 1];
        //        myCombo.Items.Add(item);
        //    }
        //}

        private void newGame_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void loadGame_Click(object sender, RoutedEventArgs e)
        {
            if(myCombo.SelectedItem != null)
            {     
                ComboBoxItem item = (ComboBoxItem)myCombo.SelectedItem;

                MainWindow mainWindow = new MainWindow(item.Content.ToString());
                mainWindow.Show();
            }
        }
    }
}