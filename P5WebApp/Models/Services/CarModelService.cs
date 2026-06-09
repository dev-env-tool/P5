using Microsoft.EntityFrameworkCore;
using P5WebApp.Data;
using P5WebApp.Models.Entities;
using P5WebApp.Models.Repositories;
using P5WebApp.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace P5WebApp.Models.Services
{
    public class CarModelService : ICarModelService
    {
        private readonly ICarModelRepository ?_carModelRepository;
        private readonly ApplicationDbContext _context;

        public CarModelService(ICarModelRepository carModelRepository, ApplicationDbContext context) 
        {
            _carModelRepository = carModelRepository;
            _context = context;
        }

        public List<CarModel> GetAllCarModels()
        {
            IEnumerable<CarModel> CarModelEntities = _carModelRepository.GetAllCarModels();
            return CarModelEntities.ToList();
        }


        public List<CarModelViewModel> GetAllCarModelsViewModel()
        {

            IEnumerable<CarModel> CarModelEntities = GetAllCarModels();
            return MapToViewModel(CarModelEntities);
        }




        private static List<CarModelViewModel> MapToViewModel(IEnumerable<CarModel> CarModelEntities)
        {
            List<CarModelViewModel> CarModels = new List<CarModelViewModel>();
            foreach (CarModel CarModel in CarModelEntities)
            {
                CarModels.Add(new CarModelViewModel
                {
                    Id = CarModel.Id,
                    Name = CarModel.Name,
                    AssociatedBrandId = CarModel.AssociatedBrandId,
                });
            }

            return CarModels;
        }


        public CarModel GetCarModelById(int id)
        {
            List<CarModel> CarModels = GetAllCarModels().ToList();
            var CarModelToReturn = CarModels.Find(c => c.Id == id);
            return CarModelToReturn;
        }



        public Dictionary<string, string> CheckCarModelModelErrors(CarModelViewModel CarModel)
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

            if (!Attribute1.IsValid(CarModel.Name))
            {
                modelErrors.Add("", "Veuillez renseigner un nom de modèle");
            }


            var Attribute2 = new RequiredAttribute();

            if (!Attribute2.IsValid(CarModel.FinishTypes))
            {
                modelErrors.Add("", "Veuillez renseigner au moins une finition associée");
            }

            return modelErrors;
        }

        public CarModelViewModel GetCarModelByIdViewModel(int id)
        {
            List<CarModelViewModel> CarModels = GetAllCarModelsViewModel().ToList();
            return CarModels.Find(c => c.Id == id);
        }


        public void UpdateCarModel(CarModelViewModel CarModel)
        {

            var CarModelToEdit = GetCarModelById(CarModel.Id);

            CarModelToEdit.Name = CarModel.Name;
            CarModelToEdit.AssociatedBrandId = CarModel.AssociatedBrandId;

            _carModelRepository.UpdateCarModel(CarModelToEdit);

        }

        public void SaveCarModel(CarModelViewModel CarModel)
        {
            var CarModelToAdd = MapToCarModelEntity(CarModel);
            _carModelRepository.SaveCarModel(CarModelToAdd);
        }



        private CarModel MapToCarModelEntity(CarModelViewModel CarModel)
        {

            CarModel CarModelEntity = new CarModel
            {
                Name = CarModel.Name,
                AssociatedBrandId = CarModel.AssociatedBrandId,
            };
            return CarModelEntity;
        }


        public void DeleteCarModel(int id)
        {
            _carModelRepository.DeleteCarModel(id);
        }

        public async Task<CarModel> GetCarModel(int id)
        {
            var CarModel = await _carModelRepository.GetCarModel(id);
            return CarModel;
        }

        public async Task<IList<CarModel>> GetCarModel()
        {
            var CarModels = await _carModelRepository.GetCarModel();
            return CarModels;
        }

    }
}
