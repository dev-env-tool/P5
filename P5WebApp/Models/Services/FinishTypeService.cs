using Microsoft.EntityFrameworkCore;
using P5WebApp.Models.Entities;
using P5WebApp.Models.Repositories;
using P5WebApp.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace P5WebApp.Models.Services
{
    public class FinishTypeService : IFinishTypeService
    {
        private readonly IFinishTypeRepository ?_FinishTypeRepository;

        public FinishTypeService(IFinishTypeRepository FinishTypeRepository) 
        {
            _FinishTypeRepository = FinishTypeRepository;
        }

        public List<FinishType> GetAllFinishTypes()
        {
            IEnumerable<FinishType> FinishTypeEntities = _FinishTypeRepository.GetAllFinishTypes();
            return FinishTypeEntities.ToList();
        }

        public List<FinishTypeViewModel> GetAllFinishTypesViewModel()
        {

            IEnumerable<FinishType> FinishTypeEntities = GetAllFinishTypes();
            return MapToViewModel(FinishTypeEntities);
        }




        private static List<FinishTypeViewModel> MapToViewModel(IEnumerable<FinishType> FinishTypeEntities)
        {
            List<FinishTypeViewModel> FinishTypes = new List<FinishTypeViewModel>();
            foreach (FinishType FinishType in FinishTypeEntities)
            {
                FinishTypes.Add(new FinishTypeViewModel
                {
                    FinishTypeId = FinishType.FinishTypeId,
                    FinishTypeName = FinishType.FinishTypeName,
                    AssociatedBrandsIds = FinishType.AssociatedBrandsIds,
                    AssociatedCarModelIds = FinishType.AssociatedCarModelIds,
                });
            }

            return FinishTypes;
        }


        public FinishType GetFinishTypeById(int id)
        {
            List<FinishType> FinishTypes = GetAllFinishTypes().ToList();
            var FinishTypeToReturn = FinishTypes.Find(f => f.FinishTypeId == id);
            return FinishTypeToReturn;
        }



        public Dictionary<string, string> CheckFinishTypeModelErrors(FinishTypeViewModel FinishType)
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

            if (!Attribute1.IsValid(FinishType.FinishTypeName))
            {
                modelErrors.Add("", "Veuillez renseigner un nom de finition");
            }

            var Attribute2 = new RequiredAttribute();

            if (!Attribute2.IsValid(FinishType.Brands))
            {
                modelErrors.Add("", "Veuillez choisir au moins une marque associée");
            }

            var Attribute3 = new RequiredAttribute();

            if (!Attribute3.IsValid(FinishType.CarModels))
            {
                modelErrors.Add("", "Veuillez choisir au moins un modèle associé");
            }

            return modelErrors;
        }

        public FinishTypeViewModel GetFinishTypeByIdViewModel(int id)
        {
            List<FinishTypeViewModel> FinishTypes = GetAllFinishTypesViewModel().ToList();
            return FinishTypes.Find(f => f.FinishTypeId == id);
        }




        public void UpdateFinishType(FinishTypeViewModel FinishType)
        {

            var FinishTypeToEdit = GetFinishTypeById(FinishType.FinishTypeId);

            FinishTypeToEdit.FinishTypeName = FinishType.FinishTypeName;
            FinishTypeToEdit.AssociatedBrandsIds = FinishType.AssociatedBrandsIds;
            FinishTypeToEdit.AssociatedCarModelIds = FinishType.AssociatedCarModelIds;


            _FinishTypeRepository.UpdateFinishType(FinishTypeToEdit);

        }

        public void SaveFinishType(FinishTypeViewModel FinishType)
        {
            var FinishTypeToAdd = MapToFinishTypeEntity(FinishType);
            _FinishTypeRepository.SaveFinishType(FinishTypeToAdd);
        }



        private FinishType MapToFinishTypeEntity(FinishTypeViewModel FinishType)
        {

            FinishType FinishTypeEntity = new FinishType
            {
                FinishTypeName = FinishType.FinishTypeName,
                Brands = FinishType.Brands,
                CarModels = FinishType.CarModels,
                AssociatedBrandsIds = FinishType.AssociatedBrandsIds,
                AssociatedCarModelIds = FinishType.AssociatedCarModelIds,
            };
            return FinishTypeEntity;
        }


        public void DeleteFinishType(int id)
        {
            _FinishTypeRepository.DeleteFinishType(id);
        }

        public async Task<FinishType> GetFinishType(int id)
        {
            var FinishType = await _FinishTypeRepository.GetFinishType(id);
            return FinishType;
        }

        public async Task<IList<FinishType>> GetFinishType()
        {
            var FinishTypes = await _FinishTypeRepository.GetFinishType();
            return FinishTypes;
        }

    }
}
