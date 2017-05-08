using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class Vender
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Commission { get; set; }

        public Vender()
        {
            Commission = .5;

        }
    }
}
