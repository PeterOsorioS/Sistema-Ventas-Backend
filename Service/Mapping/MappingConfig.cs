using Entities.Models;
using Mapster;
using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapping
{
    public class MappingConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<RegisterDTO, User>.NewConfig()
                .Map(dest => dest.FirstName, src => src.FirstName)
                .Map(dest => dest.LastName, src => src.LastName)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.Password, src => src.Password)
                .Map(dest => dest.DNI, src => src.DNI)
                .Map(dest => dest.IdRole, src => src.IdRole)
                .Map(dest => dest.Birthday, src => src.Birthdate.ToString());

            TypeAdapterConfig<Product, ProductDTO>.NewConfig()
                .PreserveReference(true);

            TypeAdapterConfig<CreateProductDTO, Product>.NewConfig()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.CodeQR, src => src.CodeQR)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.State, src => src.State)
                .Map(dest => dest.Stock, src => src.Stock)
                .Map(dest => dest.CreationDate, src => src.CreationDate.ToString());

            TypeAdapterConfig<IEnumerable<Product>, IEnumerable<ProductDTO>>
                .NewConfig()
                .MapWith(src => src.Select(item => item.Adapt<ProductDTO>()));

            TypeAdapterConfig<UpdateProductDTO, Product>.NewConfig()
                .Ignore(dest => dest.Id)
                .Ignore(dest => dest.CreationDate);

        }
    }
}
