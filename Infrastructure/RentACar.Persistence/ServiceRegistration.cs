using Microsoft.Extensions.DependencyInjection;
using RentACar.Application.Features.CQRS.Handlers.AboutHandlers;
using RentACar.Application.Features.CQRS.Handlers.BannerHandlers.Read;
using RentACar.Application.Features.CQRS.Handlers.BannerHandlers.Write;
using RentACar.Application.Features.CQRS.Handlers.BrandHandlers.Read;
using RentACar.Application.Features.CQRS.Handlers.BrandHandlers.Write;
using RentACar.Application.Features.CQRS.Handlers.CarHandlers.Read;
using RentACar.Application.Features.CQRS.Handlers.CarHandlers.Write;
using RentACar.Application.Features.CQRS.Handlers.CategoryHandlers.Read;
using RentACar.Application.Features.CQRS.Handlers.CategoryHandlers.Write;
using RentACar.Application.Features.CQRS.Handlers.ContactHandlers.Read;
using RentACar.Application.Features.CQRS.Handlers.ContactHandlers.Write;
using RentACar.Application.IRepositories.IAuthorRepository;
using RentACar.Application.IRepositories.IBlogRepository;
using RentACar.Application.IRepositories.IBrandRepository;
using RentACar.Application.IRepositories.ICarBookingRepository;
using RentACar.Application.IRepositories.ICarDescriptionRepository;
using RentACar.Application.IRepositories.ICarFeatureRepository;
using RentACar.Application.IRepositories.ICarPricingRepository;
using RentACar.Application.IRepositories.ICarRepository;
using RentACar.Application.IRepositories.ICommentRepository;
using RentACar.Application.IRepositories.ILocationRepository;
using RentACar.Application.IRepositories.IReservationRepository;
using RentACar.Application.IRepositories.IReviewRepository;
using RentACar.Application.IRepositories.IServiceRepository;
using RentACar.Application.IRepositories.ITagCloudRepository;
using RentACar.Application.Repositories;
using RentACar.Persistence.Configuration;
using RentACar.Persistence.Contexts;
using RentACar.Persistence.Repositories;
using RentACar.Persistence.Repositories.AuthorRepository;
using RentACar.Persistence.Repositories.BlogRepository;
using RentACar.Persistence.Repositories.BrandRepository;
using RentACar.Persistence.Repositories.CarBookingRepository;
using RentACar.Persistence.Repositories.CarDescriptionRepository;
using RentACar.Persistence.Repositories.CarFeatureRepository;
using RentACar.Persistence.Repositories.CarPricingRepository;
using RentACar.Persistence.Repositories.CarRepository;
using RentACar.Persistence.Repositories.CommentRepository;
using RentACar.Persistence.Repositories.LocationRepository;
using RentACar.Persistence.Repositories.ReservationRepository;
using RentACar.Persistence.Repositories.ReviewRepository;
using RentACar.Persistence.Repositories.ServiceRepository;
using RentACar.Persistence.Repositories.TagCloudRepository;

namespace RentACar.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<RentACarContext>();

            services.AddScoped<IConnectionConfig, ConnectionConfig>();

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<CreateAboutCommandHandler>();
            services.AddScoped<GetAboutByIdQueryHandler>();
            services.AddScoped<GetAboutQueryHandler>();
            services.AddScoped<RemoveAboutCommandHandler>();
            services.AddScoped<UpdateAboutCommandHandler>();

            services.AddScoped<CreateBannerCommandHandler>();
            services.AddScoped<GetBannerByIdQueryHandler>();
            services.AddScoped<GetBannerQueryHandler>();
            services.AddScoped<RemoveBannerCommandHandler>();
            services.AddScoped<UpdateBannerCommandHandler>();

            services.AddScoped<GetBrandByIdQueryHandler>();
            services.AddScoped<GetBrandQueryHandler>();
            services.AddScoped<CreateBrandCommandHandler>();
            services.AddScoped<UpdateBrandCommandHandler>();
            services.AddScoped<RemoveBrandCommandHandler>();

            services.AddScoped<GetCarByIdQueryHandler>();
            services.AddScoped<GetCarQueryHandler>();
            services.AddScoped<CreateCarCommandHandler>();
            services.AddScoped<UpdateCarCommandHandler>();
            services.AddScoped<RemoveCarCommandHandler>();
            services.AddScoped<GetCarWithBrandQueryHandler>();

            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();

            services.AddScoped<GetContactByIdQueryHandler>();
            services.AddScoped<GetContactQueryHandler>();
            services.AddScoped<CreateContactCommandHandler>();
            services.AddScoped<UpdateContactCommandHandler>();
            services.AddScoped<RemoveContactCommandHandler>();

            services.AddScoped<ICarReadRepository, CarReadRepository>();
            services.AddScoped<IBlogReadRepository, BlogReadRepository>();

            services.AddScoped<ICommentReadRepository, CommentReadRepository>();
            services.AddScoped<ICommentWriteRepository, CommentWriteRepository>();

            services.AddScoped<ICarBookingReadRepository, CarBookingReadRepository>();
            services.AddScoped<ICarBookingWriteRepository, CarBookingWriteRepository>();

            services.AddScoped<IReservationReadRepository, ReservationReadRepository>();
            services.AddScoped<IReservationWriteRepository, ReservationWriteRepository>();

            services.AddScoped<ILocationReadRespository, LocationReadRepository>();


            services.AddScoped<IAuthorReadRepository, AuthorReadRepository>();

            services.AddScoped<ITagCloudReadRepository, TagCloudReadRepository>();


            services.AddScoped<IBlogReadRepository, BlogReadRepository>();


            services.AddScoped<IBrandReadRespoitory, BrandReadRepository>();


            services.AddScoped<ICarPricingReadRepository, CarPricingReadRepository>();


            services.AddScoped<IServiceReadRepository, ServiceReadRepository>();

            services.AddScoped<ICarDescriptionReadRepository, CarDescriptionReadRepository>();


            services.AddScoped<ICarFeatureReadRepository, CarFeatureReadRepository>();
            services.AddScoped<ICarFeatureWriteRepository, CarFeatureWriteRepository>();

            services.AddScoped<IReviewReadRepository, ReviewReadRepository>();
            services.AddScoped<IReviewWriteRepository, ReviewWriteRepository>();

        }
    }
}
