﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSConstruct.DBClasses
{
    public class DBGPU
    {
        public int DBGPUId { get; set; }
        public string GPUName { get; set; }
        public string GPUsocket { get; set; }
        public int GPUMemoryCount { get; set; }
        public string MemoryType { get; set; }
        public int bandwidth { get; set; }
        public int PowerEat { get; set; }


    }
}
