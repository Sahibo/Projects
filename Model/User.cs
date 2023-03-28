using System;
using System.Collections.Generic;

namespace ECommerceAdmin.Model;

public partial class User
{
    public int Id { get; set; }

    public string Role { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
