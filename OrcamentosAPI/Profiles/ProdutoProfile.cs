using AutoMapper;
using OrcamentosAPI.Data.Dtos.Product;
using OrcamentosAPI.Models;

namespace OrcamentosAPI.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<CreateProdutoDto, Produto>();
            CreateMap<Produto, ReadProdutoDto>();
            CreateMap<UpdateProdutoDto, Produto>();
        }
    }
}
