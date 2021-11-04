using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPortal.Entities.Dtos;
using NewsPortal.Shared.Utilities.Results.Abstract;

namespace NewsPortal.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> GetAsync(int categoryId);
        /// <summary>
        /// Verilen id parametresine ait kategorinin CategoryUpdateDto temsilini geriye döner.
        /// </summary>
        /// <param name="categoryId">0'dan büyük integer bir Id değeri.</param>
        /// <returns>Asenkron bir operasyon ile Task olarak DataResult döndürür.</returns>
        Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDtoAsync(int categoryId);
        Task<IDataResult<CategoryListDto>> GetAllAsync();
        Task<IDataResult<CategoryListDto>> GetAllNonDeletedAsync();
        Task<IDataResult<CategoryListDto>> GetAllNonDeletedAndActiveAsync();
        /// <summary>
        /// Parametreleri alarak yeni bir Category ekler.
        /// </summary>
        /// <param name="categoryAddDto"></param>
        /// <param name="createdByName">string tipinde kullanıcı adı</param>
        /// <returns>Asenkron Task olarak DataResult geri döndürür.</returns>
        Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto categoryAddDto, string createdByName);
        Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IDataResult<CategoryDto>> DeleteAsync(int categoryId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int categoryId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}