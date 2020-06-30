﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientWCF.ComService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://receptionplatform.java.com/", ConfigurationName="ComService.ComEndpoint")]
    public interface ComEndpoint {
        
        // CODEGEN : La génération du contrat de message depuis le nom d'élément fileName de l'espace de noms  n'est pas marqué nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://receptionplatform.java.com/ComEndpoint/checkFileOperationRequest", ReplyAction="http://receptionplatform.java.com/ComEndpoint/checkFileOperationResponse")]
        ClientWCF.ComService.checkFileOperationResponse checkFileOperation(ClientWCF.ComService.checkFileOperationRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://receptionplatform.java.com/ComEndpoint/checkFileOperationRequest", ReplyAction="http://receptionplatform.java.com/ComEndpoint/checkFileOperationResponse")]
        System.Threading.Tasks.Task<ClientWCF.ComService.checkFileOperationResponse> checkFileOperationAsync(ClientWCF.ComService.checkFileOperationRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class checkFileOperationRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="checkFileOperation", Namespace="http://receptionplatform.java.com/", Order=0)]
        public ClientWCF.ComService.checkFileOperationRequestBody Body;
        
        public checkFileOperationRequest() {
        }
        
        public checkFileOperationRequest(ClientWCF.ComService.checkFileOperationRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class checkFileOperationRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string fileName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string fileContent;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string cypherKey;
        
        public checkFileOperationRequestBody() {
        }
        
        public checkFileOperationRequestBody(string fileName, string fileContent, string cypherKey) {
            this.fileName = fileName;
            this.fileContent = fileContent;
            this.cypherKey = cypherKey;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class checkFileOperationResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="checkFileOperationResponse", Namespace="http://receptionplatform.java.com/", Order=0)]
        public ClientWCF.ComService.checkFileOperationResponseBody Body;
        
        public checkFileOperationResponse() {
        }
        
        public checkFileOperationResponse(ClientWCF.ComService.checkFileOperationResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class checkFileOperationResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string operationResult;
        
        public checkFileOperationResponseBody() {
        }
        
        public checkFileOperationResponseBody(string operationResult) {
            this.operationResult = operationResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ComEndpointChannel : ClientWCF.ComService.ComEndpoint, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ComEndpointClient : System.ServiceModel.ClientBase<ClientWCF.ComService.ComEndpoint>, ClientWCF.ComService.ComEndpoint {
        
        public ComEndpointClient() {
        }
        
        public ComEndpointClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ComEndpointClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ComEndpointClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ComEndpointClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ClientWCF.ComService.checkFileOperationResponse ClientWCF.ComService.ComEndpoint.checkFileOperation(ClientWCF.ComService.checkFileOperationRequest request) {
            return base.Channel.checkFileOperation(request);
        }
        
        public string checkFileOperation(string fileName, string fileContent, string cypherKey) {
            ClientWCF.ComService.checkFileOperationRequest inValue = new ClientWCF.ComService.checkFileOperationRequest();
            inValue.Body = new ClientWCF.ComService.checkFileOperationRequestBody();
            inValue.Body.fileName = fileName;
            inValue.Body.fileContent = fileContent;
            inValue.Body.cypherKey = cypherKey;
            ClientWCF.ComService.checkFileOperationResponse retVal = ((ClientWCF.ComService.ComEndpoint)(this)).checkFileOperation(inValue);
            return retVal.Body.operationResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ClientWCF.ComService.checkFileOperationResponse> ClientWCF.ComService.ComEndpoint.checkFileOperationAsync(ClientWCF.ComService.checkFileOperationRequest request) {
            return base.Channel.checkFileOperationAsync(request);
        }
        
        public System.Threading.Tasks.Task<ClientWCF.ComService.checkFileOperationResponse> checkFileOperationAsync(string fileName, string fileContent, string cypherKey) {
            ClientWCF.ComService.checkFileOperationRequest inValue = new ClientWCF.ComService.checkFileOperationRequest();
            inValue.Body = new ClientWCF.ComService.checkFileOperationRequestBody();
            inValue.Body.fileName = fileName;
            inValue.Body.fileContent = fileContent;
            inValue.Body.cypherKey = cypherKey;
            return ((ClientWCF.ComService.ComEndpoint)(this)).checkFileOperationAsync(inValue);
        }
    }
}
