using Microsoft.AspNetCore.Mvc;

namespace Veturilo.API.Attributes
{
    public class VeturiloV1Route : RouteAttribute
    {
        public VeturiloV1Route() : base("api/v1/[controller]")
        {
        }
    }
}
