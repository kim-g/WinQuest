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

namespace WinQuest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User CurrentUser;
        private UsersDB DB = new UsersDB("users.db");

        public MainWindow()
        {
            InitializeComponent();
            HideAll();
            SlideGrid_01.Visibility = Visibility.Visible;
        }
        
        /// <summary>
        /// Скрыть все Grid
        /// </summary>
        private void HideAll()
        {
            foreach (Grid Slide in CoreGrid.Children.OfType<Grid>())
                Slide.Visibility = Visibility.Collapsed;
        }

        private void TestBox_GotFocus(object sender, RoutedEventArgs e)
        {
            VK.Show((TextBox)sender);
        }

        private void S_01_B_1_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            SlideGrid_Input.Visibility = Visibility.Visible;
        }

        private void S_In_B_1_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            CurrentUser = new User(DB);
            CurrentUser.Name = UserName.Text;
            CurrentUser.Phone = UserPhone.Text;
            CurrentUser.Mail = UserMail.Text;
            CurrentUser.Points = 0;
            SlideGrid_02.Visibility = Visibility.Visible;
        }

        private void S_02_B_1_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            CurrentUser.Points++;
            SlideGrid_03.Visibility = Visibility.Visible;
        }
        private void S_02_B_2_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            SlideGrid_03.Visibility = Visibility.Visible;
        }

        private void S_03_B_1_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            CurrentUser.Points++;
            SlideGrid_04.Visibility = Visibility.Visible;
        }
        private void S_03_B_2_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            SlideGrid_04.Visibility = Visibility.Visible;
        }

        private void S_04_B_1_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            CurrentUser.Points++;
            SlideGrid_05.Visibility = Visibility.Visible;
        }
        private void S_04_B_2_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            SlideGrid_05.Visibility = Visibility.Visible;
        }

        private void S_05_B_1_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            CurrentUser.Points++;
            SlideGrid_06.Visibility = Visibility.Visible;
        }
        private void S_05_B_2_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            SlideGrid_06.Visibility = Visibility.Visible;
        }

        private void S_06_B_1_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            CurrentUser.Points++;
            SlideGrid_07.Visibility = Visibility.Visible;
        }
        private void S_06_B_2_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            SlideGrid_07.Visibility = Visibility.Visible;
        }

        private void S_07_B_1_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            CurrentUser.Points++;
            SlideGrid_08.Visibility = Visibility.Visible;
        }
        private void S_07_B_2_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            SlideGrid_08.Visibility = Visibility.Visible;
        }

        private void S_08_B_1_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            CurrentUser.Points++;
            SlideGrid_09.Visibility = Visibility.Visible;
        }
        private void S_08_B_2_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            SlideGrid_09.Visibility = Visibility.Visible;
        }

        private void S_09_B_1_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            CurrentUser.Points++;
            SlideGrid_10.Visibility = Visibility.Visible;
        }
        private void S_09_B_2_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            SlideGrid_10.Visibility = Visibility.Visible;
        }

        private void S_10_B_1_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            CurrentUser.Points++;
            SlideGrid_11.Visibility = Visibility.Visible;
        }
        private void S_10_B_2_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            SlideGrid_11.Visibility = Visibility.Visible;
        }

        private void S_11_B_1_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            CurrentUser.Points++;
            SlideGrid_Code.Visibility = Visibility.Visible;
        }
        private void S_11_B_2_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            SlideGrid_Code.Visibility = Visibility.Visible;
        }

        private void S_Co_B_1_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            SlideGrid_12.Visibility = Visibility.Visible;
        }

        private void S_12_B_1_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            SlideGrid_01.Visibility = Visibility.Visible;
        }
    }
}
