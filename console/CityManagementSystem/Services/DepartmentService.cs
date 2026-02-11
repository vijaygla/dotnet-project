using CityManagementSystem.Models;

namespace CityManagementSystem.Services;

public static class DepartmentService
{
    public static DepartmentType GetDepartment(string description)
    {
        description = description.ToLower();

        if (description.Contains("road")) return DepartmentType.Road;
        if (description.Contains("water")) return DepartmentType.Water;
        if (description.Contains("power")) return DepartmentType.Electricity;
        if (description.Contains("traffic")) return DepartmentType.Traffic;

        return DepartmentType.General;
    }
}
