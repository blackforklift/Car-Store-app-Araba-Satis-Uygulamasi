using Newtonsoft.Json;
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

namespace Final_Araba_Satis
{
    public partial class Satış : Form
    {
        Store myStore = new Store();

        public static Satış instance;
        public ListBox listboxsepet;
        public Label lblsatis;
        BindingSource cartBindingSource = new BindingSource();  //Binding source nesnesi tanımlıyorum Cart listim için


        public Satış()
        {
            InitializeComponent();
            instance = this;

            listboxsepet = lst_sepet;
              

        }

        private void label25_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit(); //uygulamayı kapat
        }


        private void label6_Click_1(object sender, EventArgs e)
        {
            Fatura obj = new Fatura();
            obj.Show();
            this.Hide();

      
        }


        private void btn_ekle_Click(object sender, EventArgs e)
        {
            Car selected = (Car)lst_katalog.SelectedItem; //object casting burada listden aldığımız itemleri car tipine dönüştürüyor

            myStore.Cart.Add(selected);  //burda ise car tipine dönüştürdüğümüz itemi mystore nesnesi aracılığıyla Cart'a ekliyoruz.
          
            cartBindingSource.ResetBindings(false);   //listbox'ı yeniliyoruz

        }
        private void button1_Click(object sender, EventArgs e)
        {
            decimal total = myStore.Checkout();
           lbl_tplm.Text = total.ToString("C");
            lblsatis = lbl_tplm;
            Car selected = (Car)lst_katalog.SelectedItem; //object casting burada listden aldığımız itemleri car tipine dönüştürüyor

            string output = JsonConvert.SerializeObject(selected);  //car tipindeki itemi json formata dönüştürdü
            string fileName = "Satılan arabalar.json";
            File.AppendAllText(fileName, output); //appendalltext ile dosyaya ekledik

            //cartBindingSource.ResetBindings(false);


        }
        private void lbl_devam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Fatura obj = new Fatura();
            obj.Show();
            this.Hide();
            
            var dateString = DateTime.Now.ToString("MM/dd/yyyy");
            txt_tc.Text = obj.tc;
            obj.address = txt_address.Text;
            obj.name = txt_name.Text;
            obj.surname = txt_surname.Text;
          
            List<string> customers = new List<string>();  // müşteri adında list oluşturup textbıoxlara girdiğimz verileri bu listte saklıyoruz. müşteribilgileri için ayrı sınıf da oluşturulabilirdi bu daha güvenli olabilirdi ama araba üstüne yoğunlaştığım için bu şekilde yaptım. 
            customers.Add(dateString); customers.Add(txt_tc.Text); customers.Add(txt_name.Text); customers.Add(txt_surname.Text); customers.Add(txt_address.Text);
            var customerJson = JsonConvert.SerializeObject(customers);
            File.AppendAllText("MusteriBilgileri.json", customerJson);

        }
        private void lbl_toplam_Click(object sender, EventArgs e)
        {

        }
   
        private void label7_Click(object sender, EventArgs e)
        {
            Araba obj = new Araba();
            obj.Show();
            this.Hide();
        }

        private void Satış_Load(object sender, EventArgs e)
        {


            for (int i = 0; i < Araba.instance.listbox.Items.Count; i++)
            {
                lst_katalog.Items.Add(Araba.instance.listbox.Items[i]);

            }
            cartBindingSource.DataSource = myStore.Cart;
            lst_sepet.HorizontalScrollbar = true;
            lst_sepet.DataSource = cartBindingSource;      //class daki datalarla birleştirelim
            lst_sepet.DisplayMember = ToString();

           
           


        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            Car selected = (Car)lst_sepet.SelectedItem;
            myStore.Cart.Remove(selected);

            cartBindingSource.ResetBindings(false);

        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            lst_sepet.HorizontalScrollbar = true;
            
        }
    }
}
