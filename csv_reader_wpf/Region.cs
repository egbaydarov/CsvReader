using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csv_reader_wpf
{
    public class Region
    {
        public Region(string admArea, string district)
        {
            AdmArea = admArea;
            District = district;
        }
        public string AdmArea { get; set; }
        public string District { get; set; }

        public static bool operator ==(Region rg1, Region rg2)
        {
            return rg1.AdmArea.Equals(rg2.AdmArea) && rg1.District.Equals(rg2.District); 
        }
        public static bool operator !=(Region rg1, Region rg2)
        {
            return !(rg1.AdmArea.Equals(rg2.AdmArea) && rg1.District.Equals(rg2.District));
        }
    }
}
