using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private double _firstOperand = 0;
        private string _operation = "";
        private bool _isNewEntry = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Digit_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            if (_isNewEntry || Display.Text == "0")
            {
                Display.Text = btn.Content.ToString();
                _isNewEntry = false;
            }
            else
            {
                Display.Text += btn.Content.ToString();
            }
        }

        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            if (_isNewEntry)
            {
                Display.Text = "0,";
                _isNewEntry = false;
            }
            else if (!Display.Text.Contains(","))
            {
                Display.Text += ",";
            }
        }

        private void Op_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            _firstOperand = double.Parse(Display.Text);
            _operation = btn.Content.ToString();
            _isNewEntry = true;
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            double second = double.Parse(Display.Text);
            double result = 0;

            switch (_operation)
            {
                case "+": result = _firstOperand + second; break;
                case "−": result = _firstOperand - second; break;
                case "×": result = _firstOperand * second; break;
                case "÷":
                    if (second == 0) { Display.Text = "Ошибка"; _isNewEntry = true; return; }
                    result = _firstOperand / second;
                    break;
                default: return;
            }

            Display.Text = result.ToString();
            _isNewEntry = true;
            _operation = "";
        }
    }
}