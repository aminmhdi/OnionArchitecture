using Domain.DataModel.Contracts;

namespace Domain.DataModel
{
    public class Permission : IIntegerBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
