using MindWord.DataAccess.Interfaces.Repositories;
using MindWord.DataAccess.Repositories;
using MindWord.Domain.Entities;
using MindWord.Service.Attributes;
using MindWord.Service.Interfaces.Services;
using MindWord.Service.ViewModel;
using PagedList;

namespace MindWord.Service.Services
{
    public class CategoryService : ICategoryService
    {
        public async Task<(bool isSuccessful, string Message)> CreateAsync(CategoryViewModel viewmodel)
        {
            ICategoryRepository repository = new CategoryRepository();

            Category category = new Category()
            {
                Title = viewmodel.Title,
                Description = viewmodel.Description,
                UserId = IdentitySingelton.currentId().UserId
            };

            var result = await repository.CreateAsync(category);
            if (result)
            {
                return (true, "Success");
            }
            else
                return (false, "Not Added");

        }

        public async Task<IPagedList<CategoryViewModel>> GetPagedListAsync(int pageNumber = 1, int pageSize = 5)
        {
            List<CategoryViewModel> list = new List<CategoryViewModel>();
            ICategoryRepository repository = new CategoryRepository();
            var result = await repository.GetAllAsync();
            var res = result.Where(x => x.UserId == IdentitySingelton.currentId().UserId).ToList();
            foreach (var item in res)
            {
                CategoryViewModel model = new CategoryViewModel()
                {
                    Id = item.Id,
                    Description= item.Description,
                    Title = item.Title,
                };
                list.Add(model);
            }
            return list.ToPagedList(pageNumber, pageSize);
            throw new NotImplementedException();
        }
    }
}
