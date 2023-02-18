using univercityApiBackend.Models.DataModels;

namespace univercityApiBackend.Services
{
    public interface IEstudentService
    {
        IEnumerable<Student> GetStudentWithCourses();
        IEnumerable<Student> GetStudentWithNotCourses();
    }
}
