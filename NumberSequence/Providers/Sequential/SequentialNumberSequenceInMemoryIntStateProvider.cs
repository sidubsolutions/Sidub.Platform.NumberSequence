namespace Sidub.Platform.NumberSequence.Providers.Sequential
{

    /// <summary>
    /// Represents a number sequence state provider that stores the current state in memory as an integer.
    /// </summary>
    public class SequentialNumberSequenceInMemoryIntStateProvider : SequentialNumberSequenceIntStateProvider
    {
        #region Member variables

        private int? _currentState;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SequentialNumberSequenceInMemoryIntStateProvider"/> class.
        /// </summary>
        public SequentialNumberSequenceInMemoryIntStateProvider() : base()
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets the current value of the number sequence.
        /// </summary>
        /// <returns>The current value of the number sequence.</returns>
        public override Task<NumberSequenceValue<int>?> GetCurrentValue()
        {
            return Task.Run(() =>
            {
                if (_currentState is null)
                    return null;

                return new NumberSequenceValue<int>(_currentState.Value);
            });
        }

        /// <summary>
        /// Sets the current value of the number sequence.
        /// </summary>
        /// <param name="value">The value to set as the current value of the number sequence.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public override Task SetCurrentValue(NumberSequenceValue<int> value)
        {
            return Task.Run(() =>
            {
                _currentState = value.Value;
            });
        }

        #endregion

    }

}
