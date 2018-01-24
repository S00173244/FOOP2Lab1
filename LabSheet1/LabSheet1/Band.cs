using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSheet1
{
    public abstract class Band : IComparable<Band>
    {
        private string bandName;
        private string yearFormed;
        private List<string> members;
        private List<Album> albums;

        #region Accessors
        public string BandName
        {
            get
            {
                return bandName;
            }

            set
            {
                bandName = value;
            }
        }

        public string YearFormed
        {
            get
            {
                return yearFormed;
            }

            set
            {
                yearFormed = value;
            }
        }

        public List<string> Members
        {
            get
            {
                return members;
            }

            set
            {
                members = value;
            }
        }

        internal List<Album> Albums
        {
            get
            {
                return albums;
            }

            set
            {
                albums = value;
            }
        }
        #endregion

        
        public int CompareTo(Band other)
        {
            return this.BandName.CompareTo(other.BandName);
        }

        public override string ToString()
        {
            return BandName;
        }

        public string DetailsForFileWrite()
        {
            return string.Format("{0},{1},{2}", BandName, YearFormed, String.Join(",",Members));
        }
    }
}
