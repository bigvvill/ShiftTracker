using ShiftTracker.Entities;
using ShiftTracker.Models.Dtos;

namespace ShiftTracker.Api.Extensions;

public static class DtoConversions
{
    public static IEnumerable<ShiftToAddDto> ConvertToDto(this IEnumerable<Shift> shifts)
    {
        return (from product in products
                join ProductCategory in productCategories
                on product.CategoryId equals ProductCategory.Id
                select new ShiftToAddDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    ImageURL = product.ImageURL,
                    Price = product.Price,
                    Qty = product.Qty,
                    CategoryId = product.CategoryId,
                    CategoryName = ProductCategory.Name
                }).ToList();
    }
}
