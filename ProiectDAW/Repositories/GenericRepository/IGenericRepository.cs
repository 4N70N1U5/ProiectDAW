using ProiectDAW.Models.Base;

namespace ProiectDAW.Repositories.GenericRepository
{
    public interface IGenericRepository<TemplateEntity> where TemplateEntity : BaseEntity
    {
        // Create
        Task CreateAsync(TemplateEntity templateEntity);

        // Read
        Task<List<TemplateEntity>> GetAllAsync();
        Task<TemplateEntity> GetByIdAsync(Guid id);

        // Update
        void Update(TemplateEntity templateEntity);

        // Delete
        void Delete(TemplateEntity templateEntity);

        // Save
        Task<bool> SaveAsync();
    }
}
