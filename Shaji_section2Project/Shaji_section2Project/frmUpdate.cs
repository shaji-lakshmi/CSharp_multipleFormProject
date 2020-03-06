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
    public partial class frmUpdate : Form
    {
        public frmUpdate()
        {
            InitializeComponent();
        }


        string[] updateInfo;
        decimal[] updateScore;
        string addedValue = "";
        decimal total = 0;
        int count = 0;
        decimal average;
        List<decimal> scores = new List<decimal>();

        public void convertFormData()
        {
            updateInfo = frmstudentScoreCalc.ActiveForm.Tag as string[];
            txtStudentName.Text = updateInfo[0];
            string[] h = updateInfo[1].Split();

            for (var i = 0; i < h.Length; i++)
            {
                if (h[i] != "")
                {
                    listScores.Items.Add(h[i]);
                    scores.Add(Convert.ToDecimal(h[i]));
                }

            }
            listScores.SetSelected(0, true);

        }
        private void frmUpdate_Load(object sender, EventArgs e)
        {

            convertFormData();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form addScore = new frmaddScore();
            DialogResult selectedButton = addScore.ShowDialog();
            addedValue = addScore.Tag.ToString();
            listScores.Items.Add(addedValue);
            scores.Add(Convert.ToDecimal(addedValue));
            updateScore = scores.ToArray();
            updateArray(updateScore, updateInfo);


        }

        private void updateArray(decimal[] updateScore, string[] updateInfo)
        {
            updateInfo[1] = "";
            total = 0;
            count = 0;

            for (var i = 0; i < updateScore.Length; i++)
            {
                updateInfo[1] += updateScore[i].ToString() + " ";
                total += updateScore[i];
                count++;
            }
            average = total / count;
            updateInfo[2] = total.ToString();
            updateInfo[3] = count.ToString();
            updateInfo[4] = average.ToString();
            
        }

        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Form updateValue = new frmUpdateScore();
            DialogResult selectedButton = updateValue.ShowDialog();

            string value = updateValue.Tag.ToString();
            scores.RemoveAt(listScores.SelectedIndex);
            listScores.Items.RemoveAt(listScores.SelectedIndex);
            
            listScores.Items.Add(value);
            scores.Add(Convert.ToDecimal(updateValue.Tag));
            updateScore = scores.ToArray();
            updateArray(updateScore, updateInfo);
           
        }

     

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Tag = updateInfo;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            scores.Clear();
            scores.Add(0); 
            updateScore = scores.ToArray();
            listScores.Items.Clear();
            listScores.Items.Add("");
            updateArray(updateScore, updateInfo);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //int removalIndex = lstStudents.SelectedIndex + 1;
            //string[] placeholder = new string[] { "", "", "", "", "" };
            //getInfo.Insert(lstStudents.SelectedIndex, placeholder);
            //lstStudents.Items.Insert(lstStudents.SelectedIndex, "");
            //lstStudents.SetSelected(0, true);
            //getInfo.RemoveAt(removalIndex);
            //lstStudents.Items.RemoveAt(removalIndex);

            int removalIndex = listScores.SelectedIndex + 1;
            scores.RemoveAt(listScores.SelectedIndex);
            updateScore = scores.ToArray();
            listScores.Items.RemoveAt(listScores.SelectedIndex);
            updateArray(updateScore,updateInfo);
        }
    }
}
