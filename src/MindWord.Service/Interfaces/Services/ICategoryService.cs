using MindWord.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindWord.Service.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<(bool isSuccessful, string Message)> CreateAsync(CategoryViewModel viewmodel);
    }
}
