using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSheet1
{
    public class Album
    {
        private string albumName;
        private DateTime releasedYear;
        private int sales;


        #region Accessors
        public string AlbumName
        {
            get
            {
                return albumName;
            }

            set
            {
                albumName = value;
            }
        }

        public DateTime ReleasedYear
        {
            get
            {
                return releasedYear;
            }

            set
            {
                releasedYear = value;
            }
        }

        public int Sales
        {
            get
            {
                return sales;
            }

            set
            {
                sales = value;
            }
        }
        #endregion

        public Album(string n, DateTime year, int s)
        {
            AlbumName = n;
            ReleasedYear = year;
            sales = s;
        }

        public override string ToString()
        {
            return AlbumName + " " + ReleasedYear.Year + " " + Sales;
        }

        public string DetailsForFileWrite()
        {
            return string.Format("{0},{1},{2}", AlbumName, ReleasedYear.Year, Sales);
        }
    }
}
