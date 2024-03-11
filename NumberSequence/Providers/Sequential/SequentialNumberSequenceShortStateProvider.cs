namespace Sidub.Platform.NumberSequence.Providers.Sequential
{

    /// <summary>
    /// Represents a base class for sequential number sequence state providers with short data type.
    /// </summary>
    public abstract class SequentialNumberSequenceShortStateProvider : ISequentialNumberSequenceStateProvider<short>
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SequentialNumberSequenceShortStateProvider"/> class.
        /// </summary>
        public SequentialNumberSequenceShortStateProvider()
        {

        }

        #endregion

        #region Public abstract methods

        /// <summary>
        /// Gets the current value of the number sequence.
        /// </summary>
        /// <returns>The current value of the number sequence.</returns>
        public abstract Task<NumberSequenceValue<short>?> GetCurrentValue();

        /// <summary>
        /// Sets the current value of the number sequence.
        /// </summary>
        /// <param name="value">The value to set as the current value of the number sequence.</param>
        public abstract Task SetCurrentValue(NumberSequenceValue<short> value);

        #endregion

        #region Public methods

        /// <summary>
        /// Gets the next value in the number sequence.
        /// </summary>
        /// <returns>The next value in the number sequence.</returns>
        public async Task<NumberSequenceValue<short>> GetNextValue()
        {
            NumberSequenceValue<short>? currentValue = await GetCurrentValue();
            var current = currentValue?.Value;
            short result;

            if (current is null)
            {
                result = GetInitialState();
            }
            else
            {
                short currentInner = current.Value;
                Increment(ref currentInner);

                result = currentInner;
            }

            return new NumberSequenceValue<short>(result);
        }

        #endregion

        #region Protected virtual methods

        /// <summary>
        /// Increments the current value of the number sequence.
        /// </summary>
        /// <param name="current">The current value of the number sequence to increment.</param>
        protected virtual void Increment(ref short current)
        {
            current++;
        }

        /// <summary>
        /// Gets the initial state of the number sequence.
        /// </summary>
        /// <returns>The initial state of the number sequence.</returns>
        protected virtual short GetInitialState()
        {
            return 0;
        }

        #endregion

    }

}
