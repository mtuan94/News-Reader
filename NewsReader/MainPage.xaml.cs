using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace NewsReader
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<NewsItem> ListNewsItemCollection = new ObservableCollection<NewsItem>();
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.


            //add du lieu
            //var ListNews = new List<NewsItem>();
            //var News1 = new NewsItem();
            //News1.Title = "iPhone 6 dính lỗi màn hình xanh và tự khởi động lại";
            //News1.Thumb = "http://c1.f5.img.vnecdn.net/2015/06/26/iphone-5s-blue-screen-of-death-3710-5183-1435290111.jpg";
            //ListNews.Add(News1);

            //var News2 = new NewsItem();
            //News2.Title = "Sony Xperia M4 Aqua - smartphone chống nước giá mềm";
            //News2.Thumb = "http://c1.f5.img.vnecdn.net/2015/06/27/Xperia-M4-Aqua-VnE5-2670-8630-1435370896.jpg";
            //ListNews.Add(News2);

            //var News3 = new NewsItem();
            //News3.Title = "Bộ đôi smartphone pin khỏe từ Lenovo ";
            //News3.Thumb = "http://m.f5.img.vnecdn.net/2015/06/29/29-6-201517-6101-1435566109.jpg";
            //News3.Link = "http://sohoa.vnexpress.net/tin-tuc/san-pham/bo-doi-smartphone-pin-khoe-tu-lenovo-3240906.html";
            //ListNews.Add(News3);

            var ListCattegory = new ObservableCollection<CattegoryModel>();
            ListCattegory.Add(new CattegoryModel()
            {
                title = "Tin mới nhất",
                links = "http://vnexpress.net/rss/tin-moi-nhat.rss",
                NewsItems = new ObservableCollection<NewsItem>()
            });

            ListCattegory.Add(new CattegoryModel()
            {
                title = "Thế giới",
                links = "http://vnexpress.net/rss/the-gioi.rss",
                NewsItems = new ObservableCollection<NewsItem>()
            });

            ListCattegory.Add(new CattegoryModel()
            {
                title = "Kinh doanh",
                links = "http://vnexpress.net/rss/kinh-doanh.rss",
                NewsItems = new ObservableCollection<NewsItem>()
            });

            ListCattegory.Add(new CattegoryModel()
            {
                title = "Giải trí",
                links = "http://vnexpress.net/rss/giai-tri.rss",
                NewsItems = new ObservableCollection<NewsItem>()
            });

            ListCattegory.Add(new CattegoryModel()
            {
                title = "Pháp luật",
                links = "http://vnexpress.net/rss/phap-luat.rss",
                NewsItems = new ObservableCollection<NewsItem>()
            });

            //ListCattegory.Add(new CattegoryModel()
            //{
            //    title = "Giáo dục",
            //    links = "http://vnexpress.net/rss/giao-duc.rss",
            //    NewsItems = new ObservableCollection<NewsItem>()
            //});

            //ListCattegory.Add(new CattegoryModel()
            //{
            //    title = "Sức khỏe",
            //    links = "http://vnexpress.net/rss/suc-khoe.rss",
            //    NewsItems = new ObservableCollection<NewsItem>()
            //});

            //ListCattegory.Add(new CattegoryModel()
            //{
            //    title = "Gia đình",
            //    links = "http://vnexpress.net/rss/gia-dinh.rss",
            //    NewsItems = new ObservableCollection<NewsItem>()
            //});

            //ListCattegory.Add(new CattegoryModel()
            //{
            //    title = "Du lịch",
            //    links = "http://vnexpress.net/rss/du-lich.rss",
            //    NewsItems = new ObservableCollection<NewsItem>()
            //});

            //ListCattegory.Add(new CattegoryModel()
            //{
            //    title = "Khoa học",
            //    links = "http://vnexpress.net/rss/khoa-hoc.rss",
            //    NewsItems = new ObservableCollection<NewsItem>()
            //});

            //ListCattegory.Add(new CattegoryModel()
            //{
            //    title = "Số hóa",
            //    links = "http://vnexpress.net/rss/so-hoa.rss",
            //    NewsItems = new ObservableCollection<NewsItem>()
            //});

            //ListCattegory.Add(new CattegoryModel()
            //{
            //    title = "Xe",
            //    links = "http://vnexpress.net/rss/oto-xe-may.rss",
            //    NewsItems = new ObservableCollection<NewsItem>()
            //});

            //ListCattegory.Add(new CattegoryModel()
            //{
            //    title = "Cộng đồng",
            //    links = "http://vnexpress.net/rss/cong-dong.rss",
            //    NewsItems = new ObservableCollection<NewsItem>()
            //});

            ControlPivot.ItemsSource = ListCattegory;


            //Goi folder Local
            var _LocalFolder = ApplicationData.Current.LocalFolder;
            
            //Lay du lieu tu RSS
            int i = 1;
            foreach(var CattegoryModel in ListCattegory)
            {
                var httpClient = new HttpClient();

                // Ham co Async se doi ham thuc hien xong r ms chay xuong doi
                i++;
                //tao file cache với tên dc mã hóa để tránh bị trùng
                var fileCache = await _LocalFolder.CreateFileAsync(i.ToString(), CreationCollisionOption.OpenIfExists);
                
                string strRSS = await Helper.readFile(fileCache);

                var properties = await fileCache.GetBasicPropertiesAsync();
                if((DateTime.Now - properties.DateModified).TotalMinutes > 5 || string.IsNullOrEmpty(strRSS))
                {
                     strRSS = await httpClient.GetStringAsync(CattegoryModel.links);
                     await Helper.writeFile(fileCache, strRSS); 
                }
                else
                {
                    strRSS =await Helper.readFile(fileCache);
                }


                //chuyen chuoi strRSS sang dinh danh file xml

                var DocXML = XDocument.Parse(strRSS);
                try
                {
                    var ListNews = from item in DocXML.Descendants("item")
                                   select new NewsItem()
                                   {
                                       Title = item.Element("title").Value,
                                       Description = item.Element("description").Value,
                                       Link = item.Element("link").Value,
                                       Thumb = GetLinkThumb(item.Element("description").Value)
                                   };
                    foreach (var newsitem in ListNews)
                    {
                        CattegoryModel.NewsItems.Add(newsitem);
                    }
                }
                catch (Exception a)
                {

                }
            
            }
            //Load xong du lieu
            LoadScreen.Visibility = Visibility.Collapsed;
        }

        

        public string GetLinkThumb( string StrContent)
        {
            var link = "";
            var match = Regex.Match(StrContent, "<img.*?src=\"(.*?)\".*?>", RegexOptions.IgnoreCase);
            if(match.Groups.Count > 0)
            {
                link = match.Groups[1].Value;
            }
            return link;
        }

        private async void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ControlPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var newsItem = (sender as ListBox).SelectedItem as NewsItem;
                if (newsItem != null)
                {

                    Frame.Navigate(typeof(ReadingPage), newsItem);
                }
            }
            catch (Exception a) { };
            
        }

        private void TinMoiNhatListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void ThoiSuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
