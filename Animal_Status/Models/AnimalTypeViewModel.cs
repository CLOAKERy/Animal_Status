namespace Animal_Status.Models
{
    public class AnimalTypeViewModel
    {
        public int TypeId { get; set; }

        public string TypeName { get; set; } = null!;

        public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
    }
}
