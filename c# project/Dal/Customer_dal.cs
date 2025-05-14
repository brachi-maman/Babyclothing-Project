using Dal.Converters;
using Dal.Models;
using Dto.dto_classes;
using Idal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Customer_dal : IdalCustomer
    {

        public async Task<List<CustomerDto>> SelectAll()
        {
            BabyClothingStoreContext db = new BabyClothingStoreContext();
            var q = await db.Customers.ToListAsync();
            return CustomerConverter.ToListCustomerDto(q);
        }

        public async Task<CustomerDto> Add(CustomerDto c)
        {
            BabyClothingStoreContext db = new BabyClothingStoreContext();
            var customer = CustomerConverter.ToCustomer(c); // המרת DTO לאובייקט מודל
            db.Customers.Add(customer); // הוספת הלקוח לבסיס הנתונים
            await db.SaveChangesAsync(); // שמירת השינויים
            return CustomerConverter.ToCustomer(customer); // המרת הלקוח שנשמר בחזרה ל-DTO
        }
        public async Task<CustomerDto> Login(MailAddress address, string password)
        {
            BabyClothingStoreContext db = new BabyClothingStoreContext();
            var customer =await db.Customers.FirstOrDefaultAsync(c => c.Email.Equals(address.Address) && c.PasswordCustomer == password);
            if (customer != null)
                return CustomerConverter.ToCustomer(customer);
            return null;

        }

    }
    }




