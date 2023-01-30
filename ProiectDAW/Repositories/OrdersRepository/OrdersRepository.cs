﻿using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;

namespace ProiectDAW.Repositories.OrdersRepository
{
    public class OrdersRepository : GenericRepository<Order>, IOrdersRepository
    {
        public OrdersRepository(DataContext context) : base(context) { }

        public async Task<List<Order>> GetAllIncludeInfo()
        {
            return await _table.Include(o => o.Payment).Include(o => o.User).ToListAsync();
        }

        public Task<List<Order>> GetByPurchaseDate(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
