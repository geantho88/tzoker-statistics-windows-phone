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
using TzokerStatistics.Model;
using System.Collections.ObjectModel;
using System.Windows.Media;
using TzokerStatistics.ResourcesAccessLogic;
using TzokerStatistics.Enviroment;
using GoogleAds;

namespace TzokerStatistics
{
    public partial class TableBoard : PhoneApplicationPage
    {
        ObservableCollection<NumberStatistics> numbers = new ObservableCollection<NumberStatistics>();


        public TableBoard()
        {
            InitializeComponent();

            var bannerAd = MonetizeApp.SetAdBanner(AdFormats.Banner);
            AdRequest adRequest = new AdRequest();
            adRequest.ForceTesting = true;     // Enable test ads
            AdPanel.Children.Add(bannerAd);
            bannerAd.LoadAd(adRequest);

            DetailsNumber.Visibility = Visibility.Collapsed;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            FillNumberPanel();
        }

        private void FillNumberPanel()
        {
            //NumbersGrid.Children.Clear();
            numbers = AnalyzeService.NumbersStatisticsList;

            int margin = 45;
            int count = 0;

            foreach (var number in numbers)
            {
                count++;
                Button numberbtn = new Button();
                numberbtn.Content = number.number.ToString();
                if (number.possibilitytoshownext == PossibilityToShow.Χαμηλή)
                {
                    numberbtn.Background = MultimediaLoad.LoadBackground("tzokerballJoker");
                }
                if (number.possibilitytoshownext == PossibilityToShow.Μέτρια)
                {
                    numberbtn.Background = MultimediaLoad.LoadBackground("tzokerballorange");
                }
                if (number.possibilitytoshownext == PossibilityToShow.Υψηλή)
                {
                    numberbtn.Background = MultimediaLoad.LoadBackground("tzokerbalgreen");
                }
                numberbtn.Width = 85;
                numberbtn.Height = 85;
                numberbtn.BorderThickness = new Thickness(0, 0, 0, 0);
                numberbtn.HorizontalAlignment = HorizontalAlignment.Left;
                numberbtn.Click += new RoutedEventHandler(NumbersButton_Click);
                numberbtn.VerticalAlignment = VerticalAlignment.Top;
                numberbtn.Margin = new Thickness(margin, 0, 38, 0);
                numberbtn.Foreground = new SolidColorBrush(Colors.Black);

                if (count < 6)
                {
                    NumbersGrid.Children.Add(numberbtn);
                }

                else if (count >= 6 && count < 11)
                {
                    if (count == 6) { margin = 45; }
                    numberbtn.Margin = new Thickness(margin, 65, 8, 0);
                    NumbersGrid.Children.Add(numberbtn);
                }

                else if (count >= 11 && count < 16)
                {
                    if (count == 11) { margin = 45; }
                    numberbtn.Margin = new Thickness(margin, 130, 8, 0);
                    NumbersGrid.Children.Add(numberbtn);
                }

                else if (count >= 16 && count < 21)
                {
                    if (count == 16) { margin = 45; }
                    numberbtn.Margin = new Thickness(margin, 195, 8, 0);
                    NumbersGrid.Children.Add(numberbtn);
                }

                else if (count >= 21 && count < 26)
                {
                    if (count == 21) { margin = 45; }
                    numberbtn.Margin = new Thickness(margin, 260, 8, 0);
                    NumbersGrid.Children.Add(numberbtn);
                }

                else if (count >= 26 && count < 31)
                {
                    if (count == 26) { margin = 45; }
                    numberbtn.Margin = new Thickness(margin, 325, 8, 0);
                    NumbersGrid.Children.Add(numberbtn);
                }

                else if (count >= 31 && count < 36)
                {
                    if (count == 31) { margin = 45; }
                    numberbtn.Margin = new Thickness(margin, 390, 8, 0);
                    NumbersGrid.Children.Add(numberbtn);
                }

                else if (count >= 36 && count < 41)
                {
                    if (count == 36) { margin = 45; }
                    numberbtn.Margin = new Thickness(margin, 455, 8, 0);
                    NumbersGrid.Children.Add(numberbtn);
                }

                else if (count >= 41 && count < 46)
                {
                    if (count == 41) { margin = 45; }
                    numberbtn.Margin = new Thickness(margin, 520, 8, 0);
                    NumbersGrid.Children.Add(numberbtn);
                }

                margin += 72;
            }
        }

        private void NumbersButton_Click(object sender, EventArgs e)
        {
            DetailsNumber.Visibility = Visibility.Visible;
            Button button = (Button)sender;

            var statistics = AnalyzeService.GetSingleNumberStatistics(button.Content.ToString());
            //kinogamelabel3.Text = "Σύνολο εμφανίσεων " + statistics.numbercount + " " + "Ποσοστό εμφάνισης " + statistics.percentageshow.ToString() + " % " + "Πιθανότητα εμφάνισης " + statistics.possibilitytoshownext.ToString() + " Τελευταία εμφάνιση πριν από " + statistics.countfromlastdraw.ToString() + " Κληρώσεις στις " + statistics.stringlastdrawshowedTime.ToString();
            NumerDetail1.Text = "Εμφανίστηκε πρίν απο " + statistics.countfromlastdraw.ToString() + " Κληρώσεις";
            NumerDetail2.Text = "Ποσοστό εμφάνισης " + statistics.percentageshow.ToString() + " % ";
            NumerDetail3.Text = "Τελευταία εμφάνιση στις " + statistics.stringlastdrawshowedTime.ToString();
            DetailsNumber1.Content = button.Content.ToString();
            DetailsNumber1.Foreground = new SolidColorBrush(Colors.Black);

            if (statistics.possibilitytoshownext == PossibilityToShow.Χαμηλή)
            {
                DetailsNumber1.Background = MultimediaLoad.LoadBackground("tzokerballJoker");
            }
            if (statistics.possibilitytoshownext == PossibilityToShow.Μέτρια)
            {
                DetailsNumber1.Background = MultimediaLoad.LoadBackground("tzokerballorange");
            }
            if (statistics.possibilitytoshownext == PossibilityToShow.Υψηλή)
            {
                DetailsNumber1.Background = MultimediaLoad.LoadBackground("tzokerbalgreen");
            }
        }

        private void DetailsExit_Click(object sender, RoutedEventArgs e)
        {
            DetailsNumber.Visibility = Visibility.Collapsed;
        }
    }
}