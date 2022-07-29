using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using SchemeForFarmers_BackEnd_WebAPI.Models;

namespace SchemeForFarmers_BackEnd_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidderController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public BidderController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                    select *
                    from dbo.Bidders
                    ";//to match
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("");//to add : connection string variable in appdettings.json
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
        public JsonResult Post(Bidder b)
        {
            string query = @"
                    insert into dbo.Farmer 
                    (email,password,name,contact,address,city,state,pincode,account_no,iifc)
                    values 
                    (
                    '" + b.email + @"'
                    ,
                    '" + b.password + @"'
                    ,
                    '" + b.name + @"'
                    ,
                    '" + b.contact + @"'
                    ,
                    '" + b.address + @"'
                    ,
                    '" + b.city + @"'
                    ,
                    '" + b.State + @"'
                    ,
                    " + b.pincode + @"
                    ,
                    '" + b.accNo + @"'
                    ,
                    '" + b.iifc + @"'                   
                    )
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("");//to add : connection string variable in appdettings.json
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

    }
}
