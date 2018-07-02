using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TzokerStatistics.Resources;
using TzokerStatistics.BusinessLogic;
using System.IO.IsolatedStorage;
using TzokerStatistics.Enviroment;

namespace TzokerStatistics
{
    public partial class MainPage : PhoneApplicationPage
    {
        IsolatedStorageSettings AppSettings = IsolatedStorageSettings.ApplicationSettings;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            DrawsLabel.Text = "Αναλύθηκαν " + SyncService.DrawsList.Count() + " κληρώσεις. Από " + SyncService.DrawsList[0].DrawTime.Value.ToShortDateString() + " έως " + SyncService.DrawsList[(SyncService.DrawsList.Count) - 1].DrawTime.Value.ToShortDateString();
        }

        #region Frequency Category Navigation
        private void FrequencyButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/FrequencyShowPage.xaml", UriKind.Relative));
        }

        private void FrequencyImage_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/FrequencyShowPage.xaml", UriKind.Relative));
        }

        private void FrequencyText_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/FrequencyShowPage.xaml", UriKind.Relative));
        }

        private void FrequencyDetails_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/FrequencyShowPage.xaml", UriKind.Relative));
        }
        #endregion

        #region Percentage Category Navigation
        private void PercentageButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PercentageShowPage.xaml", UriKind.Relative));
        }

        private void PercentageImage_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PercentageShowPage.xaml", UriKind.Relative));

        }

        private void PercentageText_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PercentageShowPage.xaml", UriKind.Relative));

        }

        private void PercentageDetails_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PercentageShowPage.xaml", UriKind.Relative));

        }
        #endregion

        #region Tzoker Category Navigation
        private void TzokerButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TzokerStatisticsPage.xaml", UriKind.Relative));
        }

        private void TzokerImage_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TzokerStatisticsPage.xaml", UriKind.Relative));
        }

        private void TzokerText_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TzokerStatisticsPage.xaml", UriKind.Relative));
        }

        private void TzokerDetails_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TzokerStatisticsPage.xaml", UriKind.Relative));
        }
        #endregion

        #region Table Board Navigation
        private void BoardButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TableBoardPage.xaml", UriKind.Relative));
        }

        private void TableBoardText_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TableBoardPage.xaml", UriKind.Relative));

        }

        private void TableBoardImage_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TableBoardPage.xaml", UriKind.Relative));

        }

        private void TableBoardDetails_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TableBoardPage.xaml", UriKind.Relative));

        }
        #endregion

        #region SuggestedNumbers Navigaiton
        private void SuggestedNumbersButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SuggestedNumbersPage.xaml", UriKind.Relative));
        }

        private void SuggestedNumbersText_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SuggestedNumbersPage.xaml", UriKind.Relative));
        }

        private void SuggestedNumbersImage_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SuggestedNumbersPage.xaml", UriKind.Relative));
        }
        #endregion

        #region Help Navigation
        private void HelpText_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/HelpPage.xaml", UriKind.Relative));
        }

        private void HelpImage_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/HelpPage.xaml", UriKind.Relative));
        }

        private void HelpDetails_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/HelpPage.xaml", UriKind.Relative));
        }

        private void HelpButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/HelpPage.xaml", UriKind.Relative));
        }
        #endregion

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((bool)AppSettings["ApplicationRated"] == false)
            {
                while (this.NavigationService.BackStack.Any())
                {
                    this.NavigationService.RemoveBackEntry();
                }

                RateHelper rateHelper = new RateHelper();
                rateHelper.RateAppMessage();
            }
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}