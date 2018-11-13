namespace Chushka.Web.ViewModels.Products
{
    using System.ComponentModel.DataAnnotations;

    public class CreateProductViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a product name")]
        [StringLength(50, ErrorMessage ="The product's name must be between 6 and 50 characters long.", MinimumLength = 6)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a product price")]
        public decimal Price { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a product description")]
        [StringLength(100, ErrorMessage = "The description must be between 6 and 50 characters long.", MinimumLength = 6)]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You must choose a product type.")]
        public string ProductType { get; set; }
    }
}