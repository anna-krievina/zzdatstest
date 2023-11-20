using System;
using System.Collections.Generic;

namespace ZZDatsTest.Models;

public partial class ParametersInYear
{
    public DateTime? Datetime { get; set; }

    public string? ParameterLv { get; set; }

    public double? Value { get; set; }

    public string? Units { get; set; }
}
