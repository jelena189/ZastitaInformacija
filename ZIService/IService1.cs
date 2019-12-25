using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ZIService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        UploadReply UploadFile(FileDetails details);

        [OperationContract]
        string[] GetUploadedFilesNames();

        [OperationContract]
        FileDetails DownloadFile(DownloadFile details);


        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "ZIService.ContractType".
    [MessageContract]
    public class UploadReply
    {
        [MessageBodyMember] public bool UploadSuccess;
    }

    [MessageContract]
    public class FileDetails : IDisposable
    {

        [MessageHeader(MustUnderstand = true)] public byte[] hashValue;

        [MessageHeader(MustUnderstand = true)] public string FileName;

        [MessageBodyMember(Order = 1)] public System.IO.Stream FileStreamReader;

        public void Dispose()
        {
            //To be sure that stream is closed on server side
            if (FileStreamReader == null) return;
            FileStreamReader.Close();
            FileStreamReader = null;
        }
    }

    [MessageContract]
    public class DownloadFile
    {
        [MessageBodyMember] public string FileName;
    }

    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
