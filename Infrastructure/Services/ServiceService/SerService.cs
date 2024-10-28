using EmployeeManagement.Filters;
using EmployeeManagement.Response;
using Reservation_Management_System.DTOs;
using Reservation_Management_System.Infrastructure.Entities;
using Reservation_Management_System.Mapper;

namespace Reservation_Management_System.Infrastructure.Services.ServiceService;

public class SerService(DataContext context) : ISerService
{

    public PaginationResponse<IEnumerable<ServiceReadInfo>> GetServices(ServiceFilter filter)
    {
        IQueryable<Service> services = context.Services.Where(s => !s.IsDeleted);

        if (filter.Price > 0)
            services = context.Services.Where(s =>s.IsDeleted == false && s.Price == filter.Price);

        int totalRecords = services.Count();

        IQueryable<ServiceReadInfo> paginatedServices = services.Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(s => s.ServiceToReadInfo());

        return PaginationResponse<IEnumerable<ServiceReadInfo>>.Create(filter.PageNumber, filter.PageSize, totalRecords, paginatedServices);
    }

    public ServiceReadInfo? GetServiceById(int id)
    {
        ServiceReadInfo? services = context.Services
            .Where(s => !s.IsDeleted && s.Id == id)
            .Select(s => s.ServiceToReadInfo())
            .FirstOrDefault();

        return services;
    }

    public bool CreateService(ServiceCreateInfo createInfo)
    {
        context.Services.Add(createInfo.CreateInfoToService());
        return context.SaveChanges() > 0;
    }

    public bool UpdateService(ServiceUpdateInfo updateInfo)
    {
        Service? service = context.Services.FirstOrDefault(s => !s.IsDeleted && s.Id == updateInfo.Id);
        if (service == null) return false;

        context.Services.Update(service.UpdateInfoToService(updateInfo));
        return context.SaveChanges() > 0;
    }

    public bool DeleteService(int id)
    {
        Service? service = context.Services.FirstOrDefault(s => !s.IsDeleted && s.Id == id);
        if (service == null) return false;

        context.Services.Remove(service.DeleteInfoToService()); 
        return context.SaveChanges() > 0;
    }
}
