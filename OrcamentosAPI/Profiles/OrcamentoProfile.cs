using AutoMapper;
using OrcamentosAPI.Data.Dtos;
using OrcamentosAPI.Models;

namespace OrcamentosAPI.Profiles
{
    public class OrcamentoProfile : Profile
    {
        public OrcamentoProfile()
        {

            CreateMap<CreateOrcamentoDto, Orcamento>();
            CreateMap<Orcamento, ReadOrcamentoDto>();
        }
    }
}
