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
    public class CompnyControllers : ControllerBase
    {
        public CompnyControllers(ICompanyBll c)
        {
            this.c = c;
        }

        ICompanyBll c;
        [HttpGet]
        public async Task<List<CompanyDto>> Get()
        {
            return await c.SelectAll();
        }
    }
}





