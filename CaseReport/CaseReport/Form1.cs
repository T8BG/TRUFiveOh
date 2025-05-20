using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

namespace CaseReport
{
    public partial class Form1 : Form
    {
        public bool submitted = false;
        public static string OutLine = "";
        public static string inLine = "";
        private Form3 admin;
        public Form1(Form3 admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        // Submit button
        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists("D:\\CaseReport\\Stage1\\" + admin.caseNum + "StageOne.txt")) // Check if it has been submitted before.
            {
                StreamReader sRead = new StreamReader("D:\\CaseReport\\Stage1\\" + admin.caseNum + "StageOne.txt");
                inLine = sRead.ReadToEnd();
                sRead.Close();
            }
            if (inLine.Contains("Submitted"))
            {
                MessageBox.Show("This file has already been submitted");
            }
            else
            {
                if (textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "" || textBox14.Text == "" || textBox15.Text == "" || textBox16.Text == "" || textBox17.Text == "" || richTextBox1.Text == "" || richTextBox2.Text == "" || (checkBox1.Checked == false && checkBox2.Checked == false))
                {
                    MessageBox.Show("Incomplete form.");
                }
                else
                {
                    DialogResult result = MessageBox.Show("You acknowledge that the submission of this form is an agreement to the terms, and will act as a signature.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        if (textBox9.Text.Contains("¥") || textBox10.Text.Contains("¥") || textBox11.Text.Contains("¥") || textBox12.Text.Contains("¥") || textBox13.Text.Contains("¥") || textBox14.Text.Contains("¥") || textBox15.Text.Contains("¥") || textBox16.Text.Contains("¥") || textBox17.Text.Contains("¥") || richTextBox1.Text.Contains("¥") || richTextBox2.Text.Contains("¥"))
                        {
                            MessageBox.Show("¥ symbol not allowed. Please remove and submit again.");
                        }
                        else
                        {
                            StreamWriter sWrite = new StreamWriter("D:\\CaseReport\\Stage1\\" + admin.caseNum + "StageOne.txt");
                            OutLine = textBox9.Text + "¥" + textBox10.Text + "¥" + textBox11.Text + "¥" + textBox12.Text + "¥" + textBox13.Text + "¥" + textBox14.Text + "¥" + textBox15.Text + "¥" + textBox16.Text + "¥" + textBox17.Text + "¥" + richTextBox1.Text + "¥" + richTextBox2.Text + "¥" + dateTimePicker3.Text + "¥" + checkBox1.Checked + "¥" + checkBox2.Checked + "¥" + dateTimePicker2.Text + "¥Submitted";
                            sWrite.WriteLine(OutLine);
                            sWrite.Close();
                            this.Hide();
                            admin.Show();
                        }
                    }
                }
            }       
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            textBox17.Text = textBox12.Text;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if(File.Exists("D:\\CaseReport\\Stage1\\" + admin.caseNum + "StageOne.txt")) // Check if it has been submitted before.
            {
                StreamReader sRead = new StreamReader("D:\\CaseReport\\Stage1\\" + admin.caseNum + "StageOne.txt");
                inLine = sRead.ReadToEnd();
                sRead.Close();
            }
            //Writing to a text file
            if (inLine.Contains("Submitted") == false)
            {
                if(textBox9.Text.Contains("¥") || textBox10.Text.Contains("¥") || textBox11.Text.Contains("¥") || textBox12.Text.Contains("¥") || textBox13.Text.Contains("¥") || textBox14.Text.Contains("¥") || textBox15.Text.Contains("¥") || textBox16.Text.Contains("¥") || textBox17.Text.Contains("¥") || richTextBox1.Text.Contains("¥") || richTextBox2.Text.Contains("¥"))
                {
                    MessageBox.Show("¥ symbol not allowed. Please remove and save again.");
                }
                else
                {
                    StreamWriter sWrite2 = new StreamWriter("D:\\CaseReport\\Stage1\\" + admin.caseNum + "StageOne.txt");
                    OutLine = textBox9.Text + "¥" + textBox10.Text + "¥" + textBox11.Text + "¥" + textBox12.Text + "¥" + textBox13.Text + "¥" + textBox14.Text + "¥" + textBox15.Text + "¥" + textBox16.Text + "¥" + textBox17.Text + "¥" + richTextBox1.Text + "¥" + richTextBox2.Text + "¥" + dateTimePicker3.Text + "¥" + checkBox1.Checked + "¥" + checkBox2.Checked + "¥" + dateTimePicker2.Text;
                    sWrite2.WriteLine(OutLine);
                    sWrite2.Close();
                    MessageBox.Show("Saved!");
                }
            }
            else
            {
                MessageBox.Show("Sorry, this form has already been submitted and cannot be saved.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Reading from a text file
            if(File.Exists("D:\\CaseReport\\Stage1\\" + admin.caseNum + "StageOne.txt"))
            {
                StreamReader sRead = new StreamReader("D:\\CaseReport\\Stage1\\" + admin.caseNum + "StageOne.txt");
                inLine = sRead.ReadLine();
                String[] load = inLine.Split('¥');
                textBox9.Text = load[0];
                textBox10.Text = load[1];
                textBox11.Text = load[2];
                textBox12.Text = load[3];
                textBox17.Text = load[3];
                textBox13.Text = load[4];
                textBox14.Text = load[5];
                textBox15.Text = load[6];
                textBox16.Text = load[7];
                textBox17.Text = load[8];
                richTextBox1.Text = load[9];
                richTextBox2.Text = load[10];
                dateTimePicker3.Text = load[11];
                if (load[12] == "True")
                {
                    checkBox1.Checked = true;
                }
                if (load[13] == "True")
                {
                    checkBox2.Checked = true;
                }
                dateTimePicker2.Text = load[14];
                sRead.Close();
            }
            else
            {
                MessageBox.Show("File does not exist, please save first.");
            }
        }

        //Close Button
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin.Show();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            textBox17.Text = textBox12.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
