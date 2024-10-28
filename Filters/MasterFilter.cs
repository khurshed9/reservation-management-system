namespace EmployeeManagement.Filters;

public class MasterFilter : BaseFilter
{
    public string? Specialty { get; set; }
    
    public int? ExperienceYears { get; set; }
}