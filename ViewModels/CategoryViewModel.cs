namespace LuminariasWeb.sln.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        // Propiedad de navegación para los productos relacionados
        public List<ProductViewModel> Products { get; set; }
    }

}
