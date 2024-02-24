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
    /// Interaction logic for FrmProdaja.xaml
    /// </summary>
    public partial class FrmProdaja : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmProdaja()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmProdaja(bool azuriraj, DataRowView pomocniRed)
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
                string vratiKorisnika = @"select korisnikID, imeKor+' '+prezimeKor as korisnik from tblKorisnik";
                DataTable dtKorisnik = new DataTable()
                {
                    Locale = CultureInfo.InvariantCulture
                };
                SqlDataAdapter daKorisnik = new SqlDataAdapter(vratiKorisnika, konekcija);
                daKorisnik.Fill(dtKorisnik);
                cbKorisnik.ItemsSource = dtKorisnik.DefaultView;
                dtKorisnik.Dispose();
                daKorisnik.Dispose();


                konekcija.Open();
                string vratiPosetioca = @"select posetilacID, imePosetioca as posetilac from tblPosetilac";
                DataTable dtPosetilac = new DataTable();
                SqlDataAdapter daPosetilac = new SqlDataAdapter(vratiPosetioca, konekcija);
                daPosetilac.Fill(dtPosetilac);
                cbPosetilac.ItemsSource = dtPosetilac.DefaultView;
                dtPosetilac.Dispose();
                daPosetilac.Dispose();

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
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };

      
                cmd.Parameters.Add("@posetilacID", SqlDbType.Int).Value = cbPosetilac.SelectedValue;
                cmd.Parameters.Add("@korisnikID", SqlDbType.Int).Value = cbKorisnik.SelectedValue;
                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"Update tblProdajaSlike
                     Set posetilacID=@posetilacID, korisnikID=@korisnikID
                     where prodajaSlikeID=@ID";
                }
                else
                {
                    cmd.CommandText = @"insert into tblProdajaSlike(posetilacID, korisnikID) values (@posetilacID, @korisnikID);";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Unos nije validan. Detalji greške: " + ex.Message, "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
