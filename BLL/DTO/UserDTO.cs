using System;
using System.Collections.Generic;

namespace Animal_Status;

public partial class UserDTO
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<PetDTO> Pets { get; set; } = new List<PetDTO>();

    public virtual RoleDTO Role { get; set; } = null!;
}
