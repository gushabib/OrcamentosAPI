using AutoMapper;
using OrcamentosAPI.Data.Dtos.Seller;
using OrcamentosAPI.Models;

namespace OrcamentosAPI.Profiles
{
    public class VendedorProfile : Profile
    {
        public VendedorProfile()
        {
            CreateMap<CreateVendedorDto, Vendedor>();
            CreateMap<Vendedor, ReadVendedorDto>();
            CreateMap<UpdateVendedorDto, Vendedor>();
        }
    }
}
