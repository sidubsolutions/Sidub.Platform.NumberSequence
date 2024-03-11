namespace Sidub.Platform.NumberSequence
{

    /// <summary>
    /// Represents a number sequence value.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public class NumberSequenceValue<TValue>
    {

        #region Public properties

        /// <summary>
        /// Gets the value of the number sequence.
        /// </summary>
        public TValue Value { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberSequenceValue{TValue}"/> class.
        /// </summary>
        /// <param name="value">The value of the number sequence.</param>
        public NumberSequenceValue(TValue value)
        {
            Value = value;
        }

        #endregion

    }

}
