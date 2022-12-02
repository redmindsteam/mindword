using MindWord.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindWord.Service.Interfaces.Services
{
    public interface IUsersCategoriesService
    {
        public Task<List<CategoryViewModel>> GetCategoriesAsync();

        
    }
}
