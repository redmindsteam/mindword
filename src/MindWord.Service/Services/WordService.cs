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
    public class WordService : IWordService
    {
        public async Task<bool> WordCreateAsync(WordCreateViewModel viewModel)
        {
            IWordRepository wordRepository = new WordRepository();
            ICategoryRepository categoryRepository = new CategoryRepository();
            Word word = new Word()
            {
                Name = viewModel.Name,
                UserId = IdentitySingelton.currentId().UserId,
                Translate = viewModel.Translate,
                Description = "API",
                AudioPath = "API",
                CategoryId = (await categoryRepository.GetByTitleAsync(title: viewModel.Title)).Id,
            };
            return await wordRepository.CreateAsync(word);
        }
    }
}
