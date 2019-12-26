using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLibrary
{
    public class CFBMode
    {
        uint[] kljuc;
        uint[] vi;
        uint[] pad=null;
        uint[] kljucevi;
        bool validnostKljuca;
        IAlgorithm algoritam;

        public IAlgorithm PostaviAlgoritam
        {
            set { algoritam = value; }
            get { return algoritam; }
        }

        //public bool ValidnostKljuca
        //{
        //    get { return validnostKljuca; }
        //}
        public String[] VI
        {
            get
            {
                if (this.vi == null)
                    return null;
                String[] s = new String[2];
                s[0] = vi[0].ToString();
                s[1] = vi[1].ToString();
                return s;
            }
            set
            {
                this.vi = new uint[2];
                if (value.Length != 2)
                {
                    return;
                }
                //for (int j = 0; j < 2; j++)
                //{
                //    if (value[j] == null)
                //        return;
                //}
                byte[] s0 = Encoding.ASCII.GetBytes(value[0]);
                byte[] s1= Encoding.ASCII.GetBytes(value[1]);
                vi[0]=BitConverter.ToUInt32(s0,0);
                vi[1] = BitConverter.ToUInt32(s1, 0);
            }
        }

        public string[] Pad
        {
            get
            {
                String[] s = new String[pad.Length];
                for (int i = 0; i < pad.Length; i++)
                {
                    s[i] = pad[i].ToString();
                }
                return s;
            }
            set
            {
                this.pad = new uint[value.Length];
                for (int i = 0; i < value.Length; i++)
                {
                    byte[] s = Encoding.ASCII.GetBytes(value[i]);
                    pad[i] = BitConverter.ToUInt32(s, 0);
                }
            }
        }

        public string[] Kljucevi
        {
            get
            {
                if (this.kljucevi == null)
                    return null;
                String[] s = new String[3];
                for (int i = 0; i < 3; i++)
                {
                    s[i] = kljucevi[i].ToString();
                }
                return s;
            }
            set
            {
                //for (int j = 0; j < 3; j++)
                //{
                //    if (value[j] == null)
                //        return;
                //}
                this.kljucevi = new uint[3];
                for (int i = 0; i < 3; i++)
                {
                    kljucevi[i] = Convert.ToUInt32(value[i]);
                }
            }
        }

        public String[] Kljuc
        {
            get
            {
                if (this.kljuc == null)
                    return null;
                String[] s = new String[4];
                s[0] = kljuc[0].ToString();
                s[1] = kljuc[1].ToString();
                s[2] = kljuc[2].ToString();
                s[3] = kljuc[3].ToString();
                return s;
            }
            set
            {
                //for (int j = 0; j < 4; j++)
                //{
                //    if (value[j] == null)
                //        return;
                //}
                this.kljuc = new uint[4];
                for (int i = 0; i < 4; i++)
                {
                    byte[] s= Encoding.ASCII.GetBytes(value[i]);
                    kljuc[i] = BitConverter.ToUInt32(s, 0);
                }
            }
        }


        public CFBMode(IAlgorithm alg)
        {
            algoritam = alg;
            validnostKljuca = true;
        }

        public byte[] Kriptuj(byte[] nizBajtova)
        {
            if (!validnostKljuca)
                return null;
            uint[] nizUIntova = PretvoriByteUUInt(nizBajtova);
            uint[] nizKriptovanihUIntova = KriptujUIntove(nizUIntova);
            byte[] kriptovaniBajtovi = PretvoriUIntUByte(nizKriptovanihUIntova,nizBajtova.Length);
            return kriptovaniBajtovi;
        }

        public byte[] Dekriptuj(byte[] nizBajtova)
        {
            if (!validnostKljuca)
                return null;
            uint[] nizUIntova = PretvoriByteUUInt(nizBajtova);
            uint[] nizDekriptovanihUIntova = DekriptujUIntove(nizUIntova);
            byte[] kriptovaniBajtovi = PretvoriUIntUByte(nizDekriptovanihUIntova,nizBajtova.Length);
            return kriptovaniBajtovi;
        }

        public byte[] PretvoriUIntUByte(uint[] niz, int duzina)
        {
            byte[] povratna_vrednost = new byte[duzina];
            Buffer.BlockCopy(niz, 0, povratna_vrednost, 0, duzina);
            return povratna_vrednost;
        }

        public uint[] PretvoriByteUUInt(byte[] niz)
        {

            int duzina_niz = niz.Length;
            int duzina = duzina_niz / 4;
            if (duzina_niz % 4 != 0)
                duzina++;
            uint[] povratna_vrendost = new uint[duzina];
            int j = 0;
            byte[] pom = new byte[4];
            for (int i = 0; i < duzina_niz; i = i + 4)
            {
                for (int k = 0; k < 4; k++)
                {
                    if (i + k < duzina_niz)
                        pom[k] = niz[i + k];
                    else
                        pom[k] = 0;
                }
                povratna_vrendost[j++] = BitConverter.ToUInt32(pom, 0);
            }
            return povratna_vrendost;
        }

        private uint[] KriptujUIntove(uint[] niz)
        {
            int duzina = niz.Length;
            uint[] kriptovani_niz = new uint[duzina];
            uint[] vpom = new uint[2];
            vpom[0] = this.vi[0];
            vpom[1] = this.vi[1];
            uint[] izlaz = new uint[2];
            uint[] kljuc=null;
            for (int i = 0; i < duzina; i = i + 2)
            {
                kljuc=setKey(i, duzina);
                izlaz = algoritam.Kriptuj(vpom, kljuc);
                vpom[0] = izlaz[0] ^ niz[i];
                kriptovani_niz[i] = vpom[0];

                if (i + 1 >= duzina)
                    break;
                vpom[1] = izlaz[1] ^ niz[i + 1];
                kriptovani_niz[i + 1] = vpom[1];
            }
            return kriptovani_niz;
        }

        public uint[] setKey(int i, int duzina)
        {
            if (this.kljuc != null)
                return this.kljuc;
            else if (this.pad != null)
            {
                if (i + 1 >= duzina)
                {
                    uint[] partOfPad = { this.pad[i], 0 };
                    return partOfPad;
                }
                else
                {
                    uint[] partOfPad = { this.pad[i], this.pad[i + 1] };
                    return partOfPad;
                }
            }
            else {
                return this.kljucevi;
            }
        }

        private uint[] DekriptujUIntove(uint[] niz)
        {
            int duzina = niz.Length;
            uint[] dekriptovani_niz = new uint[duzina];
            uint[] vpom = new uint[2];
            vpom[0] = this.vi[0];
            vpom[1] = this.vi[1];
            uint[] izlaz = new uint[2];
            uint[] kljuc = null;
            for (int i = 0; i < duzina; i = i + 2)
            {
                kljuc = setKey(i,duzina);
                izlaz = algoritam.Kriptuj(vpom, kljuc);
                vpom[0] = izlaz[0] ^ niz[i];
                dekriptovani_niz[i] = vpom[0];
                if (i + 1 >= duzina)
                    break;
                vpom[1] = izlaz[1] ^ niz[i + 1];
                dekriptovani_niz[i + 1] = vpom[1];

                vpom[0] = niz[i];
                vpom[1] = niz[i + 1];
            }
            return dekriptovani_niz;
        }

   
    }
}
