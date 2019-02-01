using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksDAL
{
    public class Product
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return String.Format("{0} - {1}", ProductID, Name);
        }
    }
}
