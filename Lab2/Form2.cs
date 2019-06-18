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
using MaterialSkin.Controls;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Lab2
{
    public partial class Form2 : MaterialForm
    {
        public Form2(int manager_id)
        {
            InitializeComponent();
            man_id = manager_id;
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Grey50, Primary.Grey900, Primary.Grey500, Accent.DeepOrange200, TextShade.BLACK);
            SingerContext cs = new SingerContext();
            //Singer sing = new Singer();
            //sing.Name = "Billie";
            //sing.NextConcert = "hai";
            //cs.Singers.Add(sing);
            //cs.SaveChanges();
            //var singers = cs.Singers;
            //comboBox1.Items.Add("hello");
            var concerts = cs.Singers;
            foreach(var singer in concerts)
            {
                comboBox1.Items.Add(singer.Login);
            }
            //materialTabControl1.SelectedIndex = 1;
            //ImageList imageList = new ImageList();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.Load(openFileDialog1.FileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConcertContext db = new ConcertContext();
            SingerContext dw = new SingerContext();
            Concert concert = new Concert();
            var FN = openFileDialog1.FileName.Split('\\');
            var fileOfPic = "ConcertWallpapers\\" + FN.Last();
            pictureBox2.Image.Save(fileOfPic);
            concert.Place = materialSingleLineTextField1.Text;
            concert.Tickets = Convert.ToInt32(materialSingleLineTextField2.Text);
            concert.TicketPrice = Convert.ToInt32(materialSingleLineTextField3.Text);
            concert.Name = materialSingleLineTextField4.Text;
            concert.WallPaper = fileOfPic;
            concert.Singers = dw.Singers.FirstOrDefault(p => p.Login == comboBox1.Text);
            concert.Date = dateTimePicker1.Text;
            ManagerContext mc = new ManagerContext();
            concert.Manager = mc.Managers.Find(man_id);
            //concert.SingerName = comboBox1.Text;
            db.Concerts.Add(concert);
            db.SaveChanges();
        }
    }
}
