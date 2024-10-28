using EmployeeManagement.Filters;
using EmployeeManagement.Response;
using Reservation_Management_System.DTOs;
using Reservation_Management_System.Infrastructure.Entities;
using Reservation_Management_System.Mapper;

namespace Reservation_Management_System.Infrastructure.Services.MasterService;

public class MasterService(DataContext context) : IMasterService
{
    public PaginationResponse<IEnumerable<MasterReadInfo>> GetMasters(MasterFilter filter)
    {
        IQueryable<Master> masters = context.Masters;
        if (filter.ExperienceYears > 0)
            masters = context.Masters.Where(x => x.IsDeleted == false && x.ExperienceYears == filter.ExperienceYears);
        if (filter.Specialty != null)
            masters = context.Masters.Where(x =>
                x.IsDeleted == false && x.Specialty.ToLower() == filter.Specialty.ToLower());

        IQueryable<MasterReadInfo> res = masters.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize)
            .Select(x => x.MasterToReadInfo());

        int totalRecords = context.Masters.Count();

        return PaginationResponse<IEnumerable<MasterReadInfo>>.Create(filter.PageNumber, filter.PageSize, totalRecords,
            res);
    }

    public MasterReadInfo? GetMasterById(int id)
    {
        MasterReadInfo? master = context.Masters.Where(x => x.IsDeleted == false && x.Id == id).Select(x => x.MasterToReadInfo())
            .FirstOrDefault();

        return master ?? null;
    }

    public bool CreateMaster(MasterCreateInfo createInfo)
    {
        context.Masters.Add(createInfo.CreateInfoToMaster());
        return context.SaveChanges() > 0;
    }

    public bool UpdateMaster(MasterUpdateInfo updateInfo)
    {
        Master? master = context.Masters.FirstOrDefault(x => x.IsDeleted == false && x.Id == updateInfo.Id);
        if (master == null) return false;
        context.Masters.Update(master.UpdateInfoToMaster(updateInfo));
        return context.SaveChanges() > 0;
    }

    public bool DeleteMaster(int id)
    {
        Master? master = context.Masters.FirstOrDefault(x=>x.IsDeleted == false && x.Id == id);
        if (master == null) return false;
        context.Masters.Remove(master.DeleteInfoToMaster());
        return context.SaveChanges() > 0;
    }
}