using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsReader
{
    //model category chứa các newsItem
    public class CattegoryModel
    {
        public string title { get; set; }
        public string links {get; set; }
        public ObservableCollection<NewsItem> NewsItems { get; set; }

        //constructor
        //mặc định đã có
        //khai báo lại
        // mỗi lần new CattegoryModel sẽ khởi tạo 1 NewsItems
        public CattegoryModel()
        {
            NewsItems = new ObservableCollection<NewsItem>();
        }

    }


}
