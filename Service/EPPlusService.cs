using OfficeOpenXml;
using System.Reflection;
using Domain.Service;
using ExcelColumn = Domain.Attributes.ExcelColumn;

namespace Service
{
    public class EPPlusService : IEPPlusService
    {
        public IEnumerable<T> ConvertSheetToObjects<T>(ExcelWorksheet worksheet) where T : new()
        {
            var columns = typeof(T)
                .GetProperties()
                .Where(x => x.CustomAttributes.Any(q => q.AttributeType == typeof(ExcelColumn)))
                .Select(p => new
                {
                    Property = p,
                    Column = p.GetCustomAttributes<ExcelColumn>().First().ColumnIndex //safe because if where above
                }).ToList();

            var rows = worksheet.Cells
                .Select(cell => cell.Start.Row)
                .Distinct()
                .OrderBy(x => x);

            //Create the collection container
            var collection = rows.Skip(1)
                .Select(row =>
                {
                    var newModel = new T();
                    columns.ForEach(col =>
                    {
                        //This is the real wrinkle to using reflection - Excel stores all numbers as double including int
                        var val = worksheet.Cells[row, col.Column];
                        //If it is numeric it is a double since that is how excel stores all numbers
                        if (val.Value == null)
                        {
                            col.Property.SetValue(newModel, null);
                            return;
                        }

                        if (col.Property.PropertyType == typeof(int))
                        {
                            col.Property.SetValue(newModel, val.GetValue<int>());
                            return;
                        }

                        if (col.Property.PropertyType == typeof(double))
                        {
                            col.Property.SetValue(newModel, val.GetValue<double>());
                            return;
                        }

                        if (col.Property.PropertyType == typeof(DateTime))
                        {
                            col.Property.SetValue(newModel, val.GetValue<DateTime>());
                            return;
                        }

                        //Its a string
                        col.Property.SetValue(newModel, val.GetValue<string>());
                    });

                    return newModel;
                });


            //Send it back
            return collection;
        }
    }
}
