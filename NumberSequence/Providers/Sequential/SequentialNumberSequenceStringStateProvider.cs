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

namespace Sidub.Platform.NumberSequence.Providers.Sequential
{

    /// <summary>
    /// Represents a base class for sequential number sequence state providers that generate string values.
    /// </summary>
    /// <typeparam name="string">The type of the number sequence value.</typeparam>
    public abstract class SequentialNumberSequenceStringStateProvider : ISequentialNumberSequenceStateProvider<string>
    {

        #region Readonly members

        private readonly int _width;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SequentialNumberSequenceStringStateProvider"/> class with the specified width.
        /// </summary>
        /// <param name="width">The width of the number sequence value.</param>
        public SequentialNumberSequenceStringStateProvider(int width)
        {
            _width = width;
        }

        #endregion

        #region Public abstract methods

        /// <summary>
        /// Gets the current value of the number sequence.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the current number sequence value.</returns>
        public abstract Task<NumberSequenceValue<string>?> GetCurrentValue();

        /// <summary>
        /// Sets the current value of the number sequence.
        /// </summary>
        /// <param name="value">The new value of the number sequence.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public abstract Task SetCurrentValue(NumberSequenceValue<string> value);

        #endregion

        #region Public methods

        /// <summary>
        /// Gets the next value of the number sequence.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the next number sequence value.</returns>
        public async Task<NumberSequenceValue<string>> GetNextValue()
        {
            NumberSequenceValue<string>? currentValue = await GetCurrentValue();
            var current = currentValue?.Value;

            if (current is null)
            {
                current = GetInitialState();
            }
            else
            {
                var lastCharIndex = current.Length - 1;
                Increment(ref current, lastCharIndex);
            }

            return new NumberSequenceValue<string>(current);
        }

        #endregion

        #region Protected virtual methods

        /// <summary>
        /// Increments the current value of the number sequence.
        /// </summary>
        /// <param name="current">The current value of the number sequence.</param>
        /// <param name="currentIncrementIndex">The index of the character to increment.</param>
        protected virtual void Increment(ref string current, int currentIncrementIndex)
        {
            if (currentIncrementIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(currentIncrementIndex), $"String '{current}' has been fully incremented.");

            var chars = "0123456789abcdefghijklmnopqrstuvwxyz";

            var currentChar = current[currentIncrementIndex];
            char[] currentAsArray = current.ToCharArray() ?? throw new Exception("Current number sequence failed to produce character array.");

            if (IsMaxChar(currentChar))
            {
                // current analyzed char is at max, we will need to reset it and then increment the next char
                currentAsArray[currentIncrementIndex] = chars[0];
                var currentForRecursive = new string(currentAsArray);

                Increment(ref currentForRecursive, currentIncrementIndex - 1);

                currentAsArray = currentForRecursive.ToCharArray();
            }
            else
            {
                int currentCharIndex = chars.IndexOf(currentChar);
                currentAsArray[currentIncrementIndex] = chars[currentCharIndex + 1];
            }

            current = new string(currentAsArray);
        }

        /// <summary>
        /// Gets the initial state of the number sequence.
        /// </summary>
        /// <returns>The initial state of the number sequence.</returns>
        protected virtual string GetInitialState()
        {
            string result = string.Empty;

            for (var i = 0; i < _width; i++)
            {
                result += "0";
            }

            return result;
        }

        /// <summary>
        /// Determines whether the specified character is the maximum character.
        /// </summary>
        /// <param name="c">The character to check.</param>
        /// <returns><c>true</c> if the character is the maximum character; otherwise, <c>false</c>.</returns>
        protected virtual bool IsMaxChar(char c)
        {
            return c == 'z' || c == 'Z';
        }

        #endregion

    }

}
