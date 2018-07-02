using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace TzokerStatistics.ResourcesAccessLogic
{
    public class MultimediaLoad
    {
        /// <summary>
        ///<para> Summary:
        ///     Gets the name of the png image without the type format .png  
        /// </para> 
        /// 
        /// <para>
        /// Returns:
        ///      The image to the control retrieved from the resources of the project. 
        ///</para> 
        ///<para>
        /// Exceptions:
        ///      No image in the Resource file. 
        ///</para>
        ///</summary>   
        public static BitmapImage LoadPngImage(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    Uri uri = new Uri(@"Resources/Images/noimage.png", UriKind.Relative);
                    BitmapImage imgSource = new BitmapImage(uri);
                    return imgSource;
                }
                else
                {
                    Uri uri = new Uri(@"Resources/Images/" + name + ".png", UriKind.Relative);
                    BitmapImage imgSource = new BitmapImage(uri);
                    return imgSource;
                }
            }
            catch
            {
                Uri uri = new Uri(@"Resources/Images/noimage.png", UriKind.Relative);
                BitmapImage imgSource = new BitmapImage(uri);
                return imgSource;
            }
        }

        /// <summary>
        ///<para> Summary:
        ///     Gets the name of the Jpg image without the type format .jpg  
        /// </para> 
        /// 
        /// <para>
        /// Returns:
        ///      The image to the control retrieved from the resources of the project. 
        ///</para> 
        ///<para>
        /// Exceptions:
        ///      No image in the Resource file. 
        ///</para>
        ///</summary>  
        public static BitmapImage LoadJpgImage(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    Uri uri = new Uri("/TzokerStatistics;component/Resources/Images/noimage.png", UriKind.Relative);
                    BitmapImage imgSource = new BitmapImage(uri);
                    return imgSource;
                }
                else
                {
                    Uri uri = new Uri("/TzokerStatistics;component/Resources/Images/" + name + ".jpg", UriKind.Relative);
                    BitmapImage imgSource = new BitmapImage(uri);
                    return imgSource;
                }
            }
            catch
            {
                Uri uri = new Uri("/TzokerStatistics;component/Resources/Images/noimage.png", UriKind.Relative);
                BitmapImage imgSource = new BitmapImage(uri);
                return imgSource;
            }
        }

        public static BitmapImage LoadGifImage(int frame)
        {
            Uri uri = new Uri("/TzokerStatistics;component/Resources/Images/" + frame + ".png", UriKind.Relative);
            BitmapImage imgSource = new BitmapImage(uri);
            return imgSource;
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

        public static ImageBrush LoadBackground_UniformToFill(string name)
        {
            try
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri("/TzokerStatistics;component/Resources/Images/" + name + ".png", UriKind.Relative));
                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = bitmapImage;
                imageBrush.Stretch = Stretch.UniformToFill;
                return imageBrush;
            }
            catch { return null; }
        }

        public static ImageBrush LoadBackground_Fill(string name)
        {
            try
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri("/TzokerStatistics;component/Resources/Images/" + name + ".png", UriKind.Relative));
                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = bitmapImage;
                imageBrush.Stretch = Stretch.Fill;
                return imageBrush;
            }
            catch { return null; }
        }

        public static ImageBrush LoadBackground_Uniform(string name)
        {
            try
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri("/TzokerStatistics;component/Resources/Images/" + name + ".png", UriKind.Relative));
                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = bitmapImage;
                imageBrush.Stretch = Stretch.Uniform;
                return imageBrush;
            }
            catch { return null; }
        }

        public static StackPanel LoadButtonBackround(string name)
        {
            try
            {
                Uri dir = new Uri("/TzokerStatistics;component/Resources/Images/" + name + ".png", UriKind.Relative);
                ImageSource source = new System.Windows.Media.Imaging.BitmapImage(dir);
                Image image = new Image();
                image.Source = source;
                StackPanel stack = new StackPanel();
                stack.Children.Add(image);
                return stack;
            }
            catch { return null; }
        }

    }
}
