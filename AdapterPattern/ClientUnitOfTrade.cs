using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class ClientUnitOfTrade
    {
        public int Id { get; set; }
        public string ProducingCompany { get; set; }
        public string Name { get; set; }
        public string ProducingCountry { get; set; }
        public double RetailPrice { get; set; }
        public double WholesalePrice { get; set; }
        public string Unit { get; set; }
        public string ManufacturesArticle { get; set; }
    }
}
