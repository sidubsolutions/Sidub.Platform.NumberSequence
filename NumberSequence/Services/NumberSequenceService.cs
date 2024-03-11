#region Imports

using Sidub.Platform.NumberSequence.Providers;

#endregion

namespace Sidub.Platform.NumberSequence.Services
{

    /// <summary>
    /// Number sequence service implementation.
    /// </summary>
    public class NumberSequenceService : INumberSequenceService
    {

        #region Readonly members

        private readonly List<INumberSequenceProvider> _providers;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberSequenceService"/> class.
        /// </summary>
        /// <param name="providers">The collection of number sequence providers.</param>
        public NumberSequenceService(IEnumerable<INumberSequenceProvider> providers)
        {
            _providers = providers.ToList();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Retrieves a provider for a given number sequence options implementation.
        /// </summary>
        /// <typeparam name="TNumberSequenceProvider">Type of number sequence provider; implied from parameter.</typeparam>
        /// <param name="options">Typed number sequence options instance.</param>
        /// <returns>A typed number sequence provider instance.</returns>
        public TNumberSequenceProvider GetProvider<TNumberSequenceProvider>(INumberSequenceOptions<TNumberSequenceProvider> options)
            where TNumberSequenceProvider : class, INumberSequenceProvider
        {
            TNumberSequenceProvider result = _providers.SingleOrDefault(provider => provider is TNumberSequenceProvider) as TNumberSequenceProvider
                ?? throw new Exception($"Provider not found for options class '{options.GetType().Name}'.");

            return result;
        }

        #endregion

    }
}
