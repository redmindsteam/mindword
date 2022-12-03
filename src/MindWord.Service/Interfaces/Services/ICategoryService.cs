using MindWord.Service.ViewModel;
using PagedList;

namespace MindWord.Service.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<(bool isSuccessful, string Message)> CreateAsync(CategoryViewModel viewmodel);

        Task<List<string>> GetStringsAsync();
       
        Task<IPagedList<CategoryViewModel>> GetPagedListAsync(int pageNumber, int pageSize);

    }
}
