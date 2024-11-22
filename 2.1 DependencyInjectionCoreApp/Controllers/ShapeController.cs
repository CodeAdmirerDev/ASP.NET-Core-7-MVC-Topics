using DependencyInjectionCoreApp.FactoryDP;
using DependencyInjectionCoreApp.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionCoreApp.Controllers
{
    public class ShapeController : Controller
    {

        private readonly IShapeFactory _shapeFactory;
        private IShape _shape;

       public ShapeController(IShapeFactory shapeFactory)
        {
            _shapeFactory = shapeFactory;
        }



        public IShape GetShapeBasedOnUserInput(int shapeType, decimal shapeValue)
        {

            switch(shapeType)
            {

                case 1:
                    return _shapeFactory.GetShape(Enums.ShapeEnum.Sphere);
                case 2:
                    return _shapeFactory.GetShape(Enums.ShapeEnum.Cube);
                default:
                    throw new ArgumentOutOfRangeException("Invalid input");

            }
        }

        public JsonResult UserInput(int shapeType,decimal shapeValue)
        {
            try
            {
                _shape = GetShapeBasedOnUserInput(shapeType, shapeValue);
                _shape.GetInputValues(shapeValue);
                _shape.DisplaySurfaceArea();
                _shape.DisplayVolume();
            }catch(Exception ex)
            {
                return Json(ex.Message);
            }
            return Json(_shape);
        }
    }
}
