namespace Sidub.Platform.NumberSequence.Providers.Sequential
{

    /// <summary>
    /// Represents a sequential number sequence provider that stores the current state in memory as a long value.
    /// </summary>
    public class SequentialNumberSequenceInMemoryLongStateProvider : SequentialNumberSequenceLongStateProvider
    {

        #region Member variables

        private long? _currentState;

        #endregion

        #region Public methods

        /// <summary>
        /// Gets the current value of the number sequence.
        /// </summary>
        /// <returns>The current value of the number sequence.</returns>
        public override Task<NumberSequenceValue<long>?> GetCurrentValue()
        {
            return Task.Run(() =>
            {
                if (_currentState is null)
                    return null;

                return new NumberSequenceValue<long>(_currentState.Value);
            });
        }

        /// <summary>
        /// Sets the current value of the number sequence.
        /// </summary>
        /// <param name="value">The value to set as the current value of the number sequence.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public override Task SetCurrentValue(NumberSequenceValue<long> value)
        {
            return Task.Run(() =>
            {
                _currentState = value.Value;
            });
        }

        #endregion

    }

}
