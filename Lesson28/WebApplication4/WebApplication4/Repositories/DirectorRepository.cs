using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;
using WebApplication4.Repositories.Interfaces;

namespace WebApplication4.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly CinemaDbContext _cinemaDbContext;
        public DirectorRepository(CinemaDbContext cinemaDbContext) 
        {
            _cinemaDbContext = cinemaDbContext;
        }

        public async Task AddDirector(Director director, CancellationToken cancellationToken = default)
        {
            var existingDirector = await _cinemaDbContext.Directors.FirstOrDefaultAsync(x => x.Id == director.Id, cancellationToken);

            if (existingDirector != null)
            {
                existingDirector.Name = director.Name;
                existingDirector.BirthDate = director.BirthDate;
            }
            else
            {
                _cinemaDbContext.Add(director);
            }

            await _cinemaDbContext.SaveChangesAsync(cancellationToken);
        }

        public Task DeleteAllDirectors(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDirector(int directorId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task EditDirector(int directorId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Director> GetDirector(int directorId, CancellationToken cancellationToken)
        {
            return await _cinemaDbContext.Directors.FirstOrDefaultAsync(x => x.Id == directorId, cancellationToken) ?? throw new Exception("Not Found!");
        }

        public async Task<IEnumerable<Director>> GetDirectors(CancellationToken cancellationToken)
        {
            return await _cinemaDbContext.Directors.ToListAsync(cancellationToken) ?? [];
        }
    }
}
