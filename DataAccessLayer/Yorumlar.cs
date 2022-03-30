using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Yorumlar
    {
        public int ID { get; set; }
        public int UyeID { get; set; }
        public string UyeAdi { get; set; }
        public int MakaleID { get; set; }
        public string MakaleAdi { get; set; }
        public string İcerik { get; set; }
        public DateTime YorumTarih { get; set; }
        public bool OnayDurum { get; set; }
    }
}
