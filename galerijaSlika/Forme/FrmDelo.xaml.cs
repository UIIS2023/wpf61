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
using System.Globalization;

namespace galerijaSlika.Forme
{
    /// <summary>
    /// Interaction logic for FrmDelo.xaml
    /// </summary>
    public partial class FrmDelo : Window
    {

        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;
        

        public FrmDelo()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmDelo(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtDeloNaziv.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            PopuniPadajuceListe();
        }

        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();
                string vratiIzlagaca = @"select izlagacID, ime +' '+ prezime as izlagac from tblIzlagac";
                DataTable dtIzlagac = new DataTable()
                {
                    Locale = CultureInfo.InvariantCulture
                };
                SqlDataAdapter daIzlagac = new SqlDataAdapter(vratiIzlagaca, konekcija);
                daIzlagac.Fill(dtIzlagac);
                cbIzlagac.ItemsSource = dtIzlagac.DefaultView;
                dtIzlagac.Dispose();
                daIzlagac.Dispose();

            
                string vratiSalu = @"select salaID, brojSale as sala from tblSala";
                DataTable dtSala = new DataTable();
                SqlDataAdapter daSala = new SqlDataAdapter(vratiSalu, konekcija);
                daSala.Fill(dtSala);
                cbSala.ItemsSource = dtSala.DefaultView;
                dtSala.Dispose();
                daSala.Dispose();

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
                DateTime dateGodinaStvaranja = dpGodinaStvaranja.SelectedDate ?? DateTime.MinValue;
                string godinaStvaranja = dateGodinaStvaranja.ToString("yyyy-MM-dd");

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = konekcija;
                cmd.Parameters.Add("@nazivDela", SqlDbType.NVarChar).Value = txtDeloNaziv.Text;
                cmd.Parameters.Add("@godinaStvaranja", SqlDbType.DateTime).Value = godinaStvaranja;
                cmd.Parameters.Add("@opis", SqlDbType.NVarChar).Value = txtOpis.Text;
                cmd.Parameters.Add("@cena", SqlDbType.NVarChar).Value = txtCena.Text;
                cmd.Parameters.Add("@izlagacID", SqlDbType.Int).Value = cbIzlagac.SelectedValue;
                cmd.Parameters.Add("@salaID", SqlDbType.Int).Value = cbSala.SelectedValue;

                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update tblDelo set deloNaziv=@nazivDela, godinaStvaranja=@godinaStvaranja, opis=@opis, cena=@cena, izlagacID=@izlagacID, salaID=@salaID
                                        Where deloID=@id";
                }
                else
                {
                    cmd.CommandText = @"insert into tblDelo(nazivDela, godinaStvaranja, opis, cena, izlagacID, salaID) 
                                        values (@nazivDela, @godinaStvaranja, @opis, @cena, @izlagacID, @salaID)";
                }

                cmd.ExecuteNonQuery();
                MessageBox.Show("Unos uspešan.", "Informacija", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Unos nije validan. Greška: " + ex.Message, "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
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
            TextBox? txtBox = sender as TextBox;
            if (txtBox.Text == "Ime izlagaca")
                txtBox.Text = string.Empty;
        }



        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtCena_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox? txtBox = sender as TextBox;
            if (txtBox.Text == "Cena")
                txtBox.Text = string.Empty;
        }

        private void txtDeloNaziv_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox? txtBox = sender as TextBox;
            if (txtBox.Text == "Naziv dela")
                txtBox.Text = string.Empty;
        }



    }
}
