namespace Eventures.Web
{
    using AutoMapper;
    using Eventures.Models;
    using Eventures.Web.ViewModels.Accounts;
    using Eventures.Web.ViewModels.Events;

    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            this.CreateMap<RegisterUserViewModel, EventureUser>();
            this.CreateMap<CreateEventInputModel, Event>();
        }
    }
}