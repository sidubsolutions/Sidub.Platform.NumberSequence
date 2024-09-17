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
    /// Represents the options for a sequential number sequence provider.
    /// </summary>
    /// <typeparam name="TValue">The type of the values in the number sequence.</typeparam>
    public class SequentialNumberSequenceOptions<TValue> : INumberSequenceOptions<SequentialNumberSequenceProvider>
    {

        #region Public properties

        /// <summary>
        /// Gets the state provider for the sequential number sequence.
        /// </summary>
        public ISequentialNumberSequenceStateProvider<TValue> StateProvider { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SequentialNumberSequenceOptions{TValue}"/> class.
        /// </summary>
        /// <param name="stateProvider">The state provider for the sequential number sequence.</param>
        public SequentialNumberSequenceOptions(ISequentialNumberSequenceStateProvider<TValue> stateProvider)
        {
            StateProvider = stateProvider;
        }

        #endregion

    }

}
