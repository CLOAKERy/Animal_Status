using System;
using System.Collections.Generic;

namespace Animal_Status;

public partial class User
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();

    public virtual Role Role { get; set; } = null!;
}
