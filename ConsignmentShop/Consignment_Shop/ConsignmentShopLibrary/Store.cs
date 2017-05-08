using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopLibrary
{
    public class Store
    {

        public string Name { get; set; }

        public List<Vender> Venders { get; set; }

        public List<Item> Items { get; set; }
    }
}
