using Microsoft.Data.SqlClient;
using ProiectDAW.Models.Base;

namespace ProiectDAW.Repositories.GenericRepository
{
    public class GenericRepository<TemplateEntity> : IGenericRepository<TemplateEntity> where TemplateEntity : BaseEntity
    {
        protected readonly DataContext _context;
        protected readonly DbSet<TemplateEntity> _table;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _table = _context.Set<TemplateEntity>();
        }

        // Create
        public async Task CreateAsync(TemplateEntity templateEntity)
        {
            await _table.AddAsync(templateEntity);
        }

        // Read
        public async Task<List<TemplateEntity>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<TemplateEntity> GetByIdAsync(Guid id)
        {
            return await _table.FindAsync(id);
        }

        // Update
        public void Update(TemplateEntity templateEntity)
        {
            _table.Update(templateEntity);
        }

        // Delete
        public void Delete(TemplateEntity templateEntity)
        {
            _table.Remove(templateEntity);
        }

        // Save
        public async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
            }

            return false;
        }
    }
}
