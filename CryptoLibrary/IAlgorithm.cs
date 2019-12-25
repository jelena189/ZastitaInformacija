using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLibrary
{
    public interface IAlgorithm
    {
        //uint[] GenerateRandomIV();
        uint[] Kriptuj(uint[] iv, uint[] k);// vektor iv i kljuc
        uint[] Dekriptuj(uint[] iv, uint[] k);
    }
}
