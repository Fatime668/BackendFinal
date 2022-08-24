using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IGalleryService
    {
        List<Gallery> GetGalleries();

        List<Category> GetCategories();
        Task<Category> GetCategoryById(int id);
        List<Gallery> GalleryFilter(int? categoryId);
    }
}
