#region Imports

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sidub.Platform.NumberSequence.Providers;
using Sidub.Platform.NumberSequence.Providers.RandomValue;
using Sidub.Platform.NumberSequence.Providers.Sequential;
using Sidub.Platform.NumberSequence.Providers.UniqueIdentifier;
using Sidub.Platform.NumberSequence.Services;

#endregion

namespace Sidub.Platform.NumberSequence
{

    /// <summary>
    /// Static helper class providing IServiceCollection extensions.
    /// </summary>
    public static class ServiceCollectionExtension
    {

        #region Extension methods

        /// <summary>
        /// Registers the Sidub filter system within the container. Initializes base configuration.
        /// </summary>
        /// <param name="services">IServiceCollection extension.</param>
        /// <param name="parser">Filter parser configuration type.</param>
        /// <returns>IServiceCollection result.</returns>
        public static IServiceCollection AddSidubNumberSequence(
            this IServiceCollection services)
        {
            services.TryAddEnumerable(ServiceDescriptor.Transient<INumberSequenceProvider, RandomNumberSequenceProvider>());
            services.TryAddEnumerable(ServiceDescriptor.Transient<INumberSequenceProvider, GuidNumberSequenceProvider>());
            services.TryAddEnumerable(ServiceDescriptor.Transient<INumberSequenceProvider, SequentialNumberSequenceProvider>());
            services.TryAddTransient<INumberSequenceService, NumberSequenceService>();

            return services;
        }

        #endregion

    }

}
