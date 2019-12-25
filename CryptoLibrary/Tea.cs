using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLibrary
{
    public class Tea:IAlgorithm
    { 

        public uint[] Dekriptuj(uint[] iv, uint[] k)
        {
            uint v0 = iv[0];
            uint v1 = iv[1];//levi i desni deo

            uint k0 = k[0];
            uint k1 = k[1];
            uint k2 = k[2];
            uint k3 = k[3];

            uint sum = 0;
            uint delta = 0x9e3779b9;//konstanta

            for (int i = 0; i < 32; i++)
            {
                sum += delta;

                v0 += ((v1 << 4) + k0) ^ (v1 + sum) ^ ((v1 >> 5) + k1);
                v1 += ((v0 << 4) + k2) ^ (v0 + sum) ^ ((v0 >> 5) + k3);
            }

            uint[] vNovo = new uint[2];
            vNovo[0] = v0;
            vNovo[1] = v1;

            return vNovo;
        }

        public uint[] Kriptuj(uint[] iv, uint[] k)
        {
            uint v0 = iv[0];
            uint v1 = iv[1];

            uint k0 = k[0];
            uint k1 = k[1];
            uint k2 = k[2];
            uint k3 = k[3];

            uint delta = 0x9e3779b9;
            uint sum = delta << 5;

            for (int i = 0; i < 32; i++)
            {
                v1 -= ((v0 << 4) + k2) ^ (v0 + sum) ^ ((v0 >> 5) + k3);
                v0 -= ((v1 << 4) + k0) ^ (v1 + sum) ^ ((v1 >> 5) + k1);
                sum -= delta;
            }

            uint[] vNovo = new uint[2];
            vNovo[0] = v0;
            vNovo[1] = v1;

            return vNovo;
        }
    }
}
