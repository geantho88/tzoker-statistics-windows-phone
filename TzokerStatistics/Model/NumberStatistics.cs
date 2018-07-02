using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TzokerStatistics.Model
{
    public class NumberStatistics
    {
        static CultureInfo ci = new CultureInfo("el-GR");

        public int number { get; set; }
        public int numbercount { get; set; }
        public double numberpercentage { get; set; }
        public Int64 lastdrawshowed { get; set; }
        public DateTime lastdrawshowedTime { get; set; }
        public string stringlastdrawshowedTime { get { return lastdrawshowedTime.ToShortDateString(); } }
        public Int64 countfromlastdraw { get; set; }
        public PossibilityToShow possibilitytoshownext { get; set; }
        public string posibilitytextcolor { get; set; }
        public double percentageshow { get { return Math.Round(numberpercentage, 1); } set { } }
    }

    public enum PossibilityToShow
    {
        Υψηλή,
        Μέτρια,
        Χαμηλή
    }
}
