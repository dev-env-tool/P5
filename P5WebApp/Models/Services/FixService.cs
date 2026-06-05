using Microsoft.EntityFrameworkCore;
using P5WebApp.Models.Entities;
using P5WebApp.Models.Repositories;
using P5WebApp.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace P5WebApp.Models.Services
{
    public class FixService : IFixService
    {
        private readonly IFixRepository ?_fixRepository;

        public FixService(IFixRepository FixRepository) 
        {
            _fixRepository = FixRepository;
        }

        public List<Fix> GetAllFixes()
        {
            IEnumerable<Fix> FixEntities = _fixRepository.GetAllFixes();
            return FixEntities.ToList();
        }

        public List<FixViewModel> GetAllFixesViewModel()
        {

            IEnumerable<Fix> FixEntities = GetAllFixes();
            return MapToViewModel(FixEntities);
        }




        private static List<FixViewModel> MapToViewModel(IEnumerable<Fix> FixEntities)
        {
            List<FixViewModel> Fixs = new List<FixViewModel>();
            foreach (Fix Fix in FixEntities)
            {
                Fixs.Add(new FixViewModel
                {
                    FixId = Fix.FixId,
                    FixDescription = Fix.FixDescription,
                    FixDate = Fix.FixDate,
                    FixCost = Fix.FixCost,
                    AssociatedCarId = Fix.AssociatedCarId,
                });
            }

            return Fixs;
        }


        public Fix GetFixById(int id)
        {
            List<Fix> Fixs = GetAllFixes().ToList();
            var FixToReturn = Fixs.Find(f => f.FixId == id);
            return FixToReturn;
        }



        public Dictionary<string, string> CheckFixModelErrors(FixViewModel Fix)
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

            if (!Attribute1.IsValid(Fix.FixDescription))
            {
                modelErrors.Add("", "Veuillez renseigner la description de la réparation");
            }

            var Attribute2 = new RequiredAttribute();

            if (!Attribute2.IsValid(Fix.FixDate))
            {
                modelErrors.Add("", "Veuillez renseigner la date de la réparation");
            }

            var Attribute3 = new RequiredAttribute();

            if (!Attribute3.IsValid(Fix.FixCost))
            {
                modelErrors.Add("", "Veuillez renseigner le coût de la réparation");
            }


            var Attribute4 = new RegularExpressionAttribute("^(-?(\\d+\\.?\\d+|\\d))+$");

            if (!Attribute4.IsValid(Fix.FixCost))
            {
                modelErrors.Add("", "Le coût n'est pas un nombre");


            }
            var Attribute5 = new RangeAttribute(0.0001, double.MaxValue);

            if (!Attribute5.IsValid(Fix.FixCost))
            {
                modelErrors.Add("", "Le coût n'est pas supérieur à 0\"");
            }


            var Attribute6 = new RequiredAttribute();

            if (!Attribute6.IsValid(Fix.AssociatedCarId))
            {
                modelErrors.Add("", "Veuillez choisir une voiture associée");
            }

            return modelErrors;
        }

        public FixViewModel GetFixByIdViewModel(int id)
        {
            List<FixViewModel> Fixs = GetAllFixesViewModel().ToList();
            return Fixs.Find(f => f.FixId == id);
        }




        public void UpdateFixInfos(FixViewModel Fix)
        {

            var FixToEdit = GetFixById(Fix.FixId);

            FixToEdit.FixDescription = Fix.FixDescription;
            FixToEdit.FixDate = Fix.FixDate ?? DateOnly.MinValue;
            FixToEdit.FixCost = Fix.FixCost;
            FixToEdit.AssociatedCarId = Fix.AssociatedCarId;


            _fixRepository.UpdateFix(FixToEdit);

        }

        public void SaveFix(FixViewModel Fix)
        {
            var FixToAdd = MapToFixEntity(Fix);
            _fixRepository.SaveFix(FixToAdd);
        }



        private Fix MapToFixEntity(FixViewModel Fix)
        {

            Fix FixEntity = new Fix
            {
                FixDescription = Fix.FixDescription,
                FixDate = Fix.FixDate ?? DateOnly.MinValue,
                FixCost = Fix.FixCost,
                AssociatedCarId = Fix.AssociatedCarId,
            };
            return FixEntity;
        }


        public void DeleteFix(int id)
        {
            _fixRepository.DeleteFix(id);
        }

        public async Task<Fix> GetFix(int id)
        {
            var Fix = await _fixRepository.GetFix(id);
            return Fix;
        }

        public async Task<IList<Fix>> GetFix()
        {
            var Fixs = await _fixRepository.GetFix();
            return Fixs;
        }

    }
}
