using Lab6.Data;
using Lab6.Models;
using Lab6.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Repositories;

public class ArticleRepository : Repository<Article>, IArticleRepository
{
    public ArticleRepository(AppDbContext context) : base(context) { }

    public async Task<List<Article>> GetAllWithDetailsAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Articles
            .Include(a => a.Category)
            .Include(a => a.User)
            .OrderByDescending(a => a.PublishedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<Article?> GetByIdWithDetailsAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Articles
            .Include(a => a.Category)
            .Include(a => a.User)
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
    }

    public async Task<List<Article>> GetByCategoryAsync(int categoryId, CancellationToken cancellationToken = default)
    {
        return await _context.Articles
            .Where(a => a.CategoryId == categoryId)
            .Include(a => a.Category)
            .Include(a => a.User)
            .OrderByDescending(a => a.PublishedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync(int? categoryId, CancellationToken ct)
    {
        var query = _context.Articles.AsQueryable();
        if (categoryId.HasValue) query = query.Where(a => a.CategoryId == categoryId);
        return await query.CountAsync(ct);
    }

    public async Task<List<Article>> GetPagedAsync(int page, int pageSize, int? categoryId, CancellationToken ct)
    {
        var query = _context.Articles
            .Include(a => a.Category)
            .Include(a => a.User)
            .AsQueryable();

        if (categoryId.HasValue) query = query.Where(a => a.CategoryId == categoryId);

        return await query
            .OrderByDescending(a => a.PublishedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }
}
