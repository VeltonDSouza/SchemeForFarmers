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
    public class FarmerController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public FarmerController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                    select *
                    from dbo.Farmers
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
        public JsonResult Post(Farmer f)
        {
            string query = @"
                    insert into dbo.Farmer 
                    (email,password,name,contact,address,city,state,pincode,land_area,land_address,land_pincode,account_no,iifc,adhar,pan,certificate)
                    values 
                    (
                    '" + f.email + @"'
                    ,
                    '" + f.password + @"'
                    ,
                    '" + f.name + @"'
                    ,
                    '" + f.contact + @"'
                    ,
                    '" + f.address + @"'
                    ,
                    '" + f.city + @"'
                    ,
                    '" + f.State + @"'
                    ,
                    '" + f.pincode + @"'
                    ,
                    '" + f.landArea + @"'
                    ,
                     '" + f.landAddress + @"'
                      ,
                    '" + f.landPincode + @"'
                                              ,
                    '" + f.accNo + @"'
                    ,
                    '" + f.iifc + @"'
                    ,
                    '" + f.adhaar + @"'
                    ,
                    '" + f.pan + @"'
                    ,
                    '" + f.certi + @"'
                    ,
                    )
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
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
