using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GreenTeaBereke
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        string filePath;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        

        
        private void Form2_Load(object sender, EventArgs e)
        {
            {
                DateLabel.Text = DateTime.Now.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || comboBox1.Text.Length == 0 )
            {
                MessageBox.Show("Please enter full data before proceeding.");
            }

            else
            {
                Donor donor = new Donor();
                
                Random random = new Random();
                int id = random.Next(10000, 99999);
                donor.id = id;
                donor.name = textBox1.Text.Trim( );
                donor.surname = textBox2.Text.Trim( );
                donor.socialId = textBox3.Text.Trim( );
                donor.phoneNumber = textBox4.Text.Trim( );
                donor.email = textBox5.Text.Trim( );
                donor.bloodType = comboBox1.Text.Trim( );
                donor.donationDate = Convert.ToString( DateLabel.Text).Trim( );
                //donor.image = filePath;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                DateLabel.Text = DateTime.Now.ToString();


                FileStream fs = new FileStream("donorData.txt",FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);


                sw.WriteLine(donor.id + ";" + donor.name + ";" + donor.surname + ";" + donor.socialId + ";" + donor.phoneNumber + ";" + donor.email + ";" + donor.bloodType + ";" + donor.donationDate + "~");
                sw.Close();
                fs.Close();
                MessageBox.Show("Data has been saved to the file.");
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            filePath = openFileDialog.FileName;
            if (result == DialogResult.OK)
            pictureBox1.Image= Image.FromFile(filePath);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
