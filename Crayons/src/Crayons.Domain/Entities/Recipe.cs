namespace Crayons.Domain.Entities
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }
        public string Ingrediences { get; set; }
        public string Steps { get; set; }
    }
}