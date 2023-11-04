namespace MagicVilla_Web.Models.ViewModels
{
    public sealed class VillaViewModel
    {
        public string? Name { get; set; }
        public string? Detail { get; set; }
        public double Rate { get; set; }
        public int Price { get; set; }
        public int Occupancy { get; set; }
        public string? ImageUrl { get; set; }
        public string? Amenity { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
