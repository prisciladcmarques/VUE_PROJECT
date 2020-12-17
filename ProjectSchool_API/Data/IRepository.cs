using System.Threading.Tasks;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
    public interface IRepository
    {
        //Geral
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Aluno
        Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor);
        Task<Aluno[]> GetAlunosAsyncByProfessorId(int ProfessorId, bool includeProfessor);
        Task<Aluno> GetAlunosAsyncById(int AlunoId, bool includeProfessor);

        //Professor    
        Task<Professor[]> GetAllProfessoresAsync(bool includeAluno);
        Task<Professor> GetProfessorAsyncById(int ProfessorId, bool includeAluno);

    }
}