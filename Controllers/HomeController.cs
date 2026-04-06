using Lab6.ViewModels;
using Lab6.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers;

public class HomeController : Controller
{
    private readonly IArticleService _articleService;
    private readonly ICategoryService _categoryService;

    public HomeController(IArticleService articleService, ICategoryService categoryService)
    {
        _articleService = articleService;
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index(CancellationToken ct)
    {
 
        var recentData = await _articleService.GetPagedAsync(1, 3, null, ct);


        var totalArticles = await _articleService.CountAsync(null, ct);
        var categories = await _categoryService.GetAllAsync(ct);

        var viewModel = new HomeViewModel
        {
            TotalArticles = totalArticles,
            TotalCategories = categories.Count,
            RecentArticles = recentData.Select(a => new ArticleViewModel
            {
                Id = a.Id,
                Title = a.Title,
                Content = a.Content.Length > 100 ? a.Content[..100] + "..." : a.Content,
                PublishedAt = a.PublishedAt,
                CategoryName = a.Category?.Name ?? "N/A",
                ImagePath = a.ImagePath
            }).ToList()
        };

        return View(viewModel);
    }
}