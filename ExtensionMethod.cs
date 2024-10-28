using Reservation_Management_System.Infrastructure.Services.BookingService;
using Reservation_Management_System.Infrastructure.Services.ClientService;
using Reservation_Management_System.Infrastructure.Services.MasterService;
using Reservation_Management_System.Infrastructure.Services.ReviewService;
using Reservation_Management_System.Infrastructure.Services.ServiceService;

namespace Reservation_Management_System;

public static class ExtensionMethod
{
    public static void AddService(this IServiceCollection service)
    {
        service.AddTransient<IMasterService, MasterService>();
        service.AddTransient<IClientService, ClientService>();
        service.AddTransient<IBookingService, BookingService>();
        service.AddTransient<ISerService, SerService>();
        service.AddTransient<IReviewService, ReviewService>();
    }
}