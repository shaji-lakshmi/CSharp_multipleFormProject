using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shaji_section2Project
{
    public partial class frmaddStudent : Form
    {
        public frmaddStudent()
        {
            InitializeComponent();
        }

        decimal average = 0;
        decimal total = 0;
        decimal count = 0;
        string[] infoForForm;
        List<decimal> listScores = new List<decimal>();
        List<string> listNeededInfo = new List<string>();



        private void btnOk_Click(object sender, EventArgs e)
        {
            infoForForm = listNeededInfo.ToArray();
            this.Tag = infoForForm;
        }

        private void btnAddScore_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                convertListData();
                assignTextAndMakeList();
                
            }

        }

        public void convertListData()
        {
            listNeededInfo = new List<string>();
            listScores.Add(Convert.ToInt32(txtScore.Text));
            total = 0;

            txtScores.Text = " ";
            foreach (int i in listScores)
            {
                if (i != 0)
                {
                    txtScores.Text += i.ToString() + " ";
                    total += i;

                }
            }

            count++;
            average = total / count;
        }

        public void assignTextAndMakeList()
        {
            string studentName = txtName.Text;
            string studentScores = txtScores.Text;
            string scoreTotal = total.ToString();
            string scoreCount = count.ToString();
            string scoreAverage = average.ToString();

            listNeededInfo.Add(studentName);
            listNeededInfo.Add(studentScores);
            listNeededInfo.Add(scoreTotal);
            listNeededInfo.Add(scoreCount);
            listNeededInfo.Add(scoreAverage);
        }
        public bool IsValidData()
        {
            return
                // Validate the Score text box
                IsPresent(txtScore, "Score") &&
                IsDecimal(txtScore, "Score") &&
                IsWithinRange(txtScore, "Score", 01, 100);
        }

        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        public bool IsDecimal(TextBox textBox, string name)
        {
            decimal number = 0;
            if (Decimal.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be a valid integer.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        public bool IsWithinRange(TextBox textBox, string name,
            decimal min, decimal max)
        {
            int number = Convert.ToInt32(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(name + " must be between " + min +
                    " and " + max + ".", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtScore.Text = "";
            txtScores.Text = "";
            listScores = new List<decimal>();
        }
    }
}
