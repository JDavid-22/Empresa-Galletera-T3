using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class entComponente
    {
        public int idComponente { get; set; }
        public string codComponente { get; set; }
        public string nomComponente { get; set; }
        public int stockComponente { get; set; }
        public bool estComponente { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} (stock: {2})", codComponente, nomComponente, stockComponente);
        }
    }
}
