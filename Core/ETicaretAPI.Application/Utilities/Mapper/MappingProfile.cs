using System.Reflection;
using AutoMapper;

namespace ETicaretAPI.Application.Utilities.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            var entry = Assembly.GetEntryAssembly();
            var assemblies = new List<Assembly>
            {
                entry,
                Assembly.GetExecutingAssembly()
            };

            if (entry != null)
            {
                var referencedAssemblyNames = 
                    entry.GetReferencedAssemblies()
                        .Where(asmName => 
                            (asmName.Name?.StartsWith("Project") ?? false) ||
                            (asmName.Name?.StartsWith("System") ?? false)
                            );

                foreach (var referencedAssemblyName in referencedAssemblyNames)
                {
                    if (assemblies.All(asm => 
                            asm.FullName != referencedAssemblyName.FullName))
                    {
                        assemblies.Add(
                            Assembly.Load(referencedAssemblyName));
                    }
                }
            }

            ApplyMappingsFromAssembly(assemblies.ToArray());
        }
        public MappingProfile(params Assembly[] assemblies)
        {
            ApplyMappingsFromAssembly(assemblies);
        }

        private void ApplyMappingsFromAssembly(params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetExportedTypes()
                    .Where(t => t.GetInterfaces().Any(i =>
                        i.IsGenericType && (i.GetGenericTypeDefinition() == typeof(IMapFrom<>) || i.GetGenericTypeDefinition() == typeof(IMapTo<>))))
                    .ToList();

                foreach (var type in types)
                {
                    var instance = Activator.CreateInstance(type);
                    var interfaces = type
                        .GetInterfaces()
                        .Where(i => i.IsGenericType);

                    foreach (var i in interfaces)
                    {
                        var typeDef = i.GetGenericTypeDefinition();
                        Type mapperType = null;
                        if (typeDef == typeof(IMapFrom<>))
                        {
                            mapperType = type.GetInterface("IMapFrom`1");
                        }

                        else if (typeDef == typeof(IMapTo<>))
                        {
                            mapperType = type.GetInterface("IMapTo`1");
                        }

                        mapperType?.GetMethod("Mapping")?
                            .Invoke(instance, new object[] { this });
                    }
                }
            }
        }
    }

}
