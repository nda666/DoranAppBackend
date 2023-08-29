using AutoMapper;

namespace DoranOfficeBackend.Extentsions
{
    public static class AutoMapperExtension
    {
        public static void AddAutoMapperFromNamespace(this IServiceCollection services, string targetNamespace)
        {
            // Find and register all profiles from the specified namespace
            var profileType = typeof(Profile);
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
            {
                var profiles = assembly.GetTypes()
                    .Where(t => t.IsSubclassOf(profileType) && t.Namespace == targetNamespace);

                foreach (var profile in profiles)
                {
                    services.AddAutoMapper(profile);
                }
            }
        }
    }
}
