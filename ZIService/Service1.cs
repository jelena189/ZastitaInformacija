using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace ZIService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        long maxPodataka = 51200;
        int chunkSize=2;
        long trenutnoPodataka = 0;
        private string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Fajlovi");

        public Service1()
        {
            Directory.CreateDirectory(folderPath);
            this.trenutnoPodataka = GetDirectorySize(folderPath);
        }

        private static long GetDirectorySize(string folderPath)
        {
            DirectoryInfo di = new DirectoryInfo(folderPath);
            return di.EnumerateFiles("*.*", SearchOption.AllDirectories).Sum(fi => fi.Length);
        }

        public FileDetails DownloadFile(DownloadFile details)
        {
            var filePath = Path.Combine(folderPath, details.FileName);

            if (!File.Exists(filePath)) return null;

            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            return new FileDetails
            {
                FileName = details.FileName,
                FileStreamReader = stream
            };
        }

        public string[] GetUploadedFilesNames()
        {
            return Directory.GetFiles(folderPath).OrderBy(d => new FileInfo(d).CreationTime).ToArray(); 
        }

        public UploadReply UploadFile(FileDetails details)
        {
            string filePath = "";
            //if (details.FileStreamReader.Length + trenutnoPodataka < maxPodataka)
            //{
                //trenutnoPodataka += details.FileStreamReader.Length;
                filePath = Path.Combine(folderPath, details.FileName);
                int numberOfSameFile = 0;
                
                while (File.Exists(filePath))
                {
                    numberOfSameFile++;
                    string[] fileNameSplited = details.FileName.Split('.');
                    filePath = Path.Combine(folderPath, fileNameSplited[0] + "[" + numberOfSameFile + "]." + fileNameSplited[1]);
                }

                using (FileStream wr = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write))
                {
                    
                    do
                    {
                        
                        byte[] buffer = new byte[1024 * chunkSize];

                        int bytesRead = details.FileStreamReader.Read(buffer, 0, 1024 * chunkSize);

                        //If there is no more blocks brake while loop
                        if (bytesRead == 0)
                            break;

                        //When last block is uploaded
                        if (bytesRead < 1024 * chunkSize)
                        {
                            var temp = new byte[bytesRead];
                            Array.Copy(buffer, temp, bytesRead);
                            buffer = temp;
                        }

                    if (trenutnoPodataka <= maxPodataka)
                    {
                        wr.Write(buffer, 0, buffer.Length);
                        trenutnoPodataka += buffer.Length;
                    }
                    else
                        return new UploadReply() { UploadSuccess = false };

                    } while (true);

                }
            //}
            if (File.Exists(filePath))
                return new UploadReply() { UploadSuccess = true };
            else
                return new UploadReply() { UploadSuccess = false };
        }
    }
}
