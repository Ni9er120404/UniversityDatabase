using LaboratoryWorkOnDatabase.Models;

namespace LaboratoryWorkOnDatabase.Services.TeacherService
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAll();

        Task<Teacher> Get(int id);

        Task<Teacher> Create(Teacher item);

        Task<Teacher> Update(Teacher item);

        Task<Teacher> Delete(int id);
    }
}