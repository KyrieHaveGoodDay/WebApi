using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buildtest.Models
{
    public class BuildModels
    {
        public int Build_ID { get; set; }
        public String Build_Date { get; set; }
        public int Build_Money { get; set; }
        public int Build_Class { get; set; }
        public List<String>Img_Base { get; set; }
        public int Class_ID { get; set; }
        public String Class_name { get; set; }
        public String Image_text { get; set; }
    }
}