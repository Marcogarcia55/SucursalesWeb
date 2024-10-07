namespace SucursalesWeb.Service
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<EmpleadoDto>?> GetAllAsync();
        Task<bool> AddAsync(Empleado empleado);
    }
}