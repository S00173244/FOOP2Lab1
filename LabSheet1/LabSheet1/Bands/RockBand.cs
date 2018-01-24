using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSheet1
{
    class RockBand : Band
    {
        public RockBand(string bn, string yf, List<string> m, List<Album> a)
        {
            BandName = bn;
            YearFormed = yf;
            Members = m;
            Albums = a;
        }
    }
}
