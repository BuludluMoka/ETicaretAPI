namespace Domain.SPModels.System;

public class SP_GetUserRolesByUserId
{
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public bool AssignStatus { get; set; }
}
