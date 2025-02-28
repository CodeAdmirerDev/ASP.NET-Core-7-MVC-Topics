namespace FiltersInASPNETCoreMVCApp.Models
{
    public class CustomModel
    {
       
        public string? Name { get; set; }
        public string? Address { get; set; }

        public void DataTransform()
        {
            // Implement your custom logic here
            Name += " - Action Filter Executed";
            Address += " - Action Filter Executed";

        }
    }
}
