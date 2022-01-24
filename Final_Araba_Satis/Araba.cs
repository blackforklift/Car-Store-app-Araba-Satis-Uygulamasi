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
    public partial class Araba : Form
    {
        public static Araba instance; //bu formdan bilgi çekeceğim o yüzden instance tanımlıyorum

        Store myStore = new Store();
        public static BindingSource carCatalogueBindingSource = new BindingSource();  //Binding source nesnesi tanımlıyorum katalog listim için  (bunları yapıyorum çünküsatış formundaki lst_katalog ile store sınıfındaki carcatalogue listim birbirine bağlı olmalı aynı şekilde lst_sepet ile cart da.


        public ListBox listbox; //lst_katalogu çağırıcam Satış kısmında lazım olacak bu yüzden public bir listboxa ihtiyacım var.



        public Araba ()
        {
            InitializeComponent();
            instance = this; //instance bu forma ait.
            listbox = lst_katalog;
        }

        private void btn_ekle_Click(object sender, EventArgs e)//araba katalogumuza araba eklemeliyiz bunun için Car sınıfımızdan car nesnemizi çağırıp içine girilen verileri yollayacağız.
        {
            try   //beklenilenden farklı tür veri girildiğinde program çökmesin diye try-catch kullanacağız.
            {
                Car c = new Car(int.Parse(txt_id.Text), txt_marka.Text, txt_model.Text, txt_renk.Text, int.Parse(txt_yıl.Text), decimal.Parse(txt_fiyat.Text));

                myStore.CarCatalogue.Add(c);
                string output = JsonConvert.SerializeObject(c);
                string fileName = "araba katalog.json";
                File.AppendAllText(fileName, output + Environment.NewLine);


                carCatalogueBindingSource.ResetBindings(false);
                txt_id.Text = "";
                txt_marka.Text = "";
                txt_model.Text = "";
                txt_renk.Text = "";
                (txt_yıl.Text) = "";
                (txt_fiyat.Text) = "";
             
             
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen geçerli veri girin");
                return;
            }



        }


        private void Araba_Load(object sender, EventArgs e)
        {
            carCatalogueBindingSource.DataSource = myStore.CarCatalogue;  //carcataloguebindingsource u datasource propertysi ile mystore daki carcatalogue a bağlıyoruz.



            lst_katalog.DataSource = carCatalogueBindingSource;  //lst_katalogun veri kaynağını da carcataloguebindingsource nesnesi yapıyoruz.
            lst_katalog.DisplayMember = ToString(); //lst_ katalgun elemanlarını stringe dönüştürüp gösteriyor



        }

        private void label5_Click(object sender, EventArgs e)
        {
            Satış obj = new Satış();
            obj.Show();
            this.Hide();
        }

        private void btn_sil_Click(object sender, EventArgs e) // araba silme işlemi. seçilen itemi car olarak seç(object casting) store daki carcataloguedan bu itemi sil. 
        {
            Car selected = (Car)lst_katalog.SelectedItem;
            myStore.CarCatalogue.Remove(selected);

            carCatalogueBindingSource.ResetBindings(false);



        }

        private void label6_Click(object sender, EventArgs e)
        {

            Fatura obj = new Fatura();
            obj.Show();
            this.Hide();
        }

        private void label25_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit(); //çık
        }
    }
}
