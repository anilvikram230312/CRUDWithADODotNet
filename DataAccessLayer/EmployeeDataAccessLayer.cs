using CRUDWithADODotNet.Models;
using System.Data;
using System.Data.SqlClient;

namespace CRUDWithADODotNet.DataAccessLayer
{
    public class EmployeeDataAccessLayer
    {
        public EmployeeDataAccessLayer() { }
        public string cs = Utility.ApplicationConnectionString.DBCS;

        public List<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> employeeModelList = new List<EmployeeModel>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeModel employeeModel = new EmployeeModel();
                    employeeModel.Id = Convert.ToInt32(reader["Id"]);
                    employeeModel.Name = reader["Name"].ToString() ?? "";
                    employeeModel.Gender = reader["Gender"].ToString() ?? "";
                    employeeModel.Age = Convert.ToInt32(reader["Age"]);
                    employeeModel.Email = reader["Email"].ToString() ?? "";
                    employeeModel.Designation = reader["Designation"].ToString() ?? "";
                    employeeModel.City = reader["City"].ToString() ?? "";
                    employeeModelList.Add(employeeModel);
                }
                return employeeModelList;
            }
        }

        public EmployeeModel GetEmployeesById(int? Id)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("spGetEmployeesById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", Id);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employeeModel.Id = Convert.ToInt32(reader["Id"]);
                    employeeModel.Name = reader["Name"].ToString() ?? "";
                    employeeModel.Gender = reader["Gender"].ToString() ?? "";
                    employeeModel.Age = Convert.ToInt32(reader["Age"]);
                    employeeModel.Email = reader["Email"].ToString() ?? "";
                    employeeModel.Designation = reader["Designation"].ToString() ?? "";
                    employeeModel.City = reader["City"].ToString() ?? "";
                }
                return employeeModel;
            }
        }

        public void AddUpdateEmployees(EmployeeModel employeeModel)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertUpdateEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", employeeModel.Id);
                cmd.Parameters.AddWithValue("Name", employeeModel.Name);
                cmd.Parameters.AddWithValue("Gender", employeeModel.Gender);
                cmd.Parameters.AddWithValue("Age", employeeModel.Age);
                cmd.Parameters.AddWithValue("Email", employeeModel.Email);
                cmd.Parameters.AddWithValue("Designation", employeeModel.Designation);
                cmd.Parameters.AddWithValue("City", employeeModel.City);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployeesById(int? Id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("spDeleteEmployeesById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
