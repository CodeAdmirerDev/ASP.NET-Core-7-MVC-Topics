using DependencyInjectionCoreApp.Models.Interfaces;

namespace DependencyInjectionCoreApp.Models
{
    public class Cube : IShape
    {


        public decimal Slide { get; set; }
        public decimal SurfaceVal { get; set; }
        public decimal Volume { get; set; }

        public void GetInputValues(decimal input)
        {
            Slide = input;
        }



        public decimal DisplaySurfaceArea()
        {
            SurfaceVal = 6 * Slide * Slide;
            return SurfaceVal;
        }

        public decimal DisplayVolume()
        {
            Volume = Slide * Slide * Slide; 
            return Volume;
        }


    }
}
