using System;
using System.Collections.Generic;

namespace SandBox.DbEntityMock
{
    class TableExtensions
    {
        public static List<Table> GenerateTables(int tablesCount, int columnsCount)
        {
            var random = new Random();
            var tables = new List<Table>();

            for (int t = 0; t < tablesCount; t++)
            {
                var tId = t + 1;
                var table = new Table()
                {
                    Id = tId,
                    Name = $"table_{tId}",
                    Columns = new List<Column<string>>()
                };

                for (int c = 0; c < columnsCount; c++)
                {
                    var cId = c + 1;
                    var column = new Column<string>
                    {
                        Id = cId,
                        Name = $"{table.Name}_column_{cId}",
                        Value = random.Next(1, 100).ToString(),
                        Values = new List<string>()
                    };

                    for (int i = 0; i < 5; i++)
                        column.Values.Add(random.Next(0, 100).ToString());

                    table.Columns.Add(column);
                }
                tables.Add(table);
            }

            return tables;
        }
    }
}
