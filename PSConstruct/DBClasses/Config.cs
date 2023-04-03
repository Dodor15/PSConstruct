using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PSConstruct.DBClasses
{
    public class Config
    {
        public int ConfigId { get; set; }
        public string ConfigName { get; set; }
        public List<BDMotherBoard> BDMotherBoards { get; set; }
        public List<DBCPU> DBCPUs { get; set; }
        public List<DBGPU> DBGPUs { get; set; }
        public List<DBHDD> DBHDDs { get; set; }
        public List<DBRAM> DBRAMs { get; set; }
        public List<DBPowerUnit> DBPowerUnits { get; set; }


    }
}
