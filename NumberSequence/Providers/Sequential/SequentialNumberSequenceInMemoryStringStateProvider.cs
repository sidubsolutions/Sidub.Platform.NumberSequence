namespace Sidub.Platform.NumberSequence.Providers.Sequential
{

    /// <summary>
    /// Represents a sequential number sequence provider that stores the state in memory as a string.
    /// </summary>
    public class SequentialNumberSequenceInMemoryStringStateProvider : SequentialNumberSequenceStringStateProvider
    {

        #region Member variables

        private string? _currentState;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SequentialNumberSequenceInMemoryStringStateProvider"/> class with the specified width.
        /// </summary>
        /// <param name="width">The width of the number sequence.</param>
        public SequentialNumberSequenceInMemoryStringStateProvider(int width) : base(width)
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets the current value of the number sequence.
        /// </summary>
        /// <returns>The current value of the number sequence.</returns>
        public override Task<NumberSequenceValue<string>?> GetCurrentValue()
        {
            if (_currentState is null)
                return Task.FromResult<NumberSequenceValue<string>?>(null);

            return Task.FromResult<NumberSequenceValue<string>?>(new NumberSequenceValue<string>(_currentState));
        }

        /// <summary>
        /// Sets the current value of the number sequence.
        /// </summary>
        /// <param name="value">The value to set as the current value of the number sequence.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public override Task SetCurrentValue(NumberSequenceValue<string> value)
        {
            _currentState = value.Value;

            return Task.CompletedTask;
        }

        #endregion

    }

}
