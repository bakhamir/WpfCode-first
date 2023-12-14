using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Создание Grid
            var grid = new Grid();
            this.Content = grid;

            // Добавление строк и колонок в Grid
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });

            // Создание TextBox для ввода числа (Задача 1)
            var inputTextBox1 = CreateTextBox();
            Grid.SetRow(inputTextBox1, 0);
            Grid.SetColumn(inputTextBox1, 0);
            Grid.SetColumnSpan(inputTextBox1, 2);

            // Создание Button для проверки числа на простоту (Задача 1)
            var checkPrimeButton = CreateButton("Проверить простое число", CheckPrimeButton_Click);
            Grid.SetRow(checkPrimeButton, 1);
            Grid.SetColumn(checkPrimeButton, 0);
            Grid.SetColumnSpan(checkPrimeButton, 2);

            // Создание Label для вывода результата (Задача 1)
            var resultLabel1 = CreateLabel();
            Grid.SetRow(resultLabel1, 2);
            Grid.SetColumn(resultLabel1, 0);
            Grid.SetColumnSpan(resultLabel1, 2);

            // Создание TextBox для ввода строки (Задача 2)
            var inputTextBox2 = CreateTextBox();
            Grid.SetRow(inputTextBox2, 3);
            Grid.SetColumn(inputTextBox2, 0);
            Grid.SetColumnSpan(inputTextBox2, 2);

            // Создание ComboBox для выбора действия (Задача 2)
            var countComboBox = CreateComboBox(new string[] { "Гласные", "Согласные", "Цифры", "Слова" });
            Grid.SetRow(countComboBox, 4);
            Grid.SetColumn(countComboBox, 0);
            Grid.SetColumnSpan(countComboBox, 2);

            // Создание Button для выполнения действия (Задача 2)
            var countCharactersButton = CreateButton("Выполнить", CountCharactersButton_Click);
            Grid.SetRow(countCharactersButton, 5);
            Grid.SetColumn(countCharactersButton, 0);
            Grid.SetColumnSpan(countCharactersButton, 2);

            // Создание Label для вывода результата (Задача 2)
            var resultLabel2 = CreateLabel();
            Grid.SetRow(resultLabel2, 6);
            Grid.SetColumn(resultLabel2, 0);
            Grid.SetColumnSpan(resultLabel2, 2);

            // Создание CheckBox для выбора символов в пароле (Задача 3)
            var useLettersCheckBox = CreateCheckBox("Использовать буквы");
            Grid.SetRow(useLettersCheckBox, 7);
            Grid.SetColumn(useLettersCheckBox, 0);

            var useDigitsCheckBox = CreateCheckBox("Использовать цифры");
            Grid.SetRow(useDigitsCheckBox, 7);
            Grid.SetColumn(useDigitsCheckBox, 1);

            var useSpecialCharsCheckBox = CreateCheckBox("Использовать спецсимволы");
            Grid.SetRow(useSpecialCharsCheckBox, 8);
            Grid.SetColumn(useSpecialCharsCheckBox, 0);
            Grid.SetColumnSpan(useSpecialCharsCheckBox, 2);

            // Создание Button для генерации пароля (Задача 3)
            var generatePasswordButton = CreateButton("Генерировать пароль", GeneratePasswordButton_Click);
            Grid.SetRow(generatePasswordButton, 9);
            Grid.SetColumn(generatePasswordButton, 0);
            Grid.SetColumnSpan(generatePasswordButton, 2);

            // Создание Label для вывода результата (Задача 3)
            var resultLabel3 = CreateLabel();
            Grid.SetRow(resultLabel3, 10);
            Grid.SetColumn(resultLabel3, 0);
            Grid.SetColumnSpan(resultLabel3, 2);

            // Создание TextBox для ввода первого числа (Задача 4)
            var number1TextBox = CreateTextBox();
            Grid.SetRow(number1TextBox, 11);
            Grid.SetColumn(number1TextBox, 0);

            // Создание TextBox для ввода второго числа (Задача 4)
            var number2TextBox = CreateTextBox();
            Grid.SetRow(number2TextBox, 11);
            Grid.SetColumn(number2TextBox, 1);

            // Создание RadioButton для выбора операции сложения (Задача 4)
            var additionRadioButton = CreateRadioButton("Сложение");
            Grid.SetRow(additionRadioButton, 12);
            Grid.SetColumn(additionRadioButton, 0);

            // Создание RadioButton для выбора операции вычитания (Задача 4)
            var subtractionRadioButton = CreateRadioButton("Вычитание");
            Grid.SetRow(subtractionRadioButton, 12);
            Grid.SetColumn(subtractionRadioButton, 1);

            // Создание RadioButton для выбора операции умножения (Задача 4)
            var multiplicationRadioButton = CreateRadioButton("Умножение");
            Grid.SetRow(multiplicationRadioButton, 13);
            Grid.SetColumn(multiplicationRadioButton, 0);

            // Создание RadioButton для выбора операции деления (Задача 4)
            var divisionRadioButton = CreateRadioButton("Деление");
            Grid.SetRow(divisionRadioButton, 13);
            Grid.SetColumn(divisionRadioButton, 1);

            // Создание Button для выполнения операции (Задача 4)
            var calculateButton = CreateButton("Выполнить операцию", CalculateButton_Click);
            Grid.SetRow(calculateButton, 14);
            Grid.SetColumn(calculateButton, 0);
            Grid.SetColumnSpan(calculateButton, 2);

            // Создание TextBox для ввода шести чисел (Задача 5)
            var inputTextBox3 = CreateTextBox();
            Grid.SetRow(inputTextBox3, 15);
            Grid.SetColumn(inputTextBox3, 0);
            Grid.SetColumnSpan(inputTextBox3, 2);

            // Создание Button для выполнения действий (Задача 5)
            var performActionButton1 = CreateButton("Действие 1", PerformActionButton_Click);
            Grid.SetRow(performActionButton1, 16);
            Grid.SetColumn(performActionButton1, 0);

            var performActionButton2 = CreateButton("Действие 2", PerformActionButton_Click);
            Grid.SetRow(performActionButton2, 16);
            Grid.SetColumn(performActionButton2, 1);

            // Добавление элементов в Grid
            grid.Children.Add(inputTextBox1);
            grid.Children.Add(checkPrimeButton);
            grid.Children.Add(resultLabel1);
            grid.Children.Add(inputTextBox2);
            grid.Children.Add(countComboBox);
            grid.Children.Add(countCharactersButton);
            grid.Children.Add(resultLabel2);
            grid.Children.Add(useLettersCheckBox);
            grid.Children.Add(useDigitsCheckBox);
            grid.Children.Add(useSpecialCharsCheckBox);
            grid.Children.Add(generatePasswordButton);
            grid.Children.Add(resultLabel3);
            grid.Children.Add(number1TextBox);
            grid.Children.Add(number2TextBox);
            grid.Children.Add(additionRadioButton);
            grid.Children.Add(subtractionRadioButton);
            grid.Children.Add(multiplicationRadioButton);
            grid.Children.Add(divisionRadioButton);
            grid.Children.Add(calculateButton);
            grid.Children.Add(inputTextBox3);
            grid.Children.Add(performActionButton1);
            grid.Children.Add(performActionButton2);

            // Установка Margin
            foreach (UIElement element in grid.Children)
            {
                if (element is FrameworkElement frameworkElement)
                {
                    frameworkElement.Margin = new Thickness(5);
                }
            }

            // Отображение окна
            this.ShowDialog();
        }

        // Метод для проверки на простое число (Задача 1)
        private void CheckPrimeButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(inputTextBox1.Text, out int number))
            {
                bool isPrime = IsPrime(number);
                resultLabel1.Content = isPrime ? "Простое число" : "Не простое число";
            }
            else
            {
                resultLabel1.Content = "Введите корректное число";
            }
        }

        private bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // Метод для подсчета символов в строке (Задача 2)
        private void CountCharactersButton_Click(object sender, RoutedEventArgs e)
        {
            string input = inputTextBox2.Text;
            string selectedOption = ((ComboBoxItem)countComboBox.SelectedItem).Content.ToString();

            switch (selectedOption)
            {
                case "Гласные":
                    resultLabel2.Content = CountVowels(input);
                    break;
                case "Согласные":
                    resultLabel2.Content = CountConsonants(input);
                    break;
                case "Цифры":
                    resultLabel2.Content = CountDigits(input);
                    break;
                case "Слова":
                    resultLabel2.Content = CountWords(input);
                    break;
            }
        }

        private int CountVowels(string input) => input.Count(c => "aeiouAEIOU".Contains(c));

        private int CountConsonants(string input) => input.Count(c => char.IsLetter(c) && !"aeiouAEIOU".Contains(c));

        private int CountDigits(string input) => input.Count(char.IsDigit);

        private int CountWords(string input) => input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;

        // Метод для генерации пароля (Задача 3)
        private void GeneratePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            string password = GeneratePassword(10, useLettersCheckBox.IsChecked == true, useDigitsCheckBox.IsChecked == true, useSpecialCharsCheckBox.IsChecked == true);
            resultLabel3.Content = password;
        }

        private string GeneratePassword(int length, bool useLetters, bool useDigits, bool useSpecialChars)
        {
            string chars = "";
            if (useLetters) chars += "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (useDigits) chars += "0123456789";
            if (useSpecialChars) chars += "!@#$%^&*()_+-=[]{}|;:'\",.<>/?";

            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // Метод для выполнения операции с двумя числами (Задача 4)
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(number1TextBox.Text, out double num1) && double.TryParse(number2TextBox.Text, out double num2))
            {
                string operation = "";
                if (additionRadioButton.IsChecked == true)
                    operation = "Сложение";
                else if (subtractionRadioButton.IsChecked == true)
                    operation = "Вычитание";
                else if (multiplicationRadioButton.IsChecked == true)
                    operation = "Умножение";
                else if (divisionRadioButton.IsChecked == true)
                    operation = "Деление";

                double result = PerformOperation(num1, num2, operation);
                MessageBox.Show($"Результат {operation}: {result}");
            }
            else
            {
            {
                MessageBox.Show("Введите корректные числа");
            }
        }

        private double PerformOperation(double num1, double num2, string operation)
        {
            switch (operation)
            {
                case "Сложение":
                    return num1 + num2;
                case "Вычитание":
                    return num1 - num2;
                case "Умножение":
                    return num1 * num2;
                case "Деление":
                    return num1 / num2;
                default:
                    throw new ArgumentException("Недопустимая операция");
            }
        }
