using System.Reflection;

namespace RosariumBackEnd.Service.Interfaces
{
    public interface IObjectMapper
    {
        TOut Map<TIn, TOut>(TIn input, Action<TOut, TIn> customMapping = null);
        bool IsCustomMappedProperty(PropertyInfo property);
    }
}
