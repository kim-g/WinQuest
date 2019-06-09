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
    /// Логика взаимодействия для VK_Button.xaml
    /// </summary>
    public partial class VK_Button : Button
    {
        string small;
        string big;
        bool shift = false;

        /// <summary>
        /// Выдаёт нажатую букву
        /// </summary>
        public string Letter { get { return Shift ? Big : Small; } }

        // Прописная буква
        public string Small
        {
            get => small;
            set
            {
                small = value;
                Content = Letter;
            }
        }

        // Заглавная буква
        public string Big
        {
            get => big;
            set
            {
                big = value;
                Content = Letter;
            }
        }

        public bool Shift
        {
            get => shift;
            set
            {
                shift = value;
                Content = Letter;
            }
        }

        public VK_Button() : base()
        {
            InitializeComponent();

            Background = new SolidColorBrush(Colors.Transparent);
            BorderBrush = new SolidColorBrush(Colors.White);
            FontFamily = new FontFamily("Formular");
            FontWeight = FontWeights.Bold;
        }

        /// <summary>
        /// Задаёт символы для отображения.
        /// </summary>
        /// <param name="big">Верхний регистр</param>
        /// <param name="small">Нижний регистр</param>
        public void SetLetters(string small, string big)
        {
            Big = big;
            Small = small;
            Content = Letter;
        }
    }
}
