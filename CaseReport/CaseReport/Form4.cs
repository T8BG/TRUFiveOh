using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CaseReport
{
    public partial class Form4 : Form
    {
        Form3 admin = new Form3();
        public static string inLine = "";
        public static string outLine = "";
        public Form4(Form3 admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        //Submit button
        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("D:\\CaseReport\\Stage3\\" + admin.caseNum + "StageThree.txt")) // Check if it has been submitted before.
            {
                StreamReader sRead = new StreamReader("D:\\CaseReport\\Stage3\\" + admin.caseNum + "StageThree.txt");
                inLine = sRead.ReadToEnd();
                sRead.Close();
            }
            if (inLine.Contains("Submitted"))
            {
                MessageBox.Show("This file has already been submitted");
            }
            else
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Incomplete form.");
                }
                else
                {
                    DialogResult result = MessageBox.Show("You acknowledge that the submission of this form is an agreement to the terms, and will act as a signature.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        if(textBox1.Text.Contains("¥"))
                        {
                            MessageBox.Show("¥ symbol not allowed. Please remove and submit again.");
                        }
                        else
                        {
                            StreamWriter sWrite2 = new StreamWriter("D:\\CaseReport\\Stage3\\" + admin.caseNum + "StageThree.txt");
                            outLine = textBox1.Text + "¥" + dateTimePicker1.Text + "¥Submitted";
                            sWrite2.WriteLine(outLine);
                            sWrite2.Close();
                            this.Hide();
                            admin.Show();
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Reading
            if(File.Exists("D:\\CaseReport\\Stage3\\" + admin.caseNum + "StageThree.txt"))
            {
                StreamReader sRead = new StreamReader("D:\\CaseReport\\Stage3\\" + admin.caseNum + "StageThree.txt");
                inLine = sRead.ReadLine();
                String[] load = inLine.Split('¥');
                textBox1.Text = load[0];
                dateTimePicker1.Text = load[1];

                sRead.Close();
            }
            else
            {
                MessageBox.Show("File does not exist, please save first.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Writing to a file
            if (textBox1.Text.Contains("¥"))
            {
                MessageBox.Show("¥ symbol not allowed. Please remove and save again.");
            }
            else
            {
                StreamWriter sWrite2 = new StreamWriter("D:\\CaseReport\\Stage3\\" + admin.caseNum + "StageThree.txt");
                outLine = textBox1.Text + "¥" + dateTimePicker1.Text;
                sWrite2.WriteLine(outLine);
                sWrite2.Close();
                MessageBox.Show("Saved!");
            }
        }

        //Close button
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
