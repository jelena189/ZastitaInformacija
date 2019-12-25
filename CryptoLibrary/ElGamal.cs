using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLibrary
{
    public class ElGamal : IAlgorithm
    {
        public uint[] Dekriptuj(uint[] iv, uint[] k)//iv je 4 uinta
        {
            uint[] result = new uint[2];
            uint p = k[0];
            uint x = k[2];
            for (int i = 0; i < 2; i++)
            {
                result[i] = ((1 / (uint)Math.Pow(iv[i+i], x)) * iv[i+1+i]) % p;
            }
            return result;
        }

        public uint[] Kriptuj(uint[] iv, uint[] key)//k 
        {
            uint p = key[0];//moduo, prost broj
            uint a = key[1];//uzajamno prost sa p
            uint x = key[2];//privatni kljuc, uz prost sa p
            uint y = (uint)Math.Pow(a, x) % p;// y = a x (mod p).
            uint[] result = new uint[4];
            for (int i = 0; i < 2; i++)
            {
                var random = new Random();
                int number = random.Next(1, (int)(p/2));
                uint k = (uint)(number);
                uint[] partialResult = new uint[2];
                partialResult[0] = (uint)Math.Pow(a, k) % p;
                partialResult[1] = (iv[i] * (uint)Math.Pow(y, k)) % p;
                result[i+i] = partialResult[0];
                result[i+1+i] = partialResult[1];
            }
            return result;
        }

        //public uint Pow(uint num, uint pow)
        //{
        //    uint result = 1;
        //    for (int i = 1; i <= pow; ++i)
        //    {
        //        result *= num;
        //    }
        //    return result;
        //}
    }
}
