using Asp.Versioning;
using Bookify.Application.Apartments.SearchApartments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.API.Controllers.Apartments
{
    [ApiController]
    [ApiVersion(ApiVersions.V1)]
    [Route("api/v{version:apiVersion}/apartments")]
    public class ApartmentsController : ControllerBase
    {
        private readonly ISender _sender;
        public ApartmentsController(ISender sender)
        {
            _sender = sender;
        }
        [HttpGet]
        public async Task<IActionResult> SearchApartments(
            DateTime startDate,
            DateTime endDate,
            CancellationToken cancellationToken)
        {
            var query = new SearchApartmentQuery(startDate, endDate);

            var result = await _sender.Send(query, cancellationToken);

            return Ok(result.Value);
        }
    }
}
