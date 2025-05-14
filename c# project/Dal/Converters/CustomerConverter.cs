using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
    internal class CustomerConverter
    {
     
            public static Dto.dto_classes.CustomerDto ToCustomer(Models.Customer c)
            {
                Dto.dto_classes.CustomerDto cNew = new Dto.dto_classes.CustomerDto();
                cNew.CustomerId = c.CustomerId;
                cNew.PasswordCustomer = c.PasswordCustomer;
                cNew.CustomerName = c.CustomerName;
                cNew.Phone = c.Phone;
                cNew.Email = c.Email;   
                cNew.BirthDate = c.BirthDate;

                return cNew;
            }
            public static List<Dto.dto_classes.CustomerDto> ToListCustomerDto(List<Models.Customer> lc)
            {
                List<Dto.dto_classes.CustomerDto> lnew = new List<Dto.dto_classes.CustomerDto>();
                foreach (Models.Customer c in lc)
                {
                    lnew.Add(ToCustomer(c));
                }
                return lnew;
            }


            public static Models.Customer ToCustomer(Dto.dto_classes.CustomerDto c)
            {
                Models.Customer cNew = new Models.Customer();
                //מאחר והשדה הוא מספור אוטומטי אין טעם ואפילו יגרום לשגיאה לעדכן אותו
                //    cNew.Courseid = c.Courseid;
                cNew.CustomerId = c.CustomerId;
                cNew.PasswordCustomer = c.PasswordCustomer;
                cNew.CustomerName = c.CustomerName;
                cNew.Phone = c.Phone;
                cNew.Email = c.Email;
                cNew.BirthDate = c.BirthDate;

                return cNew;
            }
        }
    }

