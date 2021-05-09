using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CommandController (IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                    select id_cmd, date_cmd,datedeliv_cmd,location_cmd,modedeliv_cmd,price_cmd,modepayment_cmd from dbo.command";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("backCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult Post(Command cmd)
        {
            string query = @"
                    insert into dbo.command values 
                    ('" + cmd.date_cmd + @"'
,'" + cmd.amount_cmd + @"'
,'" + cmd.datedeliv_cmd + @"'
,'" + cmd.location_cmd + @"'
,'" + cmd.modedeliv_cmd + @"'
,'" + cmd.price_cmd + @"'
,'" + cmd.modepayment_cmd + @"')
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("backCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(Command cmd)
        {
            string query = @"
                    update dbo.command set 
                    date_cmd = '" + cmd.date_cmd + @"'
,datedeliv_cmd = '" + cmd.datedeliv_cmd + @"'
,location_cmd = '" + cmd.location_cmd + @"'
,modedeliv_cmd = '" + cmd.modedeliv_cmd + @"'
,price_cmd = '" + cmd.price_cmd + @"'
,modepayment_cmd = '" + cmd.modepayment_cmd + @"'

                    where id_cmd = " + cmd.id_cmd + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("backCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }
    }
}
