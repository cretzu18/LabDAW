using Lab6.Models;

namespace Lab6.Services;

public interface IArticleService
{
    Task<List<Article>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Article?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddAsync(Article article, CancellationToken cancellationToken = default);
    Task UpdateAsync(Article article, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<int> CountAsync(int? categoryId, CancellationToken ct);
    Task<List<Article>> GetPagedAsync(int page, int pageSize, int? categoryId, CancellationToken ct);
}
