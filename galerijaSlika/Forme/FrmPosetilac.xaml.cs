using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace galerijaSlika.Forme
{
    /// <summary>
    /// Interaction logic for FrmPosetilac.xaml
    /// </summary>
    public partial class FrmPosetilac : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmPosetilac()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
        }

        public FrmPosetilac(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtPosetilacIme.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
        }


        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = konekcija;

                cmd.Parameters.Add("@imePosetioca", SqlDbType.NVarChar).Value = txtPosetilacIme.Text;
                cmd.Parameters.Add("@kupac", SqlDbType.Bit).Value = cbxKupac.IsChecked ?? false;

                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"UPDATE tblPosetilac SET imePosetioca = @imePosetioca, kupac = @kupac WHERE posetilacID = @id;";
                }
                else
                {
                    cmd.CommandText = @"INSERT INTO tblPosetilac(imePosetioca, kupac) VALUES (@imePosetioca, @kupac);";
                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos nije validan", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void txtPosetilacIme_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox.Text == "Ime posetioca")
                txtBox.Text = string.Empty;

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
