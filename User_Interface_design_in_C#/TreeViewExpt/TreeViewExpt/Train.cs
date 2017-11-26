using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewExpt
{
    public partial class Train
    {
        
        public string BlockAlias { get; set; }
        public byte SiteID { get; set; }
        public string BlockName { get; set; }

        public string BlockType { get; set; }
        public bool InletAirCoolingCheck { get; set; }
        public bool InletAirHeatingCheck { get; set; }
        public bool PeakFiringCheck { get; set; }
        public bool SteamInjectionCheck { get; set; }
        public bool DuctBurnersCheck { get; set; }

        public bool HOLForecastCheck { get; set; }

        public bool LOLForecastCheck { get; set; }

        public bool CompressorMapCheck { get; set; }

        public bool TESCheck { get; set; }

        public string ConfigureUnitComboBox { get; set; }

        public string TrainAlias { get; set; }
    }
}
