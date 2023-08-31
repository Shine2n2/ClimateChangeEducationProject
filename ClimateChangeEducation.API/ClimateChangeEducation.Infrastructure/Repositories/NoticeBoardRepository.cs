using ClimateChangeEducation.Domain.DTOs;
using ClimateChangeEducation.Domain.Entities;
using ClimateChangeEducation.Infrastructure.Data;
using ClimateChangeEducation.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Repositories
{
    public class NoticeBoardRepository : INoticeBoardRepository
    {
        private readonly ClimateDataContext _dataContext;
        public NoticeBoardRepository(ClimateDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<NoticeBoard> CreateNoticeAsync(NoticeBoard request)
        {
            var article = await _dataContext.Notices.AddAsync(request);
            await _dataContext.SaveChangesAsync();
            return article.Entity;
        }

        public async Task<bool> DeleteNotice(string request)
        {
            var result = await GetNoticeByIdAsync(request);
            if (result != null)
            {
                _dataContext.Notices.Remove(result);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ExistsNoticeAsync(string id)
        {
            return await _dataContext.Notices.AnyAsync(x => x.NoticeId == id);
        }

        public async Task<List<NoticeBoard>> GetAllNoticesAsync()
        {       
            return await _dataContext.Notices.ToListAsync();
        }

        public async Task<NoticeBoard> GetAllPublishedNoticesAsync()
        {
            return await _dataContext.Notices.FirstOrDefaultAsync(x => x.IsPublished == true);  
        }

        public async Task<NoticeBoard> GetAllPublishedNoticesBySchoolIdAsync(string schoolId)
        {
            //var result = from x in _dataContext.Notices
            //             where x.IsPublished == true && x.School.SchoolId == schoolId
            //             select x;
             return await _dataContext.Notices.FirstOrDefaultAsync(x => x.School.SchoolId == schoolId && x.IsPublished == true);           
        }

        public async Task<NoticeBoard> GetNoticeByIdAsync(string id)
        {
            return await _dataContext.Notices.FirstOrDefaultAsync(x => x.NoticeId == id);
        }

        public async Task<NoticeBoard> GetNoticesBySchoolIdAsync(string schoolId)
        {
            return await _dataContext.Notices.FirstOrDefaultAsync(x => x.School.SchoolId == schoolId);
        }

        public async Task<NoticeBoard> UpdateNoticeAsync(string id, NoticeBoard request)
        {
            var notice = await GetNoticeByIdAsync(id);
            if (notice != null)
            {
                notice.NoticeDescription = request.NoticeDescription;            
                notice.IsPublished = request.IsPublished;
                notice.NoticeContent = request.NoticeContent;
                notice.IsPublished = request.IsPublished;
                notice.PublishEndDateTime = request.PublishEndDateTime;
                notice.PublishStartDateTime = request.PublishStartDateTime;
                
                await _dataContext.SaveChangesAsync();
                return notice;
            }
            return null;
        }
    }
}
