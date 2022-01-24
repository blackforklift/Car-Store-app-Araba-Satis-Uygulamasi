using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using Newtonsoft.Json;

namespace Final_Araba_Satis
{
    public partial class Fatura : Form
    {
        Store myStore = new Store();
        public static Fatura instance;
        public string Date, Time, tc, address, name, surname, arababilgi; //public değerleri bilgi çekmek için kullanacağım
     
        public Fatura()
        {
            InitializeComponent();
            Date = DateTime.Now.ToString("dd/MM/yyy"); //gün ay yıl şeklinde yaz zamanı.
            Time = DateTime.Now.ToString("HH:mm"); //saat dakika şeklinde yaz.
            instance = this;
        }

        private void pictureBox_print_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox_print, "yazdır"); //fare iley yazıcı ikonu üstüne gelince yazdır yazsın
            Print(this.panelprint); //yazdır
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Araba obj = new Araba();     //araba ekleyi aç
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Satış obj = new Satış();
            obj.Show();
            this.Hide();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)


        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memorying, (pagearea.Width / 4) - (this.panelprint.Width / 4), this.panelprint.Location.Y);

        }


        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

     
        private void btn_Print_Click_1(object sender, EventArgs e)
        {
            Print(this.panelprint);

        }

        private void label25_Click_1(object sender, EventArgs e)  //çıkış labeline tıklandığında uygulama kapansın.
        { 
            System.Windows.Forms.Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void panelprint_Paint_1(object sender, PaintEventArgs e)
        {

          
            lbl_tarih.Text = Date;          //bilgi çekmek için değerleri public stringlere atıyorum

            lbl_saat.Text = Time;
            lbl_adres.Text = address;
            lbl_kimlik.Text = tc;
            lbl_ad.Text = name;
            lbl_soyad.Text = surname;
      
                string[] veriler = new string[Satış.instance.listboxsepet.Items.Count];      //araç bilgilerini çekiyorum.
                string mesaj = "";
                for (int i = 0; i < Satış.instance.listboxsepet.Items.Count; i++)
                {
                    veriler[i] = Satış.instance.listboxsepet.Items[i].ToString();
                    mesaj += veriler[i];

                }
                lbl_id.Text = mesaj;

            lbl_kdv.Text = "%18";
            lbl_ötv.Text = "%130";
            lbl_toplam.Text = Satış.instance.lblsatis.Text;


        }
  

     

        private void Print(Panel pnl)      // yazdıralacak yerleri seç ve göster
        {
            PrinterSettings ps = new PrinterSettings();
            panelprint = pnl;
            getprintarea(pnl);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.ShowDialog();

        }
        private Bitmap memorying;
        private void getprintarea(Panel pnl)  //yazdırılacak alanı çiz hesapla
        {
            memorying = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memorying, new Rectangle(0, 0, pnl.Width, pnl.Height));

        }

        private void Fatura_Load(object sender, EventArgs e)
        {

      


        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
