using AutoMapper;
using OrcamentosAPI.Data.Dtos;
using OrcamentosAPI.Models;

namespace OrcamentosAPI.Profiles
{
    public class LivroProfile : Profile
    {
        public LivroProfile()
        {
            CreateMap<CreateLivroDto, Livro>();
            CreateMap<Livro, ReadLivroDto>();
            CreateMap<UpdateLivroDto, Livro>();
        }
    }
}
