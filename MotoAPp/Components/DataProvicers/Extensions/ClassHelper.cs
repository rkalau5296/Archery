using MotoAPp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoAPp.DataProvicers.Extensions
{
    public static class ClassHelper
    {
        public static IEnumerable<Car> ByColor(this IEnumerable<Car> query, string color)
        {
            return query.Where(x => x.Color == color);
        }
    }
}
