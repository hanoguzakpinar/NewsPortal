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
    public class ReportManager : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReportManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<ReportDto>> Get(int reportId)
        {
            var report = await _unitOfWork.Reports.GetAsync(r => r.Id == reportId, r => r.User, r => r.Category);
            if (report is not null)
            {
                return new DataResult<ReportDto>(ResultStatus.Success, new ReportDto
                {
                    Report = report,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ReportDto>(ResultStatus.Error, "Böyle bir haber bulunamadı.", null);
        }

        public async Task<IDataResult<ReportListDto>> GetAll()
        {
            var reports = await _unitOfWork.Reports.GetAllAsync(null, r => r.User, r => r.Category);
            if (reports.Count > -1)
            {
                return new DataResult<ReportListDto>(ResultStatus.Success, new ReportListDto
                {
                    Reports = reports,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ReportListDto>(ResultStatus.Error, "Haberler bulunamadı.", null);
        }

        public async Task<IDataResult<ReportListDto>> GetAllNonDeleted()
        {
            var reports = await _unitOfWork.Reports.GetAllAsync(r => !r.IsDeleted, r => r.User, r => r.Category);
            if (reports.Count > -1)
            {
                return new DataResult<ReportListDto>(ResultStatus.Success, new ReportListDto
                {
                    Reports = reports,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ReportListDto>(ResultStatus.Error, "Haberler bulunamadı.", null);
        }

        public async Task<IDataResult<ReportListDto>> GetAllNonDeletedAndActive()
        {
            var reports = await _unitOfWork.Reports.GetAllAsync(r => !r.IsDeleted && r.IsActive, r => r.User, r => r.Category);
            if (reports.Count > -1)
            {
                return new DataResult<ReportListDto>(ResultStatus.Success, new ReportListDto
                {
                    Reports = reports,
                    ResultStatus = ResultStatus.Success
                });
            }

            return new DataResult<ReportListDto>(ResultStatus.Error, "Haberler bulunamadı.", null);
        }

        public async Task<IDataResult<ReportListDto>> GetAllByCategory(int categoryId)
        {
            var category = await _unitOfWork.Categories.AnyAsync(c => c.Id == categoryId);
            if (category)
            {
                var reports = await _unitOfWork.Reports.GetAllAsync(r => r.CategoryId == categoryId && !r.IsDeleted && r.IsActive, r => r.User, r => r.Category);
                if (reports.Count > -1)
                {
                    return new DataResult<ReportListDto>(ResultStatus.Success, new ReportListDto
                    {
                        Reports = reports,
                        ResultStatus = ResultStatus.Success
                    });
                }
                return new DataResult<ReportListDto>(ResultStatus.Error, "Haberler bulunamadı.", null);
            }
            return new DataResult<ReportListDto>(ResultStatus.Error, "Kategori bulunamadı.", null);
        }

        public async Task<IResult> Add(ReportAddDto reportAddDto, string createdByName)
        {
            var report = _mapper.Map<Report>(reportAddDto);
            report.CreatedByName = createdByName;
            report.ModifiedByName = createdByName;
            report.UserId = 1;

            await _unitOfWork.Reports.AddAsync(report).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success,
                $"{reportAddDto.Title} başlıklı haber eklenmiştir.");
        }

        public async Task<IResult> Update(ReportUpdateDto reportUpdateDto, string modifiedByName)
        {
            var report = _mapper.Map<Report>(reportUpdateDto);
            report.ModifiedByName = modifiedByName;

            await _unitOfWork.Reports.UpdateAsync(report).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success,
                $"{reportUpdateDto.Title} başlıklı haber güncellenmiştir.");
        }

        public async Task<IResult> Delete(int reportId, string modifiedByName)
        {
            var status = await _unitOfWork.Reports.AnyAsync(r => r.Id == reportId);
            if (status)
            {
                var report = await _unitOfWork.Reports.GetAsync(r => r.Id == reportId);
                report.IsDeleted = true;
                report.ModifiedByName = modifiedByName;
                report.ModifiedDate = DateTime.Now;

                await _unitOfWork.Reports.UpdateAsync(report).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success,
                    $"{report.Title} başlıklı haber silinmiştir.");
            }
            return new Result(ResultStatus.Success,
                "Böyle bir haber bulunamadı.");
        }

        public async Task<IResult> HardDelete(int reportId)
        {
            var status = await _unitOfWork.Reports.AnyAsync(r => r.Id == reportId);
            if (status)
            {
                var report = await _unitOfWork.Reports.GetAsync(r => r.Id == reportId);

                await _unitOfWork.Reports.DeleteAsync(report).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success,
                    $"{report.Title} başlıklı haber veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Success,
                "Böyle bir haber bulunamadı.");
        }
    }
}