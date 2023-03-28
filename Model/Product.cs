using System;
using System.Collections.Generic;

namespace ECommerceAdmin.Model;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Make { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Composition { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderProduct> OrderProducts { get; } = new List<OrderProduct>();

    public virtual ICollection<ProductAttribute> ProductAttributes { get; } = new List<ProductAttribute>();
}
