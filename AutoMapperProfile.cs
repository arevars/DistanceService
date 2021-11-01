//using AutoMapper;
//using System;

//namespace DistanceService
//{
//    public class AutoMapperProfile : Profile
//    {
//        public AutoMapperProfile()
//        {
//            //CreateMap<ViberMessage, NikitaMessage>();

//        }

//        public static MapperConfiguration GetMapperConfiguration()
//        {
//            var mapper = new MapperConfiguration(mc =>
//            {
//                mc.AddProfile(new AutoMapperProfile());
//            });

//            return mapper;
//        }
//    }

//    public static class MappingExpressionExtensions
//    {
//        public static IMappingExpression<TSource, TDest> IgnoreAllUnmapped<TSource, TDest>(this IMappingExpression<TSource, TDest> expression)
//        {
//            expression = expression ?? throw new ArgumentNullException(nameof(expression));

//            expression.ForAllMembers(opt => opt.Ignore());

//            return expression;
//        }
//    }
//}
