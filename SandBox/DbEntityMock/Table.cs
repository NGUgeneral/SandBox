using System.Collections.Generic;

namespace SandBox.DbEntityMock
{
    public class Table
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Column<string>> Columns { get; set; }

    }
}