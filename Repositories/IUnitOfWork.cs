using Lab6.Models;
using Lab6.Repositories;

namespace Lab6.Repositories;

public interface IUnitOfWork
{
    IArticleRepository ArticleRepository { get; }
    IRepository<Category> CategoryRepository { get; }
    IRepository<User> UserRepository { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
