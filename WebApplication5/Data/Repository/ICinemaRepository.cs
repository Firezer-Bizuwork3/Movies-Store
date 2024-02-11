using WebApplication5.Models;

namespace WebApplication5.Data.Repository
{
    public interface ICinemaRepository
    {
        Task<IEnumerable<Cinema>> GetAllAsync();
        public List<Cinema> DataSource();
        Task<Cinema> GetByIdAsync(int id);
        void AddAsync(Cinema cinema);
        Task<Actor> UpdateAsync(int id, Cinema newcinema);
        Task DeleteAsync(int id);
    }
}
