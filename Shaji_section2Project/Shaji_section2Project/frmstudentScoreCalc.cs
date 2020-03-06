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
    public partial class frmstudentScoreCalc : Form
    {
        public frmstudentScoreCalc()
        {
            InitializeComponent();
        }

        List<string[]> getInfo = new List<string[]>();
        string[] frmInfo;
        string[] PrintMe;
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            Form addNewStudent = new frmaddStudent();
            DialogResult selectedButton = addNewStudent.ShowDialog();
            if (selectedButton == DialogResult.OK)
            {
                try
                {
                //https://stackoverflow.com/questions/9043773/how-to-convert-object-to-liststring-in-c
                    frmInfo = addNewStudent.Tag as string[];
                    getInfo.Add(frmInfo);
                    lstStudents.Items.Add(frmInfo[0] + " | " + frmInfo[1]);
                    txtTotal.Text = frmInfo[2];
                    txtCount.Text = frmInfo[3];
                    txtAverage.Text = frmInfo[4];
                    lstStudents.SetSelected(0, true);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrintMe = getInfo[lstStudents.SelectedIndex];
            this.Tag = PrintMe;
            txtTotal.Text = PrintMe[2];
            txtCount.Text = PrintMe[3];
            txtAverage.Text = PrintMe[4];

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Form updateForm = new frmUpdate();
                DialogResult selectedButton = updateForm.ShowDialog();
                int removalIndex = lstStudents.SelectedIndex + 1;
                int index = lstStudents.SelectedIndex;
                PrintMe = updateForm.Tag as string[];
                getInfo.Insert(lstStudents.SelectedIndex, PrintMe);
                lstStudents.Items.Insert(lstStudents.SelectedIndex, PrintMe[0] + " | " + PrintMe[1]);
                lstStudents.SetSelected(0, true);
                getInfo.RemoveAt(removalIndex);
                lstStudents.Items.RemoveAt(removalIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int removalIndex = lstStudents.SelectedIndex + 1;
            string[] placeholder = new string[] { "", "", "", "", "" };
            getInfo.Insert(lstStudents.SelectedIndex, placeholder);
            lstStudents.Items.Insert(lstStudents.SelectedIndex, "");
            lstStudents.SetSelected(0, true);
            getInfo.RemoveAt(removalIndex);
            lstStudents.Items.RemoveAt(removalIndex);

        }

        public void printIt(string[] frm)
        {
            getInfo.Add(frmInfo);
            lstStudents.Items.Add(frmInfo[0] + " | " + frmInfo[1]);
            txtTotal.Text = frmInfo[2];
            txtCount.Text = frmInfo[3];
            txtAverage.Text = frmInfo[4];
            lstStudents.SetSelected(0, true);
        }

        private void frmstudentScoreCalc_Load(object sender, EventArgs e)
        {
            frmInfo = new string[] { "Lakshmi", "90 10 100", "200", "3", "66.67" };
            printIt(frmInfo);
            frmInfo = new string[] { "Kacy", "10 20 30 40", "100", "4", "25" };
            printIt(frmInfo);
            frmInfo = new string[] { "Mark", "100 50", "150", "2", "75" };
            printIt(frmInfo);
        }
    }
}
