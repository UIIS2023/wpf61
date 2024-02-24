using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace galerijaSlika.Forme
{
    /// <summary>
    /// Interaction logic for FrmKorisnik.xaml
    /// </summary>
    public partial class FrmKorisnik : Window
    {

        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmKorisnik()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
        }

        public FrmKorisnik(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtKorisnikIme.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
        }


        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@imeKor", SqlDbType.NVarChar).Value = txtKorisnikIme.Text;
                cmd.Parameters.Add("@prezimeKor", SqlDbType.NVarChar).Value = txtKorisnikPrezime.Text;
                cmd.Parameters.Add("@jmbgKor", SqlDbType.NVarChar).Value = txtJMBGKor.Text;
                cmd.Parameters.Add("@adresaKor", SqlDbType.NVarChar).Value = txtAdresaKor.Text;
                cmd.Parameters.Add("@gradKor", SqlDbType.NVarChar).Value = txtGradKor.Text;
                cmd.Parameters.Add("@kontaktKor", SqlDbType.NVarChar).Value = txtKontaktKor.Text;
          
                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update tblKorisnik set imeKor=@imeKor, prezimeKor=@prezimeKor, jmbgKor=@jmbgKor, adresaKor=@adresaKor, gradKorKor=@gradKor, kontaktKor=@kontakKor,
                                                                    Where korisnikID=@id";
                    this.pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblKorisnik(imeKor, prezimeKor, jmbgKor, adresaKor, gradKor, kontaktKor) values (@imeKor, @prezimeKor, @jmbgKor, @adresaKor, @gradKor, @kontaktKor)";
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos nije validan", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void txtKorisnikIme_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox.Text == "Ime korisnika")
                txtBox.Text = string.Empty;

        }

        private void txtKorisnikPrezime_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox.Text == "Prezime korisnika")
                txtBox.Text = string.Empty;

        }

        private void txtJMBG_PreviewTextInput(object sender, TextCompositionEventArgs e)   // automacki se poziva kada korisnik unese tekst   // REGEX proverava da li je cifra od 0-9  ako nije e.handled se postavlja na true --> sprecava unos karaktera u textbox
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void txtJMBGKor_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox.Text == "JMBG")
            txtBox.Text = string.Empty;
        }

        private void txtAdresaKor_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox.Text == "Adresa")
                txtBox.Text = string.Empty;

        }

        private void txtGradKor_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox.Text == "Grad")
                txtBox.Text = string.Empty;

        }

        private void txtKontakt_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox.Text == "Kontakt")
                txtBox.Text = string.Empty;

        }
    }
}
