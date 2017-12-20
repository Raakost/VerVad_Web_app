using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateways.ServiceGateways
{
    public class CloudinaryServiceGateway
    {
        Cloudinary cloudinary;

        public CloudinaryServiceGateway()
        {
            cloudinary = new Cloudinary(new Account(
         "vervad",              /*Cloud Name*/
         "565953923116584",           /*API key*/
         "V0lC8eULgJOhkldBCuwRujmo0jM"));  /*API Secret*/
        }

        public List<Resource> GetImages(string folderPath)
        {
            var images = cloudinary.ListResourcesByPrefix(folderPath, "upload", null).Resources;
            return images.ToList();
        }

        public List<Folder> GetGlobalGoalFolders()
        {
            var subFolders = cloudinary.SubFolders("verdensmål");
            return subFolders.Folders.OrderBy(x => int.Parse(x.Name.Split('.')[0])).ToList();
        }
    }
}