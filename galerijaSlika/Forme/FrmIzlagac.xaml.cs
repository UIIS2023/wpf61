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
using System.Data.SqlClient;
using System.Globalization;

namespace galerijaSlika.Forme
{
    /// <summary>
    /// Interaction logic for FrmIzlagac.xaml
    /// </summary>
    public partial class FrmIzlagac : Window
    {

        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmIzlagac()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmIzlagac(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtIzlagacIme.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            PopuniPadajuceListe();
        }

        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();
                string vratiKorisnika = @"select korisnikID, imeKor +' '+prezimeKor as korisnik from tblKorisnik";
                DataTable dtKorisnik = new DataTable();
                SqlDataAdapter daKorisnik = new SqlDataAdapter(vratiKorisnika, konekcija);
                daKorisnik.Fill(dtKorisnik);
                cbKorisnik.ItemsSource = dtKorisnik.DefaultView;
                dtKorisnik.Dispose();
                daKorisnik.Dispose();

            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuce liste nisu popunjene!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }


        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = konekcija;
                cmd.Parameters.Add("@ime", SqlDbType.NVarChar).Value = txtIzlagacIme.Text;
                cmd.Parameters.Add("@prezime", SqlDbType.NVarChar).Value = txtIzlagacPrezime.Text;
                cmd.Parameters.Add("@jmbg", SqlDbType.NVarChar).Value = txtJMBG.Text;
                cmd.Parameters.Add("@adresa", SqlDbType.NVarChar).Value = txtAdresa.Text;
                cmd.Parameters.Add("@grad", SqlDbType.NVarChar).Value = txtGrad.Text;
                cmd.Parameters.Add("@kontakt", SqlDbType.NVarChar).Value = txtKontakt.Text;
                cmd.Parameters.Add("@korisnikID", SqlDbType.Int).Value = cbKorisnik.SelectedValue;

                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update tblIzlagac set ime=@ime, prezime=@prezime, jmbg=@jmbg, adresa=@adresa, grad=@grad, kontakt=@kontakt, korisnikID=@korisnikID
                                        Where izlagacID=@id";
                }
                else
                {
                    cmd.CommandText = @"insert into tblIzlagac(ime, prezime, jmbg, adresa, grad, kontakt, korisnikID) 
                                        values (@ime, @prezime, @jmbg, @adresa, @grad, @kontakt, @korisnikID)";
                }

                cmd.ExecuteNonQuery();
                MessageBox.Show("Unos uspešan.", "Informacija", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Greška prilikom unosa: " + ex.Message, "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                {
                    konekcija.Close();
                }
            }
        }

        private void txtIzlagacIme_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox.Text == "Ime izlagaca")
                txtBox.Text = string.Empty;
        }

        private void txtAutorPrezime_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox; 
            if (txtBox.Text == "Prezime izlagaca ")
                txtBox.Text = string.Empty;
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox? txtBox = sender as TextBox;
            if (txtBox.Text == "JMBG")
                txtBox.Text = string.Empty;
        }

        private void txtJMBG_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox.Text == "JMBG")
                txtBox.Text = string.Empty;
        }

        private void txtAdresa_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox.Text == "Adresa")
                txtBox.Text = string.Empty;
        }

        private void txtGrad_TextChanged(object sender, TextChangedEventArgs e)
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
