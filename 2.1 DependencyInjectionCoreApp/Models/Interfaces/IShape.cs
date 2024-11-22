namespace DependencyInjectionCoreApp.Models.Interfaces
{
    public interface IShape
    {
        public void GetInputValues(decimal input);
        public decimal DisplaySurfaceArea();
        public decimal DisplayVolume();
    }
}
