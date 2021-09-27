using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class Tren
    {
        public string Ad { get; set; }
        
        public List<Vagon> Vagonlar { get; set; }

    }
}
