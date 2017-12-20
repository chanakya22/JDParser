using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDParser
{
    public partial class Form1 : Form
    {
        private string resume;
        private string[] resumeParser;
        private int matchingCounter;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            string JD = richTextBox1.Text.ToUpper();
            clbResults.Items.Clear();
            matchingCounter = 0;

            if (string.IsNullOrWhiteSpace(resume))
            {
                resume = rtbResume.Text.ToUpper();
                resumeParser = resume.Split(' ');
            }

            //loop the JD and check if that exists in resume
            foreach (string s in JD.Split(' '))
            {
                if (resumeParser.Contains(s.Trim()))
                {
                    clbResults.Items.Add(s, true);
                    matchingCounter++;
                }
                else
                {
                    clbResults.Items.Add(s, false);
                }

            }

            decimal d = ((matchingCounter*100) / JD.Split(' ').Count());
            lblMatchingPerc.Text = "Matching % - "+d.ToString() ;

            //check if the JD is looking for GC/Citizenship
            if (JD.Contains("US CITIZEN")
                || JD.Contains("GREEN")
                || JD.Contains("GC HOLDER")
                || JD.Contains("H1B")
                || JD.Contains("VISA")
                || JD.Contains("SPONSORSHIP"))
            {
                radioButton1.Checked = true;
            }

            radioButton1.BackColor = radioButton1.Checked ? Color.Red : Color.Green;
            tabControl1.SelectTab(2);

        }
    }
}
