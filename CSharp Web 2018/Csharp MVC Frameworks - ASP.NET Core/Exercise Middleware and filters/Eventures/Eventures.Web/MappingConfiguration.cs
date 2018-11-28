namespace Eventures.Web
{
    using AutoMapper;
    using Eventures.Models;
    using Eventures.Web.ViewModels.Accounts;
    using Eventures.Web.ViewModels.Events;
    using Eventures.Web.ViewModels.Orders;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            this.CreateMap<RegisterUserViewModel, EventureUser>();

            this.CreateMap<LoginUserInputModel, EventureUser>();

            this.CreateMap<CreateEventInputModel, Event>();

            this.CreateMap<Event, MyEventsViewModel>()
                .ForMember(e => e.EventName,
                x => x.MapFrom(src => src.Name))
                .ForMember(e => e.MyTickets,
                x => x.MapFrom(src => src.TotalTickets))
                .ForMember(e => e.EndDate, 
                x => x.MapFrom(src => src.End))
                .ForMember(e => e.StartDate,
                x => x.MapFrom(src => src.Start));

            this.CreateMap<Order, OrderViewModel>()
                .ForMember(x => x.CustomerName,
                o => o.MapFrom(src => src.Customer.UserName))
                .ForMember(x => x.EventName,
                o => o.MapFrom(src => src.Event.Name));
        }
    }
}