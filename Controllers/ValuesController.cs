using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAPI.Models;
using MySql.Data.MySqlClient;

namespace webAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        private MySqlConnection conn;
        private MySqlDataAdapter adapter;
        public IEnumerable<doctor> Get()
        {
            conn = new MySqlConnection("server=localhost;user id=root;database=medical;pwd=123456");
            DataTable table = new DataTable();
            var query = "select * from doctor";
            adapter = new MySqlDataAdapter
            {
                SelectCommand = new MySqlCommand(query, conn),
            };
            adapter.Fill(table);
            List<doctor> doctors = new List<doctor>(table.Rows.Count);
            if(table.Rows.Count > 0)
            {
                foreach(DataRow data in table.Rows)
                {
                    doctors.Add(new readDoctor(data));
                }
            }
            return doctors;
        }

        // GET api/values/5
        public IEnumerable<doctor> Get(int id)
        {
            conn = new MySqlConnection("server=localhost;user id=root;database=medical;pwd=123456");
            DataTable table = new DataTable();
            var query = "select * from doctor where ID = "+id;
            adapter = new MySqlDataAdapter
            {
                SelectCommand = new MySqlCommand(query, conn),
            };
            adapter.Fill(table);
            List<doctor> doctors = new List<doctor>(table.Rows.Count);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow data in table.Rows)
                {
                    doctors.Add(new readDoctor(data));
                }
            }
            return doctors;
        }

        // POST api/values
        public string Post([FromBody]createDoctor value)
        {
            conn = new MySqlConnection("server=localhost;user id=root;database=medical;pwd=123456");
            var query = "insert into doctor values (@Name, @ShortName, @Pass, @sex, @address, @email, @MRI , @CT, @permission,@DX, @US,@EO, @PET, @MAMO)";
            MySqlCommand insert = new MySqlCommand(query, conn);
            insert.Parameters.AddWithValue("Name",value.name);
            insert.Parameters.AddWithValue("ShortName",value.shortname);
            insert.Parameters.AddWithValue("Pass",value.pass);
            insert.Parameters.AddWithValue("sex",value.sex);
            insert.Parameters.AddWithValue("address",value.address);
            insert.Parameters.AddWithValue("email",value.email);
            insert.Parameters.AddWithValue("MRI",value.MRI);
            insert.Parameters.AddWithValue("CT",value.CT);
            insert.Parameters.AddWithValue("permission",value.peemission);
            insert.Parameters.AddWithValue("DX",value.DX);
            insert.Parameters.AddWithValue("US",value.US);
            insert.Parameters.AddWithValue("EO",value.EO);
            insert.Parameters.AddWithValue("PET",value.PET);
            insert.Parameters.AddWithValue("MAMO",value.MAMO);
            conn.Open();
            int result = insert.ExecuteNonQuery();
            if (result > 0)
            {
                return "inserted";
            }
            else
            {
                return "fail";
            }
        }

        // PUT api/values/5
        public string Put(int id, [FromBody] createDoctor value)
         {
            conn = new MySqlConnection("server=localhost;user id=root;database=medical;pwd=123456");
            var query = "update doctor set Name=@Name,ShortName = @ShortName,Pass = @Pass,sex = @sex,address = @address,email = @email,MRI = @MRI ,CT = @CT,permission = @permission,DX = @DX,US = @US,EO = @EO,PET = @PET,MAMO = @MAMO where ID = "+id;
            MySqlCommand insert = new MySqlCommand(query, conn);
            //insert.Parameters.AddWithValue("ID",value.id);
            insert.Parameters.AddWithValue("Name", value.name);
            insert.Parameters.AddWithValue("ShortName", value.shortname);
            insert.Parameters.AddWithValue("Pass", value.pass);
            insert.Parameters.AddWithValue("sex", value.sex);
            insert.Parameters.AddWithValue("address", value.address);
            insert.Parameters.AddWithValue("email", value.email);
            insert.Parameters.AddWithValue("MRI", value.MRI);
            insert.Parameters.AddWithValue("CT", value.CT);
            insert.Parameters.AddWithValue("permission", value.peemission);
            insert.Parameters.AddWithValue("DX", value.DX);
            insert.Parameters.AddWithValue("US", value.US);
            insert.Parameters.AddWithValue("EO", value.EO);
            insert.Parameters.AddWithValue("PET", value.PET);
            insert.Parameters.AddWithValue("MAMO", value.MAMO);
            conn.Open();
            int result = insert.ExecuteNonQuery();
            if (result > 0)
            {
                return "Update compely !";
            }
            else
            {
                return "fail";
            }
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            conn = new MySqlConnection("server=localhost;user id=root;database=medical;pwd=123456");
            var query = "delete from doctor where ID = " + id;
            MySqlCommand insert = new MySqlCommand(query, conn);
            conn.Open();
            int result = insert.ExecuteNonQuery();
            if (result > 0)
            {
                return "Delete compely !";
            }
            else
            {
                return "fail";
            }
        }
    }
}
