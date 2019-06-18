using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using MaterialSkin;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Lab2
{
    delegate void MoneyHandler(int money);
    delegate int Converter(int money);
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        
        public Form1(int id, int rank)
        {
            multi_s = 0;
            multi_c = 0;
            user_id = id;
            user_rank = rank;
            InitializeComponent();
            //materialLabel2.Text = user_id.ToString();
            MoneyHandler handler = delegate (int money)
            {
                materialLabel1.Text = '$'+money.ToString();
            };
            Converter convertGrivnas = money_ => money_ * 28;
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Grey50, Primary.Grey900, Primary.Grey500, Accent.DeepOrange200, TextShade.BLACK);
            materialTabControl1.SelectedIndex = 1;
            handler.Invoke(convertGrivnas(2000));
            switch (rank)
            {
                case 1:
                    button4.Show();
                    button5.Hide();
                    VisitorContext vc = new VisitorContext();
                    var current_user =  vc.Visitors.Find(id);
                    materialLabel14.Text = current_user.Login;
                    //pictureBox18.Load(current_user.profileImage);
                    materialLabel15.Text = "Відвідувач";
                    break;
                case 2:
                    SingerContext sc = new SingerContext();
                    var current_user1 = sc.Singers.Find(id);
                    materialLabel14.Text = current_user1.Login;
                    //pictureBox18.Load(current_user1.profileImage);
                    materialLabel15.Text = "Співак";
                    break;
                case 3:
                    button4.Show();
                    button5.Show();
                    ManagerContext mc = new ManagerContext();

                    var current_user2 = mc.Managers.Find(id);
                    materialLabel14.Text = current_user2.Login;
                    //pictureBox18.Load(current_user2.profileImage);
                    materialLabel15.Text = "Менеджер";
                    break;
            }
            //ImageList imageList = new ImageList();

            // tableLayoutPanel1.
        }

        private void materialContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (materialTabControl1.SelectedIndex == 1)
            {
                multi_c++;
                show_concerts();
            }
            else if (materialTabControl1.SelectedIndex == 2)
            {
                multi_s++;
                show_singers();
            }
            
        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 0;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 1;
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 2;
        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton8_Click(object sender, EventArgs e)
        {
            //Manager mang = new Manager();
            //Singer Vinnyk = new Singer();
            //Vinnyk.Name = "Олег Вінник";
            //mang.MakeConcert(Vinnyk, "30.04.2019");
            //Singer Elish = new Singer();
            //Elish.Name = "Bille Elish";
            //ConcertContext db = new ConcertContext();
            // SingerContext dw = new SingerContext();
            //dw.Singers.Add(Elish);
            //dw.Singers.Add(Vinnyk);
            // Vinnyk.Name = "Bille Elish";
            // mang.MakeConcert(Elish, "01.08.2019");
            Form2 form2 = new Form2(user_id);
            form2.ShowDialog();
        }

        private void materialRaisedButton6_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectedIndex = 1;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void aaa1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            show_concerts();
            show_singers();

        }
        public void show_concerts()
        {
            ConcertContext db = new ConcertContext();
            var concerts = db.Concerts.ToList();
            if (concerts.Count > 3 * multi_c)
            {
                pictureBox3.Load(concerts[3 * multi_c].WallPaper);
                materialLabel6.Text = concerts[3 * multi_c].Name;
                materialLabel3.Text = concerts[3 * multi_c].Place;
                price1.Text = concerts[3 * multi_c].TicketPrice.ToString();
            }
            else
            {
                pictureBox3.Hide();
                materialLabel6.Hide();
                materialLabel3.Hide();
                price1.Hide();
                pictureBox12.Hide();
                pictureBox15.Hide();
                materialFlatButton3.Hide();
            }
            if (concerts.Count > 3 * multi_c + 1)
            {
                pictureBox4.Load(concerts[3 * multi_c + 1].WallPaper);
                materialLabel7.Text = concerts[3 * multi_c + 1].Name;
                materialLabel4.Text = concerts[3 * multi_c + 1].Place;
                price2.Text = concerts[3 * multi_c+1].TicketPrice.ToString();
            }
            else
            {
                pictureBox4.Hide();
                materialLabel7.Hide();
                materialLabel4.Hide();
                price2.Hide();
                pictureBox14.Hide();
                pictureBox16.Hide();
                materialFlatButton2.Hide();
            }
            if (concerts.Count > 3 * multi_c + 2)
            {
                pictureBox11.Load(concerts[3 * multi_c + 2].WallPaper);
                materialLabel8.Text = concerts[3 * multi_c + 2].Name;
                materialLabel5.Text = concerts[3 * multi_c + 2].Place;
                price3.Text = concerts[3 * multi_c + 2].TicketPrice.ToString();
            }
            else
            {
                //pictureBox1.Hide();
                materialLabel8.Hide();
                materialLabel5.Hide();
                price3.Hide();
                pictureBox13.Hide();
                pictureBox17.Hide();
                materialFlatButton1.Hide();
            }
        }
        public void show_singers()
        {
            //SingerContext dw = new SingerContext();
            //var singers = dw.Singers.ToList();
            //if (singers.Count > 6 * multi_s)
            //{
            //    pictureBox5.Load(singers[6 * multi_s].profileImage);
            //    materialLabel11.Text = singers[6 * multi_s].Login;
            //}
            //if (singers.Count > 6 * multi_s+1)
            //{
            //    pictureBox6.Load(singers[6 * multi_s + 1].profileImage);
            //    materialLabel12.Text = singers[6 * multi_s + 1].Login;
            //}
            //if (singers.Count > 6 * multi_s+2)
            //{
            //    pictureBox7.Load(singers[6 * multi_s + 2].profileImage);
            //    materialLabel13.Text = singers[6 * multi_s + 2].Login;
            //}
            //if (singers.Count > 6 * multi_s+3)
            //{
            //    pictureBox8.Load(singers[6 * multi_s + 3].profileImage);
            //    materialLabel9.Text = singers[6 * multi_s + 3].Login;
            //}
            //if (singers.Count > 6 * multi_s+4)
            //{
            //    pictureBox9.Load(singers[6 * multi_s + 4].profileImage);
            //    materialLabel10.Text = singers[6 * multi_s + 4].Login;
            //}
            //if (singers.Count > 6 * multi_s+5)
            //{
            //    pictureBox10.Load(singers[6 * multi_s + 5].profileImage);
            //    materialLabel17.Text = singers[6 * multi_s + 5].Login;
            //}

        }
        private void button3_Click(object sender, EventArgs e)
        {
            //show_concerts();
            tabPage3.Show();
            tabPage1.Hide();
            tabPage2.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabPage2.Show();
            tabPage1.Hide();
            tabPage3.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabPage1.Show();
            tabPage2.Hide();
            tabPage3.Hide();
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            ConcertContext cc = new ConcertContext();
            var concert = cc.Concerts.Find(multi_c * 3 + 1);
            VisitorContext vc = new VisitorContext();
            var visitor = vc.Visitors.Find(user_id);
            concert.Visitors.Add(visitor);
            visitor.Concerts.Add(concert);
            vc.SaveChanges();
            cc.SaveChanges();
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            materialTabControl1.TabIndex = 1;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        { 
            if (materialTabControl1.SelectedIndex == 1)
            {
                if (multi_c > 0)
                {
                    multi_c--;
                    show_concerts();
                }
            }
            else if (materialTabControl1.SelectedIndex == 2)
            {
                if (multi_s > 0)
                {
                    multi_s--;
                    show_singers();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(user_id);
            form2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            materialLabel2.Text = multi_c.ToString();
            ConcertContext cc = new ConcertContext();
            var concert = cc.Concerts.Find(multi_c*3+1);
            var g = concert.Name;
            VisitorContext vc = new VisitorContext();
            var visitor = vc.Visitors.Find(user_id);
            visitor.BuyTicket(ref concert);
            var f = visitor.Login;
            //Visitor vs = new Visitor();
            //vs.cardNumber = visitor.cardNumber;
            //vs.CurrentSum = visitor.CurrentSum;
            //vs.Id = visitor.Id;
            //vs.Login = visitor.Login;
            //vs.Password = visitor.Password;
            //vs.phoneNumber = visitor.phoneNumber;
            //vs.profileImage = visitor.profileImage;
            //vs.rank = visitor.rank;
            //vs.Concerts = visitor.Concerts;
            //Concert cnc = new Concert();
            //cnc.Date = concert.Date;
            //cnc.Id = concert.Id;
            //cnc.Manager = concert.Manager;
            //cnc.Name = concert.Name;
            //cnc.Place = concert.Place;
            //cnc.Singers = concert.Singers;
            //cnc.TicketPrice = concert.TicketPrice;
            //cnc.Tickets = concert.Tickets;
            //cnc.Visitors = concert.Visitors;
            //cnc.WallPaper = concert.WallPaper;
            cc.Entry(concert).State = EntityState.Modified;
            vc.Entry(visitor).State = EntityState.Modified;
            //visitor.Concerts.Add(concert);
            concert.Visitors.Add(visitor);
            
            vc.SaveChanges();
            cc.SaveChanges();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            ConcertContext cc = new ConcertContext();
            var concert = cc.Concerts.Find(multi_c * 3+2);
            VisitorContext vc = new VisitorContext();
            var visitor = vc.Visitors.Find(user_id);
            concert.Visitors.Add(visitor);
            visitor.Concerts.Add(concert);
            vc.SaveChanges();
            cc.SaveChanges();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    ConcertContext db = new ConcertContext();
                    var concerts = db.Concerts.OrderBy(p => p.Date).ToList();
                    if (concerts.Count > 3 * multi_c)
                    {
                        pictureBox3.Load(concerts[3 * multi_c].WallPaper);
                        materialLabel6.Text = concerts[3 * multi_c].Name;
                        materialLabel3.Text = concerts[3 * multi_c].Place;
                        price1.Text = concerts[3 * multi_c].TicketPrice.ToString();
                    }
                    else
                    {
                        pictureBox3.Hide();
                        materialLabel6.Hide();
                        materialLabel3.Hide();
                        price1.Hide();
                        pictureBox12.Hide();
                        pictureBox15.Hide();
                        materialFlatButton3.Hide();
                    }
                    if (concerts.Count > 3 * multi_c + 1)
                    {
                        pictureBox4.Load(concerts[3 * multi_c + 1].WallPaper);
                        materialLabel7.Text = concerts[3 * multi_c + 1].Name;
                        materialLabel4.Text = concerts[3 * multi_c + 1].Place;
                        price2.Text = concerts[3 * multi_c + 1].TicketPrice.ToString();
                    }
                    else
                    {
                        pictureBox4.Hide();
                        materialLabel7.Hide();
                        materialLabel4.Hide();
                        price2.Hide();
                        pictureBox14.Hide();
                        pictureBox16.Hide();
                        materialFlatButton2.Hide();
                    }
                    if (concerts.Count > 3 * multi_c + 2)
                    {
                        pictureBox11.Load(concerts[3 * multi_c + 2].WallPaper);
                        materialLabel8.Text = concerts[3 * multi_c + 2].Name;
                        materialLabel5.Text = concerts[3 * multi_c + 2].Place;
                        price3.Text = concerts[3 * multi_c + 2].TicketPrice.ToString();
                    }
                    else
                    {
                        //pictureBox1.Hide();
                        materialLabel8.Hide();
                        materialLabel5.Hide();
                        price3.Hide();
                        pictureBox13.Hide();
                        pictureBox17.Hide();
                        materialFlatButton1.Hide();
                    }
                    break;
                case 1:
                    ConcertContext db1 = new ConcertContext();
                    var concerts1 = db1.Concerts.OrderBy(p => p.TicketPrice).ToList();
                    if (concerts1.Count > 3 * multi_c)
                    {
                        pictureBox3.Load(concerts1[3 * multi_c].WallPaper);
                        materialLabel6.Text = concerts1[3 * multi_c].Name;
                        materialLabel3.Text = concerts1[3 * multi_c].Place;
                        price1.Text = concerts1[3 * multi_c].TicketPrice.ToString();
                    }
                    else
                    {
                        pictureBox3.Hide();
                        materialLabel6.Hide();
                        materialLabel3.Hide();
                        price1.Hide();
                        pictureBox12.Hide();
                        pictureBox15.Hide();
                        materialFlatButton3.Hide();
                    }
                    if (concerts1.Count > 3 * multi_c + 1)
                    {
                        pictureBox4.Load(concerts1[3 * multi_c + 1].WallPaper);
                        materialLabel7.Text = concerts1[3 * multi_c + 1].Name;
                        materialLabel4.Text = concerts1[3 * multi_c + 1].Place;
                        price2.Text = concerts1[3 * multi_c + 1].TicketPrice.ToString();
                    }
                    else
                    {
                        pictureBox4.Hide();
                        materialLabel7.Hide();
                        materialLabel4.Hide();
                        price2.Hide();
                        pictureBox14.Hide();
                        pictureBox16.Hide();
                        materialFlatButton2.Hide();
                    }
                    if (concerts1.Count > 3 * multi_c + 2)
                    {
                        pictureBox11.Load(concerts1[3 * multi_c + 2].WallPaper);
                        materialLabel8.Text = concerts1[3 * multi_c + 2].Name;
                        materialLabel5.Text = concerts1[3 * multi_c + 2].Place;
                        price3.Text = concerts1[3 * multi_c + 2].TicketPrice.ToString();
                    }
                    else
                    {
                        //pictureBox1.Hide();
                        materialLabel8.Hide();
                        materialLabel5.Hide();
                        price3.Hide();
                        pictureBox13.Hide();
                        pictureBox17.Hide();
                        materialFlatButton1.Hide();
                    }
                    break;
                case 2:
                    ConcertContext db2 = new ConcertContext();
                    var concerts2 = db2.Concerts.OrderBy(p => p.Id).ToList();
                    if (concerts2.Count > 3 * multi_c)
                    {
                        pictureBox3.Load(concerts2[3 * multi_c].WallPaper);
                        materialLabel6.Text = concerts2[3 * multi_c].Name;
                        materialLabel3.Text = concerts2[3 * multi_c].Place;
                        price1.Text = concerts2[3 * multi_c].TicketPrice.ToString();
                    }
                    else
                    {
                        pictureBox3.Hide();
                        materialLabel6.Hide();
                        materialLabel3.Hide();
                        price1.Hide();
                        pictureBox12.Hide();
                        pictureBox15.Hide();
                        materialFlatButton3.Hide();
                    }
                    if (concerts2.Count > 3 * multi_c + 1)
                    {
                        pictureBox4.Load(concerts2[3 * multi_c + 1].WallPaper);
                        materialLabel7.Text = concerts2[3 * multi_c + 1].Name;
                        materialLabel4.Text = concerts2[3 * multi_c + 1].Place;
                        price2.Text = concerts2[3 * multi_c + 1].TicketPrice.ToString();
                    }
                    else
                    {
                        pictureBox4.Hide();
                        materialLabel7.Hide();
                        materialLabel4.Hide();
                        price2.Hide();
                        pictureBox14.Hide();
                        pictureBox16.Hide();
                        materialFlatButton2.Hide();
                    }
                    if (concerts2.Count > 3 * multi_c + 2)
                    {
                        pictureBox11.Load(concerts2[3 * multi_c + 2].WallPaper);
                        materialLabel8.Text = concerts2[3 * multi_c + 2].Name;
                        materialLabel5.Text = concerts2[3 * multi_c + 2].Place;
                        price3.Text = concerts2[3 * multi_c + 2].TicketPrice.ToString();
                    }
                    else
                    {
                        //pictureBox1.Hide();
                        materialLabel8.Hide();
                        materialLabel5.Hide();
                        price3.Hide();
                        pictureBox13.Hide();
                        pictureBox17.Hide();
                        materialFlatButton1.Hide();
                    }
                    break;
            }
        }
    }
}
