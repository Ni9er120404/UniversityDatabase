using LaboratoryWorkOnDatabase.Data;
using LaboratoryWorkOnDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryWorkOnDatabase.Services.TeacherService
{
    public class TeacherService(Context context) : ITeacherService
    {
        private readonly Context _context = context;

        public async Task<Teacher> Create(Teacher item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                await _context.Teachers.AddAsync(item);
                return item;
            }
        }

        public async Task<Teacher> Delete(int id)
        {
            Teacher? item = await _context.Teachers.FirstOrDefaultAsync(x => x.TeacherId == id);

            if (item is null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            else
            {
                _context.Teachers.Remove(item);
                return item;
            }
        }

        public async Task<Teacher> Get(int id)
        {
            var item = await _context.Teachers.FirstOrDefaultAsync(x => x.TeacherId == id);

            if (item is null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            else
            {
                return item;
            }
        }

        public async Task<IEnumerable<Teacher>> GetAll()
        {
            var items = await _context.Teachers.ToListAsync();

            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            else
            {
                return items;
            }
        }

        public async Task<Teacher> Update(Teacher item)
        {
            Teacher? teacher = await _context.Teachers.FirstOrDefaultAsync(x => x == item);

            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                _context.Teachers.Update(item);
                
                return item;
            }
        }
    }
}