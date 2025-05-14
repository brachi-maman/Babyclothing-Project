using Dal.Models;
using Dto.dto_classes;
using Ibll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Customer_Bll : ICustomerBll
    {
        Idal.IdalCustomer c;
        public Customer_Bll(Idal.IdalCustomer c)
        {
            this.c = c;
        }

        public async Task<List<CustomerDto>> SelectAll()
        {
            return await c.SelectAll();
        }

        public async Task<CustomerDto> Add(CustomerDto customer)
        {
            return await c.Add(customer); // קריאה לפונקציה ב-DAL להוספת לקוח חדש
        }


        //ליצור פונקציה שבודקת תקינות של מייל וכל פעם שנצטרך בדיקת תקינות על מייל נקרא לפונקציה הזו
        public async Task<CustomerDto> Login(MailAddress address , string password)
        {
            return await c.Login(address, password);  
        }

    }
}
