using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _6MKT.BackOffice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IMapper mapper, IPurchaseService purchaseService)
        {
            _mapper = mapper;
            _purchaseService = purchaseService;
        }


    }
}
