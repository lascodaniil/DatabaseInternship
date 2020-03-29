using ServerPart.Domain.Entities;
using ServerPart.API.EFDbContext;

namespace ServerPart.API.Repositories
{
    public class StudentRepository : GenericRepostiry<Student>, IStudentRepositoy
    {
        FLCenterDbContext fLCenterDbContext = new FLCenterDbContext();
    }







}