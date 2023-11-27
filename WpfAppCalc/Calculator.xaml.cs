using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace WpfAppCalc
{
    /// <summary>
    /// Interaction logic for Calculator.xaml
    /// </summary>
    public partial class Calculator : RadWindow
    {
        public Calculator()
        {
            InitializeComponent();
        }

        String Number1, Number2, Operation;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TextResult.Text += button.Content.ToString();
        }
        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (TextResult.Text.Length == 0) return;
            TextResult.Text = TextResult.Text.Substring(0, TextResult.Text.Length - 1);
        }
        private void Button_Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string OperationAction = button.Content.ToString();
            if (TextResult.Text.Contains("+") || TextResult.Text.Contains("-") || TextResult.Text.Contains("*") || TextResult.Text.Contains("/"))
            {
                RadWindow.Alert(new DialogParameters()
                {
                    Content = "One Operation Allowed!!"
                });
                return;
            }
            Number1 = TextResult.Text;
            Operation = OperationAction;
            TextResult.Text += Operation;
        }
        private void Button_Result_Click(object sender, RoutedEventArgs e)
        {
            int OperationIndex = TextResult.Text.IndexOf(Operation) + 1;
            int lentgh = TextResult.Text.Length - OperationIndex;
            Number2 = TextResult.Text.Substring(OperationIndex, lentgh);

            decimal FristNumber = decimal.Parse(Number1), SecondNumber = decimal.Parse(Number2), FinalResul = 0;

            if (Operation == "+")
            {
                FinalResul = FristNumber + SecondNumber;
            }
            else if (Operation == "-")
            {
                FinalResul = FristNumber - SecondNumber;
            }
            else if (Operation == "*")
            {
                FinalResul = (FristNumber * SecondNumber);
            }
            else if (Operation == "/")
            {
                FinalResul = FristNumber / SecondNumber;
            }

            TextResult.Text = FinalResul.ToString("N0");
        }
    }
}

