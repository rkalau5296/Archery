using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoAPp.Entities
{
    public class Car : EntityBase
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Type { get; set; }

        public int? NameLength { get; set; }
        public decimal? TotalSales { get; set; }

        #region ToString Override
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} ID: {Id}");
            sb.AppendLine($"    Color: {Color}  Type: {(Type ?? "n/a")}");
            sb.AppendLine($"    Cost: {StandardCost:c}  Price: {ListPrice:c}");
            if ( NameLength.HasValue ) 
            {
                sb.AppendLine($"    Name Length: {NameLength}");
            }
            if( TotalSales.HasValue ) 
            {
                sb.AppendLine($"    Name Length: {NameLength}");
            }
            return sb.ToString();
        }
    }
    #endregion
}
