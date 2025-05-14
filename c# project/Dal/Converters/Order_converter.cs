using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
    internal class Order_converter
    {

        public static Dto.dto_classes.OrderDto ToOrder(Models.Order c)
        {
            Dto.dto_classes.OrderDto cNew = new Dto.dto_classes.OrderDto();
            cNew.OrderId = c.OrdersId;
            cNew.CustomerId = c.CustomerId;
            cNew.OrderDate = c.OrderDate;
            cNew.TotalPayment = c.TotalPayment;
            cNew.Note = c.Note;
            cNew.Paid = c.Paid;



            //ונקבל את ערכה תוך שימוש בשדה הניווט Dtoהשדה הבא קיים רק במחלקה מסוג ה
            //if (c.Depart != null)
            //    //פה אנחנו נהנות משדה הניווט שלא דרש קש"ג מסובך אלא אפשר גישה ישירה לשדות טבלת המפתח זר
            //    //Depart = null אחרת שדה הinclude חובה בשלב השליפה לדאוג לבצע פעולת 
            //    cNew.DepartName = c.Depart.Name;
            return cNew;
        }
        public static List<Dto.dto_classes.OrderDto> ToListOrderDto(List<Models.Order> lc)
        {
            List<Dto.dto_classes.OrderDto> lnew = new List<Dto.dto_classes.OrderDto>();
            foreach (Models.Order c in lc)
            {
                lnew.Add(ToOrder(c));
            }
            return lnew;
        }


        public static Models.Order ToOrder(Dto.dto_classes.OrderDto c)
        {
            Models.Order cNew = new Models.Order();
            //מאחר והשדה הוא מספור אוטומטי אין טעם ואפילו יגרום לשגיאה לעדכן אותו
            //    cNew.Courseid = c.Courseid;
            cNew.OrdersId = c.OrderId;
            cNew.CustomerId = c.CustomerId;
            cNew.OrderDate = c.OrderDate;
            cNew.TotalPayment = c.TotalPayment;
            cNew.TotalPayment = c.TotalPayment;
            cNew.Note = c.Note;
            cNew.Paid = c.Paid;
            return cNew;
        }

    }
}