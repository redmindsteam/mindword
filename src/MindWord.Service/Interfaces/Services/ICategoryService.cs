using MindWord.Service.ViewModel;
using PagedList;

namespace MindWord.Service.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<(bool isSuccessful, string Message)> CreateAsync(CategoryViewModel viewmodel);
        Task<IPagedList<CategoryViewModel>> GetPagedListAsync(int pageNumber = 1, int pageSize = 5);
    }
}
