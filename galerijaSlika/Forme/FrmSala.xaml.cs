using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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

namespace galerijaSlika.Forme
{
    /// <summary>
    /// Interaction logic for FrmSala.xaml
    /// </summary>
    public partial class FrmSala : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmSala()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmSala(bool azuriraj, DataRowView pomocniRed)
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
                string vratiIzlozbu = @"select izlozbaID as izlozba from tblIzlozba";
                DataTable dtIzlozba = new DataTable();
                SqlDataAdapter daIzlozba = new SqlDataAdapter(vratiIzlozbu, konekcija);
                daIzlozba.Fill(dtIzlozba);
                cbIzlozba.ItemsSource = dtIzlozba.DefaultView;
                dtIzlozba.Dispose();
                daIzlozba.Dispose();

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
                cmd.Parameters.Add("@brojSale", SqlDbType.NVarChar, 20).Value = txtBrojSale.Text;
                cmd.Parameters.Add("@izlozbaID", SqlDbType.Int).Value = (cbIzlozba.SelectedValue != null) ? cbIzlozba.SelectedValue : DBNull.Value;

                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"UPDATE dbo.tblSala SET brojSale=@brojSale, izlozbaID=@izlozbaID
                                        WHERE salaID=@id";
                    this.pomocniRed = null;

                   // DataGrid.Refresh();
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO dbo.tblSala(brojSale, izlozbaID) VALUES (@brojSale, @izlozbaID)";
                }

                cmd.ExecuteNonQuery();
                MessageBox.Show("Podaci uspešno sačuvani!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbIzlozba_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
