using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            var grid = new Grid();
            for (int i = 0; i < 17; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());


            var inputTextBox1 = CreateTextBox();
            var checkPrimeButton = CreateButton("Проверить простое число");
            var resultLabel1 = CreateLabel();

            checkPrimeButton.Click += (s, e) =>
            {
                int inputNumber;
                if (int.TryParse(inputTextBox1.Text, out inputNumber))
                {
                    resultLabel1.Content = IsPrime(inputNumber) ? "Простое число" : "Не простое число";
                }
                else
                {
                    MessageBox.Show("Введите корректное число");
                }
            };

            PlaceInGrid(grid, inputTextBox1, 0, 0);
            PlaceInGrid(grid, checkPrimeButton, 0, 1);
            PlaceInGrid(grid, resultLabel1, 1, 0, 2);


            var inputTextBox2 = CreateTextBox();
            var countComboBox = CreateComboBox(new string[] { "Гласные", "Согласные", "Цифры", "Слова" });
            var countCharactersButton = CreateButton("Выполнить");
            var resultLabel2 = CreateLabel();

            countCharactersButton.Click += (s, e) =>
            {
                string inputText = inputTextBox2.Text;
                string selectedOption = countComboBox.SelectedItem as string;

                if (selectedOption != null)
                {
                    resultLabel2.Content = CountCharacters(inputText, selectedOption).ToString();
                }
            };

            PlaceInGrid(grid, inputTextBox2, 2, 0);
            PlaceInGrid(grid, countComboBox, 2, 1);
            PlaceInGrid(grid, countCharactersButton, 3, 0, 2);
            PlaceInGrid(grid, resultLabel2, 4, 0, 2);


            var useLettersCheckBox = CreateCheckBox("Использовать буквы");
            var useDigitsCheckBox = CreateCheckBox("Использовать цифры");
            var useSpecialCharsCheckBox = CreateCheckBox("Использовать спецсимволы");
            var generatePasswordButton = CreateButton("Генерировать пароль");
            var resultLabel3 = CreateLabel();

            generatePasswordButton.Click += (s, e) =>
            {
                int passwordLength = 8; 
                string password = GeneratePassword(passwordLength, Convert.ToBoolean(useLettersCheckBox.IsChecked), Convert.ToBoolean(useDigitsCheckBox.IsChecked), Convert.ToBoolean(useSpecialCharsCheckBox.IsChecked));
                resultLabel3.Content = password;
            };

            PlaceInGrid(grid, useLettersCheckBox, 5, 0);
            PlaceInGrid(grid, useDigitsCheckBox, 5, 1);
            PlaceInGrid(grid, useSpecialCharsCheckBox, 6, 0, 2);
            PlaceInGrid(grid, generatePasswordButton, 7, 0, 2);
            PlaceInGrid(grid, resultLabel3, 8, 0, 2);


            var number1TextBox = CreateTextBox();
            var number2TextBox = CreateTextBox();
            var additionRadioButton = CreateRadioButton("Сложение");
            var subtractionRadioButton = CreateRadioButton("Вычитание");
            var multiplicationRadioButton = CreateRadioButton("Умножение");
            var divisionRadioButton = CreateRadioButton("Деление");
            var calculateButton = CreateButton("Выполнить операцию");
            var resultLabel4 = CreateLabel();

            calculateButton.Click += (s, e) =>
            {
                double number1, number2;
                if (double.TryParse(number1TextBox.Text, out number1) && double.TryParse(number2TextBox.Text, out number2))
                {
                    if (additionRadioButton.IsChecked == true)
                    {
                        resultLabel4.Content = (number1 + number2).ToString();
                    }
                    else if (subtractionRadioButton.IsChecked == true)
                    {
                        resultLabel4.Content = (number1 - number2).ToString();
                    }
                    else if (multiplicationRadioButton.IsChecked == true)
                    {
                        resultLabel4.Content = (number1 * number2).ToString();
                    }
                    else if (divisionRadioButton.IsChecked == true && number2 != 0)
                    {
                        resultLabel4.Content = (number1 / number2).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Введите корректные числа и выберите операцию");
                    }
                }
                else
                {
                    MessageBox.Show("Введите корректные числа");
                }
            };

            PlaceInGrid(grid, number1TextBox, 9, 0);
            PlaceInGrid(grid, number2TextBox, 9, 1);
            PlaceInGrid(grid, additionRadioButton, 10, 0);
            PlaceInGrid(grid, subtractionRadioButton, 10, 1);
            PlaceInGrid(grid, multiplicationRadioButton, 11, 0);
            PlaceInGrid(grid, divisionRadioButton, 11, 1);
            PlaceInGrid(grid, calculateButton, 12, 0, 2);
            PlaceInGrid(grid, resultLabel4, 13, 0, 2);

            var inputTextBox3 = CreateTextBox();
            var performActionButton1 = CreateButton("Действие 1");
            var performActionButton2 = CreateButton("Действие 2");
            var resultLabel5 = CreateLabel();

            performActionButton1.Click += (s, e) =>
            {
                double inputNumber;
                if (double.TryParse(inputTextBox3.Text, out inputNumber))
                {
                    resultLabel5.Content = PerformAction1(inputNumber).ToString();
                }
                else
                {
                    MessageBox.Show("Введите корректное число");
                }
            };

            performActionButton2.Click += (s, e) =>
            {
                double inputNumber;
                if (double.TryParse(inputTextBox3.Text, out inputNumber))
                {
                    resultLabel5.Content = PerformAction2(inputNumber).ToString();
                }
                else
                {
                    MessageBox.Show("Введите корректное число");
                }
            };

            PlaceInGrid(grid, inputTextBox3, 14, 0, 2);
            PlaceInGrid(grid, performActionButton1, 15, 0);
            PlaceInGrid(grid, performActionButton2, 15, 1);
            PlaceInGrid(grid, resultLabel5, 16, 0, 2);
            grid.HorizontalAlignment = HorizontalAlignment.Center;
            grid.VerticalAlignment = VerticalAlignment.Center;
            this.Content = grid;
        }

        private TextBox CreateTextBox()
        {
            return new TextBox
            {
                Width = 200,
                Height = 30,
                Margin = new Thickness(10)
            };
        }

        private Button CreateButton(string content)
        {
            var button = new Button
            {
                Width = 150,
                Height = 30,
                Content = content,
                Margin = new Thickness(10)
            };
            return button;
        }

        private Label CreateLabel()
        {
            return new Label
            {
                Content = "",
                Margin = new Thickness(10)
            };
        }

        private ComboBox CreateComboBox(string[] items)
        {
            var comboBox = new ComboBox
            {
                Width = 150,
                Height = 30,
                Margin = new Thickness(10),
                ItemsSource = items
            };
            return comboBox;
        }

        private CheckBox CreateCheckBox(string content)
        {
            return new CheckBox
            {
                Content = content,
                Margin = new Thickness(10)
            };
        }

        private RadioButton CreateRadioButton(string content)
        {
            return new RadioButton
            {
                Content = content,
                Margin = new Thickness(10)
            };
        }

        private void PlaceInGrid(Grid grid, UIElement element, int row, int column, int columnSpan = 1)
        {
            Grid.SetRow(element, row);
            Grid.SetColumn(element, column);
            Grid.SetColumnSpan(element, columnSpan);
            grid.Children.Add(element);
        }

        private bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        private int CountCharacters(string input, string option)
        {
            switch (option)
            {
                case "Гласные":
                    return input.Count(c => "aeiouAEIOUаеёиоуыэюяАЕЁИОУЫЭЮЯ".Contains(c));
                case "Согласные":
                    return input.Count(c => "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZбвгджзйклмнпрстфхцчшщБВГДЖЗЙКЛМНПРСТФХЦЧШЩ".Contains(c));
                case "Цифры":
                    return input.Count(c => char.IsDigit(c));
                case "Слова":
                    return input.Split(new char[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
                default:
                    return 0;
            }
        }

        private string GeneratePassword(int length, bool useLetters, bool useDigits, bool useSpecialChars)
        {
            const string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";
            const string specialChars = "!@#$%^&*()-=_+[]{}|;:'\",.<>/?";

            string validChars = "";
            if (useLetters)
                validChars += letters;
            if (useDigits)
                validChars += digits;
            if (useSpecialChars)
                validChars += specialChars;

            Random random = new Random();
            return new string(Enumerable.Repeat(validChars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private double PerformAction1(double number)
        {
            return number * 2;
        }

        private double PerformAction2(double number)
        {
            return Math.Pow(number, 2);
        }
    }
}
