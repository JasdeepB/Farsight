using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farsight
{
    class RunePage
    {
        public string name { get; set; }
        public int primaryStyleId { get; set; }
        public int[] selectedPerkIds = new int[9];
        public int subStyleId { get; set; }
        public RunePage()
        {

        }
    }
}
