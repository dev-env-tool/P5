using Microsoft.EntityFrameworkCore;
using P5WebApp.Models.Entities;
using P5WebApp.Models.Repositories;
using P5WebApp.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace P5WebApp.Models.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository ?_photoRepository;
        private readonly ICarModelService? _carModelService;
        private readonly ICarModelRepository ?_carModelRepository;
        private readonly IWebHostEnvironment? _webHostEnvironment;

        public PhotoService(IPhotoRepository photoRepository, ICarModelService? carModelService, ICarModelRepository carModelRepository, IWebHostEnvironment webHostEnvironment) 
        {
            _photoRepository = photoRepository;
            _carModelService = carModelService;
            _carModelRepository = carModelRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public List<Photo> GetAllPhotos()
        {
            IEnumerable<Photo> photoEntities = _photoRepository.GetAllPhotos();
            return photoEntities.ToList();
        }

        public List<PhotoViewModel> GetAllPhotosViewModel()
        {

            IEnumerable<Photo> photoEntities = GetAllPhotos();
            return MapToViewModel(photoEntities);
        }




        private static List<PhotoViewModel> MapToViewModel(IEnumerable<Photo> photoEntities)
        {
            List<PhotoViewModel> photos = new List<PhotoViewModel>();
            foreach (Photo photo in photoEntities)
            {
                photos.Add(new PhotoViewModel
                {
                    PhotoId = photo.PhotoId,
                    PhotoName = photo.PhotoName,
                    PhotoPath = photo.PhotoPath,
                    AssociatedCarId = photo.AssociatedCarId,
                });
            }

            return photos;
        }


        public Photo GetPhotoById(int id)
        {
            List<Photo> photos = GetAllPhotos().ToList();
            var photoToReturn = photos.Find(b => b.PhotoId == id);
            return photoToReturn;
        }

        public int GetPhotoIdByAssociatedCarId(int associatedCarId)
        {
            int photoIdToReturn = 0;
            List<Photo> photos = GetAllPhotos().ToList();
            var photoToReturn = photos.Find(p => p.AssociatedCarId == associatedCarId);
            if (photoToReturn != null)
            { 
                photoIdToReturn = photoToReturn.PhotoId;
            }
            else
            {
                photoIdToReturn = 0;
            }

            return photoIdToReturn;
        }

        public Dictionary<string, string> CheckPhotoModelErrors(PhotoViewModel photo)
        {
            /// <summary>
            /// Use of a dictionnary to ease ModelState tests.
            /// [Key ,Value]
            /// [Key = Value = "ErrorMessageName" ]
            /// </summary >
            Dictionary<string, string> modelErrors = new Dictionary<string, string>();


            /// <summary>
            /// Declaration of the same PhotoViewModel RegularExpression attributes
            /// to run server side attribute validation.
            /// </summary >
            var Attribute1 = new RequiredAttribute();

            if (!Attribute1.IsValid(photo.PhotoPath))
            {
                modelErrors.Add("", "Le chemin de la photo n'est pas renseigné");
            }

            var Attribute2 = new RequiredAttribute();

            if (!Attribute2.IsValid(photo.AssociatedCarId))
            {
                modelErrors.Add("", "L'annonce associée à la photo n'est pas renseigné");
            }

            return modelErrors;
        }

        public PhotoViewModel GetPhotoByIdViewModel(int id)
        {
            List<PhotoViewModel> photos = GetAllPhotosViewModel().ToList();
            return photos.Find(b => b.PhotoId == id);
        }

        //public void UpdatephotoInfos()
        //{
        //    photo photo = (Cart)_cart;
        //    foreach (CartLine line in cart.Lines)
        //    {
        //        _photoRepository.UpdatephotoStocks(line.photo.Id, line.Quantity);
        //    }
        //}

        public void UpdatePhoto(PhotoViewModel photo)
        {

            var photoToEdit = GetPhotoById(photo.PhotoId);
   
            //photoToEdit.PhotoName = photo.PhotoName;
            //photoToEdit.PhotoPath = photo.PhotoPath;

            _photoRepository.UpdatePhoto(photoToEdit);

        }

        public void SavePhoto(PhotoViewModel photo)
        {
            var photoToAdd = MapToPhotoEntity(photo);
            _photoRepository.SavePhoto(photoToAdd);
        }



        private Photo MapToPhotoEntity(PhotoViewModel photo)
        {

            Photo photoEntity = new Photo
            {
                PhotoId = photo.PhotoId,
                PhotoName = photo.PhotoName,
                PhotoPath = photo.PhotoPath,
                AssociatedCarId = photo.AssociatedCarId,
            };
            return photoEntity;
        }


        public void DeletePhoto(int id)
        {
            int PhotoId = _photoRepository.GetAllPhotos().Where(p => p.PhotoId == id).Select(p => p.PhotoId).FirstOrDefault();

            if (PhotoId > 0)
            {
                _photoRepository.DeletePhoto(id);
            }
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _photoRepository.GetPhoto(id);
            return photo;
        }

        public async Task<IList<Photo>> GetPhoto()
        {
            var photos = await _photoRepository.GetPhoto();
            return photos;
        }




    }
}
