using CatServerApi.Model;

namespace CatServerApi.IRepo
{
    public interface IEmployeeRepo
    {

        Task<List<Employee>> GetAll();
        Task<List<Employee>> GetAllbyrole(string role);
        Task<Employee> GetbyId(int id);
        Task<string> Create(Employee employee);
        Task<string> Update(Employee employee, int id);
        Task<string> Remove(int id);

    }
}
