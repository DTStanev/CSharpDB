namespace EmployeeInformationServices.Services.Interfaces
{
    public interface IManagerService
    {
        void SetManager(int empId, int managerId);

        TModel ManagerInfo<TModel>(int managerId);

        bool Exists(int managerId);
    }
}
