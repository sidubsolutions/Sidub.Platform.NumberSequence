namespace Sidub.Platform.NumberSequence.Providers.Sequential
{

    /// <summary>
    /// Represents the options for a sequential number sequence provider.
    /// </summary>
    /// <typeparam name="TValue">The type of the values in the number sequence.</typeparam>
    public class SequentialNumberSequenceOptions<TValue> : INumberSequenceOptions<SequentialNumberSequenceProvider>
    {

        #region Public properties

        /// <summary>
        /// Gets the state provider for the sequential number sequence.
        /// </summary>
        public ISequentialNumberSequenceStateProvider<TValue> StateProvider { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SequentialNumberSequenceOptions{TValue}"/> class.
        /// </summary>
        /// <param name="stateProvider">The state provider for the sequential number sequence.</param>
        public SequentialNumberSequenceOptions(ISequentialNumberSequenceStateProvider<TValue> stateProvider)
        {
            StateProvider = stateProvider;
        }

        #endregion

    }

}
