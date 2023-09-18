using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Warriors.EQ.Items
{

    // Common base class Item
    public class Item
    {
        public string Name { get; set; }
        public Slot Slot { get; set; }
        public int RequiredLevel { get; set; }
    }
}
