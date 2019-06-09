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
    /// Логика взаимодействия для VirtualKeyboard.xaml
    /// </summary>
    public partial class VirtualKeyboard : UserControl
    {
        double _FontSize = 14;
        List<VK_Button> Buttons;
        List<VK_Button> LetterButtons;
        string _Language = "Rus";
        bool _Shift = false;

        public VirtualKeyboard()
        {
            InitializeComponent();

            LetterButtons = new List<VK_Button>();
            LetterButtons.AddRange(RusNumbers.Children.OfType<VK_Button>());
            LetterButtons.AddRange(EngNumbers.Children.OfType<VK_Button>());
            foreach (Grid Panel in RusLetters.Children.OfType<Grid>())
                LetterButtons.AddRange(Panel.Children.OfType<VK_Button>());
            foreach (Grid Panel in EngLetters.Children.OfType<Grid>())
                LetterButtons.AddRange(Panel.Children.OfType<VK_Button>());

            Buttons = new List<VK_Button>();
            Buttons.AddRange(LetterButtons);
            Buttons.AddRange(Functions.Children.OfType<VK_Button>());
        }

        //свойства
        /// <summary>
        /// Размер шрифта кнопок
        /// </summary>
        new public double FontSize
        {
            get { return _FontSize; }
            set
            {
                _FontSize = value;
                foreach (VK_Button Button in Buttons)
                    Button.FontSize = _FontSize;
            }
        }

        /// <summary>
        /// Язык кнопок
        /// </summary>
        public string Lang
        {
            get { return _Language; }
            set
            {
                _Language = value;
                switch (_Language)
                {
                    case "Rus":
                        RusNumbers.Visibility = Visibility.Visible;
                        EngNumbers.Visibility = Visibility.Collapsed;
                        RusLetters.Visibility = Visibility.Visible;
                        EngLetters.Visibility = Visibility.Collapsed;
                        break;
                    case "Eng":
                        RusNumbers.Visibility = Visibility.Collapsed;
                        EngNumbers.Visibility = Visibility.Visible;
                        RusLetters.Visibility = Visibility.Collapsed;
                        EngLetters.Visibility = Visibility.Visible;
                        break;
                    default:
                        RusNumbers.Visibility = Visibility.Visible;
                        EngNumbers.Visibility = Visibility.Collapsed;
                        RusLetters.Visibility = Visibility.Visible;
                        EngLetters.Visibility = Visibility.Collapsed;
                        break;
                }
            }
        }

        /// <summary>
        /// Определяет рекистр букв
        /// </summary>
        public bool Shift
        {
            get => _Shift;
            set
            {
                _Shift = value;
                foreach (VK_Button Button in LetterButtons)
                    Button.Shift = _Shift;
            }
        }

        /// <summary>
        /// Элемент, в который вносятся изменения
        /// </summary>
        public TextBox InTextBox { get; set; }


        public bool MoveToElement { get; set; } = false;

        /// <summary>
        /// Событие на нажатие кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VK_Button_Click(object sender, RoutedEventArgs e)
        {
            // Получим текст кнопки
            string Out = ((VK_Button)sender).Letter;
            // и произведём операцию
            switch (Out)
            {
                // Сначала специфичные
                // - Shift - изменим регистр
                case "Shift":
                    Shift = !Shift;
                    break;
                // - Изменим язык
                case "En/Ru":
                    Lang = Lang == "Eng" ? "Rus" : "Eng";
                    break;
                // - Закроем клавиатуру
                case "OK":
                    Visibility = Visibility.Collapsed;
                    break;
                // - В остальных случаях напечатаем написанный символ
                default:
                    WriteLetter(Out);
                    break;
            }
        }

        /// <summary>
        /// Функция печати символа
        /// </summary>
        /// <param name="Letter">Символ для печати</param>
        public void WriteLetter(string Letter)
        {
            // Если не выбрано поле, то ничего не печатаем.
            if (InTextBox == null) return;

            // Вернём фокус элементу
            InTextBox.Focus();

            // Получим размер выделения
            int begin = InTextBox.SelectionStart;
            int length = InTextBox.SelectionLength;

            // Удалим выделение
            InTextBox.Text = InTextBox.Text.Remove(begin, length);
            // Если нажали на Backspace, то удалим выделение или предыдущий символ
            if (Letter == "<-")
            {
                InTextBox.SelectionStart = begin;
                if (begin == 0) return;
                if (length > 0) return;
                InTextBox.Text = InTextBox.Text.Remove(begin - 1, 1);
            }
            // В противном случае напечатаем символ
            else InTextBox.Text = InTextBox.Text.Insert(begin, Letter);

            // И выставим обратно курсор.
            if (Letter == "<-") InTextBox.SelectionStart = begin - 1;
            else InTextBox.SelectionStart = begin + Letter.Length;
        }

        /// <summary>
        /// Показать виртуальную клавиатуру, привязав её к текстовому блоку
        /// </summary>
        /// <param name="Input"></param>
        public void Show(TextBox Input)
        {
            InTextBox = Input;

            if (MoveToElement)
            {
                // Расчитаем отступ слева
                double Left = Input.Margin.Left + (Input.ActualWidth - Width) / 2;
                if (Left <= 20) Left = 20;
                if (Left + Width >= ((Panel)Parent).ActualWidth - 20) Left = ((Panel)Parent).ActualWidth - Width - 20;

                // Расчитаем отступ сверху
                double Top = Input.Margin.Top + Input.ActualHeight + 20;
                if (Top + Height >= ((Panel)Parent).ActualHeight - 20) Top = Input.Margin.Top - Height - 20;

                Margin = new Thickness(Left, Top, 0, 0);
            }

            // И покажем виртуальную клавиатуру
            Visibility = Visibility.Visible;
        }
    }
}
