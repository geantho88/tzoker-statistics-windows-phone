using GoogleAds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TzokerStatistics.Enviroment
{
    class MonetizeApp
    {
        public static AdView SetAdBanner(AdFormats format)
        {
            AdView bannerAd = new AdView
            {
                Format = format,
                AdUnitID = "ca-app-pub-5683686090349772/3780616240"
            };

            return bannerAd;
        }
    }
}
