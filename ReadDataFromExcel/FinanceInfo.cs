using System;
using System.Collections.Generic;

namespace ReadDataFromExcel;

public partial class FinanceInfo
{
    public int Id { get; set; }

    public string? PostDate { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; }

    public string? Type { get; set; }

    public double? Amount { get; set; }

    public string? Memo { get; set; }

    public string? CardType { get; set; }

    public override string ToString()
    {
        return $"Transaction: {PostDate} {Description} {Category} {Type} {Amount} {Memo}";
    }
}
