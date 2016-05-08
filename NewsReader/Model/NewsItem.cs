using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsReader
{
    public class NewsItem
    {
        //Đối tượng để hiển thị từng item trong news list

        public string Title { get; set; }

        public string Description { set; get; }

        public string Thumb { get; set; }

        public string Link { get; set; }

        public NewsItem()
        {

        }
    }

}
