using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeEducation.Common.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Course, CourseDTO>();
            //CreateMap<Category,
            //    UpdateCategoryDiscountDto>().ReverseMap();
            //CreateMap<Category,
            //    GetCategoryProductsDto>();
            //CreateMap<Product,
            //    ProductDto>().ReverseMap();
        }
    }
}
