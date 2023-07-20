using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DoranOfficeBackend
{
    public class SwaggerFromQuery : IOperationFilter
{
    
    
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var description = context.ApiDescription;
            if (description.HttpMethod.ToLower() != HttpMethod.Get.ToString().ToLower())
            {
                // Ignore other http methods for now
                return;
            }

            var actionParameters = description.ActionDescriptor.Parameters;
            var apiParameters = description.ParameterDescriptions
                    .Where(p => p.Source.IsFromRequest)
                    .ToList();

            if (actionParameters.Count == apiParameters.Count)
            {
                // If no complex query parameters detected, leave this operation as is, do not modify
                return;
            }

            foreach (var opParam in operation.Parameters)
            {
                if (actionParameters.Any(ap => ap.Name == opParam.Name))
                {
                    var actionParam = actionParameters.First(ap => ap.Name == opParam.Name);
                    if (actionParam.ParameterType == typeof(Dictionary<string, string>))
                        opParam.Style = ParameterStyle.DeepObject;
                }
            }
        }
    }
}
