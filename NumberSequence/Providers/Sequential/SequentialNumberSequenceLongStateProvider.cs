namespace Sidub.Platform.NumberSequence.Providers.Sequential
{

    /// <summary>
    /// Represents a base class for sequential number sequence state providers with long values.
    /// </summary>
    public abstract class SequentialNumberSequenceLongStateProvider : ISequentialNumberSequenceStateProvider<long>
    {

        #region Public abstract methods

        /// <summary>
        /// Gets the current value of the number sequence.
        /// </summary>
        /// <returns>The current value of the number sequence.</returns>
        public abstract Task<NumberSequenceValue<long>?> GetCurrentValue();

        /// <summary>
        /// Sets the current value of the number sequence.
        /// </summary>
        /// <param name="value">The value to set as the current value of the number sequence.</param>
        public abstract Task SetCurrentValue(NumberSequenceValue<long> value);

        #endregion

        #region Public methods

        /// <summary>
        /// Gets the next value in the number sequence.
        /// </summary>
        /// <returns>The next value in the number sequence.</returns>
        public async Task<NumberSequenceValue<long>> GetNextValue()
        {
            NumberSequenceValue<long>? currentValue = await GetCurrentValue();
            var current = currentValue?.Value;
            long result;

            if (current is null)
            {
                result = GetInitialState();
            }
            else
            {
                long currentInner = current.Value;
                Increment(ref currentInner);

                result = currentInner;
            }

            return new NumberSequenceValue<long>(result);
        }

        #endregion

        #region Protected virtual methods

        /// <summary>
        /// Increments the current value of the number sequence.
        /// </summary>
        /// <param name="current">The current value of the number sequence to increment.</param>
        protected virtual void Increment(ref long current)
        {
            current++;
        }

        /// <summary>
        /// Gets the initial state of the number sequence.
        /// </summary>
        /// <returns>The initial state of the number sequence.</returns>
        protected virtual long GetInitialState()
        {
            return 0;
        }

        #endregion

    }

}
