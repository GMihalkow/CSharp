namespace Chushka.Web.ViewModels.Products
{
    public class EditDeleteProductViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ShortDescription
        {
            get
            {
                return this.Description + "...";
            }
            set
            {

            }
        }

        public string LongDescription
        {
            get
            {
                if (this.Description != null)
                {
                    if (this.Description.Length > 50)
                    {
                        return this.Description.Substring(0, 50) + "...";
                    }
                }
                return null;
            }
            set
            {

            }
        }

        public string ProductType { get; set; }
    }
}