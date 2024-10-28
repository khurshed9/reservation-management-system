using Reservation_Management_System.DTOs;
using Reservation_Management_System.Infrastructure.Entities;

namespace Reservation_Management_System.Mapper;

public static class MasterMapperExtension
{
    
    public static MasterReadInfo MasterToReadInfo(this Master master)
    {
        return new MasterReadInfo
        {
            Id = master.Id,
            FullName = master.FullName,
            Specialty = master.Specialty,
            ExperienceYears = master.ExperienceYears,
            Availability = master.Availability
        };
    }

    public static Master UpdateInfoToMaster(this Master master, MasterUpdateInfo updateInfo)
    {
        master.Id = updateInfo.Id;
        master.FullName = updateInfo.FullName;
        master.Specialty = updateInfo.Specialty;
        master.ExperienceYears = updateInfo.ExperienceYears;
        master.Availability = updateInfo.Availability;
        return master;
    }

    public static Master CreateInfoToMaster(this MasterCreateInfo createInfo)
    {
        return new Master
        {
            FullName = createInfo.FullName,
            Specialty = createInfo.Specialty,
            ExperienceYears = createInfo.ExperienceYears,
            Availability = createInfo.Availability
        };
    }

    public static Master DeleteInfoToMaster(this Master deleteInfo)
    {
        deleteInfo.IsDeleted = true;
        deleteInfo.DeletedAt = DateTime.UtcNow;
        deleteInfo.Version += 1;
        deleteInfo.UpdatedAt = DateTime.UtcNow;
        return deleteInfo;
    }
}