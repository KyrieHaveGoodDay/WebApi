using Buildtest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buildtest.Service
{
    public class UpdateService:BaseSql
    {
        public int Updata( int Build_class , int Build_money , int Build_ID)
        {
            command.CommandText = ($@"UPDATE Table_build
                                     set Build_class = '{Build_class}' ,Build_money = '{Build_money}'
                                     WHERE Build_ID = '{Build_ID}'");
            var ready = command.ExecuteNonQuery();

            return ready;

        }
    }
}