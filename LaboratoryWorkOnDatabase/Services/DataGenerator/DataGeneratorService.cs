using LaboratoryWorkOnDatabase.Data;
using LaboratoryWorkOnDatabase.Models;

namespace LaboratoryWorkOnDatabase.Services.DataGenerator
{
    public class DataGeneratorService
    {
        private List<Discipline>? _disciplines;
        private List<Form>? _forms;
        private List<Plan>? _plans;
        private List<Sheet>? _sheets;
        private List<Student>? _students;
        private List<Teacher>? _teachers;
        private List<TeacherDiscipline>? _teacherDisciplines;
        private List<Title>? _titles;

        public async Task SaveDataInDatabase(Context context, int quantity)
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            GenerateAsync(quantity);

            await context.Disciplines.AddRangeAsync(_disciplines!);
            await context.Plans.AddRangeAsync(_plans!);
            await context.Sheets.AddRangeAsync(_sheets!);
            await context.Students.AddRangeAsync(_students!);
            await context.Teachers.AddRangeAsync(_teachers!);
            await context.TeacherDisciplines.AddRangeAsync(_teacherDisciplines!);
            await context.Titles.AddRangeAsync(_titles!);
            await context.Forms.AddRangeAsync(_forms!);

            await context.SaveChangesAsync();
        }

        private void GenerateAsync(int quantity)
        {
            _disciplines = CreateDisciplines(quantity/4);
            _titles = CreateTitle(quantity/4);
            _teachers = CreateTeachers(_titles, quantity);
            _forms = CreateForms(_teachers, quantity);
            _students = CreateStudents(_forms, quantity*4);
            _teacherDisciplines = CreateTeacherDisciplines(_teachers, _disciplines, quantity/4);
            _plans = CreatePlans(_teacherDisciplines, quantity/4);
            _sheets = CreateSheet(_students, _plans, quantity);
        }

        private readonly string[] _lastName = File.ReadAllLines("C:\\Users\\Niger\\source\\repos\\LaboratoryWorkOnDatabase\\LaboratoryWorkOnDatabase\\LastName.txt");

        private readonly string[] _firstNameM = File.ReadAllLines("C:\\Users\\Niger\\source\\repos\\LaboratoryWorkOnDatabase\\LaboratoryWorkOnDatabase\\FirstNameM.txt");

        private List<Discipline> CreateDisciplines(int quantity)
        {
            List<Discipline> list = [];

            for (int i = 0; i < quantity; i++)
            {
                Discipline discipline = new()
                {
                    DisciplineName = $"Дисциплина {i + 1}"
                };

                list.Add(discipline);
            }

            return list;
        }

        private List<Form> CreateForms(List<Teacher> teachers, int quantity)
        {
            List<Form> list = [];

            for (int i = 0; i < quantity; i++)
            {
                Teacher teacher = teachers.ElementAt(Random.Shared.Next(0, teachers.Count - 1));

                Form form = new()
                {
                    FormCreatedDate = new DateOnly(Random.Shared.Next(1950, 2000), Random.Shared.Next(1, 12), Random.Shared.Next(1, 28)),
                    FormLetter = $"{i + 1}",
                    Teacher = teacher,
                };

                list.Add(form);
            }

            return list;
        }

        private List<Plan> CreatePlans(List<TeacherDiscipline> teacherDisciplines, int quantity)
        {
            List<Plan> list = [];

            for (int i = 0; i < quantity; i++)
            {
                TeacherDiscipline teacherDiscipline = teacherDisciplines.ElementAt(Random.Shared.Next(0, teacherDisciplines.Count - 1));

                Plan plan = new()
                {
                    PlanClassNumber = i + 1,
                    TeacherDiscipline = teacherDiscipline,
                };

                list.Add(plan);
            }

            return list;
        }

        private List<Sheet> CreateSheet(List<Student> students, List<Plan> plans, int quantity)
        {
            List<Sheet> list = [];

            for (int i = 0; i < quantity; i++)
            {
                Student student = students.ElementAt(Random.Shared.Next(0, students.Count - 1));

                Plan plan = plans.ElementAt(Random.Shared.Next(0, plans.Count - 1));

                Sheet sheet = new()
                {
                    SheetDate = new DateOnly(Random.Shared.Next(1950, 2000), Random.Shared.Next(1, 12), Random.Shared.Next(1, 28)),
                    Student = student,
                    Plan = plan,
                    SheetPoint = Random.Shared.Next(0, 100),
                };

                list.Add(sheet);
            }

            return list;
        }

        private List<Student> CreateStudents(List<Form> forms, int quantity)
        {
            List<Student> list = [];

            for (int i = 0; i < quantity; i++)
            {
                Form form = forms.ElementAt(Random.Shared.Next(0, forms.Count - 1));

                Student student = new()
                {
                    LastName = _lastName[Random.Shared.Next(0, _lastName.Length)],
                    FirstName = _firstNameM[Random.Shared.Next(0, _firstNameM.Length)],
                    DateBorn = new DateOnly(Random.Shared.Next(2000, 2023), Random.Shared.Next(1, 12), Random.Shared.Next(1, 28)),
                    Form = form,
                    Sex = true,
                };

                list.Add(student);
            }

            return list;
        }

        private List<Teacher> CreateTeachers(List<Title> titles, int quantity)
        {
            List<Teacher> list = [];

            for (int i = 0; i < quantity; i++)
            {
                Title title = titles.ElementAt(Random.Shared.Next(0, titles.Count - 1));

                Teacher teacher = new()
                {
                    FirstName = _firstNameM[Random.Shared.Next(0, _firstNameM.Length)],
                    LastName = _lastName[Random.Shared.Next(0, _lastName.Length)],
                    DateBorn = new DateOnly(Random.Shared.Next(1950, 2000), Random.Shared.Next(1, 12), Random.Shared.Next(1, 28)),
                    Title = title,
                    Sex = true,
                };

                list.Add(teacher);
            }

            return list;
        }

        private List<TeacherDiscipline> CreateTeacherDisciplines(List<Teacher> teachers, List<Discipline> disciplines, int quantity)
        {
            List<TeacherDiscipline> list = [];

            for (int i = 0; i < quantity; i++)
            {
                TeacherDiscipline teacherDiscipline = new()
                {
                    Teacher = teachers.ElementAt(Random.Shared.Next(1, teachers.Count)),
                    Discipline = disciplines.ElementAt(Random.Shared.Next(1, disciplines.Count)),
                };

                list.Add(teacherDiscipline);
            }

            return list;
        }

        private List<Title> CreateTitle(int quantity)
        {
            List<Title> list = [];

            for (int i = 0; i < quantity; i++)
            {
                Title title = new()
                {
                    TitleName = $"Должность {i}"
                };

                list.Add(title);
            }

            return list;
        }
    }
}