using Lab6.Models;
using Lab6.Repositories;

namespace Lab6.Repositories;

public interface IArticleRepository : IRepository<Article>
{
    Task<List<Article>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default);
    Task<Article?> GetByIdWithDetailsAsync(int id, CancellationToken cancellationToken = default);
    Task<List<Article>> GetByCategoryAsync(int categoryId, CancellationToken cancellationToken = default);
    Task<int> CountAsync(int? categoryId, CancellationToken ct);
    Task<List<Article>> GetPagedAsync(int page, int pageSize, int? categoryId, CancellationToken ct);
}
