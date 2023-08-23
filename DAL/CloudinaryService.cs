using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(string cloudName, string apiKey, string apiSecret)
        {
            _cloudinary = new Cloudinary(new Account(cloudName, apiKey, apiSecret));
        }

        public string UploadImage(Stream imageStream, string id)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(id, imageStream),
                PublicId = id,
            };

            var uploadResult = _cloudinary.Upload(uploadParams);

            if (uploadResult.Error != null)
            {
                throw new Exception($"Error uploading image: {uploadResult.Error.Message}");
            }

            return uploadResult.SecureUri.ToString();
        }

        public void DeleteImage(string id)
        {
            var deleteParams = new DeletionParams(id);

            var deleteResult = _cloudinary.Destroy(deleteParams);

            if (deleteResult.Result == "not found")
            {
                throw new Exception($"Image with public ID {id} not found on Cloudinary.");
            }
        }

        public string GetImageUrl(string id)
        {
            return _cloudinary.Api.UrlImgUp.BuildUrl(id);
        }
    }
}
