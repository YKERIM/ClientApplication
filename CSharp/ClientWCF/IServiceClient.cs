using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ClientWCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IServiceClient" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServiceClient
    {
        [OperationContract]
        string Message();
    }
}
