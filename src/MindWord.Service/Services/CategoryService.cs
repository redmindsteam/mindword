using MindWord.DataAccess.Interfaces.Repositories;
using MindWord.DataAccess.Repositories;
using MindWord.Domain.Entities;
using MindWord.Service.Attributes;
using MindWord.Service.Interfaces.Services;
using MindWord.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Description= viewmodel.Description,
                UserId= IdentitySingelton.currentId().UserId
             };
                
            var result = await repository.CreateAsync(category);
            if (result)
            {
                return(true, "Success");
            }
            else
                return(false, "Not Added");
           
        }
    }
}
