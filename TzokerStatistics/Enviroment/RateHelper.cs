using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TzokerStatistics.Enviroment
{
    class RateHelper
    {
        IsolatedStorageSettings AppSettings = IsolatedStorageSettings.ApplicationSettings;

        public void RateAppMessage()
        {
            MessageBoxResult mm = MessageBox.Show("AVC IT. Ευχαριστούμε που χρησιμοποιείτε την εφαρμογή Tzoker Statistics. Η γνώμη σας μας Βοηθάει ! Παρακαλούμε αξιολογήστε την Εφαρμογή", "Tzoker Statistics", MessageBoxButton.OKCancel);
            if (mm == MessageBoxResult.OK)
            {
                AppSettings["ApplicationRated"] = true;
                MarketplaceReviewTask rr = new MarketplaceReviewTask();
                rr.Show();
            }
            if (mm == MessageBoxResult.Cancel)
            {
                
            }
        }
    }
}
