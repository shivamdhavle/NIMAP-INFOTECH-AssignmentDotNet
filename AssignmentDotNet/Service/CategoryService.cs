using AssignmentDotNet.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace AssignmentDotNet.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ProductDb conn;

        public CategoryService(ProductDb context)
        {
            conn = context;
        }

        // Get all categories without pagination
        public List<Category> GetCategories()
        {
            return conn.categories.ToList(); // Return all categories as a list
        }

        public void AddCategory(Category category)
        {
            if (conn.categories.Any(c => c.CategoryName == category.CategoryName))
            {
                throw new Exception("Category name already exists.");
            }

            conn.categories.Add(category);
            conn.SaveChanges();
        }

        public Category GetCategoryById(int id)
        {
            return conn.categories.Find(id); // Find category by Id
        }

        public void UpdateCategory(Category category)
        {
            if (conn.categories.Any(c => c.CategoryName == category.CategoryName && c.CategoryId != category.CategoryId))
            {
                throw new Exception("Category name already exists.");
            }

            conn.categories.Update(category);
            conn.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = conn.categories.Find(id);

            if (category != null)
            {
                conn.categories.Remove(category);
                conn.SaveChanges();
            }
            else
            {
                throw new Exception("Category not found.");
            }
        }
    }
}
