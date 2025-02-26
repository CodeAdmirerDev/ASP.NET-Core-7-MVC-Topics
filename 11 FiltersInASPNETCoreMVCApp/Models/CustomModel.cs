namespace FiltersInASPNETCoreMVCApp.Models
{
    public class CustomModel
    {
        public string? Name { get; set; }
        public string? Adress { get; set; }

        public void DataTransform()
        {
            // Implement your custom logic here
            Name += " - Transformed";
            Adress += " - Transformed";

        }
    }
}
