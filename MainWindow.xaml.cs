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

namespace NIR
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GreyXButtom_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void GreyLowButtom_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Toolbar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Logo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void CountryButton_Click(object sender, RoutedEventArgs e)
        {
            if (LeftGrid.Visibility == Visibility.Hidden)
            {
                RightGrid.Visibility = Visibility.Hidden;
                LeftGrid.Visibility = Visibility.Visible;
            }
            else
                LeftGrid.Visibility = Visibility.Hidden;
                
         
        }

        private void OptionButton_Click(object sender, RoutedEventArgs e)
        {
            if (RightGrid.Visibility == Visibility.Hidden)
            {
                LeftGrid.Visibility = Visibility.Hidden;
                RightGrid.Visibility = Visibility.Visible;
            }
            else
                RightGrid.Visibility = Visibility.Hidden;
        }

        private void AmericaButton_Click(object sender, RoutedEventArgs e)
        {
            AmerikaImg.Visibility = Visibility.Visible;
            EroupeImg.Visibility = Visibility.Hidden;
            AsiaImg.Visibility = Visibility.Hidden;
            ChinaImg.Visibility = Visibility.Hidden;
            LeftGrid.Visibility = Visibility.Hidden;
            CountryChosen.Text = "Америка";
        }

        private void EroupeButton_Click(object sender, RoutedEventArgs e)
        {
            AmerikaImg.Visibility = Visibility.Hidden;
            EroupeImg.Visibility = Visibility.Visible;
            AsiaImg.Visibility = Visibility.Hidden;
            ChinaImg.Visibility = Visibility.Hidden;
            LeftGrid.Visibility = Visibility.Hidden;
            CountryChosen.Text = "Европа";
        }

        private void AsiaButton_Click(object sender, RoutedEventArgs e)
        {
            AmerikaImg.Visibility = Visibility.Hidden;
            EroupeImg.Visibility = Visibility.Hidden;
            AsiaImg.Visibility = Visibility.Visible;
            ChinaImg.Visibility = Visibility.Hidden;
            LeftGrid.Visibility = Visibility.Hidden;
            CountryChosen.Text = "Азия";
        }

        private void ChinaButton_Click(object sender, RoutedEventArgs e)
        {
            AmerikaImg.Visibility = Visibility.Hidden;
            EroupeImg.Visibility = Visibility.Hidden;
            AsiaImg.Visibility = Visibility.Hidden;
            ChinaImg.Visibility = Visibility.Visible;
            LeftGrid.Visibility = Visibility.Hidden;
            CountryChosen.Text = "Китай";
        }

        private void UseMyLastStatusButton_Click(object sender, RoutedEventArgs e)
        {
            if (PointInvis.Visibility == Visibility.Visible)
            {
                RightGrid.Visibility = Visibility.Hidden;
                PointInvis.Visibility = Visibility.Hidden;
                PointUseMyLastStatus.Visibility = Visibility.Visible;
            }
        }

        private void invisButton_Click(object sender, RoutedEventArgs e)
        {
            if(PointUseMyLastStatus.Visibility == Visibility.Visible)
            {
                RightGrid.Visibility = Visibility.Hidden;
                PointUseMyLastStatus.Visibility = Visibility.Hidden;
                PointInvis.Visibility = Visibility.Visible;
            }
        }
    }
}
