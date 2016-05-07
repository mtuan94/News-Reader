using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsReader
{
    public class CattegoryModel
    {
        public string title { get; set; }
        public string links {get; set; }
        public ObservableCollection<NewsItem> NewsItems { get; set; }

        //constructor
        public CattegoryModel()
        {
            NewsItems = new ObservableCollection<NewsItem>();
        }

    }


}
