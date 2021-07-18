using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuickBase.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var interfaceTypeName = typeof(IMapFrom<>).Name;

            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(x => x.Name.Contains(interfaceTypeName)))
                .ToList();


            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetInterfaces().First(x => x.Name.Contains(interfaceTypeName)).GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
