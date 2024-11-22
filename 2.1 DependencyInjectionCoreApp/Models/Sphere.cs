using DependencyInjectionCoreApp.Models.Interfaces;

namespace DependencyInjectionCoreApp.Models
{
    public class Sphere :IShape
    {
        public decimal Radius { get; set; }
        public decimal SurfaceVal { get; set; }
        public decimal Volume { get; set; }

        public void GetInputValues(decimal input)
        {
            Radius = input;
        }

        public decimal DisplaySurfaceArea()
        {
            SurfaceVal = 4 * 314m * Radius * Radius;
            return SurfaceVal;
        }

        public decimal DisplayVolume()
        {
            Volume = 4/3*3.14m* Radius*Radius*Radius;
            return Volume;
        }
    }
}
