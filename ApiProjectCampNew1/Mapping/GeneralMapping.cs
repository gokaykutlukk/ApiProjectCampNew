using ApiProjectCampNew1.Dtos.FeatureDtos;
using ApiProjectCampNew1.Dtos.MessageDtos;
using ApiProjectCampNew1.Entities;
using AutoMapper;

namespace ApiProjectCampNew1.Mapping
{
    public class GeneralMapping : Profile
    { //ctor
        public GeneralMapping()
        {
            CreateMap<Feature,ResultFeatureDto>().ReverseMap();
            CreateMap<Feature,CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature,GetByIdFeatureDto>().ReverseMap();
          
            CreateMap<Message,ResultMessageDto>().ReverseMap();
            CreateMap<Message,CreateMessageDto>().ReverseMap();
            CreateMap<Message,UpdateMessageDto>().ReverseMap();
            CreateMap<Message,GetByIdMessageDto>().ReverseMap();
        }
    }
}
