namespace FiltersInASPNETCoreMVCApp.Models
{
    public class CustomModel
    {
       
        public string? Name { get; set; }
        public string? Adress { get; set; }

        public void DataTransform()
        {
            // Implement your custom logic here
            Name += " - Action Filter Executed";
            Adress += " - Action Filter Executed";

        }
    }
}
