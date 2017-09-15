using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Models
{
    public class RideEstimate
    {
        public Coordinates PickUpLocation { get; set; }

        public int Distance { get; set; }

        public int Time { get; set; }


        public bool isValid()
        {
            return true;
        }

    }



}
