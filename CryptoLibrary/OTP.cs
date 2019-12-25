using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLibrary
{
    public class OTP : IAlgorithm
    {
        public uint[] Dekriptuj(uint[] iv, uint[] k)
        {
            uint[] rez = new uint[2];
            rez[0] = iv[0] ^ k[0];
            rez[1] = iv[1] ^ k[1];
            return rez;
        }

        public uint[] Kriptuj(uint[] iv, uint[] k)
        {
            uint[] rez = new uint[2];
            rez[0] = iv[0] ^ k[0];
            rez[1] = iv[1] ^ k[1];
            return rez;
        }
    }
}
