using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Buildtest.Models
{
    public class BuildService:BaseSql
    {
        public List<BuildModels> GetData(String sql)
        {
            command.CommandText = sql;
            var reader = command.ExecuteReader();
            List<BuildModels> list = new List<BuildModels>();
            while(reader.Read())
            {
                BuildModels modd = new BuildModels();
                modd.Build_ID = (int)reader["Build_Id"];
                modd.Build_Date = ((DateTime)reader["Build_date"]).ToShortDateString();
                modd.Build_Money = (int)reader["Build_money"];
                modd.Class_name = (String)reader["Class_name"];
                modd.Image_text = (String)reader["Image_text"];
                list.Add(modd);
            }

            return list;
        }

        public int InsertData(String Build_date , int Build_class , int Build_money)
        {
            command.CommandText = $@"INSERT INTO Table_build(Build_date, Build_class, Build_money)
                                   VALUES('{Build_date}',{Build_class},{Build_money})";

            int status= command.ExecuteNonQuery();

            return status;
        }

        private int GetBuildID(String sql)
        {
            command.CommandText = sql;
            SqlDataReader dataReader = command.ExecuteReader();
            int auto = 0;
            while (dataReader.Read())
            {
                auto = Int32.Parse(dataReader["auto"].ToString());
            }
            dataReader.Close();
            return auto;
        }

        public String InsertImg(List<String>imgData)
        {
            // 先取得Build_ID
            int Build_ID =  GetBuildID("SELECT IDENT_CURRENT('Table_build') as auto");
            int count = 0;
            foreach(var data in imgData)
            {
                command.CommandText = $"insert into Table_Image(Build_id,Image_text) values({Build_ID},'{data}')";
                int status =  command.ExecuteNonQuery();
                if(status == 1)
                {
                    count++;
                }
            }

            if(count == imgData.Count)
            {
                return "新增成功";

            }
            else
            {
                return "新增失敗";
            }

        }

        
        public List<BuildModels> SearchRecord(DateTime Start, DateTime End,int ClassId=0)
        {

            command.CommandText = $@"select * from Table_build
                                     join Table_Class on Table_build.Build_class = Table_Class.Class_id
                                     where 1=1 ";
            String Date_Start = Start.ToShortDateString();
            String Date_End = End.ToShortDateString();
            if (!Date_Start.Equals("0001/1/1") && !Date_End.Equals("0001/1/1"))
            {
                command.CommandText += $"and Build_date BETWEEN '{Date_Start}'and '{Date_End}'";
            }

            if(ClassId !=0)
            {
                command.CommandText += $"and Class_id = {ClassId}";
            }

            var reader =  command.ExecuteReader();
            List<BuildModels> list = new List<BuildModels>();
            while(reader.Read())
            {
                BuildModels models = new BuildModels();
                models.Build_ID = (int)reader["Build_ID"];
                models.Build_Date = ((DateTime)reader["Build_date"]).ToShortDateString();
                models.Class_name = (String)reader["Class_name"];
                models.Build_Money = (int)reader["Build_money"];
                list.Add(models);
            }

            return list;
        }
            
            
        }


    }
