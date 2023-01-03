using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Pledgewise.Host.Backend.OpenApi
{
    public static class OpenApiExtensions
    {
        public static string DefaultSchemaIdSelector(Type modelType)
        {
            if (!modelType.IsConstructedGenericType)
            {
                return modelType.Name;
            }
            var prefix = modelType.GetGenericArguments()
                .Select(genericArg => DefaultSchemaIdSelector(genericArg))
                .Aggregate((previous, current) => previous + current);

            return prefix + modelType.Name.Split('`').First();
        }

        public static string DefaultOperationIdSelector(ApiDescription e)
        {
            return $"{e.ActionDescriptor.RouteValues["controller"]}_{e.ActionDescriptor.RouteValues["action"]}";
        }
    }
}
