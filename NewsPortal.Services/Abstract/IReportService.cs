using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPortal.Entities.Dtos;
using NewsPortal.Shared.Utilities.Results.Abstract;

namespace NewsPortal.Services.Abstract
{
    public interface IReportService
    {
        Task<IDataResult<ReportDto>> GetAsync(int reportId);
        Task<IDataResult<ReportUpdateDto>> GetReportUpdateDtoAsync(int reportId);
        Task<IDataResult<ReportListDto>> GetAllAsync();
        Task<IDataResult<ReportListDto>> GetAllNonDeletedAsync();
        Task<IDataResult<ReportListDto>> GetAllNonDeletedAndActiveAsync();
        Task<IDataResult<ReportListDto>> GetAllByCategoryAsync(int categoryId);
        Task<IDataResult<ReportListDto>> GetAllByDeletedAsync();
        Task<IResult> AddAsync(ReportAddDto reportAddDto, string createdByName, int userId);
        Task<IResult> UpdateAsync(ReportUpdateDto reportUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int reportId, string modifiedByName);
        Task<IResult> UndoDeleteAsync(int reportId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int reportId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}