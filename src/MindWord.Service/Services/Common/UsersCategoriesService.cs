using MindWord.DataAccess.Interfaces.Repositories;
using MindWord.DataAccess.Repositories;
using MindWord.Service.Attributes;
using MindWord.Service.Interfaces.Services;
using MindWord.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindWord.Service.Services.Common
{
    public class UsersCategoriesService : IUsersCategoriesService
    {
        public async Task<List<CategoryViewModel>> GetCategoriesAsync()
        {
            List<CategoryViewModel> categoryViewModels= new List<CategoryViewModel>();
            ICategoryRepository categoryRepository = new CategoryRepository();
           
              var categories = await categoryRepository.GetAllAsync();

            foreach (var category in categories)
            {
                if (category.UserId == IdentitySingelton.currentId().UserId)
                {
                    var categoryViewModel = new CategoryViewModel()
                    {
                        Title= category.Title,  
                        Description = category.Description
                    };
                    categoryViewModels.Add(categoryViewModel);  

                }
            }

            
            return categoryViewModels;
        }
       
    }
}
