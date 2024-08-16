# Sidub Platform - Number Sequence

This repository contains the number sequence module for the Sidub Platform. It
provides the ability to generate and manage number sequences. Number sequences
are structured sequences of characters that are used to generate unique
identifiers and may be used for invoice numbers, order numbers, and other
various identifiers.

## Main Components

### Number sequence service

The number sequence service (`INumberSequenceService`) allows the retrieval of
a number sequence provider provided an options instance. An option class is
available for each of the available number sequence types - random, sequential,
GUID.

## Usage

To use the Sidub Platform number sequence module, you can register it within
your dependency injection container and use the provided interfaces and classes
to work with number sequence providers.

```csharp
public void ConfigureServices(IServiceCollection services)
{
  services.AddSidubNumberSequence();
}
```

The `AddSidubNumberSequence` method registers the required services and providers
within the containers.

### Unique identifier (GUID)
The unique identifier number sequence provider returns number sequences as unique
identifiers (GUIDs). The unique identifier may be retrieved as a Guid, byte[],
or string.

```csharp
public class MyService
{

  private readonly IServiceRegistry _metadataService;

  public MyService(IServiceRegistry metadataService)
  {
    _metadataService = metadataService;
  }

  public async Task Process()
  {
    var options = new GuidNumberSequenceOptions();
    var provider = _numberSequenceService.GetProvider(options);

    var guidSequence = await provider.GetValue<Guid>(options);
    var byteSequence = await provider.GetValue<byte[]>(options);
    var stringSequence = await provider.GetValue<string>(options);
    
    Guid guidResult = guidSequence.Value;
    byte[] byteResult = byteSequence.Value;
    string stringResult = stringSequence.Value;
  }

}
```

### Sequential number sequence
The sequential number sequence provider returns number sequences as a sequence
of characters. Integer, long, short, and string are supported sequence value
types. These providers maintain state and state providers are used to maintain
state; interally, in-memory state providers are available leaving the
responsibility of the implementation to maintain the provider's state.
Additional libraries extend the state provider to use a database or other
storage mechanism.

The below example demonstates the integer and string implementations which vary
slightly - the string implementation requires the configuraiton of the width of
the sequence.

```csharp
public class MyService
{

  private readonly IServiceRegistry _metadataService;

  public MyService(IServiceRegistry metadataService)
  {
    _metadataService = metadataService;
  }

  public async Task ProcessInteger()
  {
    var sequentialProvider = new SequentialNumberSequenceInMemoryIntStateProvider();
    var options = new SequentialNumberSequenceOptions<int>(sequentialProvider);
    var provider = _numberSequenceService.GetProvider(options);

    // retrieve number sequence...
    var sequenceValue = await provider.GetValue<int>(options);
    int result = result.Value; // 0

    sequenceValue = await provider.GetValue<int>(options);
    result = result.Value; // 1
  }

  public async Task ProcessString()
  {            
    // configure an in-memory state provider for the sequential number provider,
    //  set width to 5...
    var sequentialProvider = new SequentialNumberSequenceInMemoryStringStateProvider(5);
    var options = new SequentialNumberSequenceOptions<string>(sequentialProvider);
    var provider = _numberSequenceService.GetProvider(options);

    // retrieve number sequence value...
    var sequenceValue = await provider.GetValue<string>(options);
    string result = result.Value; // "00000"

    sequenceValue = await provider.GetValue<string>(options);
    result = result.Value; // "00001"
  }

}
```

### Random number sequence
The random number sequence provider determines the number sequence using
randomness and currently does not guarantee uniqueness; maintaining state may
be introduced in the future to support this. Random number sequences may be
retrieved as an integer, long, short, or string and are configured using a
length parameter on the options. The length defines the number of characters
in the sequence.

Be wary of the length and data type combinations as the length may exceed the
maximum value supported of the data type. For example, an integer has a maximum
value of 2,147,483,647 and a length of 10 could exceed this value and a length
of 11 would. This limitation only exists for numeric types and tends not to be
an issue for string types.

```csharp
public class MyService
{

  private readonly IServiceRegistry _metadataService;

  public MyService(IServiceRegistry metadataService)
  {
    _metadataService = metadataService;
  }

  public async Task Process()
  {
    var options = new RandomNumberSequenceOptions(10);
    var provider = _numberSequenceService.GetProvider(options);

    var stringSequence = await provider.GetValue<string>(options);
    string stringResult = stringSequence.Value; // i.e., "d8k30lo42w"

    var intSequence = await provider.GetValue<int>(options);
    int intResult = intSequence.Value; // i.e., 1136863213
  }

}
```

## License
This project is dual-licensed under the AGPL v3 or a proprietary license. For
details, see [https://sidub.ca/licensing](https://sidub.ca/licensing) or the
LICENSE.txt file.