using Microsoft.EntityFrameworkCore;
using P5WebApp.Models.Entities;
using P5WebApp.Models.Repositories;
using P5WebApp.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace P5WebApp.Models.Services
{
    public class ShortAddService : IShortAddService
    {
        private readonly IShortAddRepository? _shortAddRepository;

        public ShortAddService(IShortAddRepository shortAddRepository)
        {
            _shortAddRepository = shortAddRepository;
        }

        public List<ShortAdd> GetAllShortAdds()
        {
            IEnumerable<ShortAdd> shortAddEntities = _shortAddRepository.GetAllShortAdds();
            return shortAddEntities.ToList();
        }

        public List<ShortAddViewModel> GetAllShortAddsViewModel()
        {

            IEnumerable<ShortAdd> shortAddEntities = GetAllShortAdds();
            return MapToViewModel(shortAddEntities);
        }




        private static List<ShortAddViewModel> MapToViewModel(IEnumerable<ShortAdd> shortAddEntities)
        {
            List<ShortAddViewModel> shortAdds = new List<ShortAddViewModel>();
            foreach (ShortAdd shortAdd in shortAddEntities)
            {
                shortAdds.Add(new ShortAddViewModel
                {
                    ShortAddId = shortAdd.ShortAddId,
                    Description = shortAdd.Description,
                    ShortAddAvailabilityDate = shortAdd.ShortAddAvailabilityDate ?? DateOnly.MinValue,
                    ShortAddPublished = shortAdd.ShortAddPublished,
                    ShortAddDateSold = shortAdd.ShortAddDateSold ?? DateOnly.MinValue,
                    ShortAddSold = shortAdd.ShortAddSold,
                    ShortAddCarId = shortAdd.ShortAddCarId,
                    ShortAddBuyPrice = shortAdd.ShortAddBuyPrice,
                    Car = shortAdd.Car,

                });
            }

            return shortAdds;
        }


        public ShortAdd GetShortAddById(int id)
        {
            List<ShortAdd> shortAdds = GetAllShortAdds().ToList();
            var shortAddToReturn = shortAdds.Find(s => s.ShortAddId == id);
            return shortAddToReturn;
        }



        public Dictionary<string, string> CheckShortAddModelErrors(ShortAddViewModel ShortAdd)
        {
            /// <summary>
            /// Use of a dictionnary to ease ModelState tests.
            /// [Key ,Value]
            /// [Key = Value = "ErrorMessageName" ]
            /// </summary >
            Dictionary<string, string> modelErrors = new Dictionary<string, string>();


            /// <summary>
            /// Declaration of the same ProductViewModel RegularExpression attributes
            /// to run server side attribute validation.
            /// </summary >
            var Attribute1 = new RequiredAttribute();

            if (!Attribute1.IsValid(ShortAdd.Description))
            {
                modelErrors.Add("", "Veuillez renseigner une description");
            }

            var Attribute2 = new RequiredAttribute();

            if (!Attribute2.IsValid(ShortAdd.ShortAddAvailabilityDate))
            {
                modelErrors.Add("", "Veuillez renseigner une date de disponibilité");
            }

            var Attribute3 = new RequiredAttribute();

            if (!Attribute3.IsValid(ShortAdd.ShortAddCarId))
            {
                modelErrors.Add("", "Veuillez renseigner la voiture associée");
            }

            var Attribute4 = new RequiredAttribute();

            if (!Attribute4.IsValid(ShortAdd.ShortAddBuyPrice))
            {
                modelErrors.Add("", "Veuillez renseigner le prix d'achat de la voiture");
            }


            return modelErrors;
        }

        public ShortAddViewModel GetShortAddByIdViewModel(int id)
        {
            List<ShortAddViewModel> shortAdds = GetAllShortAddsViewModel().ToList();
            return shortAdds.Find(c => c.ShortAddId == id);
        }


        public void UpdateShortAddInfos(ShortAddViewModel shortAdd)
        {

            var shortAddToEdit = GetShortAddById(shortAdd.ShortAddId);



            shortAddToEdit.Description = shortAdd.Description;
            shortAddToEdit.ShortAddAvailabilityDate = shortAdd.ShortAddAvailabilityDate ?? DateOnly.MinValue;
            shortAddToEdit.ShortAddPublished = shortAdd.ShortAddPublished;
            shortAddToEdit.ShortAddDateSold = shortAdd.ShortAddDateSold ?? DateOnly.MinValue;
            shortAddToEdit.ShortAddSold = shortAdd.ShortAddSold;
            shortAddToEdit.ShortAddCarId = shortAdd.ShortAddCarId;
            shortAddToEdit.ShortAddBuyPrice = shortAdd.ShortAddBuyPrice;
            shortAddToEdit.Car = shortAdd.Car;
  


            _shortAddRepository.UpdateShortAdd(shortAddToEdit);

        }

        public void SaveShortAdd(ShortAddViewModel ShortAdd)
        {
            var ShortAddToAdd = MapToShortAddEntity(ShortAdd);
            _shortAddRepository.SaveShortAdd(ShortAddToAdd);
        }



        private ShortAdd MapToShortAddEntity(ShortAddViewModel shortAdd)
        {

            ShortAdd shortAddEntity = new ShortAdd
            {
                Description = shortAdd.Description,
                ShortAddAvailabilityDate = shortAdd.ShortAddAvailabilityDate ?? DateOnly.MinValue,
                ShortAddPublished = shortAdd.ShortAddPublished,
                ShortAddDateSold = shortAdd.ShortAddDateSold ?? DateOnly.MinValue,
                ShortAddSold = shortAdd.ShortAddSold,
                ShortAddCarId = shortAdd.ShortAddCarId,
                ShortAddBuyPrice = shortAdd.ShortAddBuyPrice,
                Car = shortAdd.Car,

            };
            return shortAddEntity;
        }


        public void DeleteShortAdd(int id)
        {
            _shortAddRepository.DeleteShortAdd(id);
        }

        public async Task<ShortAdd> GetShortAdd(int id)
        {
            var shortAdd = await _shortAddRepository.GetShortAdd(id);
            return shortAdd;
        }

        public async Task<IList<ShortAdd>> GetShortAdd()
        {
            var shortAdds = await _shortAddRepository.GetShortAdd();
            return shortAdds;
        }

    }
}
