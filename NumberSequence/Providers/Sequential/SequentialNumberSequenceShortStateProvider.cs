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
    /// Represents a base class for sequential number sequence state providers with short data type.
    /// </summary>
    public abstract class SequentialNumberSequenceShortStateProvider : ISequentialNumberSequenceStateProvider<short>
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SequentialNumberSequenceShortStateProvider"/> class.
        /// </summary>
        public SequentialNumberSequenceShortStateProvider()
        {

        }

        #endregion

        #region Public abstract methods

        /// <summary>
        /// Gets the current value of the number sequence.
        /// </summary>
        /// <returns>The current value of the number sequence.</returns>
        public abstract Task<NumberSequenceValue<short>?> GetCurrentValue();

        /// <summary>
        /// Sets the current value of the number sequence.
        /// </summary>
        /// <param name="value">The value to set as the current value of the number sequence.</param>
        public abstract Task SetCurrentValue(NumberSequenceValue<short> value);

        #endregion

        #region Public methods

        /// <summary>
        /// Gets the next value in the number sequence.
        /// </summary>
        /// <returns>The next value in the number sequence.</returns>
        public async Task<NumberSequenceValue<short>> GetNextValue()
        {
            NumberSequenceValue<short>? currentValue = await GetCurrentValue();
            var current = currentValue?.Value;
            short result;

            if (current is null)
            {
                result = GetInitialState();
            }
            else
            {
                short currentInner = current.Value;
                Increment(ref currentInner);

                result = currentInner;
            }

            return new NumberSequenceValue<short>(result);
        }

        #endregion

        #region Protected virtual methods

        /// <summary>
        /// Increments the current value of the number sequence.
        /// </summary>
        /// <param name="current">The current value of the number sequence to increment.</param>
        protected virtual void Increment(ref short current)
        {
            current++;
        }

        /// <summary>
        /// Gets the initial state of the number sequence.
        /// </summary>
        /// <returns>The initial state of the number sequence.</returns>
        protected virtual short GetInitialState()
        {
            return 0;
        }

        #endregion

    }

}
