using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TzokerStatistics.Model;

namespace TzokerStatistics.BusinessLogic
{
    public class AnalyzeService
    {
        public static ObservableCollection<NumberStatistics> NumbersStatisticsList = new ObservableCollection<NumberStatistics>();
        public static ObservableCollection<NumberStatistics> TzokerNumbersStatisticsList = new ObservableCollection<NumberStatistics>();

        public static void GetNumberStatistics()
        {
            ObservableCollection<NumberStatistics> NSList = FillNumberStatistics();

            foreach (var listitem in SyncService.DrawsList)
            {
                foreach (var number in listitem.DrawResults)
                {
                    //exclude tzoker number
                    if (listitem.DrawResults.IndexOf(number) != 5)
                    {
                        int entry = NSList.Where(a => a.number == number).Select(a => a.number).SingleOrDefault();
                        NSList[entry - 1].numbercount++;
                        NSList[entry - 1].lastdrawshowed = listitem.DrawNumber;
                        NSList[entry - 1].lastdrawshowedTime = listitem.DrawTime.Value;
                    }
                }
            }
            int i = 0;
            foreach (var number in NSList)
            {
                NSList[i].numberpercentage = (double)(NSList[i].numbercount / (double)SyncService.DrawsList.Count) * 100;
                NSList[i].countfromlastdraw = (SyncService.DrawsList.Count - 1) - NSList[i].lastdrawshowed;
                if (NSList[i].countfromlastdraw >= 20)
                {
                    NSList[i].possibilitytoshownext = PossibilityToShow.Υψηλή;
                    NSList[i].posibilitytextcolor = "#FFFF0000";
                }
                else if (NSList[i].countfromlastdraw >= 10)
                {
                    NSList[i].possibilitytoshownext = PossibilityToShow.Μέτρια;
                    NSList[i].posibilitytextcolor = "#FFF5A079";
                }
                else
                {
                    NSList[i].possibilitytoshownext = PossibilityToShow.Χαμηλή;
                    NSList[i].posibilitytextcolor = "#FF1ADA23";
                }

                i++;
            }

            foreach (var item in NSList)
            {
                NumbersStatisticsList.Add(item);
            }
        }

        public static void GetTzokerNumberStatistics()
        {
            ObservableCollection<NumberStatistics> NSList = FillJokerNumberStatistics();

            foreach (var listitem in SyncService.DrawsList)
            {
                foreach (var number in listitem.DrawResults)
                {
                    if (listitem.DrawResults.IndexOf(number) == 5)
                    {
                        int entry = NSList.Where(a => a.number == number).Select(a => a.number).SingleOrDefault();
                        NSList[entry - 1].numbercount++;
                        NSList[entry - 1].lastdrawshowed = listitem.DrawNumber;
                        NSList[entry - 1].lastdrawshowedTime = listitem.DrawTime.Value;
                    }
                }
            }
            int i = 0;
            foreach (var number in NSList)
            {
                NSList[i].numberpercentage = (double)(NSList[i].numbercount / (double)SyncService.DrawsList.Count) * 100;
                NSList[i].countfromlastdraw = (SyncService.DrawsList.Count - 1) - NSList[i].lastdrawshowed;
                if (NSList[i].countfromlastdraw >= 15)
                {
                    NSList[i].possibilitytoshownext = PossibilityToShow.Υψηλή;
                    NSList[i].posibilitytextcolor = "#FFFF0000";
                }
                else if (NSList[i].countfromlastdraw >= 8)
                {
                    NSList[i].possibilitytoshownext = PossibilityToShow.Μέτρια;
                    NSList[i].posibilitytextcolor = "#FFF5A079";
                }
                else
                {
                    NSList[i].possibilitytoshownext = PossibilityToShow.Χαμηλή;
                    NSList[i].posibilitytextcolor = "#FF1ADA23";
                }

                i++;
            }

            foreach (var item in NSList)
            {
                TzokerNumbersStatisticsList.Add(item);
            }
        }

        private static ObservableCollection<NumberStatistics> FillNumberStatistics()
        {
            var NumbersList = new ObservableCollection<NumberStatistics>();

            for (int i = 1; i < 46; i++)
            {
                NumberStatistics numberitem = new NumberStatistics();
                numberitem.number = i;
                NumbersList.Add(numberitem);
            }

            return NumbersList;
        }

        private static ObservableCollection<NumberStatistics> FillJokerNumberStatistics()
        {
            var NumbersList = new ObservableCollection<NumberStatistics>();

            for (int i = 1; i < 21; i++)
            {
                NumberStatistics numberitem = new NumberStatistics();
                numberitem.number = i;
                NumbersList.Add(numberitem);
            }

            return NumbersList;
        }

        public static NumberStatistics GetSingleNumberStatistics(string number)
        {
            NumberStatistics numberstatistics = new NumberStatistics();
            numberstatistics = NumbersStatisticsList.SingleOrDefault(s => s.number == int.Parse(number));
            return numberstatistics;
        }
    }
}
