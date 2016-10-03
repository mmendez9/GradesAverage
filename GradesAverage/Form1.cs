using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradesAverage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btmCalculate_Click(object sender, EventArgs e)
        {
            double exam1, exam2, average;
            if (isInputValid(out exam1, out exam2) == true)
            {
                average = (exam1 + exam2) / 2;
                tbxAverage.Text = average.ToString("f1");
            }
        }

        private bool isInputValid(out double ex1, out double ex2)
        {
            ex2 = 0;

            if (isFieldValid(Exam1, out ex1) && isFieldValid(Exam2, out ex2))
                return true;
            else
                return false;
        }

        private bool isFieldValid(TextBox tbxName, out double grade)
        {
            bool isFieldOK = false;

            if (double.TryParse(tbxName.Text, out grade))
            {
                if (grade >= 0 && grade <= 100)
                {
                    isFieldOK = true;
                    return isFieldOK;
                }
                else
                {
                    MessageBox.Show(tbxName.Name.Remove(0, 3) + " out of range", "Average",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show(tbxName.Name.Remove(0, 3) + " missing or not numeric", "Average",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
