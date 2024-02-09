using System.Reflection;

namespace RosariumBackEnd.Service.Utils
{
    public class ObjectMapper
    {
        public static TOut Map<TIn, TOut>(TIn input, Action<TOut, TIn> customMapping = null)
            where TOut : new()
        {
            TOut output = new TOut();

            // Obter todas as propriedades de entrada e saída
            PropertyInfo[] inProperties = typeof(TIn).GetProperties();
            PropertyInfo[] outProperties = typeof(TOut).GetProperties();

            // Mapear as propriedades
            foreach (var outProp in outProperties)
            {
                PropertyInfo inProp = Array.Find(inProperties, p => p.Name == outProp.Name);

                if (inProp != null)
                {
                    // Se o mapeador personalizado for fornecido e corresponder à propriedade atual,
                    // use-o para fazer o mapeamento, caso contrário, faça o mapeamento padrão.
                    if (customMapping != null && IsCustomMappedProperty(outProp))
                    {
                        customMapping(output, input);
                    }
                    else
                    {
                        object value = inProp.GetValue(input);
                        outProp.SetValue(output, value);
                    }
                }
            }

            return output;
        }

        private static bool IsCustomMappedProperty(PropertyInfo property)
        {
            // Lista de propriedades que devem ser mapeadas usando a lógica personalizada
            List<string> customMappedProperties = new List<string> { "Data" /* Adicione mais propriedades, se necessário */ };

            return customMappedProperties.Contains(property.Name);
        }
    }
}
