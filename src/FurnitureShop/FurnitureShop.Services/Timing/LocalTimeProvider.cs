using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Services.Timing
{
    public class LocalTimeProvider : ITimeProvider
    {
        public DateTime Now => DateTime.Now;

        public DateTime Today => DateTime.Now.Date;
    }
}
