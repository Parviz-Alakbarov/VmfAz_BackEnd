using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRefreshTokenDal : EfEntityRepositoryBase<RefreshToken, VmfAzContext>, IRefreshTokenDal
    {
        public async Task DeleteAll(int userId)
        {
            using (VmfAzContext context = new())
            {
                var result =  await (from p in context.RefreshTokens
                              where p.UserId == userId
                              select p).ToListAsync();
                context.RemoveRange(result);
                await context.SaveChangesAsync();
                return;
            }
        }
    }
}
