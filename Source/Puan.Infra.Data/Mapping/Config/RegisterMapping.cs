using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Puan.Infra.Data.Interfaces.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Puan.Infra.Data.Mapping.Config
{
    public class RegisterMapping
    {
        public static void Register()
        {
            if(FluentMapper.EntityMaps.Count == 0)
            {
                FluentMapper.Initialize(config =>
                    {
                        var typesToMapping = Assembly.Load("Puan.Infra.Data")
                                            .GetTypes()
                                            .Where(x => x.IsClass && typeof(IMapping).IsAssignableFrom(x))
                                            .ToList();

                        foreach(var mappping in typesToMapping)
                        {
                            dynamic mappingClass = Activator.CreateInstance(mappping);
                            config.AddMap(mappingClass);
                        }
                        config.ForDommel();
                    }
                    );
            }
        }
    }
}
