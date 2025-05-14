using Dto.dto_classes;

namespace Ibll
{

    public interface IproductBll
    { 
        public Task<List<ProductDto>> SelectAll();
        public Task<List<ProductDto>> SelectNewsProduct();


        Task<List<ProductDto>> getByCategory(int? categoryid, int? companyId, string? gender);

        Task<ProductDto> AddProduct(ProductDto p);


    }
}


