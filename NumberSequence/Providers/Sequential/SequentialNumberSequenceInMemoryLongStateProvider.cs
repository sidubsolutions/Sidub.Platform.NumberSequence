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
    /// Represents a sequential number sequence provider that stores the current state in memory as a long value.
    /// </summary>
    public class SequentialNumberSequenceInMemoryLongStateProvider : SequentialNumberSequenceLongStateProvider
    {

        #region Member variables

        private long? _currentState;

        #endregion

        #region Public methods

        /// <summary>
        /// Gets the current value of the number sequence.
        /// </summary>
        /// <returns>The current value of the number sequence.</returns>
        public override Task<NumberSequenceValue<long>?> GetCurrentValue()
        {
            return Task.Run(() =>
            {
                if (_currentState is null)
                    return null;

                return new NumberSequenceValue<long>(_currentState.Value);
            });
        }

        /// <summary>
        /// Sets the current value of the number sequence.
        /// </summary>
        /// <param name="value">The value to set as the current value of the number sequence.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public override Task SetCurrentValue(NumberSequenceValue<long> value)
        {
            return Task.Run(() =>
            {
                _currentState = value.Value;
            });
        }

        #endregion

    }

}
