using Microsoft.CodeAnalysis;
using P5WebApp.Models.Entities;
using P5WebApp.Models.ViewModels;

namespace P5WebApp.Models.Services
{
    public interface IAddService
    {
        List<Add> GetAllAdds();
        List<AddViewModel> GetAllAddsViewModel();
        Add GetAddById(int id);
        AddViewModel GetAddByIdViewModel(int id);
        void UpdateAddInfos();
        void SaveAdd(AddViewModel add);
        void DeleteAdd(int id);

        /// <summary>
        /// Use of a dictionnary to ease ModelState tests.
        /// </summary >
        Dictionary<string, string> CheckAddModelErrors(AddViewModel add);


        Task<Add> GetProduct(int id);
        Task<IList<Add>> GetProduct();

    }
}
