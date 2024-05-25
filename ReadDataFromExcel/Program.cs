using System.Data.SqlTypes;
using System.IO;
using System.Runtime.InteropServices;
using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using ReadDataFromExcel;
using Excel = Microsoft.Office.Interop.Excel;

// Reading too and from the Excel Document 



Excel.Application xlsApp= new Excel.Application();
Excel.Workbook wb= xlsApp.Workbooks.Open(@"C:\source\repos\ReadDataFromExcel\ReadDataFromExcel\Chase5762Checking_Activity_20240525.xlsx");
Excel._Worksheet ws = (Excel._Worksheet)wb.Sheets[1];
Excel.Range excelRange = ws.UsedRange;

int rowCount = excelRange.Rows.Count;
int columnCount = excelRange.Columns.Count;

//Initial loop over using the xlsApp but seems to be more clumsy than what I do later on.
/*
for (int i = 1; i <= rowCount; i++)
{
    for (int j = 1; j <= columnCount; j++)
    {
        if (excelRange.Cells[i, j] != null)
        {
            if(excelRange.Cells[i, j].Value2 != null)
            {
            Console.Write(excelRange.Cells[i,j].Value2.ToString()+" ");
            }
        }
    }
}

*/

// Reads from the excel document and writes the new object to the DB 
/*
using (var context = new FinanceAppContext())
    for (int i = 0; i < rowCount - 1; i++)
    {
        DateTime PostDateData = ws.Range["B" + (2 + i)].Value;
        var DescriptionData = ws.Range["C" + (2 + i)].Value;
        double AmountData = ws.Range["D" + (2 + i)].Value;
        var TypeData = ws.Range["E" + (2 + i)].Value;
        //    double AmountData = ws.Range["F" + (2 + i)].Value;
        //var MemoData = ws.Range["F" + (2 + i)].Value;

        var newFin = new FinanceInfo()
        {
            PostDate = PostDateData.ToShortDateString(),
            Description = DescriptionData,
            //Category = CategoryData,
            Type = TypeData,
            Amount = AmountData,
            //Memo = MemoData
            CardType = "DebitCard"
        };

        context.FinanceInfos.Add(newFin);
        context.SaveChanges();
        Console.WriteLine(newFin + "was written to the DB");
    }
*/

// Closes the open connections to the excel sheet. Is this necessary? Is there no way to do this once the using statement is done in the context window? Must be a better way.
Marshal.ReleaseComObject(excelRange);
Marshal.ReleaseComObject(ws);
Marshal.ReleaseComObject(wb);
xlsApp.Quit();
Marshal.ReleaseComObject(xlsApp);



// Messing with EF Core writing to and reading form the DB. Can do a stream later if I'm feeling it but who knows 
/*
Console.WriteLine("Writing to the DB:");
var FAi = new List<FinanceInfo>();
var fa = new FinanceInfo();

using (var context = new FinanceAppContext())
{
    var FAI = new FinanceInfo();

    FAI.Amount = 20.22m;
    FAI.Description = "A test";
    FAI.Category = "Food";
    FAI.PostDate = "2024-5-26";
    FAI.Type = "Type2";
    FAI.Memo = "Memo2";

    context.FinanceInfos.Add(FAI);
    fa = FAI;
    context.SaveChanges();

}

string categorySelection = "Food";

System.FormattableString sql = $""" 
    select * from FinanceInfo where Category = {categorySelection}
""";

using (var context = new FinanceAppContext())
{
    FAi = [.. context.FinanceInfos.FromSql(sql)];
}

foreach (var f in FAi)
{
    Console.WriteLine($"Finished reading {f.Category} from the db.");
}
Console.WriteLine($"Finished running {sql}");
*/


