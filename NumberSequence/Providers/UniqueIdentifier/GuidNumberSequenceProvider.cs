/*
 * Sidub Platform - Number Sequence
 * Copyright (C) 2024 Sidub Inc.
 * All rights reserved.
 *
 * This file is part of Sidub Platform - Number Sequence (the "Product").
 *
 * The Product is dual-licensed under:
 * 1. The GNU Affero General Public License version 3 (AGPLv3)
 * 2. Sidub Inc.'s Proprietary Software License Agreement (PSLA)
 *
 * You may choose to use, redistribute, and/or modify the Product under
 * the terms of either license.
 *
 * The Product is provided "AS IS" and "AS AVAILABLE," without any
 * warranties or conditions of any kind, either express or implied, including
 * but not limited to implied warranties or conditions of merchantability and
 * fitness for a particular purpose. See the applicable license for more
 * details.
 *
 * See the LICENSE.txt file for detailed license terms and conditions or
 * visit https://sidub.ca/licensing for a copy of the license texts.
 */

namespace Sidub.Platform.NumberSequence.Providers.UniqueIdentifier
{

    /// <summary>
    /// Provides a number sequence value using a GUID as the identifier.
    /// </summary>
    public class GuidNumberSequenceProvider : INumberSequenceProvider
    {

        #region Public methods

        /// <summary>
        /// Gets the number sequence value based on the provided options.
        /// </summary>
        /// <typeparam name="T">The type of the number sequence value.</typeparam>
        /// <param name="options">The number sequence options.</param>
        /// <returns>The number sequence value.</returns>
        /// <exception cref="ArgumentException">Thrown when a non-null GuidNumberSequenceOptions is not provided.</exception>
        public Task<NumberSequenceValue<T>> GetValue<T>(INumberSequenceOptions options)
        {
            if (options is null || options is not GuidNumberSequenceOptions)
                throw new ArgumentException(nameof(options), "A non-null GuidNumberSequenceOptions must be provided.");

            return Task.Run(() =>
            {
                var guidNumberOptions = options as GuidNumberSequenceOptions ?? throw new Exception($"Invalid options type '{options?.GetType().Name}' provided.");
                NumberSequenceValue<T> numberSequenceValue;
                Guid value = Guid.NewGuid();

                switch (typeof(T))
                {
                    case var TType when TType == typeof(Guid):
                        numberSequenceValue = new NumberSequenceValue<Guid>(value) as NumberSequenceValue<T>
                            ?? throw new Exception("Null number sequence value encountered.");

                        break;
                    case var TType when TType == typeof(byte[]):
                        var byteValue = value.ToByteArray();

                        numberSequenceValue = new NumberSequenceValue<byte[]>(byteValue) as NumberSequenceValue<T>
                            ?? throw new Exception("Null number sequence value encountered.");

                        break;
                    case var TType when TType == typeof(string):
                        var stringValue = value.ToString("B");

                        numberSequenceValue = new NumberSequenceValue<string>(stringValue) as NumberSequenceValue<T>
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
