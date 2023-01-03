using AutoMapper;
using CT.Common.Web.Model.Common;
using CT.Common.Web.Model.Entity;
using CT.Common.Web.RequestResponse.Entity;
using CT.Host.Backend.Dal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CT.Host.Backend.Controllers
{
    [Route("api/entity")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private readonly MainDbContext _context;
        private readonly IMapper mapper;

        public EntityController(MainDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        [Produces(typeof(GetEntitiesWebResponseDTO))]
        [HttpGet]
        public ActionResult<GetEntitiesWebResponseDTO> Get([FromQuery] GetEntitiesWebRequestDTO request)
        {
            return new JsonResult(new GetEntitiesWebResponseDTO
            {
                Entities = new PaginatedDataWebDTO<EntityWebDTO>
                {
                    Count= request.Count,
                    Page = request.Page,
                    TotalPages = 1,
                    TotalCount = 5,
                    Items = new List<EntityWebDTO>
                    {
                        new EntityWebDTO {
                            
                        }
                    }
                }
            });
        }
    }
}
