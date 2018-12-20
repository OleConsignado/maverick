using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Linq;

namespace Maverick.Application.Tests
{
    public class ServiceProviderFactory
    {
        private readonly IServiceCollection services;

        public ServiceProviderFactory(Action<IServiceCollection> serviceLambda)
        {
            services = new ServiceCollection();
            services.AddLogging(c => c.AddDebug());
            serviceLambda?.Invoke(services);
        }

        public IServiceProvider CreateServiceProviderWithMocks(params Mock[] mocks)
        {
            foreach (var mock in mocks)
            {
                if (mock.GetType().GetGenericTypeDefinition() != typeof(Mock<>))
                {
                    throw new InvalidOperationException("Mock object should be of type Mock<T>");
                }

                services.AddTransient(mock.GetType().GetGenericArguments().Single(), c => mock.Object);
            }

            return services.BuildServiceProvider();
        }
    }
}
