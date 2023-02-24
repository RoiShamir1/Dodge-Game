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
using System.Windows.Threading;
namespace GAME3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary> 
       
    public class Icons
    {
        public int SetRow { get; set; }
        public int SetColumn { get; set; }
        public bool alive { get; set; }

        public Icons(int setRow, int setColumn,bool alive)
        {
            SetRow = setRow;
            SetColumn = setColumn;
            this.alive = alive; 
        }
        public Icons()
        {

        }
    }
    public class baddie: Icons
    {
        public baddie(int setRow, int setColumn, bool alive)
            :base(setRow, setColumn, alive)
        {
            
        }
        public baddie()
        {
            alive = true;
        }
    }
    public class gooddie : Icons
    {
        public gooddie(int setRow, int setColumn, bool alive)
            : base(setRow, setColumn, alive)
        {
            
        }
        public gooddie()
        {

        }
    }
    public partial class MainWindow : Window
    {
        private string filePath;
        bool goleft, goright, goup, godown, gospace, savegame, newgame, start, close, pause, breakpause;
        int count = 0;

        Random rand;
        Rectangle [] badiesImage;
        Rectangle goodieImage;

        baddie[] badies;

        DispatcherTimer gametimer = new DispatcherTimer();
        public MainWindow()
        {
            rand = new Random();
            InitializeComponent();
            mygrid.Focus();
            gametimer.Tick += gametimerevent;
            gametimer.Interval = TimeSpan.FromSeconds(0.75);
            gametimer.Start();
            goodieImage = good;
            badiesImage = new Rectangle[10];
            badiesImage[0] = bad1;
            badiesImage[1] = bad2;
            badiesImage[2] = bad3;
            badiesImage[3] = bad4;
            badiesImage[4] = bad5;
            badiesImage[5] = bad6;
            badiesImage[6] = bad7;
            badiesImage[7] = bad8;
            badiesImage[8] = bad9;
            badiesImage[9] = bad10; 
            badies = new baddie[10];
            for (int i = 0; i < badies.Length; i++)
            {
                badies[i] = new baddie();
            }
        }
        public MainWindow(string filePath) : this()
        {

            this.filePath = filePath;
            loadSave();  
        }

        private void loadSave()
        {
            Rectangle[] badiesImage = new Rectangle[10] {bad1,bad2,bad3,bad4,bad5,bad6,bad7,bad8,bad9,bad10};
            //int count1 = 0;
            string path = this.filePath;
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                string[] goodParts = lines[0].Split('#');
                Grid.SetColumn(good, int.Parse(goodParts[1]));
                Grid.SetRow(good, int.Parse(goodParts[3]));
                if (goodParts[4] == "alive")
                {
                    good.Visibility = Visibility.Visible;
                }
                else
                {
                    good.Visibility= Visibility.Collapsed;
                }
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] badParts = lines[i].Split('#');
                    Grid.SetColumn(badiesImage[i - 1], int.Parse(badParts[1]));
                    Grid.SetRow(badiesImage[i - 1], int.Parse(badParts[3]));
                    if (badParts[4] == "alive")
                    {
                        badiesImage[i-1].Visibility = Visibility.Visible;
                    }
                    else
                    {
                        badies[i-1].alive = false;
                        badiesImage[i-1].Visibility = Visibility.Collapsed;
                    }
                    //count1++;
                }
            }
        }
        private void gametimerevent(object sender, EventArgs e)
        {
            if (start == true)
            {
                for (int i = 0; i < badiesImage.Length; i++)  // תזוזת רעים
                //for (int i = 0; i < 5; i++)  // תזוזת רעים
                {
                    int num = rand.Next(1, 3);
                    if (num == 1)
                    {
                        if (Grid.GetColumn(good) > Grid.GetColumn(badiesImage[i]))
                        {
                            Grid.SetColumn(badiesImage[i], Grid.GetColumn(badiesImage[i]) + 1);
                        }
                        else if (Grid.GetColumn(good) < Grid.GetColumn(badiesImage[i]))
                        {
                            Grid.SetColumn(badiesImage[i], Grid.GetColumn(badiesImage[i]) - 1);
                        }

                        else if (Grid.GetRow(good) > Grid.GetRow(badiesImage[i]))
                        {
                            Grid.SetRow(badiesImage[i], Grid.GetRow(badiesImage[i]) + 1);
                        }
                        else if (Grid.GetRow(good) < Grid.GetRow(badiesImage[i]))
                        {
                            Grid.SetRow(badiesImage[i], Grid.GetRow(badiesImage[i]) - 1);
                        }
                    }
                    else
                    {
                        if (Grid.GetRow(good) > Grid.GetRow(badiesImage[i]))
                        {
                            Grid.SetRow(badiesImage[i], Grid.GetRow(badiesImage[i]) + 1);
                        }
                        else if (Grid.GetRow(good) < Grid.GetRow(badiesImage[i]))
                        {
                            Grid.SetRow(badiesImage[i], Grid.GetRow(badiesImage[i]) - 1);
                        }
                        else if (Grid.GetColumn(good) > Grid.GetColumn(badiesImage[i]))
                        {
                            Grid.SetColumn(badiesImage[i], Grid.GetColumn(badiesImage[i]) + 1);
                        }
                        else if (Grid.GetColumn(good) < Grid.GetColumn(badiesImage[i]))
                        {
                            Grid.SetColumn(badiesImage[i], Grid.GetColumn(badiesImage[i]) - 1);
                        }
                    }
                    if (count == 8)
                    {
                        if(Grid.GetColumn(good) > Grid.GetColumn(badiesImage[i]))
                        {
                            Grid.SetColumn(badiesImage[i], Grid.GetColumn(badiesImage[i]) + 1);
                        }
                        if(Grid.GetColumn(good) < Grid.GetColumn(badiesImage[i]))
                        {
                            Grid.SetColumn(badiesImage[i], Grid.GetColumn(badiesImage[i]) - 1);
                        }
                        if(Grid.GetRow(good) > Grid.GetRow(badiesImage[i]))
                        {
                            Grid.SetRow(badiesImage[i], Grid.GetRow(badiesImage[i]) + 1);
                        }
                        if (Grid.GetRow(good) < Grid.GetRow(badiesImage[i]))
                        {
                            Grid.SetRow(badiesImage[i], Grid.GetRow(badiesImage[i]) - 1);
                        }
                    }
                    if (good.Visibility == Visibility.Collapsed)
                    {
                        break;
                    }
                }

                for (int i = 0; i < badiesImage.Length; i++) // התנגשות בין רע לרע
                {
                    for (int j = i + 1; j < badies.Length; j++)
                    {

                        if (badies[i].alive && Grid.GetColumn(badiesImage[i]) == Grid.GetColumn(badiesImage[j]) &&
                            Grid.GetRow(badiesImage[i]) == Grid.GetRow(badiesImage[j]))
                        {
                            badies[i].alive = false;
                            badiesImage[i].Visibility = Visibility.Collapsed;
                            count = count + 1;
                        }
                        if (count == 9)
                        {
                            MessageBox.Show("You Won");
                            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                            App.Current.Shutdown();
                        }
                    }
                }
                //התנגשות בין טוב לרע
                for (int i = 0; i < badiesImage.Length; i++)
                {
                    if (badies[i].alive && Grid.GetColumn(good) == Grid.GetColumn(badiesImage[i])
                        && Grid.GetRow(badiesImage[i]) == Grid.GetRow(good))
                    {

                        good.Visibility = Visibility.Collapsed;
                        MessageBox.Show("You Are Terminated");
                        System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                        App.Current.Shutdown();
                    }
                }
            }
        }
        private void Keyisdown(object sender, KeyEventArgs e)
        {
            if (start == true)
            {
                if (pause == false)
                {
                    if (e.Key == Key.Left)
                    {
                        goleft = true;
                        //good.Margin = new Thickness(good.Margin.Left - 78, good.Margin.Top, good.Margin.Right + 78, good.Margin.Bottom);
                        if (goleft == true && Grid.GetColumn(good) > 0)
                        {
                            Grid.SetColumn(good, Grid.GetColumn(good) - 1);
                        }
                    }
                    if (e.Key == Key.Right)
                    {
                        goright = true;
                        if (goright == true && Grid.GetColumn(good) < 9)
                        {
                            Grid.SetColumn(good, Grid.GetColumn(good) + 1);
                        }
                    }
                    if (e.Key == Key.Up)
                    {
                        goup = true;
                        if (goup == true && Grid.GetRow(good) > 0)
                        {
                            Grid.SetRow(good, Grid.GetRow(good) - 1);
                        }
                    }
                    if (e.Key == Key.Down)
                    {
                        godown = true;
                        if (godown == true && Grid.GetRow(good) < 9)
                        {
                            Grid.SetRow(good, Grid.GetRow(good) + 1);
                        }
                    }
                    if (e.Key == Key.Space)
                    {
                        gospace = true;
                        Random rnd = new Random();
                        int lr = rnd.Next(0, 11);
                        int ud = rnd.Next(0, 11);
                        Grid.SetRow(good, ud);
                        Grid.SetColumn(good, lr);
                    }
                }
                if (e.Key == Key.S)   // שמור משחק
                {
                    savegame = true;

                    var numberOfSaves = Directory.GetFiles(@"C:\Users\Roi Shamir\Desktop\DodgeGame\GAME3\bin\Debug", "*.save*").Length;
                    string path = @"Savegame.save" + (numberOfSaves);
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        if (good.Visibility == Visibility.Visible)
                        {
                            sw.WriteLine($"good: colom: #{Grid.GetColumn(good)}#, row: #{Grid.GetRow(good)}#alive");
                        }
                        else
                        {
                            sw.WriteLine($"good: colom: #{Grid.GetColumn(good)}#, row: #{Grid.GetRow(good)}#dead");
                        }
                        for (int i = 0; i < badiesImage.Length; i++)
                        {
                            if (badies[i].alive)
                            {
                                sw.WriteLine($"bad{i}: colom: #{Grid.GetColumn(badiesImage[i])}#, row: #{Grid.GetRow(badiesImage[i])}#alive");
                            }
                            else
                            {
                                sw.WriteLine($"bad{i}: colom: #{Grid.GetColumn(badiesImage[i])}#, row: #{Grid.GetRow(badiesImage[i])}#dead");
                            }
                        }
                    }

                }
                if (e.Key == Key.N) //משחק חדש
                {
                    newgame = true;
                    good.Visibility = Visibility.Visible;
                    Grid.SetRow(good, 5);
                    Grid.SetColumn(good, 5);
                    for (int i = 0; i < badiesImage.Length; i++)
                    {
                        badiesImage[i].Visibility = Visibility.Visible;
                        badies[i].alive = true;
                        int num1 = rand.Next(0, 11);
                        int num2 = rand.Next(0, 11);
                        Grid.SetColumn(badiesImage[i], num1);
                        Grid.SetRow(badiesImage[i], num2);
                        if (Grid.GetColumn(good) == Grid.GetColumn(badiesImage[i])
                        && Grid.GetRow(badiesImage[i]) == Grid.GetRow(good))
                        {
                            Grid.SetRow(good, Grid.GetRow(badiesImage[i]) - 1);
                            Grid.SetColumn(good, Grid.GetColumn(badiesImage[i]) - 1);
                        }
                    }
                }
                if (e.Key == Key.P)
                {
                    pause = true;
                    gametimer.Stop();
                }
                if (e.Key == Key.O)
                {
                    pause = false;
                    breakpause = true;
                    gametimer.Start();
                }
            }
            if (e.Key == Key.Enter)
            {
                start = true;
            }
            if (e.Key == Key.C)
            {
                close = true;
                Application.Current.Shutdown();
            }
        }
        private void Keyisup(object sender, KeyEventArgs e)
        {
            
                if (e.Key == Key.Left)
                {
                    goleft = false;
                }
                if (e.Key == Key.Right)
                {
                    goright = false;
                }
                if (e.Key == Key.Up)
                {
                    goup = false;
                }
                if (e.Key == Key.Down)
                {
                    godown = false;
                }
                if (e.Key == Key.Space)
                {
                    gospace = false;
                }          
        }
    }
}
