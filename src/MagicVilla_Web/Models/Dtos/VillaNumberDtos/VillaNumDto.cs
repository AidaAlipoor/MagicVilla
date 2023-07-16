namespace MagicVilla_Web.Models.Dtos.VillaNumberDtos
{
    public class VillaNumDto
    {
        public int Id { get; set; }
        public int VillaId { get; set; }
        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
