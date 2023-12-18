using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.Helpers
{
    public static class ImageConversions
    {
        public static async Task<byte[]> ConvertToByteArrayAsync(IFormFile file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);

                return memoryStream.ToArray();
            }
        }

        public static async Task<string> ConvertToIFormFile(byte[] fileBytes)
        {
            using (MemoryStream memoryStream = new MemoryStream(fileBytes))
            {
                var base64 = Convert.ToBase64String(fileBytes);

                return string.Format("data:image/jpg;base64,{0}", base64);
            }
        }
    }
}
