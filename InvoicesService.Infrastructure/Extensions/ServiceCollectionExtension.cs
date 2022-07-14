using InvoicesService.Core.Interfaces.Repositories;
using InvoicesService.Core.Interfaces.Services;
using InvoicesService.Core.Models.DatabaseModels;
using InvoicesService.Infrastructure.Repositories;
using InvoicesService.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InvoicesService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddTransient<IInvoiceRepository<Invoice>, InvoiceRepository>()
                .AddTransient<IInvoiceService, InvoiceService>();
        }
    }
}