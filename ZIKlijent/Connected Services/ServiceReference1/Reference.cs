﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZIKlijent.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        // CODEGEN: Generating message contract since the wrapper name (FileDetails) of message FileDetails does not match the default value (UploadFile)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UploadFile", ReplyAction="http://tempuri.org/IService1/UploadFileResponse")]
        ZIKlijent.ServiceReference1.UploadReply UploadFile(ZIKlijent.ServiceReference1.FileDetails request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UploadFile", ReplyAction="http://tempuri.org/IService1/UploadFileResponse")]
        System.Threading.Tasks.Task<ZIKlijent.ServiceReference1.UploadReply> UploadFileAsync(ZIKlijent.ServiceReference1.FileDetails request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUploadedFilesNames", ReplyAction="http://tempuri.org/IService1/GetUploadedFilesNamesResponse")]
        string[] GetUploadedFilesNames();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUploadedFilesNames", ReplyAction="http://tempuri.org/IService1/GetUploadedFilesNamesResponse")]
        System.Threading.Tasks.Task<string[]> GetUploadedFilesNamesAsync();
        
        // CODEGEN: Generating message contract since the wrapper name (FileDetails) of message FileDetails does not match the default value (DownloadFile)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DownloadFile", ReplyAction="http://tempuri.org/IService1/DownloadFileResponse")]
        ZIKlijent.ServiceReference1.FileDetails DownloadFile(ZIKlijent.ServiceReference1.DownloadFile request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DownloadFile", ReplyAction="http://tempuri.org/IService1/DownloadFileResponse")]
        System.Threading.Tasks.Task<ZIKlijent.ServiceReference1.FileDetails> DownloadFileAsync(ZIKlijent.ServiceReference1.DownloadFile request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="FileDetails", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class FileDetails {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public string FileName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream FileStreamReader;
        
        public FileDetails() {
        }
        
        public FileDetails(string FileName, System.IO.Stream FileStreamReader) {
            this.FileName = FileName;
            this.FileStreamReader = FileStreamReader;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadReply", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class UploadReply {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public bool UploadSuccess;
        
        public UploadReply() {
        }
        
        public UploadReply(bool UploadSuccess) {
            this.UploadSuccess = UploadSuccess;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DownloadFile", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class DownloadFile {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string FileName;
        
        public DownloadFile() {
        }
        
        public DownloadFile(string FileName) {
            this.FileName = FileName;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : ZIKlijent.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<ZIKlijent.ServiceReference1.IService1>, ZIKlijent.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ZIKlijent.ServiceReference1.UploadReply ZIKlijent.ServiceReference1.IService1.UploadFile(ZIKlijent.ServiceReference1.FileDetails request) {
            return base.Channel.UploadFile(request);
        }
        
        public bool UploadFile(string FileName, System.IO.Stream FileStreamReader) {
            ZIKlijent.ServiceReference1.FileDetails inValue = new ZIKlijent.ServiceReference1.FileDetails();
            inValue.FileName = FileName;
            inValue.FileStreamReader = FileStreamReader;
            ZIKlijent.ServiceReference1.UploadReply retVal = ((ZIKlijent.ServiceReference1.IService1)(this)).UploadFile(inValue);
            return retVal.UploadSuccess;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ZIKlijent.ServiceReference1.UploadReply> ZIKlijent.ServiceReference1.IService1.UploadFileAsync(ZIKlijent.ServiceReference1.FileDetails request) {
            return base.Channel.UploadFileAsync(request);
        }
        
        public System.Threading.Tasks.Task<ZIKlijent.ServiceReference1.UploadReply> UploadFileAsync(string FileName, System.IO.Stream FileStreamReader) {
            ZIKlijent.ServiceReference1.FileDetails inValue = new ZIKlijent.ServiceReference1.FileDetails();
            inValue.FileName = FileName;
            inValue.FileStreamReader = FileStreamReader;
            return ((ZIKlijent.ServiceReference1.IService1)(this)).UploadFileAsync(inValue);
        }
        
        public string[] GetUploadedFilesNames() {
            return base.Channel.GetUploadedFilesNames();
        }
        
        public System.Threading.Tasks.Task<string[]> GetUploadedFilesNamesAsync() {
            return base.Channel.GetUploadedFilesNamesAsync();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ZIKlijent.ServiceReference1.FileDetails ZIKlijent.ServiceReference1.IService1.DownloadFile(ZIKlijent.ServiceReference1.DownloadFile request) {
            return base.Channel.DownloadFile(request);
        }
        
        public System.IO.Stream DownloadFile(ref string FileName) {
            ZIKlijent.ServiceReference1.DownloadFile inValue = new ZIKlijent.ServiceReference1.DownloadFile();
            inValue.FileName = FileName;
            ZIKlijent.ServiceReference1.FileDetails retVal = ((ZIKlijent.ServiceReference1.IService1)(this)).DownloadFile(inValue);
            FileName = retVal.FileName;
            return retVal.FileStreamReader;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ZIKlijent.ServiceReference1.FileDetails> ZIKlijent.ServiceReference1.IService1.DownloadFileAsync(ZIKlijent.ServiceReference1.DownloadFile request) {
            return base.Channel.DownloadFileAsync(request);
        }
        
        public System.Threading.Tasks.Task<ZIKlijent.ServiceReference1.FileDetails> DownloadFileAsync(string FileName) {
            ZIKlijent.ServiceReference1.DownloadFile inValue = new ZIKlijent.ServiceReference1.DownloadFile();
            inValue.FileName = FileName;
            return ((ZIKlijent.ServiceReference1.IService1)(this)).DownloadFileAsync(inValue);
        }
    }
}
