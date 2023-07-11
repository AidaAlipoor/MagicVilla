namespace DataAccess.Entities
{
    public class VillaNumber
    {
        public int Id { get; set; }
        public int VillaId { get; set; }
        public virtual Villa Villa { get; set; }
        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
