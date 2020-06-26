using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.UI.WebControls.WebParts;

namespace ClientWCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServiceClient" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ServiceClient.svc ou ServiceClient.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceClient : IServiceClient
    {
        public SqlConnection con = new SqlConnection(@"Data Source=JIREN-SAMA;Initial Catalog=ClientApplication;Integrated Security=True");

        public string TokenApp(string TokenApp)
        {
            Guid Guid_TokenUser;
            string TokenUser = null;
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From UserList where TokenApp ='" + TokenApp + "' and State ='" + 1 + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {

                Guid_TokenUser = Guid.NewGuid();
                TokenUser = Guid_TokenUser.ToString();
                SqlDataAdapter sdb = new SqlDataAdapter("Update UserList set TokenUser = '" + Guid_TokenUser + "' where TokenApp ='" + TokenApp +  "'", con);
                sdb.Fill(dt);
            }
            else
            {
                
            }

            return TokenUser;
        }
    }
}