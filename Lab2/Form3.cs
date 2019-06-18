using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;

namespace Lab2
{
    public partial class Form3 : MaterialSkin.Controls.MaterialForm
    {
        public Form3()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Grey50, Primary.Grey900, Primary.Grey500, Accent.Orange100, TextShade.BLACK);
            materialTabControl1.SelectedIndex = 1;
            //pictureBox5.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            //pictureBox1.Load(openFileDialog1.FileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //PersonContext dw = new PersonContext();
            //var singers = dw.Peoples.ToList();
            //pictureBox1.Load(singers[1].profileImage);
            //PersonContext ps = new PersonContext();
            //Person pers = new Person();
            //pers.profileImage = new Bitmap(pictureBox1.Image);
            //pers.profileImage = pictureBox1.Image;
            //pers.Name = "Romka";
            //pers.Password = "123";
            //pers.Rank = 1;
            //if (materialRadioButton2.Checked)
            //{
            //    pers.Rank = 2;
            //}else if (materialRadioButton3.Checked)
            //{
            //    pers.Rank = 3;
            //}
            //else
            //{
            //    pers.Rank = 1;
            //}
            //ps.Peoples.Add(pers);
            //ps.SaveChanges();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var password = maskedTextBox1.Text;
            var cpassword = maskedTextBox2.Text;
            var phone_number = maskedTextBox3.Text;
            var card_number = maskedTextBox4.Text;
            var rank = 1;
            if (materialRadioButton2.Checked) rank = 2;
            else if (materialRadioButton3.Checked) rank = 3;
            var FN = openFileDialog1.FileName.Split('\\');
            var fileOfPic = "ProfileImages\\" + FN.Last();
            pictureBox1.Image.Save(fileOfPic); //"\\ProfileImages\\" +
            if (rank == 1)
            {
                VisitorContext vc = new VisitorContext();
                Visitor visitor = new Visitor();

                if (password == cpassword)
                {
                    visitor.Login = login;
                    visitor.Password = password;
                    visitor.phoneNumber = phone_number;
                    visitor.cardNumber = card_number;
                    visitor.rank = rank;
                    visitor.profileImage = fileOfPic;
                    vc.Visitors.Add(visitor);
                    vc.SaveChanges();
                }


            }
            else if (rank == 2)
            {
                SingerContext sc = new SingerContext();
                Singer singer = new Singer();

                if (password == cpassword)
                {
                    singer.Login = login;
                    singer.Password = password;
                    singer.phoneNumber = phone_number;
                    singer.cardNumber = card_number;
                    singer.rank = rank;
                    singer.profileImage = fileOfPic;
                    sc.Singers.Add(singer);
                    sc.SaveChanges();
                }
            }
            else
            {
                ManagerContext mc = new ManagerContext();
                Manager manager = new Manager();
                if (password == cpassword)
                {
                    manager.Login = login;
                    manager.Password = password;
                    manager.phoneNumber = phone_number;
                    manager.cardNumber = card_number;
                    manager.rank = rank;
                    manager.profileImage = fileOfPic;
                    manager.Concerts = null;
                    mc.Managers.Add(manager);
                    mc.SaveChanges();
                }

            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.Load(openFileDialog1.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool complete = false;
            if (!complete)
            {
                using (VisitorContext vc = new VisitorContext())
                {
                    var Visitors = vc.Visitors.Where(p => p.Login == textBox3.Text);
                    if (Visitors.Count() > 0)
                    {
                        complete = true;
                        foreach (var v in Visitors)
                        {
                            if (v.Password == textBox2.Text)
                            {
                                Form1 form1 = new Form1(v.Id, 1);
                                form1.Show();
                                break;
                            }
                        }
                    }
                }
            }
            if (complete)
            {
                this.Hide();
            }
            else
            {
                using (SingerContext sc = new SingerContext())
                {
                    var Singers = sc.Singers.Where(p => p.Login == textBox3.Text);
                    if (Singers.Count() > 0)
                    {
                        complete = true;
                        foreach (var s in Singers)
                        {
                            if (s.Password == textBox2.Text)
                            {
                                Form1 form1 = new Form1(s.Id, 2);
                                form1.Show();
                                break;
                            }
                        }
                    }
                }
            }
            if (complete)
            {
                this.Hide();
            }
            else
            {
                using (ManagerContext mc = new ManagerContext())
                {
                    var Managers = mc.Managers.Where(p => p.Login == textBox3.Text);
                    if (Managers.Count() > 0)
                    {
                        complete = true;
                        foreach (var m in Managers)
                        {
                            if (m.Password == textBox2.Text)
                            {
                                Form1 form1 = new Form1(m.Id, 3);
                                form1.Show();
                                break;
                            }
                        }
                            
                    }
                }
            }
            if (complete)
            {
                this.Hide();
            }
            else
            {
                button2.Text = "Net";
            }
            
        }

        private void label9_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 1;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 0;
        }
    }
}
