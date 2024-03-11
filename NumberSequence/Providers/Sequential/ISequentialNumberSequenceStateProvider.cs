namespace Sidub.Platform.NumberSequence.Providers.Sequential
{

    /// <summary>
    /// Represents a provider for managing the state of a sequential number sequence.
    /// </summary>
    /// <typeparam name="TValue">The type of the number sequence value.</typeparam>
    public interface ISequentialNumberSequenceStateProvider<TValue>
    {

        #region Interface methods

        /// <summary>
        /// Gets the current value of the number sequence.
        /// </summary>
        /// <returns>The current value of the number sequence, or null if the value is not available.</returns>
        Task<NumberSequenceValue<TValue>?> GetCurrentValue();

        /// <summary>
        /// Sets the current value of the number sequence.
        /// </summary>
        /// <param name="value">The new value to set.</param>
        Task SetCurrentValue(NumberSequenceValue<TValue> value);

        /// <summary>
        /// Gets the next value of the number sequence.
        /// </summary>
        /// <returns>The next value of the number sequence.</returns>
        Task<NumberSequenceValue<TValue>> GetNextValue();

        #endregion

    }

}
