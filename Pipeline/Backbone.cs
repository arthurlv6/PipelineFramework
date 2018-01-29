using System;
using System.Reflection;

namespace Pipeline
{
    public class Backbone
    {
        public void Initalize()
        {
                var types = Assembly.GetExecutingAssembly().GetExportedTypes();
                var maps = (from t in types
                            from i in t.GetInterfaces()
                            where i.IsGenericType &&
                            i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                            !t.IsAbstract &&
                            !t.IsInterface
                            select new
                            {
                                Source = i.GetGenericArguments()[0],
                                Destination = t
                            }).ToArray();

                foreach (var map in maps)
                {
                    Mapper.CreateMap(map.Source, map.Destination);
                }
        }
    }
}
