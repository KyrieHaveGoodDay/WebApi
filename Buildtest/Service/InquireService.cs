using Buildtest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buildtest.Inquire
{
    public class InquireService : BaseSql
    {
        public List<BuildModels> Inquire(int Build_ID)
        {
            command.CommandText = $@"SELECT Table_build.Build_ID, Table_build.Build_date , Table_Class.Class_name , Table_build.Build_money,Table_Image.Image_text,Table_build.Build_class
                                     FROM Table_build
                                     JOIN Table_Class on Build_class=Table_Class.Class_id
							         join Table_Image on Table_Image.Build_id = Table_build.Build_ID
                                     WHERE Table_build.Build_ID = {Build_ID}";
            var quire = command.ExecuteReader();

            List<BuildModels> list = new List<BuildModels>();
            while (quire.Read())
            {
                BuildModels models = new BuildModels();
                models.Build_ID = (int)quire["Build_ID"];
                models.Build_Date = ((DateTime)quire["Build_date"]).ToShortDateString();
                models.Build_Money = (int)quire["Build_money"];
                models.Class_name = (String)quire["Class_name"];
                models.Image_text = (String)quire["Image_text"];
                models.Class_ID = (int)quire["Build_class"];

                list.Add(models);
            }

            return list;
        }
    }
}