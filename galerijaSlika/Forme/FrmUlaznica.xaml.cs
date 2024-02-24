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
    public partial class FrmUlaznica : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmUlaznica()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmUlaznica(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            PopuniPadajuceListe();
        }

        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();
                string vratiPosetioca = @"select posetilacID, imePosetioca as posetilac from tblPosetilac";
                SqlDataAdapter daPosetilac = new SqlDataAdapter(vratiPosetioca, konekcija);
                DataTable dtPosetilac = new DataTable();
                daPosetilac.Fill(dtPosetilac);
                cbPosetilac.ItemsSource = dtPosetilac.DefaultView;

                string vratiKorisnika = @"select korisnikID, imeKor+' '+prezimeKor as korisnik from tblKorisnik";
                SqlDataAdapter daKorisnik = new SqlDataAdapter(vratiKorisnika, konekcija);
                DataTable dtKorisnik = new DataTable();
                daKorisnik.Fill(dtKorisnik);
                cbKorisnik.ItemsSource = dtKorisnik.DefaultView;

                string vratiIzlozbu = @"select izlozbaID from tblIzlozba";
                SqlDataAdapter daIzlozba = new SqlDataAdapter(vratiIzlozbu, konekcija);
                DataTable dtIzlozba = new DataTable();
                daIzlozba.Fill(dtIzlozba);
                cbIzlozba.ItemsSource = dtIzlozba.DefaultView;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Greška prilikom popunjavanja padajućih lista: " + ex.Message, "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija.State == ConnectionState.Open)
                {
                    konekcija.Close();
                }
            }
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
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = konekcija;

                // Parametri
                cmd.Parameters.Add("@cenaUlaznice", SqlDbType.Decimal).Value = decimal.Parse(txtCenaUlaznice.Text);
                cmd.Parameters.Add("@posetilacID", SqlDbType.Int).Value = cbPosetilac.SelectedValue;
                cmd.Parameters.Add("@korisnikID", SqlDbType.Int).Value = cbKorisnik.SelectedValue;
                cmd.Parameters.Add("@izlozbaID", SqlDbType.Int).Value = cbIzlozba.SelectedValue;

                // Formiranje SQL upita
                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"UPDATE tblUlaznica
                                        SET cenaUlaznice=@cenaUlaznice, posetilacID=@posetilacID, korisnikID=@korisnikID, izlozbaID=@izlozbaID
                                        WHERE ulaznicaID=@ID";
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO tblUlaznica (cenaUlaznice, posetilacID, korisnikID, izlozbaID)
                                        VALUES (@cenaUlaznice, @posetilacID, @korisnikID, @izlozbaID)";
                }

                // Izvršavanje SQL upita
                cmd.ExecuteNonQuery();

                // Obaveštenje o uspešnom čuvanju podataka
                MessageBox.Show("Podaci uspešno sačuvani!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);

                // Zatvaranje prozora nakon čuvanja podataka
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Unos nije validan. Greška: " + ex.Message, "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null && konekcija.State == ConnectionState.Open)
                {
                    konekcija.Close();
                }
            }
        }
    }
}
