using AutoMapper;
using Pledgewise.Common.Web.Model.Common;
using Pledgewise.Common.Web.Model.Entity;
using Pledgewise.Common.Web.RequestResponse.Entity;
using Pledgewise.Host.Backend.Dal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Pledgewise.Common.Web.RequestResponse.Pledge;
using Pledgewise.Common.Web.Model.Pledge;

namespace Pledgewise.Host.Backend.Controllers
{
    [Route("api/pledge")]
    [ApiController]
    public class PledgeController : ControllerBase
    {
        private readonly MainDbContext _context;
        private readonly IMapper mapper;

        public PledgeController(MainDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        [Produces(typeof(GetPledgesWebResponseDTO))]
        [HttpGet]
        public ActionResult<GetPledgesWebResponseDTO> Get([FromQuery] GetPledgesWebRequestDTO request)
        {
            return new JsonResult(new GetPledgesWebResponseDTO
            {
                Pledges = new PaginatedDataWebDTO<PledgeWebDTO>
                {
                    Count = request.Count,
                    Page = request.Page,
                    TotalPages = 1,
                    TotalCount = 5,
                    Items = new List<PledgeWebDTO>
                    {
                        new PledgeWebDTO {
                        }
                    }
                }
            });
        }
    }
}