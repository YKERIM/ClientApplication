using System;
using System.Collections.Generic;
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
        public string TokenApp()
        {
            return "Voici le Token App";
        }

        public string Squaring(string x)
        {
            return "ok";
        }
    }
}