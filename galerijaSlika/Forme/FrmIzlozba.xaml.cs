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
    /// Interaction logic for FrmIzlozba.xaml
    /// </summary>
    public partial class FrmIzlozba : Window
    {

        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmIzlozba()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmIzlozba(bool azuriraj, DataRowView pomocniRed)
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
                string vratiIzlagaca = @"select izlagacID, ime+' '+prezime as izlagac from tblIzlagac";
                DataTable dtIzlagac = new DataTable()
                {
                    Locale = CultureInfo.InvariantCulture
                };
                SqlDataAdapter daIzlagac = new SqlDataAdapter(vratiIzlagaca, konekcija);
                daIzlagac.Fill(dtIzlagac);
                cbIzlagac.ItemsSource = dtIzlagac.DefaultView;
                dtIzlagac.Dispose();
                daIzlagac.Dispose();

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
                DateTime dateZatvaranja = dpDatumZatvaranja.SelectedDate ?? DateTime.MinValue;
                DateTime dateOtvaranja = dpDatumOtvaranja.SelectedDate ?? DateTime.MinValue;

                string datumZatvaranja = dateZatvaranja.ToString("yyyy-MM-dd");
                string datumOtvaranja = dateOtvaranja.ToString("yyyy-MM-dd");

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = konekcija;
                cmd.Parameters.Add("@datumZatvaranja", SqlDbType.DateTime).Value = datumZatvaranja;
                cmd.Parameters.Add("@datumOtvaranja", SqlDbType.DateTime).Value = datumOtvaranja;
                cmd.Parameters.Add("@izlagacID", SqlDbType.Int).Value = cbIzlagac.SelectedValue;

                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["izlozbaID"];
                    cmd.CommandText = @"UPDATE tblIzlozba SET datumZatvaranja=@datumZatvaranja, datumOtvaranja=@datumOtvaranja, izlagacID=@izlagacID
                                        WHERE izlozbaID=@id";
                    this.pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO tblIzlozba (datumZatvaranja, datumOtvaranja, izlagacID) VALUES (@datumZatvaranja, @datumOtvaranja, @izlagacID)";
                }

                cmd.ExecuteNonQuery();
                MessageBox.Show("Podaci uspešno sačuvani!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close(); // Zatvaramo prozor nakon uspešnog čuvanja podataka
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Unos nije validan. Greška: " + ex.Message, "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
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
