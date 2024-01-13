using System;
using System.Collections.Generic;

namespace CoffeApp.PostgreSQL.Models;

public partial class Coffee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Category { get; set; }
}
