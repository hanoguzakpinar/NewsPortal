using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NewsPortal.Data.Abstract;
using NewsPortal.Entities.Concrete;
using NewsPortal.Entities.Dtos;
using NewsPortal.Services.Abstract;
using NewsPortal.Shared.Utilities.Results.Abstract;
using NewsPortal.Shared.Utilities.Results.ComplexTypes;
using NewsPortal.Shared.Utilities.Results.Concrete;

namespace NewsPortal.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<CategoryDto>> Get(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId, c => c.Reports);
            if (category is not null)
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = category,
                    ResultStatus = ResultStatus.Success
                });

            return new DataResult<CategoryDto>(ResultStatus.Error, "Böyle bir kategori bulunamadı.",
                null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(null, c => c.Reports);
            if (categories.Count > -1)
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });

            return new DataResult<CategoryListDto>(ResultStatus.Error, "Kategoriler bulunamadı.",
                null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAllNonDeleted()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c => !c.IsDeleted, c => c.Reports);
            if (categories.Count > -1)
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });

            return new DataResult<CategoryListDto>(ResultStatus.Error, "Kategoriler bulunamadı.",
                null);
        }

        public async Task<IDataResult<CategoryListDto>> GetAllNonDeletedAndActive()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c => !c.IsDeleted && c.IsActive, c => c.Reports);
            if (categories.Count > -1)
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });

            return new DataResult<CategoryListDto>(ResultStatus.Error, "Kategoriler bulunamadı.",
                null);
        }

        public async Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category = _mapper.Map<Category>(categoryAddDto);
            category.CreatedByName = createdByName;
            category.ModifiedByName = createdByName;
            await _unitOfWork.Categories.AddAsync(category)
            .ContinueWith(t => _unitOfWork.SaveAsync());
            //ContinueWith kullanarak ekleme işleminden sonra hızlı bir şekilde saveasync metodunu çağırır.
            //await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success,
                $"{categoryAddDto.Name} adlı kategori başarıyla eklenmiştir.");
        }

        public async Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);
            category.ModifiedByName = modifiedByName;


            await _unitOfWork.Categories.UpdateAsync(category)
                .ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success,
                $"{categoryUpdateDto.Name} adlı kategori başarıyla güncellenmiştir.");

        }

        public async Task<IResult> Delete(int categoryId, string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category is not null)
            {
                category.IsDeleted = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now; ;
                await _unitOfWork.Categories.UpdateAsync(category)
                    .ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success,
                    $"{category.Name} adlı kategori başarıyla silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle bir kategori bulunamadı.");
        }

        public async Task<IResult> HardDelete(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category is not null)
            {
                await _unitOfWork.Categories.DeleteAsync(category)
                    .ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success,
                    $"{category.Name} adlı kategori başarıyla veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle bir kategori bulunamadı.");
        }
    }
}