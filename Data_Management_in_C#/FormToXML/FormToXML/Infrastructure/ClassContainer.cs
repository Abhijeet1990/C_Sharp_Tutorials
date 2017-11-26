using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormToXML.Infrastructure
{
    public class ClassContainer
    {

        public class Site
        {
            public string SiteName { get; set; }
            public List<Block> Blocks = new List<Block>();
        }

        public class Block
        {
            
            public string BlockName { get; set; }
            public List<Object> Objects = new List<Object>();
        }

        public class PlantObject
        {
            public string ObjectName { get; set; }
            
        }
    }
}
