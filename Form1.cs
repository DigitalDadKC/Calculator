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
        bool isEqualed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "0")||(isOperationPerformed))
                textBox1.Clear();
            Button button = (Button)sender;
            if(button.Text == ".")
            {
                if (!textBox1.Text.Contains("."))
                    textBox1.Text = textBox1.Text + button.Text;
            }else
            textBox1.Text = textBox1.Text + button.Text;
            if (isOperationPerformed)
            {
                labelCurrentOperation.Text = labelCurrentOperation.Text + textBox1.Text;
            }else
            {
                labelCurrentOperation.Text = textBox1.Text;
            }
            isOperationPerformed = false;
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (isOperationPerformed)
            {
                
            }else
            {

                if (resultValue != 0)
                {
                    btnEqual.PerformClick();
                    operationPerformed = button.Text;
                    resultValue = Double.Parse(textBox1.Text);
                    labelCurrentOperation.Text = labelCurrentOperation.Text + operationPerformed + " ";
                    isOperationPerformed = true;
                }
                else
                {
                    operationPerformed = button.Text;
                    resultValue = Double.Parse(textBox1.Text);
                    labelCurrentOperation.Text = labelCurrentOperation.Text + " " + operationPerformed + " ";
                    isOperationPerformed = true;
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            labelCurrentOperation.Text = "";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            resultValue = 0;
            labelCurrentOperation.Text = "";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch(operationPerformed)
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
            resultValue = Double.Parse(textBox1.Text);
            labelCurrentOperation.Text = labelCurrentOperation.Text + " ";
            isEqualed = true;
        }
    }
}
