using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Models
{
    public class Coordinates
    {
        double Longitude;
        double Latitude;

        public Coordinates(double latitude, double longitude)
        {
            fromLatLong(latitude, longitude);
        }

        public Coordinates(string Wkt)
        {
            fromWkt(Wkt);
        }

        public void fromLatLong(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public string ToWkt()
        {

            return string.Format("POINT({0} {1})", Latitude, Longitude);
        }
        
        

        public void fromWkt(string wkt)
        {
            try
            {
                string couple = wkt.Substring(7, wkt.Length - 8);

                Latitude = Double.Parse(couple.Substring(0, couple.LastIndexOf(' ')));

                Longitude = Double.Parse(couple.Remove(0, couple.LastIndexOf(' ') + 1));


            }
            catch (Exception e)
            {

                throw new FormatException(wkt + "   :   " + Latitude + "   :   " + Longitude, e);
            }

        }

    }

    
    
}
