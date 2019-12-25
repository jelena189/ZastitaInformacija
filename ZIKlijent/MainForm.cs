using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CryptoLibrary;
using System.IO;
using ZIKlijent.ServiceReference1;
using System.Diagnostics;
using System.Security.Cryptography;

namespace ZIKlijent
{
    public partial class MainForm : Form
    {
        private string fileForCryptPath = "";
        private string fileForCryptName = "";
        private string fileExtension = "";
        private Service1Client proxy;
        private int chunkSize;
        private string ivPodaci, keyPodaci;

        public MainForm()
        {
            proxy = new Service1Client();
            chunkSize = 2;
            ivPodaci = "Ýû(†ù#ôÓ";
            keyPodaci = "-VˆS”%¥ì±¹Ãéé€2";
            InitializeComponent();
            ShowFiles();
        }

        private void ShowFiles()
        {
            string[] filesNames = proxy.GetUploadedFilesNames();
            lv1.Clear();
            foreach (var fileName in filesNames)
            {
                string[] name = fileName.Split('\\');
                lv1.Items.Add(name.Last());
            }
        }

        private void btnKljuc_Click(object sender, EventArgs e)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] randomNumbers = new byte[16];
            rng.GetNonZeroBytes(randomNumbers);
            txtKljuc.Text = Encoding.Default.GetString(randomNumbers);
        }

        private void btnIV_Click(object sender, EventArgs e)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] randomNumbers = new byte[8];
            rng.GetNonZeroBytes(randomNumbers);
            txtIV.Text = Encoding.Default.GetString(randomNumbers);
        }

        private void postaviIV(string iv, CFBMode cfb)
        {
            if (string.IsNullOrEmpty(iv))
            {
                MessageBox.Show("Vektor VI nije validan.",
                        "Obavestenje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                return;
            }

            String[] s = new String[2];
            s = divideString(iv, 2);
            cfb.VI = s;
        }

        private void postaviKljuc(string kljuc, CFBMode cfb)
        {
            String[] s = new String[4];
            if (string.IsNullOrEmpty(kljuc))
            {
                MessageBox.Show("Kljuc nije validan.",
                        "Obavestenje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                return;
            }
            s = divideString(kljuc, 4);
            cfb.Kljuc = s;
        }

        private void postaviBrojeve(string p, string a, string x, CFBMode cfb)
        {
            String[] s = new String[3];
            if (string.IsNullOrEmpty(p) || string.IsNullOrEmpty(a) || string.IsNullOrEmpty(x))
            {
                MessageBox.Show("Vrednosti nisu validne.",
                        "Obavestenje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                return;
            }
            uint p1 = Convert.ToUInt32(p);
            if (!isPrime(p1))
            {
                MessageBox.Show("P mora biti prost broj!",
                        "Obavestenje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                return;
            }
            uint a1 = Convert.ToUInt32(a), x1 = Convert.ToUInt32(x);
            if (a1 >= p1 || x1>=p1)
            {
                MessageBox.Show("nevalidne vrednosti za a ili x!",
                        "Obavestenje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                return;
            }
            s[0] = p; s[1] = a;s[2] = x;
            cfb.Kljucevi = s;
        }
        public string GenerisiPad(int duzina)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] randomNumbers = new byte[duzina];
            rng.GetNonZeroBytes(randomNumbers);
            return Encoding.Default.GetString(randomNumbers);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (ofdUploadFile.ShowDialog() == DialogResult.OK)
            {
                fileForCryptPath = ofdUploadFile.FileName;
                fileExtension = Path.GetExtension(ofdUploadFile.FileName);
                string[] tmpPath = fileForCryptPath.Split('\\');
                string[] tmpName = tmpPath.Last().Split('.');
                fileForCryptName = tmpName.First();
            }

            if (fileForCryptPath.Equals(""))
            {
                MessageBox.Show("Fajl nije selektovan!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IAlgorithm algoritam = null;
            byte alg = 0;
            if (radioButton1.Checked == true)
            {
                algoritam = new CryptoLibrary.Tea();
                alg = 1;
            }
            else if (radioButton2.Checked == true)
            {
                algoritam = new OTP();
                alg = 2;
            }
            else if (radioButton3.Checked == true)
            {
                algoritam = new ElGamal();
                alg = 3;
            }
            else
            {
                MessageBox.Show("Algoritam nije selektovan!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] file = null;
            file = File.ReadAllBytes(fileForCryptPath);
            CryptoLibrary.SHA1 sha1 = new CryptoLibrary.SHA1();
            byte[] hash = new byte[20];
            hash = sha1.GetHash(file);
            string pad = "";

            CFBMode cfb = new CFBMode(algoritam);
            postaviIV(txtIV.Text, cfb);
            if (cfb.VI == null)
                return;
            if (alg == 1)
            {
                postaviKljuc(txtKljuc.Text, cfb);
                if (cfb.Kljuc == null)
                    return;
            }
            else if (alg == 2)
            {
                int brStringova;
                pad = GenerisiPad(file.Length);
                brStringova = pad.Length / 4;
                string[] pads = divideString(pad, brStringova);
                cfb.Pad = pads;
                lblPad.Text = "Random pad je generisan.";
            }
            else
            {
                postaviBrojeve(txtP.Text,txtA.Text, txtX.Text,cfb);
                if (cfb.Kljucevi == null)
                    return;
            }
            byte[] cryptedFile = new byte[file.Length];
            cryptedFile = cfb.Kriptuj(file);
            byte[] zaUpload = new byte[20 + file.Length];
            Array.Copy(hash, zaUpload, 20);
            System.Buffer.BlockCopy(cryptedFile, 0, zaUpload, 20, cryptedFile.Length);
            File.WriteAllBytes(@".\\Kriptovano\\" + fileForCryptName + fileExtension, zaUpload);

            using (var stream = new FileStream(@".\\Kriptovano\\" + fileForCryptName + fileExtension, FileMode.Open, FileAccess.Read))
            {
                bool resultOfUpload = proxy.UploadFile(fileForCryptName + fileExtension, hash, stream);

                if (resultOfUpload == true)
                    MessageBox.Show("Fajl je uploadovan!", "Successfull upload!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Greska pri upload-u fajla!", "Error while uploading!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ShowFiles();

            int poslednji = lv1.Items.Count - 1;
            string name = lv1.Items[poslednji].Text;
            if (alg == 1)
                sacuvajPodatke(txtIV.Text, txtKljuc.Text, alg, name);
            else if (alg == 2)
                sacuvajPodatke(txtIV.Text, pad, alg, name);
            else
            {
                uint p = Convert.ToUInt32(txtP.Text), a=Convert.ToUInt32(txtA.Text),x=Convert.ToUInt32(txtX.Text);
                sacuvajPodatke(txtIV.Text, p.ToString() + a.ToString() + x.ToString(), alg, name);
            }
        }

        void sacuvajPodatke(string Iv, string Kljuc, byte Algoritam, string FileName)
        {
            byte[] iv = Encoding.ASCII.GetBytes(Iv);
            byte[] kljuc = Encoding.ASCII.GetBytes(Kljuc);

            int duzina = iv.Length + kljuc.Length + 1;
            byte[] forCrypt = new byte[duzina];

            Array.Copy(iv, forCrypt, iv.Length);
            forCrypt[iv.Length] = Algoritam;
            System.Buffer.BlockCopy(kljuc, 0, forCrypt, iv.Length + 1, kljuc.Length);

            CryptoLibrary.Tea tea1 = new CryptoLibrary.Tea();
            CFBMode cfb1 = new CFBMode(tea1);
            postaviIV(ivPodaci, cfb1);
            postaviKljuc(keyPodaci, cfb1);
            byte[] crypted = cfb1.Kriptuj(forCrypt);

            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.FullName;
            path = path + "\\podaci\\";
            File.WriteAllBytes(@path + FileName, crypted);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (lv1.SelectedItems.Count == 0)
            {
                return;
            }

            string localFilePath = "";
            string localFileName = lv1.SelectedItems[0].Text;
            string fileExtension = Path.GetExtension(localFileName);

            byte[] file = null;
            byte[] buffer = new byte[1024 * chunkSize];
            Stream inputStream = null;
            proxy.DownloadFile(ref localFileName, out inputStream);
            int offset = 0;
            do
            {
                var bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                if (bytesRead == 0) break;
                //Then it's last block
                if (bytesRead < 1024 * chunkSize)
                {
                    var temp = new byte[bytesRead];
                    Array.Copy(buffer, temp, bytesRead);
                    buffer = temp;
                }
                if (file == null)
                    file = buffer;
                else
                {
                    offset = file.Length;
                    Array.Resize(ref file, file.Length + buffer.Length);
                    System.Buffer.BlockCopy(buffer, 0, file, offset, buffer.Length);
                }
            } while (true);

            byte[] oldHash = new byte[20];
            oldHash = file.Take(20).ToArray();
            byte[] file1 = file.Skip(20).ToArray();

            byte[] podaci = uzmiPodatke(localFileName);
            string iv = System.Text.Encoding.UTF8.GetString(podaci.Take(8).ToArray());
            byte alg = podaci[8];
            byte[] p = podaci.Skip(9).ToArray();
            string key = System.Text.Encoding.UTF8.GetString(p);

            IAlgorithm algoritam = null;
            switch (alg)
            {
                case 1:
                    algoritam = new CryptoLibrary.Tea();
                    break;
                case 2:
                    algoritam = new CryptoLibrary.OTP();
                    break;
                case 3:
                    algoritam = new CryptoLibrary.ElGamal();
                    break;
                default:
                    MessageBox.Show("Algoritam nije selektovan!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            CFBMode cfb = new CFBMode(algoritam);
            postaviIV(iv, cfb);
            if (alg == 1)
                postaviKljuc(key, cfb);
            else if (alg == 2)
            {
                string[] pad = divideString(Encoding.Default.GetString(p), p.Length / 4);
                cfb.Pad = pad;
            }
            else
            {
                //string[] keys = divideString(Encoding.Default.GetString(p), 3);
                //cfb.Kljucevi = keys;
            }

            byte[] decrypted = cfb.Dekriptuj(file1);

            CryptoLibrary.SHA1 sha = new CryptoLibrary.SHA1();
            byte[] newHash = new byte[20];
            newHash = sha.GetHash(decrypted);
            if (!oldHash.SequenceEqual(newHash))
            {
                MessageBox.Show("Izracunati hash je razlicit od procitanog.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.FullName;
            path = path + "\\downloads\\";
            File.WriteAllBytes(@path + localFileName, decrypted);
            Process.Start("notepad.exe", path + localFileName);
        }

        String[] divideString(String str, int n)
        {
            int str_size = str.Length;
            int part_size;
            String s = str;
            part_size = 4;
            int br = n;
            if (4 * n < str_size)
                br++;
            String[] niz = new String[br];

            int j = 0;
            for (int i = 0; i < str_size; i += part_size)
            {
                if (i + part_size > str_size)
                {
                    part_size = str_size - i;
                    int brNula = 4 - part_size;
                    string nule = "";
                    while (brNula != 0)
                    {
                        nule += "\0";
                        brNula--;
                    }
                    niz[j] = str.Substring(i, part_size) + nule;
                }
                else
                    niz[j] = (str.Substring(i, part_size));
                j++;
            }
            return niz;
        }

        bool isPrime(uint number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            var limit = Math.Ceiling(Math.Sqrt(number));

            for (int i = 2; i <= limit; ++i)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint P=GenerisiP();
            string Pstr = P.ToString();

            var random = new Random();
            int number = random.Next(2, (int)(P/2));
            uint A = (uint)(number);
            string Astr = A.ToString();
            number = random.Next(2, (int)(P / 2));
            uint X= (uint)(number);
            string Xstr = X.ToString();
            txtP.Text = Pstr;
            txtA.Text = Astr;
            txtX.Text = Xstr;
        }
        public uint GenerisiP()
        {
            uint p = 4294967295;
            while (true)
            {
                if (isPrime(p))
                    return p;
                else
                    p -= 1;
            }
        }

        public byte[] uzmiPodatke(string FileName)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.FullName;
            path = path + "\\podaci\\";
            byte[] podaci = null;
            podaci = File.ReadAllBytes(@path + FileName);

            CryptoLibrary.Tea tea = new CryptoLibrary.Tea();
            CFBMode cfb = new CFBMode(tea);
            postaviIV(ivPodaci, cfb);
            postaviKljuc(keyPodaci, cfb);
            byte[] decr = cfb.Dekriptuj(podaci);
            return decr;
        }
    }
}
