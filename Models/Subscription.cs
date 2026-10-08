using System;
using System.Collections.Generic;

namespace Konkov_prakt6;

public partial class Subscription
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int DurationDays { get; set; }

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }
}
