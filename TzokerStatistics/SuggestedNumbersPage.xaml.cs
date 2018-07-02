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
using System.Collections.ObjectModel;
using TzokerStatistics.Model;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TzokerStatistics
{
    public partial class SuggestedNumbersPage : PhoneApplicationPage
    {
        List<NumberStatistics> suggestednumbers = new List<NumberStatistics>();
        NumberStatistics suggestedJokerNumber = new NumberStatistics();

        public SuggestedNumbersPage()
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
            suggestednumbers =
                AnalyzeService.NumbersStatisticsList.OrderByDescending(a => a.countfromlastdraw)
                    .ThenByDescending(b => b.numbercount)
                    .Take(5)
                    .ToList();

            if (AnalyzeService.TzokerNumbersStatisticsList == null)
            {
                AnalyzeService.GetTzokerNumberStatistics();
            }

            if (AnalyzeService.TzokerNumbersStatisticsList != null)
            {
                suggestedJokerNumber =
                    AnalyzeService.TzokerNumbersStatisticsList.OrderByDescending(a => a.countfromlastdraw)
                        .ThenByDescending(b => b.numbercount)
                        .Take(1)
                        .Single();
            }

            GenerateNumbers();
        }

        private void GenerateNumbers()
        {
            int margin = 40;

            foreach (var item in suggestednumbers)
            {
                Button numberbtn = new Button();
                numberbtn.Content = item.number.ToString();
                numberbtn.Background = LoadBackground("tzokerball");
                numberbtn.Width = 85;
                numberbtn.Height = 85;
                numberbtn.BorderThickness = new Thickness(0, 0, 0, 0);
                numberbtn.HorizontalAlignment = HorizontalAlignment.Left;
                numberbtn.Foreground = new SolidColorBrush(Colors.Black);
                SuggestedNumbersArea.Children.Add(numberbtn);
                numberbtn.Margin = new Thickness(margin, 0, 10, 0);
                margin += 75;
            }

            Button jokernumberbtn = new Button();
            jokernumberbtn.Content = suggestedJokerNumber.number.ToString();
            jokernumberbtn.Background = LoadBackground("tzokerballJoker");
            jokernumberbtn.Width = 85;
            jokernumberbtn.Height = 85;
            jokernumberbtn.BorderThickness = new Thickness(0, 0, 0, 0);
            jokernumberbtn.HorizontalAlignment = HorizontalAlignment.Left;
            jokernumberbtn.Foreground = new SolidColorBrush(Colors.Black);
            SuggestedJokerArea.Children.Add(jokernumberbtn);
            jokernumberbtn.Margin = new Thickness(185, 0, 10, 0);
        }

        public static ImageBrush LoadBackground(string name)
        {
            try
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri("/TzokerStatistics;component/Resources/Images/" + name + ".png", UriKind.Relative));
                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = bitmapImage;
                return imageBrush;
            }
            catch { return null; }
        }


    }
}