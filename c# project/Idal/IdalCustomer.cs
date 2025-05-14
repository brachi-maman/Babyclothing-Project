using Dto.dto_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Idal
{
    public interface IdalCustomer
    {
      

            //CRUD- create,Read,Update<Delete מממשק תשתיתי שיכיל את פעולות היסוד
            //למחלקה שיהיו פונקציות נוספות ניצור ממשק נוסף שימממש ממשק זה ויכיל את המתודות הנוספות

            public Task<List<CustomerDto>> SelectAll();
            //public Task<CustomerDto> GetById(int id);
            public Task<CustomerDto> Add(CustomerDto customer);

            public Task<CustomerDto> Login(MailAddress address , string password);

           

    }


}
