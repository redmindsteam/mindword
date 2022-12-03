using MindWord.DataAccess.Interfaces.Repositories;
using MindWord.DataAccess.Repositories;
using MindWord.Domain.Entities;
using MindWord.Service.Attributes;
using MindWord.Service.Interfaces.Services;
using MindWord.Service.ViewModel;
using PagedList;

namespace MindWord.Service.Services
{
    public class WordService : IWordService
    {
        public async Task<IPagedList<WordCreateViewModel>> GetPagedListAsync(int pageNumber, int pageSize)
        {
            List<WordCreateViewModel> list = new List<WordCreateViewModel>();
            IWordRepository repository = new WordRepository();
            var result = await repository.GetAllAsync();
            var res = result.Where(x => x.UserId == IdentitySingelton.currentId().UserId).ToList();
            foreach (var item in res)
            {
                WordCreateViewModel model = new WordCreateViewModel()
                {
                    Id = item.Id,
                    Title = item.Description,
                    Word = item.Name,
                    Translate = item.Translate
                };
                list.Add(model);    
            }
            return list.ToPagedList(pageNumber, pageSize);

        }

        public async Task<bool> WordCreateAsync(WordCreateViewModel viewModel)
        {
            IWordRepository wordRepository = new WordRepository();
            ICategoryRepository categoryRepository = new CategoryRepository();
            Word word = new Word()
            {
                Name = viewModel.Word,
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
