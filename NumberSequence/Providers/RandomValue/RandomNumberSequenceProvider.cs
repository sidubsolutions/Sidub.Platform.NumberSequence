namespace Sidub.Platform.NumberSequence.Providers.RandomValue
{

    /// <summary>
    /// Provides a random number sequence.
    /// </summary>
    public class RandomNumberSequenceProvider : INumberSequenceProvider
    {

        #region Public methods

        /// <summary>
        /// Gets a random number sequence value.
        /// </summary>
        /// <typeparam name="T">The type of the number sequence value.</typeparam>
        /// <param name="options">The number sequence options.</param>
        /// <returns>A task representing the asynchronous operation that returns the number sequence value.</returns>
        public Task<NumberSequenceValue<T>> GetValue<T>(INumberSequenceOptions options)
        {
            return Task.Run(() =>
            {
                var randomNumberOptions = options as RandomNumberSequenceOptions ?? throw new Exception($"Invalid options type '{options?.GetType().Name}' provided.");
                NumberSequenceValue<T> numberSequenceValue;
                var rand = new Random();
                string chars;
                string value = string.Empty;

                switch (typeof(T))
                {
                    case var TType when TType == typeof(string):
                        chars = "abcdefghijklmnopqrstuvwxyz0123456789";

                        for (int i = 0; i < randomNumberOptions.Length; i++)
                        {
                            int index = rand.Next(chars.Length);
                            value += chars[index];
                        }

                        numberSequenceValue = new NumberSequenceValue<string>(value) as NumberSequenceValue<T>
                            ?? throw new Exception("Null number sequence value encountered.");

                        break;
                    case var TType when TType == typeof(short):
                        chars = "0123456789";

                        for (int i = 0; i < randomNumberOptions.Length; i++)
                        {
                            int index = rand.Next(chars.Length);
                            value += chars[index];
                        }

                        short shortValue;
                        if (!short.TryParse(value, out shortValue))
                            throw new Exception($"Unable to parse '{value}' to short.");

                        numberSequenceValue = new NumberSequenceValue<short>(shortValue) as NumberSequenceValue<T>
                            ?? throw new Exception("Null number sequence value encountered.");

                        break;
                    case var TType when TType == typeof(int):
                        chars = "0123456789";

                        for (int i = 0; i < randomNumberOptions.Length; i++)
                        {
                            int index = rand.Next(chars.Length);
                            value += chars[index];
                        }

                        int intValue;
                        if (!int.TryParse(value, out intValue))
                            throw new Exception($"Unable to parse '{value}' to integer.");

                        numberSequenceValue = new NumberSequenceValue<int>(intValue) as NumberSequenceValue<T>
                            ?? throw new Exception("Null number sequence value encountered.");

                        break;
                    case var TType when TType == typeof(long):
                        chars = "0123456789";

                        for (int i = 0; i < randomNumberOptions.Length; i++)
                        {
                            int index = rand.Next(chars.Length);
                            value += chars[index];
                        }

                        long longValue;
                        if (!long.TryParse(value, out longValue))
                            throw new Exception($"Unable to parse '{value}' to long.");

                        numberSequenceValue = new NumberSequenceValue<long>(longValue) as NumberSequenceValue<T>
                            ?? throw new Exception("Null number sequence value encountered.");

                        break;
                    default:
                        throw new Exception($"Unhandled value type '{typeof(T).Name}' encountered in random number sequence provider.");
                }

                return numberSequenceValue;
            });
        }

        #endregion

    }

}
