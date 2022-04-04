using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushDansMaster.DTO
{
    public class Prix_DTO
    {
        public int ID { get; set; }
        public int prix { get; set; }
        public  int idFournisseur { get; set; }
        public int idLigneGlobal { get; set; }
    }
}
