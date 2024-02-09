using DependencyInjectionCoreApp.Enums;
using DependencyInjectionCoreApp.Models.Interfaces;

namespace DependencyInjectionCoreApp.FactoryDP
{
    public interface IShapeFactory
    {
        public IShape GetShape(ShapeEnum shapeEnum);
    }
}
