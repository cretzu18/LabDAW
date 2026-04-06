using Lab6.Models;

namespace Lab6.ViewModels;

public class ArticleListViewModel
{
    public List<ArticleViewModel> Articles { get; set; } = new();

    public List<Category> Categories { get; set; } = new();


    public int? SelectedCategoryId { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}

public class ArticleViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime PublishedAt { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
    public string? ImagePath { get; set; }
}
