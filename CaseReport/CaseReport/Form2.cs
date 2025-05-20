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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CaseReport
{
    public partial class Form2 : Form
    {
        Form3 admin = new Form3();
        public static String inLine = "";
        public static String outLine = "";
        public Form2(Form3 admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        //Submit button
        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("D:\\CaseReport\\Stage2\\" + admin.caseNum + "StageTwo.txt")) // Check if it has been submitted before.
            {
                StreamReader sRead = new StreamReader("D:\\CaseReport\\Stage2\\" + admin.caseNum + "StageTwo.txt");
                inLine = sRead.ReadToEnd();
                sRead.Close();
            }
            if (inLine.Contains("Submitted"))
            {
                MessageBox.Show("This file has already been submitted");
            }
            else
            {
                if (textBox1.Text == "" || radioButton1.Checked == false && radioButton2.Checked == false || textBox2.Text == "" || richTextBox1.Text == "")
                {
                    MessageBox.Show("Incomplete Form");
                }
                else
                {
                    DialogResult result = MessageBox.Show("You acknowledge that the submission of this form is an agreement to the terms, and will act as a signature.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        if(textBox1.Text.Contains("¥") || textBox2.Text.Contains("¥") || richTextBox1.Text.Contains("¥"))
                        {
                            MessageBox.Show("¥ symbol not allowed. Please remove and submit again.");
                        }
                        else
                        {
                            StreamWriter sWrite2 = new StreamWriter("D:\\CaseReport\\Stage2\\" + admin.caseNum + "StageTwo.txt");
                            outLine = textBox1.Text + "¥" + textBox2.Text + "¥" + richTextBox1.Text + "¥" + dateTimePicker1.Text + "¥" + radioButton1.Checked + "¥" + radioButton2.Checked + "¥Submitted";
                            sWrite2.WriteLine(outLine);
                            sWrite2.Close();
                            this.Hide();
                            admin.Show();
                        }
                    }
                }
            }
        }
        //Save button
        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists("D:\\CaseReport\\Stage2\\" + admin.caseNum + "StageTwo.txt")) // Check if it has been submitted before.
            {
                StreamReader sRead = new StreamReader("D:\\CaseReport\\Stage2\\" + admin.caseNum + "StageTwo.txt");
                inLine = sRead.ReadToEnd();
                sRead.Close();
            }
            if(inLine.Contains("Submitted") == false)
            {
                if (textBox1.Text.Contains("¥") || textBox2.Text.Contains("¥") || richTextBox1.Text.Contains("¥"))
                {
                    MessageBox.Show("¥ symbol not allowed. Please remove and save again.");
                }
                else
                {
                    StreamWriter sWrite2 = new StreamWriter("D:\\CaseReport\\Stage2\\" + admin.caseNum + "StageTwo.txt");
                    outLine = textBox1.Text + "¥" + textBox2.Text + "¥" + richTextBox1.Text + "¥" + dateTimePicker1.Text + "¥" + radioButton1.Checked + "¥" + radioButton2.Checked;
                    sWrite2.WriteLine(outLine);
                    sWrite2.Close();
                    MessageBox.Show("Saved!");
                }
            }
            else
            {
                MessageBox.Show("Sorry, this form has already been submitted and cannot be saved.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Reading file
            if(File.Exists("D:\\CaseReport\\Stage2\\" + admin.caseNum + "StageTwo.txt"))
            {
                StreamReader sRead = new StreamReader("D:\\CaseReport\\Stage2\\" + admin.caseNum + "StageTwo.txt");
                inLine = sRead.ReadLine();
                String[] load = inLine.Split('¥');
                textBox1.Text = load[0];
                textBox2.Text = load[1];
                richTextBox1.Text = load[2];
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

        //Close Button
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
