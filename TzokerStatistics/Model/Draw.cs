using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TzokerStatistics.Model
{
    public class Draw
    {
        public Draw()
        {
            DrawResults = new List<int>();
        }

        public Draw(DateTime drawtime, Int64 drawnumber)
        {
            this.DrawTime = drawtime;
            this.DrawNumber = drawnumber;
        }

        public DateTime? DrawTime { get; set; }
        public Int64 DrawNumber { get; set; }
        public List<int> DrawResults { get; set; }
    }
}
