using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class Reservation
    {
        public bool RezervasyonYapilabilir { get; set; }

        public List<YerlesimAyrinti> YerlesimAyrinti { get; set; }
    }
}
