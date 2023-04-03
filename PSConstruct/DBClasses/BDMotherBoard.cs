using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSConstruct.DBClasses
{
    public class BDMotherBoard
    {
        public int DBMotherBoardId { get; set; }
        public string MDName { get; set; }
        public string CPUsocket { get; set; }
        public string GPUsocket { get; set; }
        public string RAMsocket { get; set; }
        public int CountRAM { get; set; }
        

    }
}
