using AutoMapper;

namespace BookManagement.Helpper.Config
{
    public class MapperConfig<TEntity, TModel>
         where TEntity : class
        where TModel : class
    {
        public static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TEntity, TModel>();
                cfg.CreateMap<TModel, TEntity>();
            });
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}