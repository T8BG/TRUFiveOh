using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaseReport
{
    public partial class Form5 : Form
    {
        Form3 admin = new Form3();
        public static String inLine ="";
        public static String outLine;
        public Form5(Form3 admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        //Submit button

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("D:\\CaseReport\\Stage4\\" + admin.caseNum + "StageFour.txt")) // Check if it has been submitted before.
            {
                StreamReader sRead = new StreamReader("D:\\CaseReport\\Stage4\\" + admin.caseNum + "StageFour.txt");
                inLine = sRead.ReadToEnd();
                sRead.Close();
            }
            if (inLine.Contains("Submitted"))
            {
                MessageBox.Show("This file has already been submitted");
            }
            else
            {
                if ((radioButton1.Checked == false && radioButton2.Checked == false) || richTextBox1.Text == "" || textBox1.Text == "")
                {
                    MessageBox.Show("Incomplete form.");
                }
                else
                {
                    DialogResult result = MessageBox.Show("You acknowledge that the submission of this form is an agreement to the terms, and will act as a signature.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        if (richTextBox1.Text.Contains("¥") || richTextBox2.Text.Contains("¥") || textBox1.Text.Contains("¥"))
                        {
                            MessageBox.Show("¥ symbol not allowed. Please remove and submit again.");
                        }
                        else
                        {
                            StreamWriter sWrite2 = new StreamWriter("D:\\CaseReport\\Stage4\\" + admin.caseNum + "StageFour.txt");
                            outLine = richTextBox1.Text + "¥" + richTextBox2.Text + "¥" + textBox1.Text + "¥" + dateTimePicker1.Text + "¥" + radioButton1.Checked + "¥" + radioButton2.Checked + "¥Submitted";
                            sWrite2.WriteLine(outLine);
                            sWrite2.Close();
                            this.Hide();
                            admin.Show();
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Writing to a file
            if (richTextBox1.Text.Contains("¥") || richTextBox2.Text.Contains("¥") || textBox1.Text.Contains("¥"))
            {
                MessageBox.Show("¥ symbol not allowed. Please remove and save again.");
            }
            else
            {
                StreamWriter sWrite2 = new StreamWriter("D:\\CaseReport\\Stage4\\" + admin.caseNum + "StageFour.txt");
                outLine = richTextBox1.Text + "¥" + richTextBox2.Text + "¥" + textBox1.Text + "¥" + dateTimePicker1.Text + "¥" + radioButton1.Checked + "¥" + radioButton2.Checked;
                sWrite2.WriteLine(outLine);
                sWrite2.Close();
                MessageBox.Show("Saved!");
            }
        }

        private void button4_Click(object sender, EventArgs e) // Checking
        {
            // PYTHON STUFF
            var pstartinfo = new ProcessStartInfo();
            pstartinfo.FileName = @"C:\Users\codys\AppData\Local\Programs\Python\Python313\python.exe";
            var script = @"D:\CaseReport\Python\Test.py";
            var searchFor = textBox2.Text;
            var poolone = Form1.OutLine;
            var pooltwo = Form2.outLine;
            var poolthree = Form4.outLine;
            var searchcomplete = "";
            pstartinfo.Arguments = $"\"{script}\" \"{searchFor}\" \"{poolone}\" \"{pooltwo}\" \"{poolthree}\"";
            pstartinfo.UseShellExecute = false;
            pstartinfo.CreateNoWindow = true;
            pstartinfo.RedirectStandardOutput = true;
            pstartinfo.RedirectStandardError = true;

            using (Process process = Process.Start(pstartinfo))
            {
                searchcomplete = process.StandardOutput.ReadToEnd();
            }
            MessageBox.Show(searchcomplete);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            // Reading a file
            if(File.Exists("D:\\CaseReport\\Stage4\\" + admin.caseNum + "StageFour.txt"))
            {
                StreamReader sRead = new StreamReader("D:\\CaseReport\\Stage4\\" + admin.caseNum + "StageFour.txt");
                String inLine = sRead.ReadLine();
                String[] load = inLine.Split('¥');
                richTextBox1.Text = load[0];
                richTextBox2.Text = load[1];
                textBox1.Text = load[2];
                dateTimePicker1.Text = load[3];
                if (load[4] == "True")
                {
                    radioButton1.Checked = true;
                }
                else if (load[5] == "True")
                {
                    radioButton2.Checked = true;
                }
                sRead.Close();
            }
            else
            {
                MessageBox.Show("File does not exist, please save first.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
