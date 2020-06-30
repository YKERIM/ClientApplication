using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Web.UI.WebControls.WebParts;

namespace ClientWCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServiceClient" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ServiceClient.svc ou ServiceClient.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceClient : IServiceClient
    {
        public SqlConnection con = new SqlConnection(@"Data Source=lenovo-odeb;Initial Catalog=ClientApplication;Integrated Security=True");
        public int compteur = 0;

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

        public string Decrypt(string text, string key)
        {
            var result = new StringBuilder();
            

            for (int c = 0; c < text.Length; c++)
                result.Append((char)((uint)text[c] ^ (uint)key[c % key.Length]));

            if (key == "ZZZZ")
            {
                compteur = compteur + 1;
                //System.Diagnostics.Debug.WriteLine(result.ToString());
                //System.Diagnostics.Debug.WriteLine("Thread " + compteur + " finished at : " + DateTime.Now);
            }

            return result.ToString();
        }

        public void DecryptLauncher(List<string> file_user, List<string> file_name)
        {
            
                string[] stringArray = new string[2];

                for (int i = 0; i < file_user.Count; i++)
                {
                    stringArray[0] = file_user[i];
                    stringArray[1] = file_name[i];

                    Thread t = new Thread(KeyDecryptor);
                    t.Start(stringArray);
                    Thread.Sleep(100);
                }
        }
        
        public void KeyDecryptor(Object args)
        {
            Array argArray = new object[2];
            argArray = (Array)args;
            string text = (string)argArray.GetValue(0);
            string name = (string)argArray.GetValue(1);

            int first = 0;
            int second = 0;
            int third = 0;
            int fourth = 0;
            string attempt = "";
            string[] array = {
            "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
            };
            System.Diagnostics.Debug.WriteLine("Thread 1 : begin at : " + DateTime.Now);

            while (attempt != "ZZZZ")
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
                Decrypt(text, attempt);
                first++;
            }
            System.Diagnostics.Debug.WriteLine("Name : " + name);
        }

        private void sendToJava(string fileName, string fileContent, string key)
        {
            using (var service = new ComService.ComEndpointClient("ComPort"))
            {
                var result = service.checkFileOperation(fileName, fileContent, key);
            }
        }
    }
}