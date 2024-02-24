using galerijaSlika.Forme;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace galerijaSlika
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>    
    public partial class MainWindow : Window
    {
        #region Select upit
        string izlagacSelect = @"Select izlagacID as ID, ime +' '+ prezime as 'izlagac', jmbg, adresa, grad, kontakt 
        from tblIzlagac
        inner join tblKorisnik on tblIzlagac.korisnikID=tblKorisnik.korisnikID;";
        string deloSelect = @"Select deloID as ID, nazivDela as 'naziv dela', godinaStvaranja as 'godina stvaranja', opis, cena 
        from tblDelo
        inner join tblIzlagac on tblDelo.izlagacID=tblIzlagac.izlagacID
        inner join tblSala on tblDelo.salaID=tblSala.salaID;";
        string izlozbaSelect = @"Select izlozbaID as ID, datumZatvaranja as 'datum zatvaranja', datumOtvaranja as 'datum otvaranja'
        from tblIzlozba
        inner join tblIzlagac on tblIzlozba.izlagacID=tblIzlagac.izlagacID;";
        string korisnikSelect = @"Select korisnikID as ID, imeKor +' '+ prezimeKor as 'korisnik', jmbgKor as 'jmbg korisnika', adresaKor as 'adresa korisnika', gradKor as 'grad korisnika', kontaktKor as 'kontakt korisnika' from tblKorisnik";
        string posetilacSelect = @"Select posetilacID as ID, imePosetioca as 'ime posetioca', kupac from tblPosetilac";
        string prodajaSelect = @"Select prodajaSlikeID as ID 
        from tblProdajaSlike        
        inner join tblPosetilac on tblProdajaSlike.posetilacID=tblPosetilac.posetilacID
        inner join tblKorisnik on tblProdajaSlike.korisnikID=tblKorisnik.korisnikID;";
        string salaSelect = @"Select salaID as ID, brojSale as 'broj sale'
        from tblSala
        inner join tblIzlozba on tblSala.izlozbaID=tblIzlozba.izlozbaID;";
        string ulaznicaSelect = @"Select ulaznicaID as ID, cenaUlaznice as 'cena ulaznice' 
        from tblUlaznica
        inner join tblIzlozba on tblUlaznica.izlozbaID=tblIzlozba.izlozbaID
        inner join tblKorisnik on tblUlaznica.korisnikID=tblKorisnik.korisnikID
        inner join tblPosetilac on tblUlaznica.posetilacID=tblPosetilac.posetilacID;";
        #endregion

        #region Select upiti sa uslovima
        string selectUslovIzlagac = @"Select * from tblIzlagac Where izlagacID=";
        string selectUslovDelo = @"Select * from tblDelo Where deloID=";
        string selectUslovIzlozba = @"Select * from tblIzlozba Where izlozbaID=";
        string selectUslovKorisnik = @"Select * from tblKorisnik Where korisnikID=";
        string selectUslovPosetilac = @"Select * from tblPosetilac Where posetilacID=";
        string selectUslovProdaja = @"Select * from tblProdaja Where prodajaID=";
        string selectUslovSala = @"Select * from tblSala Where salaID=";
        string selectUslovUlaznica = @"Select * from tblUlaznica Where ulaznicaID=";
        #endregion

        #region Delete upiti
        string izlagacDelete = @"Delete * from tblIzlagac Where izlagacID=";
        string deloDelete = @"Delete * from tblDelo Where deloID=";
        string izlozbaDelete = @"Delete * from tblIzlozba Where izlozbaID=";
        string korisnikDelete = @"Delete * from tblKorisnik Where korisnikID=";
        string posetilacDelete = @"Delete * from tblPosetilac Where posetilacID=";
        string prodajaDelete = @"Delete * from tblProdaja Where prodajaID=";
        string salaDelete = @"Delete * from tblSala Where salaID=";
        string ulaznicaDelete = @"Delete * from tblUlaznica Where ulaznicaID=";
        #endregion

        string ucitanaTabela;
        bool azuriraj;
        DataRowView pomocniRed;

        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();  
        public MainWindow()
        {
            InitializeComponent();
            UcitajPodatke(dataGridCentralni, izlagacSelect);  
            konekcija = kon.KreirajKonekciju();
        }

        // READ
        public void UcitajPodatke(DataGrid grid, string selectUpit)
        {
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dt = new DataTable()
                {
                    Locale = CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(dt); //prebacuje podatke u tabelu
                if (grid != null)
                {
                    grid.ItemsSource = dt.DefaultView;//po redovima i kolonama jer je tabela
                }
                ucitanaTabela = selectUpit;
                dt.Dispose();
                dataAdapter.Dispose();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Podaci ne mgou da se ucitaju!" + ex.Message, "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        
        }

        private void btnDelo_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, deloSelect);
        }

        private void btnIzlagac_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, izlagacSelect);
        }

        private void btnPosetilac_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, posetilacSelect);
        }

        private void btnIzlozba_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, izlozbaSelect);
        }

        private void btnUlaznica_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, ulaznicaSelect);
        }

        private void btnSala_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, salaSelect);
        }

        private void btnProdaja_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, prodajaSelect);
        }
        private void btnKorisnik_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dataGridCentralni, korisnikSelect);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }


        // CREATE
        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window prozor;
            if (ucitanaTabela.Equals(izlagacSelect))
            {
                prozor = new FrmIzlagac();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, izlagacSelect);
            }
            else if (ucitanaTabela.Equals(deloSelect))
            {
                prozor = new FrmDelo();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, deloSelect);
            }
            else if (ucitanaTabela.Equals(izlozbaSelect))
            {
                prozor = new FrmIzlozba();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, izlozbaSelect);
            }
            else if (ucitanaTabela.Equals(korisnikSelect))
            {
                prozor = new FrmKorisnik();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, korisnikSelect);
            }
            else if (ucitanaTabela.Equals(posetilacSelect))
            {
                prozor = new FrmPosetilac();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, posetilacSelect);
            }
            else if (ucitanaTabela.Equals(prodajaSelect))
            {
                prozor = new FrmProdaja();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, prodajaSelect);
            }
            else if (ucitanaTabela.Equals(salaSelect))
            {
                prozor = new FrmSala();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, salaSelect);
            }
            else if (ucitanaTabela.Equals(ulaznicaSelect))
            {
                prozor = new FrmUlaznica();
                prozor.ShowDialog();
                UcitajPodatke(dataGridCentralni, ulaznicaSelect);
            }
        }
        //UPDATE
        private void PopuniFormu(DataGrid grid, string selectUslov)
        {
            try
            {
                konekcija.Open();
                azuriraj = true;
                DataRowView red = (DataRowView)grid.SelectedItems[0];
                pomocniRed = red;
                SqlCommand komanda = new SqlCommand()
                {
                    Connection = konekcija
                };
                komanda.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                komanda.CommandText = selectUslov + "@id";
                SqlDataReader citac = komanda.ExecuteReader();
                komanda.Dispose();
                while (citac.Read())
                {
                    if (ucitanaTabela.Equals(izlagacSelect, StringComparison.Ordinal))
                    {
                        FrmIzlagac prozorIzlagac = new FrmIzlagac(azuriraj, pomocniRed);

                        prozorIzlagac.txtIzlagacIme.Text = citac["ime"].ToString();
                        prozorIzlagac.txtIzlagacPrezime.Text = citac["prezime"].ToString();
                        prozorIzlagac.txtJMBG.Text = citac["jmbg"].ToString();
                        prozorIzlagac.txtAdresa.Text = citac["adresa"].ToString();
                        prozorIzlagac.txtGrad.Text = citac["grad"].ToString();
                        prozorIzlagac.txtKontakt.Text = citac["kontakt"].ToString();
                        prozorIzlagac.cbKorisnik.SelectedValue = citac["korisnikID"].ToString();
                    
                        prozorIzlagac.ShowDialog();

                    }
                    else if (ucitanaTabela.Equals(deloSelect, StringComparison.Ordinal))
                    {
                        FrmDelo prozorDelo = new FrmDelo(azuriraj, pomocniRed);
                        prozorDelo.txtDeloNaziv.Text = citac["nazivDela"].ToString();
                        prozorDelo.dpGodinaStvaranja.SelectedDate = (DateTime)citac["godinaStvaranja"];
                        prozorDelo.txtOpis.Text = citac["opis"].ToString();
                        prozorDelo.txtCena.Text = citac["cena"].ToString();
                        prozorDelo.cbIzlagac.SelectedValue = citac["izlagacID"].ToString();
                        prozorDelo.cbSala.SelectedValue = citac["salaID"].ToString();

                        prozorDelo.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(izlozbaSelect, StringComparison.Ordinal))
                    {
                        FrmIzlozba prozorIzlozba = new FrmIzlozba(azuriraj, pomocniRed);
                        prozorIzlozba.dpDatumZatvaranja.SelectedDate = (DateTime)citac["datumZatvaranja"];
                        prozorIzlozba.dpDatumOtvaranja.SelectedDate = (DateTime)citac["datumOtvaranja"];
                        prozorIzlozba.cbIzlagac.SelectedValue = citac["izlagacID"].ToString();
                       
                        prozorIzlozba.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(korisnikSelect, StringComparison.Ordinal))
                    {
                        FrmKorisnik prozorKorisnik = new FrmKorisnik(azuriraj, pomocniRed);
                        prozorKorisnik.txtKorisnikIme.Text = citac["imeKor"].ToString();
                        prozorKorisnik.txtKorisnikPrezime.Text = citac["prezimeKor"].ToString();
                        prozorKorisnik.txtJMBGKor.Text = citac["jmbgKor"].ToString();
                        prozorKorisnik.txtAdresaKor.Text = citac["adresaKor"].ToString();
                        prozorKorisnik.txtGradKor.Text = citac["gradKor"].ToString();
                        prozorKorisnik.txtKontaktKor.Text = citac["kontaktKor"].ToString();
                      
                        prozorKorisnik.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(posetilacSelect, StringComparison.Ordinal))
                    {
                        FrmPosetilac prozorPosetilac = new FrmPosetilac(azuriraj, pomocniRed);
                        prozorPosetilac.txtPosetilacIme.Text = citac["imePosetioca"].ToString();
                        prozorPosetilac.cbxKupac.IsChecked = (Boolean)citac["kupac"];

                        prozorPosetilac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(prodajaSelect, StringComparison.Ordinal))
                    {
                        FrmProdaja prozorProdaja = new FrmProdaja(azuriraj, pomocniRed);
                        prozorProdaja.cbPosetilac.SelectedValue = citac["posetilacID"].ToString();
                        prozorProdaja.cbKorisnik.SelectedValue = citac["korisnikID"].ToString();
                      
                        prozorProdaja.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(salaSelect, StringComparison.Ordinal))
                    {
                        FrmSala prozorSala = new FrmSala(azuriraj, pomocniRed);
                        prozorSala.txtBrojSale.Text = citac["brojSale"].ToString();
                        prozorSala.cbIzlozba.SelectedValue = citac["izlzobaID"].ToString();

                        prozorSala.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(ulaznicaSelect, StringComparison.Ordinal))
                    {
                        FrmUlaznica prozorUlaznica = new FrmUlaznica(azuriraj, pomocniRed);
                        prozorUlaznica.txtCenaUlaznice.Text = citac["cenaUlaznice"].ToString();
                        prozorUlaznica.cbIzlozba.SelectedValue = citac["izlzobaID"].ToString();
                        prozorUlaznica.cbKorisnik.SelectedValue = citac["korisnikID"].ToString();
                        prozorUlaznica.cbPosetilac.SelectedValue = citac["posetilacID"].ToString();

                        prozorUlaznica.ShowDialog();
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Greska!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                azuriraj = false;
            }
        }
        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(izlagacSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovIzlagac);
                UcitajPodatke(dataGridCentralni, izlagacSelect);
            }
            else if (ucitanaTabela.Equals(deloSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovDelo);
                UcitajPodatke(dataGridCentralni, deloSelect);
            }
            else if (ucitanaTabela.Equals(izlozbaSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovIzlozba);
                UcitajPodatke(dataGridCentralni, izlozbaSelect);
            }
            else if (ucitanaTabela.Equals(korisnikSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovKorisnik);
                UcitajPodatke(dataGridCentralni, korisnikSelect);
            }
            else if (ucitanaTabela.Equals(posetilacSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovPosetilac);
                UcitajPodatke(dataGridCentralni, posetilacSelect);
            }
            else if (ucitanaTabela.Equals(prodajaSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovProdaja);
                UcitajPodatke(dataGridCentralni, prodajaSelect);
            }
            else if (ucitanaTabela.Equals(salaSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovSala);
                UcitajPodatke(dataGridCentralni, salaSelect);
            }
            else if (ucitanaTabela.Equals(ulaznicaSelect))
            {
                PopuniFormu(dataGridCentralni, selectUslovUlaznica);
                UcitajPodatke(dataGridCentralni, ulaznicaSelect);
            }


        }
        //DELETE
        private void ObrisiZapis(DataGrid grid, string deleteUpit)
        {
            try
            {
                konekcija.Open();
                DataRowView red = (DataRowView)grid.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?",
                    "Upozorenje!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand
                    {
                        Connection = konekcija
                    };
                    komanda.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    komanda.CommandText = deleteUpit + "@id";
                    komanda.ExecuteNonQuery();
                    komanda.Dispose();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Obaveštenje!",
                    MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama!", "Obaveštenje!",
                    MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {

            if (ucitanaTabela.Equals(izlagacSelect))
            {
                ObrisiZapis(dataGridCentralni, izlagacDelete);
                UcitajPodatke(dataGridCentralni, izlagacSelect);
            }
            else if (ucitanaTabela.Equals(deloSelect))
            {
                ObrisiZapis(dataGridCentralni, deloDelete);
                UcitajPodatke(dataGridCentralni, deloSelect);
            }
            else if (ucitanaTabela.Equals(izlozbaSelect))
            {
                ObrisiZapis(dataGridCentralni, izlozbaDelete);
                UcitajPodatke(dataGridCentralni, izlozbaSelect);
            }
            else if (ucitanaTabela.Equals(korisnikSelect))
            {
                ObrisiZapis(dataGridCentralni, korisnikDelete);
                UcitajPodatke(dataGridCentralni, korisnikSelect);
            }
            else if (ucitanaTabela.Equals(posetilacSelect))
            {
                ObrisiZapis(dataGridCentralni, posetilacDelete);
                UcitajPodatke(dataGridCentralni, posetilacSelect);
            }
            else if (ucitanaTabela.Equals(prodajaSelect))
            {
                ObrisiZapis(dataGridCentralni, prodajaDelete);
                UcitajPodatke(dataGridCentralni, prodajaSelect);
            }
            else if (ucitanaTabela.Equals(salaSelect))
            {
                ObrisiZapis(dataGridCentralni, salaDelete);
                UcitajPodatke(dataGridCentralni, salaSelect);
            }
            else if (ucitanaTabela.Equals(ulaznicaSelect))
            {
                ObrisiZapis(dataGridCentralni, ulaznicaDelete);
                UcitajPodatke(dataGridCentralni, ulaznicaSelect);
            }



        }

        private void MenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            mi.IsSubmenuOpen = true;
        }

        private void MenuItem_MouseLeave(object sender, MouseEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            mi.IsSubmenuOpen = false;
        }

       
    }
}
