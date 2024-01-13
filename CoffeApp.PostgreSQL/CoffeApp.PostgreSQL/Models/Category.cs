using System;
using System.Collections.Generic;

namespace CoffeApp.PostgreSQL.Models;

public partial class Category
{
    public string Code { get; set; } = null!;

    public string? Name { get; set; }
}
