using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
    internal class Company_converter
    {
        public static Dto.dto_classes.CompanyDto ToCompanyDto(Models.Company c)
        {
            Dto.dto_classes.CompanyDto cNew = new Dto.dto_classes.CompanyDto();
            cNew.CompanyId = c.CompanyId;
            cNew.CompanyName = c.CompanyName;

            return cNew;
        }
        public static List<Dto.dto_classes.CompanyDto> ToListCompanyDto(List<Models.Company> lc)
        {
            List<Dto.dto_classes.CompanyDto> lnew = new List<Dto.dto_classes.CompanyDto>();
            foreach (Models.Company c in lc)
            {
                lnew.Add(ToCompanyDto(c));
            }
            return lnew;
        }

        public static Models.Company ToCompany(Models.Company c)
        {
            Models.Company cNew = new Models.Company();
            cNew.CompanyName = c.CompanyName;
            return cNew;
        }
    }

}
