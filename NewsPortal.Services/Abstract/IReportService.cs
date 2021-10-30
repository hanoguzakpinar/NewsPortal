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
        Task<IDataResult<ReportDto>> Get(int reportId);
        Task<IDataResult<ReportListDto>> GetAll();
        Task<IDataResult<ReportListDto>> GetAllNonDeleted();
        Task<IDataResult<ReportListDto>> GetAllNonDeletedAndActive();
        Task<IDataResult<ReportListDto>> GetAllByCategory(int categoryId);
        Task<IResult> Add(ReportAddDto reportAddDto, string createdByName);
        Task<IResult> Update(ReportUpdateDto reportUpdateDto, string modifiedByName);
        Task<IResult> Delete(int reportId, string modifiedByName);
        Task<IResult> HardDelete(int reportId);
    }
}
