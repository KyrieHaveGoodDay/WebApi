using Buildtest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buildtest.Service
{
    public class ClassService:BaseSql
    {
        //查詢類別
        public List<ClassModels> Inquireclass()
        {
            command.CommandText = (@"SELECT Class_id, Class_name 
                                     FROM Table_Class");
            var inquireclass = command.ExecuteReader();
            List<ClassModels> list = new List<ClassModels>();
            while(inquireclass.Read())
            {
                ClassModels models = new ClassModels();
                models.Class_ID = (int)inquireclass["Class_id"];
                models.Class_name = (String)inquireclass["Class_name"];
                list.Add(models);
            }
            return list;
        }

        //新增類別名稱
        public int Insertclass(String Class_name)
        {
            command.CommandText = ($@"INSERT INTO Table_Class(Class_name)
                                   VALUES('{Class_name}')");
            var reader = command.ExecuteNonQuery();


            return reader;
        }
    }


}