using Characters.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters.Dal.Repository
{
    public class CharacterRepository:ICharacterRepository
    {
        private readonly ApplicationDbContext _context;


        public CharacterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Character entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Character>> GetAll()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task<Character> GetById(int id)
        {
            return await _context.Characters.FindAsync(id);
        }

        public async Task<IEnumerable<Character>> GetByName(string name)
        {
            return await _context.Characters.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            return _context.Characters.Any(x => x.Id == id);
        }

        public async Task Update(Character entity)
        {
            _context.Characters.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
