using Courses.Infrastructure.Models;
using Courses.Infrastructure.Services;

namespace Courses.Infrastructure.GraphQL.Queries;

public class Query(ICourseService courseService)
{
    private readonly ICourseService _courseService = courseService;

    [GraphQLName("getCourseById")]
    public async Task<Course> GetCourseByIdAsync(string id)
    {
        return await _courseService.GetCourseByIdAsync(id);
    }

    [GraphQLName("getAllCourses")]
    public async Task<IEnumerable<Course>> GetCoursesAsync()
    {
        return await _courseService.GetCoursesAsync();
    }
}
