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
    /// Represents a sequential number sequence provider that stores the state in memory as a string.
    /// </summary>
    public class SequentialNumberSequenceInMemoryStringStateProvider : SequentialNumberSequenceStringStateProvider
    {

        #region Member variables

        private string? _currentState;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SequentialNumberSequenceInMemoryStringStateProvider"/> class with the specified width.
        /// </summary>
        /// <param name="width">The width of the number sequence.</param>
        public SequentialNumberSequenceInMemoryStringStateProvider(int width) : base(width)
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets the current value of the number sequence.
        /// </summary>
        /// <returns>The current value of the number sequence.</returns>
        public override Task<NumberSequenceValue<string>?> GetCurrentValue()
        {
            if (_currentState is null)
                return Task.FromResult<NumberSequenceValue<string>?>(null);

            return Task.FromResult<NumberSequenceValue<string>?>(new NumberSequenceValue<string>(_currentState));
        }

        /// <summary>
        /// Sets the current value of the number sequence.
        /// </summary>
        /// <param name="value">The value to set as the current value of the number sequence.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public override Task SetCurrentValue(NumberSequenceValue<string> value)
        {
            _currentState = value.Value;

            return Task.CompletedTask;
        }

        #endregion

    }

}
