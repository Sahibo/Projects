using System;
using System.Collections.Generic;

namespace ECommerceAdmin.Model;

public partial class ProductAttribute
{
    public int Id { get; set; }

    public string Size { get; set; } = null!;

    public int Discount { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;
}
