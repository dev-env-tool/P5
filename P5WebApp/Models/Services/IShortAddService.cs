using Microsoft.CodeAnalysis;
using P5WebApp.Models.Entities;
using P5WebApp.Models.ViewModels;

namespace P5WebApp.Models.Services
{
    public interface IShortAddService
    {
        List<ShortAdd> GetAllShortAdds();
        List<ShortAddViewModel> GetAllShortAddsViewModel();
        ShortAdd GetShortAddById(int id);
        ShortAddViewModel GetShortAddByIdViewModel(int id);
        void UpdateShortAddInfos();
        void SaveShortAdd(ShortAddViewModel add);
        void DeleteShortAdd(int id);

        /// <summary>
        /// Use of a dictionnary to ease ModelState tests.
        /// </summary >
        Dictionary<string, string> CheckShortAddModelErrors(ShortAddViewModel add);


        Task<ShortAdd> GetShortAdd(int id);
        Task<IList<ShortAdd>> GetShortAdd();

    }
}
