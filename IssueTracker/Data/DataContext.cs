using IssueTracker.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Designation> Designation { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<IssueLog> IssueLog { get; set; }
        public DbSet<IssueLogInvolvedPerson> IssueLogInvolvedPerson { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Notification> Notification { get; set; }        
        public DbSet<ProjectSupportPerson> ProjectSupportPerson { get; set; }
        public DbSet<ProjectContactPerson> ProjectContactPerson { get; set; }
        public DbSet<ProjectWiseStatus> ProjectWiseStatus { get; set; }
        //public DbSet<Message> Message { get; set; }
    }
}
