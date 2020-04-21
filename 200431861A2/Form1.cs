/* 
 * Title: Windows Calculator For Assignment 02
 * Author: Myles Megaffin 
 * Student Number: 200431861
 * Date: 2020-04-09
 * Summary: This Windows program is a calculator form.
 * 
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _200431861A2
{
    public partial class Calculator : Form
    {
        // Variables
        Double displyValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;
        public Calculator()
        {
            InitializeComponent();
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void buttonOneClick(object sender, EventArgs e)
        {
            disply.Text = disply.Text + "1";
        }

        private void buttonClick(object sender, EventArgs e)
        {
            if ((disply.Text == "0") || (isOperationPerformed))
            {
                disply.Clear();
            }
            Button button = (Button)sender;
            isOperationPerformed = false;
            // Making it so it doesnt have more then one dot
            if (button.Text == ".")
            {
                if (!disply.Text.Contains("."))
                {
                    disply.Text = disply.Text + button.Text;
                }
            }
            else
            {
                disply.Text = disply.Text + button.Text;
            }
            shh.Focus();
        }

        private void operatorClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (displyValue != 0)
            {
                equals.PerformClick();
                operationPerformed = button.Text;
                // Adding this to the disply label above the textbox(displayValue)
                displyLabel.Text = displyValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                displyValue = Double.Parse(disply.Text);
                // Adding this to the disply label above the textbox(displayValue)
                displyLabel.Text = displyValue + " " + operationPerformed;
                isOperationPerformed = true;
            }

        }

        private void clear_Click(object sender, EventArgs e)
        {
            disply.Text = "0";
            displyValue = 0;
            displyLabel.Text = "";
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (disply.Text.Length > 0)
            {
                disply.Text = disply.Text.Remove(disply.Text.Length - 1, 1);
            }
            if (disply.Text == "")
            {
                disply.Text = "0";
            }
        }

        private void equalsClick(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    disply.Text = (displyValue + Double.Parse(disply.Text)).ToString();
                    break;
                case "-":
                    disply.Text = (displyValue - Double.Parse(disply.Text)).ToString();
                    break;
                case "*":
                    disply.Text = (displyValue * Double.Parse(disply.Text)).ToString();
                    break;
                case "/":
                    if (disply.Text == "0")
                    {
                        MessageBox.Show("Cannot divide by zero");
                    }
                    else
                    {
                        disply.Text = (displyValue / Double.Parse(disply.Text)).ToString();
                    }
                    break;
                default:
                    break;
            }
            displyValue = Double.Parse(disply.Text);

            displyLabel.Text = "";
        }

        private void squareRoot_Click(object sender, EventArgs e)
        {
            disply.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(disply.Text)));
        }

        private void plusOrMinus_Click(object sender, EventArgs e)
        {
            if (disply.Text.Contains("-"))
            {
                disply.Text = disply.Text.Remove(0, 1);
            }
            else
            {
                disply.Text = "-" + disply.Text;
            }
        }

        private void multiplicativeInverse_Click(object sender, EventArgs e)
        {
            disply.Text = Convert.ToString(Convert.ToDouble(1.0 / Convert.ToDouble(disply.Text)));
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());
            switch (e.KeyChar.ToString())
            {
                // when you press 1-9 on the keyboard it will execute
                case "0":
                    zero.PerformClick();
                    break;
                case "1":
                    one.PerformClick();
                    break;
                case "2":
                    two.PerformClick();
                    break;
                case "3":
                    three.PerformClick();
                    break;
                case "4":
                    four.PerformClick();
                    break;
                case "5":
                    five.PerformClick();
                    break;
                case "6":
                    six.PerformClick();
                    break;
                case "7":
                    seven.PerformClick();
                    break;
                case "8":
                    eight.PerformClick();
                    break;
                case "9":
                    nine.PerformClick();
                    break;
                // when you press the + - / * = enter esc backspace on keyboard it will execute
                case "+":
                    add.PerformClick();
                    break;
                case "-":
                    sub.PerformClick();
                    break;
                case "*":
                    multi.PerformClick();
                    break;
                case "/":
                    div.PerformClick();
                    break;
                case "=":
                    equals.PerformClick();
                    break;
                //enter
                case "\r":
                    equals.PerformClick();
                    break;
                //esc
                case "\x1B":
                    clear.PerformClick();
                    break;
                //backspace
                case "\b":
                    back.PerformClick();
                    break;
                default:
                    break;
            }
        }
    }
}