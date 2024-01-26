using Application.Interfaces.AutoMapper;
using AutoMapper;
using AutoMapper.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Mapppers
{
    public class AutoMapperCommon : IAutoMapper
    {
        public static List<TypePair> typePairs = new();
       
        public IMapper _mapper;
        
        public TDestination Map<TDestination, TSource>(TSource soure, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);
            return _mapper.Map<TSource, TDestination>(soure);
            
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> sources, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);
            return _mapper.Map<IList<TSource>, IList<TDestination>>(sources);
        }

        public TDestination Map<TDestination>(object soure, string? ignore = null)
        {
            Config<TDestination, object>(5, ignore);
            return _mapper.Map<TDestination>(soure);
        }

        public IList<TDestination> Map<TDestination>(IList<object> sources, string? ignore = null)
        {
            Config<TDestination,IList<object>>(5, ignore);
            return _mapper.Map<IList<TDestination>>(sources);
        }
        protected void Config<TDestionation,TSoure>(int depth =5,string? ingore = null)
        {
            var typePair = new TypePair(typeof(TSoure),typeof(TDestionation));
            if(typePairs.Any(a => a.DestinationType == typePair.DestinationType && a.SourceType == typePair.SourceType) && ingore is null)
            {
                return;
}
                typePairs.Add(typePair);
                var config = new MapperConfiguration(cfg =>
                {
                    foreach (var item in typePairs)
                    {
                        if (ingore is not null)
                            cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ForMember(ingore, x => x.Ignore()).ReverseMap();
                        else
                            cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ReverseMap();

                    }
                });
                _mapper = config.CreateMapper();
            
        }
    }
}
