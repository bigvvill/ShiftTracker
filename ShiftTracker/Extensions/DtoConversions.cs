using ShiftTracker.Entities;

namespace ShiftTracker.Api.Extensions;

public static class DtoConversions
{
    //public static IEnumerable<ShiftToAddDto> ConvertToDto(this IEnumerable<Shift> shifts)
    //{
    //    return (from shift in shifts
    //            join ProductCategory in productCategories
    //            on product.CategoryId equals ProductCategory.Id
    //            select new ShiftToAddDto
    //            {
    //                Id = product.Id,
    //                Name = product.Name,
    //                Description = product.Description,
    //                ImageURL = product.ImageURL,
    //                Price = product.Price,
    //                Qty = product.Qty,
    //                CategoryId = product.CategoryId,
    //                CategoryName = ProductCategory.Name
    //            }).ToList();
    //}

    public static ShiftToAddDto ConvertToDto(this Shift shift)
    {
        return new ShiftToAddDto
                {                    
                    Start = shift.Start,
                    End = shift.End,
                    Pay = shift.Pay,
                    Minutes = shift.Minutes,
                    Location = shift.Location
                };
    }
}
