using System.Collections.Generic;
using WebApplication4.Models;

namespace WebApplication4.Repositories.Interfaces
{
    public interface IDirectorRepository
    {
        Task<IEnumerable<Director>> GetDirectors(CancellationToken cancellationToken = default);

        Task<Director> GetDirector(int directorId, CancellationToken cancellationToken = default);

        Task AddDirector(Director director, CancellationToken cancellationToken = default);

        Task EditDirector(int directorId, CancellationToken cancellationToken = default);

        Task DeleteDirector(int directorId, CancellationToken cancellationToken = default);

        Task DeleteAllDirectors(CancellationToken cancellationToken = default);
    }
}
