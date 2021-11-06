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
using NewsPortal.Services.Utilites;
using NewsPortal.Shared.Utilities.Results.Abstract;
using NewsPortal.Shared.Utilities.Results.ComplexTypes;
using NewsPortal.Shared.Utilities.Results.Concrete;

namespace NewsPortal.Services.Concrete
{
    public class ReportManager : ManagerBase, IReportService
    {
        public ReportManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IDataResult<ReportDto>> GetAsync(int reportId)
        {
            var report = await UnitOfWork.Reports.GetAsync(r => r.Id == reportId, r => r.User, r => r.Category);
            if (report is not null)
            {
                return new DataResult<ReportDto>(ResultStatus.Success, new ReportDto
                {
                    Report = report,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ReportDto>(ResultStatus.Error, Messages.Report.NotFound(isPlural: false), null);
        }

        public async Task<IDataResult<ReportUpdateDto>> GetReportUpdateDtoAsync(int reportId)
        {
            var result = await UnitOfWork.Reports.AnyAsync(c => c.Id == reportId);
            if (result)
            {
                var report = await UnitOfWork.Reports.GetAsync(c => c.Id == reportId);
                var reportUpdateDto = Mapper.Map<ReportUpdateDto>(report);

                return new DataResult<ReportUpdateDto>(ResultStatus.Success, reportUpdateDto);
            }
            else
            {
                return new DataResult<ReportUpdateDto>(ResultStatus.Error, Messages.Report.NotFound(isPlural: false), null);
            }
        }

        public async Task<IDataResult<ReportListDto>> GetAllAsync()
        {
            var reports = await UnitOfWork.Reports.GetAllAsync(null, r => r.User, r => r.Category);
            if (reports.Count > -1)
            {
                return new DataResult<ReportListDto>(ResultStatus.Success, new ReportListDto
                {
                    Reports = reports,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ReportListDto>(ResultStatus.Error, Messages.Report.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<ReportListDto>> GetAllNonDeletedAsync()
        {
            var reports = await UnitOfWork.Reports.GetAllAsync(r => !r.IsDeleted, r => r.User, r => r.Category);
            if (reports.Count > -1)
            {
                return new DataResult<ReportListDto>(ResultStatus.Success, new ReportListDto
                {
                    Reports = reports,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ReportListDto>(ResultStatus.Error, Messages.Report.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<ReportListDto>> GetAllNonDeletedAndActiveAsync()
        {
            var reports = await UnitOfWork.Reports.GetAllAsync(r => !r.IsDeleted && r.IsActive, r => r.User, r => r.Category);
            if (reports.Count > -1)
            {
                return new DataResult<ReportListDto>(ResultStatus.Success, new ReportListDto
                {
                    Reports = reports,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ReportListDto>(ResultStatus.Error, Messages.Report.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<ReportListDto>> GetAllByCategoryAsync(int categoryId)
        {
            var category = await UnitOfWork.Categories.AnyAsync(c => c.Id == categoryId);
            if (category)
            {
                var reports = await UnitOfWork.Reports.GetAllAsync(r => r.CategoryId == categoryId && !r.IsDeleted && r.IsActive, r => r.User, r => r.Category);
                if (reports.Count > -1)
                {
                    return new DataResult<ReportListDto>(ResultStatus.Success, new ReportListDto
                    {
                        Reports = reports,
                        ResultStatus = ResultStatus.Success
                    });
                }
                return new DataResult<ReportListDto>(ResultStatus.Error, Messages.Report.NotFound(isPlural: true), null);
            }
            return new DataResult<ReportListDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: false), null);
        }

        public async Task<IResult> AddAsync(ReportAddDto reportAddDto, string createdByName, int userId)
        {
            var report = Mapper.Map<Report>(reportAddDto);
            report.CreatedByName = createdByName;
            report.ModifiedByName = createdByName;
            report.UserId = userId;

            await UnitOfWork.Reports.AddAsync(report);
            await UnitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, Messages.Report.Add(reportAddDto.Title));
        }

        public async Task<IResult> UpdateAsync(ReportUpdateDto reportUpdateDto, string modifiedByName)
        {
            var oldReport = await UnitOfWork.Reports.GetAsync(r => r.Id == reportUpdateDto.Id);

            var report = Mapper.Map<ReportUpdateDto, Report>(reportUpdateDto, oldReport);
            report.ModifiedByName = modifiedByName;

            await UnitOfWork.Reports.UpdateAsync(report);
            await UnitOfWork.SaveAsync();

            return new Result(ResultStatus.Success, Messages.Report.Update(reportUpdateDto.Title));
        }

        public async Task<IResult> DeleteAsync(int reportId, string modifiedByName)
        {
            var status = await UnitOfWork.Reports.AnyAsync(r => r.Id == reportId);
            if (status)
            {
                var report = await UnitOfWork.Reports.GetAsync(r => r.Id == reportId);
                report.IsDeleted = true;
                report.ModifiedByName = modifiedByName;
                report.ModifiedDate = DateTime.Now;

                await UnitOfWork.Reports.UpdateAsync(report);
                await UnitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, Messages.Report.Delete(report.Title));
            }
            return new Result(ResultStatus.Success,
                Messages.Report.NotFound(isPlural: false));
        }

        public async Task<IResult> HardDeleteAsync(int reportId)
        {
            var status = await UnitOfWork.Reports.AnyAsync(r => r.Id == reportId);
            if (status)
            {
                var report = await UnitOfWork.Reports.GetAsync(r => r.Id == reportId);

                await UnitOfWork.Reports.DeleteAsync(report);
                await UnitOfWork.SaveAsync();

                return new Result(ResultStatus.Success, Messages.Report.HardDelete(report.Title));
            }
            return new Result(ResultStatus.Success,
                Messages.Report.NotFound(isPlural: false));
        }

        public async Task<IDataResult<int>> CountAsync()
        {
            var reportsCount = await UnitOfWork.Reports.CountAsync();
            if (reportsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, reportsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Hata oluştu.", -1);
            }
        }
        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var reportsCount = await UnitOfWork.Reports.CountAsync(c => !c.IsDeleted);
            if (reportsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, reportsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Hata oluştu.", -1);
            }
        }
    }
}