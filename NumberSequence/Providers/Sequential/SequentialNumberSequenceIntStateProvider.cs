namespace Sidub.Platform.NumberSequence.Providers.Sequential
{

    /// <summary>
    /// Represents an abstract base class for a sequential number sequence state provider that works with integers.
    /// </summary>
    public abstract class SequentialNumberSequenceIntStateProvider : ISequentialNumberSequenceStateProvider<int>
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SequentialNumberSequenceIntStateProvider"/> class.
        /// </summary>
        public SequentialNumberSequenceIntStateProvider()
        {

        }

        #endregion

        #region Public abstract methods

        /// <summary>
        /// Gets the current value of the number sequence.
        /// </summary>
        /// <returns>The current value of the number sequence, or null if the value is not available.</returns>
        public abstract Task<NumberSequenceValue<int>?> GetCurrentValue();

        /// <summary>
        /// Sets the current value of the number sequence.
        /// </summary>
        /// <param name="value">The new value to set.</param>
        public abstract Task SetCurrentValue(NumberSequenceValue<int> value);

        #endregion

        #region Public methods

        /// <summary>
        /// Gets the next value in the number sequence.
        /// </summary>
        /// <returns>The next value in the number sequence.</returns>
        public async Task<NumberSequenceValue<int>> GetNextValue()
        {
            NumberSequenceValue<int>? currentValue = await GetCurrentValue();
            var current = currentValue?.Value;
            int result;

            if (current is null)
            {
                result = GetInitialState();
            }
            else
            {
                int currentInner = current.Value;
                Increment(ref currentInner);

                result = currentInner;
            }

            return new NumberSequenceValue<int>(result);
        }

        #endregion

        #region Protected virtual methods

        /// <summary>
        /// Increments the current value by one.
        /// </summary>
        /// <param name="current">The current value to increment.</param>
        protected virtual void Increment(ref int current)
        {
            current++;
        }

        /// <summary>
        /// Gets the initial state of the number sequence.
        /// </summary>
        /// <returns>The initial state of the number sequence.</returns>
        protected virtual int GetInitialState()
        {
            return 0;
        }

        #endregion

    }

}
