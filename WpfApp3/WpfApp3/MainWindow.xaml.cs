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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace шещп
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Animal[] Animals = new Animal[100];
        string MouseStatus = "CreateNewAnimal";
        int index = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow1_Activated(object sender, EventArgs e)
        {
            if (index > 1) { for (int i = 0; i < Animals.Length; i++) { Animals[i].Update(); } }
        }

        private void MainWindow1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (index < Animals.Length && MouseStatus == "CreateNewAnimal")
            {
                Random rand = new Random();
                Animal[] temp = new Animal[Animals.Length + 1];
                for (int i = 0; i < Animals.Length; i++)
                {
                    temp[i] = new Animal(0, 0, 0, 0);
                    temp[i].Copy(Animals[i]);
                }
                Animals = new Animal[temp.Length];
                for (int i = 0; i < temp.Length; i++)
                {
                    Animals[i] = new Animal(0, 0, 0, 0);
                    Animals[i].Copy(temp[i]);
                }
                SolidColorBrush color = new SolidColorBrush(Color.FromRgb(Convert.ToByte(rand.Next(1, 255)), Convert.ToByte(rand.Next(1, 255)), Convert.ToByte(rand.Next(1, 255))));
                Animals[index] = new Animal(rand.Next(20, 40), rand.Next(10, 20), Convert.ToInt32(e.GetPosition(can).X), Convert.ToInt32(e.GetPosition(can).Y));
                Animals[index].SetColor(color);
                Animals[index].Load();
                can.Children.Add(Animals[index].Get());
                index++;
            }

        }

        private void NewAnim_Click(object sender, RoutedEventArgs e)
        {
            MouseStatus = "CreateNewAnimal";
        }

        private void NewTree_Click(object sender, RoutedEventArgs e)
        {
            MouseStatus = "CreateNewTrees";
        }

        private void None_Click(object sender, RoutedEventArgs e)
        {
            MouseStatus = "none";
        }
    }
}