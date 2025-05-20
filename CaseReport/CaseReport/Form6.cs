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
    public partial class Form6 : Form
    {
        Form3 admin = new Form3();
        String inLine = " ";
        public Form6(Form3 admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Writing to a file
            StreamWriter sWrite2 = new StreamWriter("D:\\CaseReport\\Stage5\\" + admin.caseNum + "StageFive.txt");
            String outLine = richTextBox1.Text + "¥" + richTextBox2.Text + "¥" + textBox1.Text + "¥" + dateTimePicker1.Text + "¥" + radioButton1.Checked + "¥" + radioButton2.Checked;
            sWrite2.WriteLine(outLine);
            sWrite2.Close();
            MessageBox.Show("Saved!");
        }


        //Submit button
        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists("D:\\CaseReport\\Stage5\\" + admin.caseNum + "StageFive.txt")) // Check if it has been submitted before.
            {
                StreamReader sRead = new StreamReader("D:\\CaseReport\\Stage5\\" + admin.caseNum + "StageFive.txt");
                inLine = sRead.ReadToEnd();
                sRead.Close();
            }
            if (inLine.Contains("Submitted"))
            {
                MessageBox.Show("This file has already been submitted");
            }
            else
            {
                if (richTextBox1.Text == "" || richTextBox2.Text == "" || textBox1.Text == "" || (radioButton1.Checked && radioButton2.Checked))
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
                            StreamWriter sWrite2 = new StreamWriter("D:\\CaseReport\\Stage5\\" + admin.caseNum + "StageFive.txt");
                            String outLine = richTextBox1.Text + "¥" + richTextBox2.Text + "¥" + textBox1.Text + "¥" + dateTimePicker1.Text + "¥" + radioButton1.Checked + "¥" + radioButton2.Checked + "¥Submitted";
                            sWrite2.WriteLine(outLine);
                            sWrite2.Close();
                            this.Hide();
                            admin.Show();
                        }
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            // Reading
            if(File.Exists("D:\\CaseReport\\Stage5\\" + admin.caseNum + "StageFive.txt"))
            {
                StreamReader sRead = new StreamReader("D:\\CaseReport\\Stage5\\" + admin.caseNum + "StageFive.txt");
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

        //Close button
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin.Show();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
