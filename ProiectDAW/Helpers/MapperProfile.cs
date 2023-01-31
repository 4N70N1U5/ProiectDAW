using AutoMapper;
using ProiectDAW.Models;
using ProiectDAW.Models.DTOs.OrderDTOs;
using ProiectDAW.Models.DTOs.PaymentDTOs;
using ProiectDAW.Models.DTOs.PublisherDTOs;
using ProiectDAW.Models.DTOs.UserDTOs;
using ProiectDAW.Models.DTOs.VideoGamesDTOs;

namespace ProiectDAW.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<User, UserGetDTO>();
            CreateMap<User, UserGetInfoDTO>();

            CreateMap<Order, OrderGetDTO>();
            CreateMap<Order, OrderGetInfoDTO>();
            CreateMap<Order, OrderGetInfoUserDTO>();
            CreateMap<Order, OrderGetInfoPaymentDTO>();

            CreateMap<Payment, PaymentGetDTO>();
            CreateMap<Payment, PaymentGetInfoDTO>();

            CreateMap<Publisher, PublisherGetDTO>();
            CreateMap<Publisher, PublisherGetInfoDTO>();

            CreateMap<VideoGame, VideoGameGetDTO>();
            CreateMap<VideoGame, VideoGameGetInfoDTO>();
        }
    }
}
