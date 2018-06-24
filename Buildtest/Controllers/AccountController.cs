using Buildtest.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Buildtest.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet]
        [Route("api/Build/Getrecord")]
        public IHttpActionResult Getrecord()
        {
            using (BuildService buildservice = new BuildService())
            {
            
            List<BuildModels> models = buildservice.GetData(@"select Table_build.Build_ID , Build_date ,Build_money, Class_name,Table_Image.Image_text
                                                              from Table_build
                                                              Join Table_Class on Table_build.Build_class = Table_Class.Class_id
							                                  join Table_Image on Table_Image.Build_id = Table_build.Build_ID
                                                              ORDER  BY Build_ID ASC");

            return Ok(models);


            
    



          
            }

        }
        [HttpPost]
        [Route("api/Build/Insertrecord")]
        public IHttpActionResult Insertrecord([FromBody] BuildModels buildModels)
        {
            using (BuildService buildservice = new BuildService())
            {
                int insertdata= buildservice.InsertData(buildModels.Build_Date,buildModels.Class_ID,buildModels.Build_Money);
                if (insertdata == 1)
                {
                    String status =  buildservice.InsertImg(buildModels.Img_Base);
                    if(status.Equals("新增成功"))
                    {
                        return Ok("新增成功");
                    }
                    else
                    {
                        return Ok("圖片新增失敗");

                    }
                }
                else
                {
                    return Ok("新增失敗");
                }
                    
            }
                
        }
      
        [HttpPost]
        [Route("api/Build/SearchRecord")]
        public IHttpActionResult SearchRecord([FromBody] RecordModels record )
        {
            using (BuildService build = new BuildService())
            {
                var list = build.SearchRecord(record.Start, record.End, record.Class_Id);
                return Ok(list);
            }
        }
        [HttpGet]
        [Route("api/Build/GetMoney")]
        public IHttpActionResult GetMoney()
        {
            using (BuildService buildservice = new BuildService())
            {
                List<BuildModels> models = buildservice.GetData(@"select Table_build.Build_ID , Build_date ,Build_money, Class_name,Table_Image.Image_text
                            from Table_build
                            Join Table_Class on Table_build.Build_class = Table_Class.Class_id
							join Table_Image on Table_Image.Build_id = Table_build.Build_ID
                            ORDER  BY Build_ID ASC");

                int sum  = models.Sum(x => x.Build_Money);

                return Ok(sum);
            }
            



        }
    }
}
