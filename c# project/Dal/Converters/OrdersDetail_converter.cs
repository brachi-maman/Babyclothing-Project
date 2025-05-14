using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
    internal class OrdersDetail_converter
    {
            public static Dto.dto_classes.OrdersDetailDto ToOrderDetails(Models.OrdersDetail c)
            {
                Dto.dto_classes.OrdersDetailDto cNew = new Dto.dto_classes.OrdersDetailDto();
                cNew.OrderDetailId = c.OrdersDetailId; 
                cNew.OrderId = c.OrdersId;
                cNew.ProductId = c.ProductId;
                cNew.Quantity = c.Quantity;
                

            //ונקבל את ערכה תוך שימוש בשדה הניווט Dtoהשדה הבא קיים רק במחלקה מסוג ה
            //if (c.Depart != null)
            //    //פה אנחנו נהנות משדה הניווט שלא דרש קש"ג מסובך אלא אפשר גישה ישירה לשדות טבלת המפתח זר
            //    //Depart = null אחרת שדה הinclude חובה בשלב השליפה לדאוג לבצע פעולת 
            //    cNew.DepartName = c.Depart.Name;
            return cNew;
            }
            public static List<Dto.dto_classes.OrdersDetailDto> ToListOrdersDetailDto(List<Models.OrdersDetail> lc)
            {
                List<Dto.dto_classes.OrdersDetailDto> lnew = new List<Dto.dto_classes.OrdersDetailDto>();
                foreach (Models.OrdersDetail c in lc)
                {
                    lnew.Add(ToOrderDetails(c));
                }
                return lnew;
            }


            public static Models.OrdersDetail ToOrderDetails(Dto.dto_classes.OrdersDetailDto c)
            {
            Models.OrdersDetail cNew = new Models.OrdersDetail();
            //מאחר והשדה הוא מספור אוטומטי אין טעם ואפילו יגרום לשגיאה לעדכן אותו
            //    cNew.Courseid = c.Courseid;
            cNew.OrdersDetailId = c.OrderDetailId;
            cNew.OrdersId = c.OrderId;
            cNew.ProductId = c.ProductId;
            cNew.Quantity = c.Quantity;
            return cNew;
            }
        }
    }
