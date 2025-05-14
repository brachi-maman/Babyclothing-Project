using Dto.dto_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Ibll
{
    public interface ICustomerBll
    {
        public Task<List<CustomerDto>> SelectAll();

        Task<CustomerDto> Add(CustomerDto c);

        Task<CustomerDto> Login(MailAddress address , string password);

    }
}
