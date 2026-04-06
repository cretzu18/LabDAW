using Lab6.Data;
using Lab6.Models;
using Lab6.Repositories;

namespace Lab6.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    private IArticleRepository? _articleRepository;
    private IRepository<Category>? _categoryRepository;
    private IRepository<User>? _userRepository;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IArticleRepository ArticleRepository
        => _articleRepository ??= new ArticleRepository(_context);

    public IRepository<Category> CategoryRepository
        => _categoryRepository ??= new Repository<Category>(_context);

    public IRepository<User> UserRepository
        => _userRepository ??= new Repository<User>(_context);

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync(cancellationToken);
}
