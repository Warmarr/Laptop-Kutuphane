using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖdevBilgisayar
{
    internal class Bilgisayar
    {
        
        public long BilgisayarId { get; set; }
        public byte[] Resim { get; set; }
       
       
        public Bilgisayar(long bilgisayarId,byte[] resim)
        {
            BilgisayarId = bilgisayarId;
            Resim = resim;
                           
        }
      
    }
}
