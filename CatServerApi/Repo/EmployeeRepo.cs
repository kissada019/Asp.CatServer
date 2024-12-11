using CatServerApi.IRepo;
using CatServerApi.Model;
using CatServerApi.Model.Data;
using Dapper;
using System.Data;

namespace CatServerApi.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly DapperDbContext context;
        public EmployeeRepo(DapperDbContext context) {
            this.context = context; 
        }

        public async Task<string> Create(Employee employee)
        {
            string response = string.Empty;
            string query = " insert into employee(name, email, phone, designation) values (@name, @email, @phone, @designation)";
            var parameters = new DynamicParameters();
            parameters.Add("name", employee.name, DbType.String);
            parameters.Add("email", employee.email, DbType.String);
            parameters.Add("phone", employee.phone, DbType.String);
            parameters.Add("designation", employee.designation, DbType.String);
            using (var connection = this.context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                response = "insert successfully";

            }
            return response;
        }

        public async Task<List<Employee>> GetAll()
        {
            string query = " select * from employee";
            using (var connection = this.context.CreateConnection())
            {
                var emplist = await connection.QueryAsync<Employee>(query);
                return emplist.ToList();
            }
        }

        public async Task<List<Employee>> GetAllbyrole(string role)
        {
            //string query = " exec GetEmployeesByRole @role";
            //using (var connection = this.context.CreateConnection())
            //{
            //    var emplist = await connection.QueryAsync<Employee>(query, new { role });
            //    return emplist.ToList();
            //}
            string query = "GetEmployeesByRole";
            using (var connection = this.context.CreateConnection())
            {
                var emplist = await connection.QueryAsync<Employee>(query, new { role }, commandType:CommandType.StoredProcedure);
                return emplist.ToList();
            }
        }

        public async Task<Employee> GetbyId(int id)
        {
            string query = " select * from employee where id=@id";
            using (var connection = this.context.CreateConnection())
            {
                var emplist = await connection.QueryFirstOrDefaultAsync<Employee>(query, new {id});
                return emplist;
            }
        }

        public async Task<string> Remove(int id)
        {
            string response = string.Empty;
            string query = " delete from employee where id=@id";
            using (var connection = this.context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
                response = "delete successfully";
              
            }
            return response;
        }

        public async Task<string> Update(Employee employee, int id)
        {
            string response = string.Empty;
            string query = " update employee set name=@name, email=@email, phone=@phone, designation=@designation where id=@id ";
            var parameters = new DynamicParameters();
            parameters.Add("id", employee.id, DbType.Int32);
            parameters.Add("name", employee.name, DbType.String);
            parameters.Add("email", employee.email, DbType.String);
            parameters.Add("phone", employee.phone, DbType.String);
            parameters.Add("designation", employee.designation, DbType.String);
            using (var connection = this.context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                response = "update successfully";

            }
            return response;
        }
    }
}
