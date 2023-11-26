using System;
using System.Collections.Generic;

namespace Animal_Status;

public partial class RoleDTO
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
