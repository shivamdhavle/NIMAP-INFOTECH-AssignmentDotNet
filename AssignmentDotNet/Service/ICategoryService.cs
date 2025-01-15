using AssignmentDotNet.Models;
using System.Collections.Generic;

namespace AssignmentDotNet.Service
{
    public interface ICategoryService
    {
        // Method to get all categories without pagination
        List<Category> GetCategories();

        Category GetCategoryById(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
