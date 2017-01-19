using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Honeymoonshop.Models.Utils
{
    public class FileUploader<T>
        where T : new()
        
    {
        /*  returnt array gevult met het type<T> van succesvol geuploade files
         */
        public static List<T> UploadImages(IFormFile[] files)
        {
            var list = new List<T>();
            foreach (var file in files)
            {
                var f = UploadImage(file);
                if (f != null)
                    list.Add(f);

            }
            return list;
        }

        /* returnt object<T> wanneer file een image is en de file succesvol geupload is
         * returnt NULL wanneer het uploaden niet gelukt is
         */
        public static T UploadImage(IFormFile file )
        {
            if (file != null)
            {
                var upload = Path.Combine("", "wwwroot/Images/productenimages");
               
                if (Path.GetExtension(file.FileName).ToLower() == ".jpg"
                || Path.GetExtension(file.FileName).ToLower() == ".png"
                || Path.GetExtension(file.FileName).ToLower() == ".gif"
                || Path.GetExtension(file.FileName).ToLower() == ".jpeg") {

                UploadFile(file, upload);   //TODO check of file geupload is
                T o = new T();
                o.GetType().GetProperty("BestandsNaam").SetValue(o, file.FileName);
                return o;
                }  
            }
            return default(T);
        }

        //uploade de file naar de pad
        static async void UploadFile(IFormFile file, string pad)
        {
            using (var fileStream = new FileStream(Path.Combine(pad, file.FileName), FileMode.Create))
                try
                {
                    await file.CopyToAsync(fileStream);

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }

    }
}
