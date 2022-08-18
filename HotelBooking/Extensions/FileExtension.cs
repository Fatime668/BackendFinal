using Microsoft.AspNetCore.Http;

namespace HotelBooking.Extensions
{
    public static class FileExtension
    {
        public static bool IsOkay(this IFormFile file, int mb)
        {
            return file.ContentType.Contains("image") && file.Length < mb * 1024 * 1024;
        }
    }
}
