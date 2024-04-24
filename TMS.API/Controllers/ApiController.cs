using Microsoft.AspNetCore.Mvc;

namespace TMS.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ApiController : ControllerBase
    {
    }
}
