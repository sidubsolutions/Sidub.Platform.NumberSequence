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
