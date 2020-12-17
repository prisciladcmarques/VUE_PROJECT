using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
    public class Repository : IRepository
    {
        public DataContext _contex { get; }

        public Repository(DataContext contex)
        {
            _contex = contex;

        }

        public void Add<T>(T entity) where T : class
        {
            _contex.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _contex.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _contex.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _contex.SaveChangesAsync() > 0);
        }

        //Alunos

        public async Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _contex.Alunos;

            if(includeProfessor)
            {
                query = query
                        .Include(a => a.Professor);
            }

            query = query
                        .AsNoTracking()
                        .OrderBy(a => a.Id);

            return await query.ToArrayAsync();

        }

        public async Task<Aluno[]> GetAlunosAsyncByProfessorId(int ProfessorId, bool includeProfessor)
        {
            IQueryable<Aluno> query = _contex.Alunos;

            if(includeProfessor)
            {
                query = query
                        .Include(a => a.Professor);
            }

            query = query.AsNoTracking()
                        .OrderBy(a => a.Id)
                        .Where(aluno => aluno.ProfessorId == ProfessorId);

            return await query.ToArrayAsync();
        }

        public async Task<Aluno> GetAlunosAsyncById(int AlunoId, bool includeProfessor)
        {
            IQueryable<Aluno> query = _contex.Alunos;

            if(includeProfessor)
            {
                query = query
                        .Include(a => a.Professor);
            }

            query = query.AsNoTracking()
                        .OrderBy(a => a.Id)
                        .Where(aluno => aluno.Id == AlunoId);

            return await query.FirstOrDefaultAsync();
        }

        //Professores

        public async Task<Professor[]> GetAllProfessoresAsync(bool includeAluno = false)
        {
            IQueryable<Professor> query = _contex.Professores;

            if(includeAluno)
            {
                query = query
                        .Include(a => a.Alunos);
            }

            query = query.AsNoTracking()
                        .OrderBy(a => a.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Professor> GetProfessorAsyncById(int ProfessorId, bool includeAluno = false)
        {
            IQueryable<Professor> query = _contex.Professores;

            if(includeAluno)
            {
                query = query
                        .Include(a => a.Alunos);
            }

            query = query.AsNoTracking()
                        .OrderBy(a => a.Id)
                        .Where(Professor => Professor.Id == ProfessorId);

            return await query.FirstOrDefaultAsync();
        }
    }
}