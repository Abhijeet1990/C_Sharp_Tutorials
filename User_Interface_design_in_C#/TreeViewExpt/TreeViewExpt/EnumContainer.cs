using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewExpt
{
    public enum GTType
    {
        None = 0,
        GT24 = 1,
        GT7FA = 2,
        M501F = 3,
        M501G = 4,
        M501GAC = 5,
        W501F = 6,
        W501G = 7

    }
    public enum GenType
    {
        None = 0,
        Gen1 = 1,
        Gen2 = 2
    }
    public enum HRSGType
    {
        None = 0,
        hrsg1 = 1,
        hrsg2 = 2
    }
    public enum STType
    {
        None = 0,
        ST1 = 1,
        ST2 = 2
    }
    public enum ICType
    {
        None = 0,
        EvaporativeCooling = 1,
        Fogging = 2,
        Chilling = 2,
        WetCompression = 3
    }
    public enum IHType
    {
        None = 0,
        IH1 = 1,
        IH2 = 2,
        IH3 = 3,
        IH4 = 4
    }
    public enum CondenserType
    {
        None = 0,
        Cond1 = 1,
        Cond2 = 2
    }
}
