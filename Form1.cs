using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        string operationPerformed = "";
        bool isOperationPerformed = false;
        bool clearEntry = false;
        bool isEqual = false;
        bool isButtonPressed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button_click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "0")||(isOperationPerformed))
                textBox1.Clear();
            Button button = (Button)sender;
            if (button.Text == ".") {
                if (!textBox1.Text.Contains(".")) {
                    textBox1.Text += button.Text;
                }
            }
            else
            {
                textBox1.Text += button.Text;
            }
            if (isOperationPerformed)
            {
                labelCurrentOperation.Text += textBox1.Text;
            }else
            {
                if (labelCurrentOperation.Text.Contains("+")||labelCurrentOperation.Text.Contains("-")|| labelCurrentOperation.Text.Contains("*")|| labelCurrentOperation.Text.Contains("/"))
                {
                    labelCurrentOperation.Text += button.Text;
                }
                else
                {
                    labelCurrentOperation.Text = textBox1.Text;
                }
            }
            isOperationPerformed = false;
            clearEntry = false;
            isEqual = false;
            isButtonPressed = true;
        }

        private void Operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operationPerformed = button.Text;
            resultValue = Double.Parse(textBox1.Text);
            if(isOperationPerformed)
            {
                if (!labelCurrentOperation.Text.Contains(operationPerformed))
                {
                    operationPerformed = button.Text;
                    labelCurrentOperation.Text = labelCurrentOperation.Text.Remove(labelCurrentOperation.Text.Length - 2);
                    labelCurrentOperation.Text = labelCurrentOperation.Text + operationPerformed + " ";
                }
            }else
            {
                labelCurrentOperation.Text = labelCurrentOperation.Text + " " + operationPerformed + " ";
            }
            isOperationPerformed = true;
            clearEntry = false;
            isEqual = false;
            isButtonPressed = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            labelCurrentOperation.Text = labelCurrentOperation.Text.Remove(labelCurrentOperation.Text.Length - 1);
            clearEntry = true;
            isButtonPressed = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            resultValue = 0;
            labelCurrentOperation.Text = "";
            clearEntry = false;
            isButtonPressed = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (!isEqual)
            {
                switch (operationPerformed)
                {
                    case "+":
                        textBox1.Text = (resultValue + Double.Parse(textBox1.Text)).ToString();
                        break;
                    case "-":
                        textBox1.Text = (resultValue - Double.Parse(textBox1.Text)).ToString();
                        break;
                    case "*":
                        textBox1.Text = (resultValue * Double.Parse(textBox1.Text)).ToString();
                        break;
                    case "/":
                        textBox1.Text = (resultValue / Double.Parse(textBox1.Text)).ToString();
                        break;
                    default:
                        break;
                }
            }
            resultValue = Double.Parse(textBox1.Text);
            isEqual = true;
            isButtonPressed = false;
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
        }
    }
}
