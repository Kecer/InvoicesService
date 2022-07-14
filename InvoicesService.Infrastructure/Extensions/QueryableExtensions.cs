using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoicesService.Core.Models.BaseModels;
using InvoicesService.Core.Models.CommonModels;
using Microsoft.EntityFrameworkCore;

namespace InvoicesService.Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize) where T : BaseModel
        {
            if (source == null) return PaginatedResult<T>.Failure(new List<string>
            {
                "Problem with source"
            });
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            int count = await source.CountAsync();
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            List<T> items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return PaginatedResult<T>.Success(items, count, pageNumber, pageSize);
        }
    }
}