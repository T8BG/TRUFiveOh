using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaseReport
{
    public partial class Form3 : Form
    {
        public int caseNum;
        private static String filePath = "";
        public bool checkCase = false;
        public int caseFile;
        public Form3()
        {
            InitializeComponent();
        }

        //Load step one
        private void button1_Click(object sender, EventArgs e)
        {
            if(caseNum == 0)
            {
                MessageBox.Show("Please select or create a case.");
            }
            else
            {
                Form1 stepOne = new Form1(this);

                this.Hide();
                stepOne.Show();
            }
        }

        //Create a randomized case number
        public int generateCase()
        {
            Random rnd = new Random();
            caseFile = rnd.Next(1, 2147483647);


            return caseFile;
        }


        //Load step two
        private void button2_Click(object sender, EventArgs e)
        {
            if (caseNum == 0)
            {
                MessageBox.Show("Please select or create a case.");
            }
            else
            {
                if (File.Exists("D:\\CaseReport\\Stage1\\" + caseNum + "StageOne.txt"))
                {
                    StreamReader sRead = new StreamReader("D:\\CaseReport\\Stage1\\" + caseNum + "StageOne.txt");
                    Form1.inLine = sRead.ReadToEnd();
                    sRead.Close();
                }
                if (Form1.inLine.Contains("Submitted"))
                {
                    Form2 stepTwo = new Form2(this);

                    this.Hide();
                    stepTwo.Show();
                }
                else
                {
                    MessageBox.Show("Step One is not yet completed.");
                }
            }
        }

        //Load step three
        private void button3_Click(object sender, EventArgs e)
        {
            if(caseNum == 0)
            {
                MessageBox.Show("Please select or create a case.");
            }
            else
            {
                if (File.Exists("D:\\CaseReport\\Stage2\\" + caseNum + "StageTwo.txt"))
                {
                    StreamReader sRead = new StreamReader("D:\\CaseReport\\Stage2\\" + caseNum + "StageTwo.txt");
                    Form2.inLine = sRead.ReadToEnd();
                    sRead.Close();
                }
                if (Form1.inLine.Contains("Submitted"))
                {
                    Form4 stepThree = new Form4(this);

                    this.Hide();
                    stepThree.Show();
                }
                else
                {
                    MessageBox.Show("Step Two is not yet completed.");
                }
            }
        }


        //Load step four
        private void button4_Click(object sender, EventArgs e)
        {
            if (caseNum == 0)
            {
                MessageBox.Show("Please select or create a case.");
            }
            else
            {
                if (File.Exists("D:\\CaseReport\\Stage3\\" + caseNum + "StageThree.txt"))
                {
                    StreamReader sRead = new StreamReader("D:\\CaseReport\\Stage3\\" + caseNum + "StageThree.txt");
                    Form4.inLine = sRead.ReadToEnd();
                    sRead.Close();
                }
                if (Form1.inLine.Contains("Submitted"))
                {
                    Form5 stepFour = new Form5(this);

                    this.Hide();
                    stepFour.Show();
                }
                else
                {
                    MessageBox.Show("Step Three is not yet completed.");
                }
            }
        }


        //Create new file
        private void button6_Click(object sender, EventArgs e) // New file
        {
            while(checkCase == false)
            {
                caseNum = generateCase();
                if(File.Exists("D:\\CaseReport\\Admin\\" + caseNum + ".txt")) // Check if the case number already exists
                {
                }
                else // The case does not already exist
                {
                    break;
                }
            }
            StreamWriter sWrite = new StreamWriter("D:\\CaseReport\\Admin\\" + caseNum + ".txt");
            MessageBox.Show("File Created. Case Number: " + caseNum + ".");
            sWrite.Close();
        }


        //Load file
        private void button7_Click(object sender, EventArgs e) // Load file
        {
            OpenFileDialog select = new OpenFileDialog();
            if(select.ShowDialog() == DialogResult.OK)
            {
                filePath = select.FileName;
                filePath = filePath.Replace("D:\\CaseReport\\Admin\\", "");
                filePath = filePath.Replace(".txt", "");
                caseNum = Convert.ToInt32(filePath);
            }
            MessageBox.Show("Selected case: " + caseNum);
        }

        //Load step five
        private void button5_Click(object sender, EventArgs e)
        {
            if (caseNum == 0)
            {
                MessageBox.Show("Please select or create a case.");
            }
            else
            {
                if (File.Exists("D:\\CaseReport\\Stage4\\" + caseNum + "StageFour.txt"))
                {
                    StreamReader sRead = new StreamReader("D:\\CaseReport\\Stage4\\" + caseNum + "StageFour.txt");
                    Form5.inLine = sRead.ReadToEnd();
                    sRead.Close();
                }
                if (Form1.inLine.Contains("Submitted"))
                {
                    Form6 stepFive = new Form6(this);

                    this.Hide();
                    stepFive.Show();
                }
                else
                {
                    MessageBox.Show("Step Four is not yet completed.");
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
