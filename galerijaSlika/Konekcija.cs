using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace galerijaSlika
{
    class Konekcija
    {
        public SqlConnection KreirajKonekciju()
        {

            SqlConnectionStringBuilder ccnSb = new SqlConnectionStringBuilder
            {
                DataSource = @"DESKTOP-BKAJ8Q7\SQLEXPRESS04", //naziv servera na kom je baza podataka smestena
                InitialCatalog = "GalerijaSlika3",    // naziv baze
                IntegratedSecurity = true   // true ukoliko se baza nalazi na lokalnoj masini
            };
            string con = ccnSb.ToString();
            SqlConnection konekcija = new SqlConnection(con);
            return konekcija;


           
        }
    }
}
