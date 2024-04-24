﻿using RTS.Accounting.Domain.Interfaces;

namespace RTS.Accounting.Infrastructure.Repositories
{
    public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext = appDbContext;
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _appDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
