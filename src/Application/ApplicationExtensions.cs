using Application.Commands.BuyerCommands;
using Application.DomainEventHandlers;
using Application.Queries;
using Application.Queries.BuyerQueries;
using Application.Queries.ViewModels;
using Domain.BuyerAggregate;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddInfrustractureDependencies();
            services.AddAutoMapper(typeof(ApplicationExtensions).Assembly);


            services.AddMediatR(typeof(ApplicationExtensions));
            services.AddScoped<IRequestHandler<AddBuyerCommand, bool>, AddBuyerCommandHandler>();
            services.AddScoped<IRequestHandler<GetBuyerByIdQuery, BuyerViewModel>, GetBuyerByIdQueryHandler>();
            services.AddScoped<INotificationHandler<BuyerCreatedEvent>, BuyerCreatedEventHandler>();

            return services;
        }
    }
}
