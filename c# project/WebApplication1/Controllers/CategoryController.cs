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
    public class CategoryControllers : ControllerBase
    {
        public CategoryControllers(IcategoryBll c)
        {
            this.c = c;
        }

        IcategoryBll c;
        [HttpGet]
        public async Task<List<CategoryDto>> Get()
        {
            return await c.SelectAll();
        }
    }
}



