namespace Domain.SPModels.System;

public class SP_GetRoleMenusByRoleId
{

    public int MenuId { get; set; }
    public string Module { get; set; }
    public string Menu { get; set; }
    public bool AssignStatus { get; set; }
}
