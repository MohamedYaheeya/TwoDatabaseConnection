using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;

namespace TwoDatabaseConnection.Models
{
    public class DataBaseConnection
    {
        public List<EmployeModel> DBConnection1()
        {
            List<EmployeModel> employe = new List<EmployeModel>();

            Thread t1 = new Thread(() =>
            {
                string connectionstring = ConfigurationManager.ConnectionStrings["FirstDb"].ToString();
                string query = "select * from Employe";
                SqlConnection con = new SqlConnection(connectionstring);
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    employe.Add(new EmployeModel
                    {
                        id = Convert.ToInt32(dataReader["id"]),
                        Name = dataReader["Name"].ToString(),
                        Email = dataReader["Email"].ToString(),
                        Age = Convert.ToInt32(dataReader["Age"]),
                        Address = dataReader["Address"].ToString(),
                        Emp_id = Convert.ToInt32(dataReader["Emp_id"])
                    });
                }
              
            });
            t1.Start();
            t1.Join();
            return employe;
        }
        public List<HrModel> DBConnection2()
        {
            List<HrModel> HrTeam = new List<HrModel>();

            Thread t2 = new Thread(() =>
            {

                string connectionstring = ConfigurationManager.ConnectionStrings["SecondDb"].ToString();
            string query = "select * from HrTeam";
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                HrTeam.Add(new HrModel
                {
                    Department_Id = Convert.ToInt32(dataReader["Department_Id"]),
                    Department = dataReader["Department"].ToString(),
                    Manager = dataReader["Manager"].ToString(),
                    Salary = Convert.ToInt32(dataReader["Salary"]),
                });
            }
            });
            t2.Start();
            t2.Join();
            return HrTeam;
        }
    }
}