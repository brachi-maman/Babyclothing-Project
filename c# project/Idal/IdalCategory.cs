using Dto.dto_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idal
{
    public interface IdalCategory
    {
        //CRUD- create,Read,Update<Delete מממשק תשתיתי שיכיל את פעולות היסוד
        //למחלקה שיהיו פונקציות נוספות ניצור ממשק נוסף שימממש ממשק זה ויכיל את המתודות הנוספות
        
            public Task<List<CategoryDto>> SelectAll();
         
        }
    
}
