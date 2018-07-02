using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TzokerStatistics.BusinessLogic;
using GoogleAds;
using TzokerStatistics.Enviroment;

namespace TzokerStatistics
{
    public partial class PercentageShowPage : PhoneApplicationPage
    {
        public PercentageShowPage()
        {
            InitializeComponent();

            var bannerAd = MonetizeApp.SetAdBanner(AdFormats.Banner);
            AdRequest adRequest = new AdRequest();
            adRequest.ForceTesting = true;     // Enable test ads
            AdPanel.Children.Add(bannerAd);
            bannerAd.LoadAd(adRequest);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            PercentageShowList.ItemsSource = AnalyzeService.NumbersStatisticsList;
            DrawsLabel.Text = "Αναλύθηκαν " + SyncService.DrawsList.Count() + " κληρώσεις. Από " + SyncService.DrawsList[0].DrawTime.Value.ToShortDateString() + " έως " + SyncService.DrawsList[(SyncService.DrawsList.Count) - 1].DrawTime.Value.ToShortDateString();      
        }
    }
}