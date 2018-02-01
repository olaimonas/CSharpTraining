using System;
using System.Windows;
using System.Windows.Controls;

namespace DesktopCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string part1 = "";
        private string part2 = "";
        private string action;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void num1btn_Click(object sender, RoutedEventArgs e)
        {
            string buttonValue = ((Button)sender).Content.ToString();
            resultBox.Text = resultBox.Text + buttonValue;
            part1 = part1 + buttonValue;
        }

        private void action_Click(object sender, RoutedEventArgs e)
        {
            string buttonValue = ((Button)sender).Content.ToString();
            resultBox.Text = resultBox.Text + buttonValue;
            part2 = part1;
            part1 = "";
            action = buttonValue;
        }

        private void executeBtn_Click(object sender, RoutedEventArgs e)
        {
            int part1num = int.Parse(part1);
            int part2num = int.Parse(part2);

            Arithmetics arithmetics = new Arithmetics();
            try
            {
                resultBox.Text = arithmetics.Calculate(part2num, part1num, action).ToString();
            }
            catch(DivideByZeroException ex)
            {
                resultBox.Text = "Division by 0 not allowed";
            }          

            part1 = resultBox.Text;
        }

        private void clear(object sender, RoutedEventArgs e)
        {
            resultBox.Text = "";
            action = "";
        }
    }
}
