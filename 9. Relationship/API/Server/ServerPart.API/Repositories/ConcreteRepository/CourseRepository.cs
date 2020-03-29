using ServerPart.Domain.Entities;
using ServerPart.API.EFDbContext;

namespace ServerPart.API.Repositories
{
    public class CourseRepository : GenericRepostiry<Course>, ICourseRepository
    {
        FLCenterDbContext fLCenterDbContext = new FLCenterDbContext();
    }







}