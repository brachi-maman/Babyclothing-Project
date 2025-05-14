using Dto.dto_classes;
using Dto;
using Ibll;
using Idal;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Dal.Models;
using System.Net.Mail;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(IproductBll c)
        {
            this.c = c;
        }

        IproductBll c;
        [HttpGet]
        public async Task<List<ProductDto>> Get() 
        {
            return await c.SelectAll();
        }

        [HttpGet("news")]
        public async Task<List<ProductDto>> GetN()
        {
            return await c.SelectNewsProduct();
        }
        public class FilterRequest
        {
            public int? categoryId { get; set; }
            public int? companyId { get; set; }
            public string? gender { get; set; }
        }

        [HttpPost("getBySFilters")]
        public async Task<ActionResult<ProductDto>> Post([FromBody] FilterRequest filterRequest)

        {
            //שליפת המייל מתוך האובייקט - והמרה
            //שליפת ה password מתוך האוביקט


            var products = await c.getByCategory(filterRequest.categoryId, filterRequest.companyId, filterRequest.gender);

            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        [HttpPost("addProduct")]
        public async Task<IActionResult> AddProduct([FromForm] ProductDto productDto)
        {
            if (productDto.ImageFile == null || productDto.ImageFile.Length == 0)
            {
                return BadRequest("Please upload an image.");
            }

            // שמירת התמונה בתיקיית wwwroot/uploads
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // יצירת שם ייחודי לקובץ
            var uniqueFileName = $"{Guid.NewGuid()}_{productDto.ImageFile.FileName}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await productDto.ImageFile.CopyToAsync(stream);
            }

            // שמירת הנתיב היחסי ב-DB
            productDto.ImageUrl = $"/upload/{uniqueFileName}";

            // שמירת המוצר במסד הנתונים
            var newProduct = new ProductDto
            {
                ProductName = productDto.ProductName,
                CategoryId = productDto.CategoryId,
                CompanyId = productDto.CompanyId,
                DescriptionProducts = productDto.DescriptionProducts,
                Price = productDto.Price,
                ImageUrl = productDto.ImageUrl,  // הנתיב לתמונה שנשמר בשרת
                StockQuantity = productDto.StockQuantity,
                LastUpdated = DateTime.UtcNow,
                Season = productDto.Season,
                Size = productDto.Size,
                Gender = productDto.Gender,
            };

            await c.AddProduct(newProduct);

            return Ok(newProduct);
        }
    }
}





