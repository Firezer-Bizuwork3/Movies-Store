using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Data.Repository
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly ApplicationDbContext _context;
        public CinemaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Cinema cinema)
        {
            await _context.Cinemas.AddAsync(cinema);
            await _context.SaveChangesAsync();
        }



        public List<Cinema> DataSource()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
            _context.Actors.Remove(result);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Cinema>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cinema>> GetAllAsync()
        {
            var result = await _context.Cinemas.ToListAsync();
            return result;
        }

        public Cinema GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Cinema> GetByIdAsync(int id)
        {
            var result = await _context.Cinemas.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newactor)
        {
            _context.Update(newactor);
            await _context.SaveChangesAsync();
            return newactor;
        }

        public Task<Actor> UpdateAsync(int id, Cinema newcinema)
        {
            throw new NotImplementedException();
        }

        void ICinemaRepository.AddAsync(Cinema cinema)
        {
            throw new NotImplementedException();
        }
    }
}
