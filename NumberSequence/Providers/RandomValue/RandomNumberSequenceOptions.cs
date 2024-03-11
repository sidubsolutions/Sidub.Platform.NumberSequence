namespace Sidub.Platform.NumberSequence.Providers.RandomValue
{

    /// <summary>
    /// Represents the options for generating a random number sequence.
    /// </summary>
    public class RandomNumberSequenceOptions : INumberSequenceOptions<RandomNumberSequenceProvider>
    {

        #region Public properties

        /// <summary>
        /// Gets or sets the length of the random number sequence.
        /// </summary>
        public int Length { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomNumberSequenceOptions"/> class with the specified length.
        /// </summary>
        /// <param name="length">The length of the random number sequence.</param>
        public RandomNumberSequenceOptions(int length)
        {
            Length = length;
        }

        #endregion

    }

}
