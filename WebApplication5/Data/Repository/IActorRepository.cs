using WebApplication5.Models;

namespace WebApplication5.Data.Repository
{
    public interface IActorRepository
    {
        Task<IEnumerable<Actor>> GetAllAsync();
        public List<Actor> DataSource();
        Task<Actor> GetByIdAsync(int id);
        void AddAsync(Actor actor);
        Task<Actor> UpdateAsync(int id, Actor newactor);
        Task DeleteAsync(int id);
        Task AddAsync(Cinema cinema);
    }
}
