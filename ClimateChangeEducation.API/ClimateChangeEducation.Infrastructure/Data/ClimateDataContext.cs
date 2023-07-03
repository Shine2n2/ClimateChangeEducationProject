using ClimateChangeEducation.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClimateChangeEducation.Infrastructure.Data
{
    public class ClimateDataContext: IdentityDbContext<ApplicationUser>
    {
        public ClimateDataContext(DbContextOptions<ClimateDataContext> options):base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseEnrollment> CourseEnrollments { get; set; }
        public DbSet<CourseLesson> CourseLessons { get; set; }
        public DbSet<CourseModule> CourseModules { get; set; }
        public DbSet<DiscussionBoard> DiscussionBoards { get; set; }
        public DbSet<DiscussionBoardComment> DiscussionBoardComments { get; set; }
        public DbSet<DiscussionBoardPost> DiscussionBoardPost { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<QuizEnrollment> QuizEnrollments { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }                     
        public DbSet<NoticeBoard> Notices { get; set; }      
        public DbSet<UserRole> UserRoles { get; set; }      
        

    }
}
