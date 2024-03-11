namespace Sidub.Platform.NumberSequence.Providers
{

    /// <summary>
    /// Represents the options for a number sequence provider.
    /// </summary>
    public interface INumberSequenceOptions
    {
    }

    /// <summary>
    /// Represents the options for a number sequence provider with a specific type of number sequence provider.
    /// </summary>
    /// <typeparam name="TNumberSequenceProvider">The type of number sequence provider.</typeparam>
    public interface INumberSequenceOptions<in TNumberSequenceProvider> : INumberSequenceOptions where TNumberSequenceProvider : INumberSequenceProvider
    {
    }

}
