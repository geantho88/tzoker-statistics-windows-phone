using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TzokerStatistics.Model;

namespace TzokerStatistics.BusinessLogic
{
    class SyncService
    {
        public static ObservableCollection<Draw> DrawsList = new ObservableCollection<Draw>();

        public static async Task GetDraws()
        {
            string data = null;

            IsolatedStorageFile ISF = IsolatedStorageFile.GetUserStoreForApplication();

            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (store.FileExists("Draws.txt"))
                {
                    IsolatedStorageFileStream FS = ISF.OpenFile("Draws.txt", FileMode.Open, FileAccess.Read);
                    using (StreamReader SR = new StreamReader(FS))
                    {
                        data = SR.ReadToEnd();
                    }
                }

                else
                {
                    using (StreamWriter SW = new StreamWriter(new IsolatedStorageFileStream("Draws.txt", FileMode.Create, FileAccess.Write, ISF)))
                    {
                        String src = "Resources/Data/Draws.txt";
                        using (StreamReader sr = new StreamReader(src))
                        {
                            data = sr.ReadToEnd();
                            SW.WriteLine(data);
                            SW.Close();
                        }
                    }
                }
            }

            JArray drawsarray = JArray.Parse(data);
            DrawsList = drawsarray.ToObject<ObservableCollection<Draw>>();

           await UpdateDraws();
        }

        private static async Task UpdateDraws()
        {
            WebClient WBclient = new WebClient();
            IsolatedStorageFile ISF = IsolatedStorageFile.GetUserStoreForApplication();

            for (int i = DrawsList.Count+1; i < 2500; i++)
            {
                try
                {
                    string Url = "http://applications.opap.gr/DrawsRestServices/joker/" + i + ".json";
                    var StringDraw = await WBclient.DownloadStringTaskAsync(new Uri(Url));

                    if (!string.IsNullOrEmpty(StringDraw))
                    {
                        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("el-GR");

                        JObject JOResult = (JObject)JObject.Parse(StringDraw)["draw"];
                        if (JOResult != null)
                        {
                            JArray draws = (JArray)JOResult["results"];

                            Draw draw = new Draw();
                            draw.DrawTime = DateTimeFormat(JOResult["drawTime"].ToString());
                            draw.DrawNumber = Int64.Parse(JOResult["drawNo"].ToString());

                            foreach (var item in draws)
                            {
                                draw.DrawResults.Add(int.Parse(item.ToString()));
                            }

                            DrawsList.Add(draw);
                        }

                        else
                        {
                            var json = JsonConvert.SerializeObject(DrawsList);

                            using (StreamWriter SW = new StreamWriter(new IsolatedStorageFileStream("Draws.txt", FileMode.Create, FileAccess.Write, ISF)))
                            {
                                SW.WriteLine(json);
                                SW.Close();
                            }

                            return;
                        }
                    }
                }

                catch
                {
                    var json = JsonConvert.SerializeObject(DrawsList);
                    using (StreamWriter SW = new StreamWriter(new IsolatedStorageFileStream("Draws.txt", FileMode.Create, FileAccess.Write, ISF)))
                    {
                        SW.WriteLine(json);
                        SW.Close();
                    }

                    return;
                }
            }
        }

        private static DateTime? DateTimeFormat(string datetime)
        {
            if (String.IsNullOrEmpty(datetime))
            {
                return null;
            }
            datetime = datetime.Replace("T", " ");
            datetime = datetime.Replace("-", "/");
            return DateTime.Parse(datetime);
        }
    }
}
