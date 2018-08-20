namespace SoftJail
{
    using AutoMapper;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;

    public class SoftJailProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public SoftJailProfile()
        {
            CreateMap<OfficerPrisoner, PrisonerIdImortDto>()
                .ForMember(op => op.Id,
                           x => x.MapFrom(src => src.PrisonerId));

            CreateMap<Officer, OfficerImportDto>()
            .ForMember(dto => dto.Name,
                       o => o.MapFrom(src => src.FullName))
            .ForMember(dto => dto.Money,
                       o => o.MapFrom(src => src.Salary))
            .ForMember(dto => dto.Position,
                       o => o.MapFrom(src => src.Position))
            .ForMember(dto => dto.Weapon,
                       o => o.MapFrom(src => src.Weapon))
            .ForMember(dto => dto.Prisoners,
                       o => o.MapFrom(src => Mapper.Map<List<OfficerPrisoner>, List<PrisonerIdImortDto>>(src.OfficerPrisoners)));


        }
    }
}
