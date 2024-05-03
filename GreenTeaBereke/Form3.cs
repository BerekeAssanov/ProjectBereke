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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GreenTeaBereke
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Donor donor = new Donor();
        }

        int n = 1;

        public void Form3_Load(object sender, EventArgs e)
        {
            {

                if (new FileInfo("donorData.txt").Length == 0)
                {
                    button1.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                }
                else
                {
                FileStream fs = new FileStream("donorData.txt", FileMode.Open, FileAccess.Read);
                Donor donor = new Donor();
                StreamReader firstsr = new StreamReader(fs);
                string[] lines = firstsr.ReadToEnd().Split('~');
                label21.Text = Convert.ToString( lines.Count() -1 );
                firstsr.Close();
                fs.Close();




                string[] data = lines[0].Split(';');

                donor.id = Convert.ToInt32(data[0]);
                donor.name = data[1];
                donor.surname = data[2];
                donor.socialId = data[3];
                donor.phoneNumber = data[4];
                donor.email = data[5];
                donor.bloodType = data[6];
                donor.donationDate = data[7];

                label12.Text = Convert.ToString(donor.id);
                label13.Text = donor.name;
                label14.Text = donor.surname;
                label15.Text = donor.socialId;
                label16.Text = donor.phoneNumber;
                label17.Text = donor.email;
                label18.Text = donor.bloodType;
                label19.Text = donor.donationDate;

                button3.Enabled = false;
                if (n == lines.Count() - 1)
                { button4.Enabled = false; }
                label20.Text = Convert.ToString(n);
                }
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("donorData.txt", FileMode.Open, FileAccess.Read);
            Donor donor = new Donor();
            StreamReader firstsr = new StreamReader(fs);
            string[] lines = firstsr.ReadToEnd().Split('~');
            firstsr.Close();
            fs.Close();

            n = --n;
            string[] data = lines[n - 1].Split(';');

            donor.id = Convert.ToInt32(data[0]);
            donor.name = data[1];
            donor.surname = data[2];
            donor.socialId = data[3];
            donor.phoneNumber = data[4];
            donor.email = data[5];
            donor.bloodType = data[6];
            donor.donationDate = data[7];

            label12.Text = Convert.ToString(donor.id);
            label13.Text = donor.name;
            label14.Text = donor.surname;
            label15.Text = donor.socialId;
            label16.Text = donor.phoneNumber;
            label17.Text = donor.email;
            label18.Text = donor.bloodType;
            label19.Text = donor.donationDate;

            button4.Enabled = true;
            if (n == 1)
            { button3.Enabled = false; }

            label20.Text = Convert.ToString(n);
        }

        public void button4_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("donorData.txt", FileMode.Open, FileAccess.Read);
            Donor donor = new Donor();
            StreamReader firstsr = new StreamReader(fs);
            string[] lines = firstsr.ReadToEnd().Split('~');
            firstsr.Close();
            fs.Close();

            n = ++n;
            string[] data = lines[n-1].Split(';');

            donor.id = Convert.ToInt32(data[0]);
            donor.name = data[1];
            donor.surname = data[2];
            donor.socialId = data[3];
            donor.phoneNumber = data[4];
            donor.email = data[5];
            donor.bloodType = data[6];
            donor.donationDate = data[7];

            label12.Text = Convert.ToString(donor.id);
            label13.Text = donor.name;
            label14.Text = donor.surname;
            label15.Text = donor.socialId;
            label16.Text = donor.phoneNumber;
            label17.Text = donor.email;
            label18.Text = donor.bloodType;
            label19.Text = donor.donationDate;

            button3.Enabled = true;
            if (n == lines.Count()-1)
               { button4.Enabled = false; }

            label20.Text = Convert.ToString(n);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("donorData.txt", FileMode.Open, FileAccess.Read);
            StreamReader firstsr = new StreamReader(fs);
            string[] lines = firstsr.ReadToEnd().Split('~');

            firstsr.Close();
            fs.Close();


            FileStream sfs = new FileStream("donorData.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(sfs);


            string deadline = lines[n - 1];

            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines[i] == deadline || lines[i].Trim() == "")
                {
                    continue;
               }
                else
                {
                    sw.WriteLine(lines[i] + "~");
                }
            }



            sw.Close();
            sfs.Close();


            //Reloading the information
            if (new FileInfo("donorData.txt").Length == 0)
            {
                button1.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                label12.Text = "-";
                label13.Text = "-";
                label14.Text = "-";
                label15.Text = "-";
                label16.Text = "-";
                label17.Text = "-";
                label18.Text = "-";
                label19.Text = "-";
                label20.Text = "0";
                label21.Text = "0";
            }
            else
            {
                n = 1;
            FileStream tfs = new FileStream("donorData.txt", FileMode.Open, FileAccess.Read);
            Donor donor = new Donor();
            StreamReader secondsr = new StreamReader(tfs);
            string[] newlines = secondsr.ReadToEnd().Split('~');
            label21.Text = Convert.ToString(newlines.Count() - 1);
            secondsr.Close();
            tfs.Close();




            string[] data = newlines[0].Split(';');

            donor.id = Convert.ToInt32(data[0]);
            donor.name = data[1];
            donor.surname = data[2];
            donor.socialId = data[3];
            donor.phoneNumber = data[4];
            donor.email = data[5];
            donor.bloodType = data[6];
            donor.donationDate = data[7];

            label12.Text = Convert.ToString(donor.id);
            label13.Text = donor.name;
            label14.Text = donor.surname;
            label15.Text = donor.socialId;
            label16.Text = donor.phoneNumber;
            label17.Text = donor.email;
            label18.Text = donor.bloodType;
            label19.Text = donor.donationDate;

            button3.Enabled = false;
            if (newlines.Count() - 1  == 1)
            { button4.Enabled = false; }
            label20.Text = Convert.ToString(n);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }    
}
