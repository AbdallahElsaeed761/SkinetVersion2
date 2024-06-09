using API.Error;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace API.Controllers
{
    [Route("Error/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErrorController : ControllerBase
    {
        public IActionResult Error(int code )
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
