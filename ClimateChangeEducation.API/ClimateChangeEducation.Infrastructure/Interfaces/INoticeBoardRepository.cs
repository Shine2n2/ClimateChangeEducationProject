using ClimateChangeEducation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Infrastructure.Interfaces
{
    public interface INoticeBoardRepository
    {
        //-----Notice Board
        Task<List<NoticeBoard>> GetAllNoticesAsync();
        Task<NoticeBoard> GetNoticeByIdAsync(string id);
        Task<NoticeBoard> GetNoticesBySchoolIdAsync(string id);
        Task<NoticeBoard> GetAllPublishedNoticesBySchoolIdAsync(string id);
        Task<NoticeBoard> GetAllPublishedNoticesAsync();
        Task<NoticeBoard> CreateNoticeAsync(NoticeBoard request);
        Task<NoticeBoard> UpdateNoticeAsync(string id, NoticeBoard request);
        Task<bool> DeleteNotice(string request);
        Task<bool> ExistsNoticeAsync(string id);
    }
}
