using Dto.dto_classes;
using Dto;
using Ibll;
using Idal;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mail;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public CustomerController(ICustomerBll c)
        {
            this.c = c;
        }

        ICustomerBll c;
        [HttpGet("GetAllCustomers")]
        public async Task<List<CustomerDto>> Get()
        {
            return await c.SelectAll();
        }
        [HttpPost("addCustomer")]
        public async Task<CustomerDto> Post([FromBody] CustomerDto customer)
        {
            return await c.Add(customer); // מוסיפה לקוח חדש
        }
        public class LoginRequest
        {
            public string Email { get; set; } // השתמש ב-string במקום MailAddress
            public string Password { get; set; }
        }

        [HttpPost("login")]
        //שולחים מה body אוביקט
        public async Task<ActionResult<CustomerDto>> Post([FromBody] LoginRequest loginRequest)
        {   //שליפת המייל מתוך האובייקט - והמרה
            var mailAddress = new MailAddress(loginRequest.Email);
            //שליפת ה password מתוך האוביקט
            var customer = await c.Login(mailAddress, loginRequest.Password);

            if (customer == null)
            {
                return NotFound(); // החזר שגיאה אם הלקוח לא נמצא
            }

            return Ok(customer); // החזר את אובייקט הלקוח
        }
    }
}





