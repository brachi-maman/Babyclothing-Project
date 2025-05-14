using Dto.dto_classes;
using Dto;
using Ibll;
using Idal;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderControllers : ControllerBase
    {
        public OrderControllers(IorderBll c)
        {
            this.c = c;
        }

        IorderBll c;

        [HttpGet]
        public async Task<List<OrderDto>> Get()
        {
            return await c.SelectAll();
        }
    }
}





