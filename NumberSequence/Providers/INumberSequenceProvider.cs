namespace Sidub.Platform.NumberSequence.Providers
{

    /// <summary>
    /// Represents a provider for generating number sequences.
    /// </summary>
    public interface INumberSequenceProvider
    {
        #region Interface methods

        /// <summary>
        /// Gets the value of the number sequence based on the provided options.
        /// </summary>
        /// <typeparam name="T">The type of the number sequence value.</typeparam>
        /// <param name="options">The options for generating the number sequence value.</param>
        /// <returns>The value of the number sequence.</returns>
        public Task<NumberSequenceValue<T>> GetValue<T>(INumberSequenceOptions options);

        #endregion
    }

}
