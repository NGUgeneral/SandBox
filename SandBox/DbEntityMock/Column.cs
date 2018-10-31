using System.Collections.Generic;

namespace SandBox.DbEntityMock
{
    public class Column<T>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Table Parent { get; set; }
        public T Value { get; set; }
        public List<T> Values { get; set; }
    }
}