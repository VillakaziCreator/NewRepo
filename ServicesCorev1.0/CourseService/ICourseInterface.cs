using ModelsCore.CourseModelCore;
using System.Collections.Generic;

namespace ServicesCorev1._0.CourseService
{
    public interface ICourseInterface
    {
        CourseModel AddCourse(CourseModel model);
        CourseModel FindCourseById(int Id);
        List<CourseModel> GetAllCourses();
        string UpdateCourse(CourseModel model);
        CourseModel DeleteCourse(string id);
    }
}
