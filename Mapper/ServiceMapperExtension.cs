using Reservation_Management_System.DTOs;
using Reservation_Management_System.Infrastructure.Entities;

namespace Reservation_Management_System.Mapper;

public static class ServiceMapperExtension
{
    public static ServiceReadInfo ServiceToReadInfo(this Service service)
    {
        return new ServiceReadInfo
        {
            Id = service.Id, 
            Name = service.Name,
            Description = service.Description,
            Duration = service.Duration,
            Price = service.Price,
            Category = service.Category
        };
    }

    public static Service UpdateInfoToService(this Service service, ServiceUpdateInfo updateInfo)
    {
        service.Name = updateInfo.Name;
        service.Description = updateInfo.Description;
        service.Duration = updateInfo.Duration;
        service.Price = updateInfo.Price;
        service.Category = updateInfo.Category;
        return service;
    }

    public static Service CreateInfoToService(this ServiceCreateInfo createInfo)
    {
        return new Service
        {
            Name = createInfo.Name,
            Description = createInfo.Description,
            Duration = createInfo.Duration,
            Price = createInfo.Price,
            Category = createInfo.Category
        };
    }

    public static Service DeleteInfoToService(this Service service)
    {
        service.IsDeleted = true;
        service.DeletedAt = DateTime.UtcNow;
        service.Version += 1;
        service.UpdatedAt = DateTime.UtcNow;
        return service;
    }
}
