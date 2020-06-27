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

        public string attempt = "";
        public int first = 0;
        public int second = 0;
        public int third = 0;
        public int fourth = 0;

        public string[] array = {
                    "A",
                    "B",
                    "C",
                    "D",
                    "E",
                    "F",
                    "G",
                    "H",
                    "I",
                    "J",
                    "K",
                    "L",
                    "M",
                    "N",
                    "O",
                    "P",
                    "Q",
                    "R",
                    "S",
                    "T",
                    "U",
                    "V",
                    "W",
                    "X",
                    "Y",
                    "Z",
                    };

        public string EncryptOrDecrypt(string text, string key)
        {
            var result = new StringBuilder();

            for (int c = 0; c < text.Length; c++)
                result.Append((char)((uint)text[c] ^ (uint)key[c % key.Length]));
            Console.WriteLine(result.ToString());
            return result.ToString();
        }


        public void KeyGenerator(string text)
        {
            while (!attempt.Equals("ZZZZ"))
            {
                if (first == 26)
                {
                    second++;
                    first = 0;
                }

                if (second == 26)
                {
                    third++;
                    second = 0;
                }

                if (third == 26)
                {
                    fourth++;
                    third = 0;
                }

                if (fourth == 26)
                {
                    break;
                }
                attempt = array[fourth] + array[third] + array[second] + array[first];
                EncryptOrDecrypt(text, attempt); //85405/(
                first++;
            }
        }
    }
}