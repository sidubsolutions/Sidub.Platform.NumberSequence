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

#region Imports

using Sidub.Platform.NumberSequence.Providers;

#endregion

namespace Sidub.Platform.NumberSequence.Services
{

    /// <summary>
    /// Number sequence service implementation.
    /// </summary>
    public class NumberSequenceService : INumberSequenceService
    {

        #region Readonly members

        private readonly List<INumberSequenceProvider> _providers;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberSequenceService"/> class.
        /// </summary>
        /// <param name="providers">The collection of number sequence providers.</param>
        public NumberSequenceService(IEnumerable<INumberSequenceProvider> providers)
        {
            _providers = providers.ToList();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Retrieves a provider for a given number sequence options implementation.
        /// </summary>
        /// <typeparam name="TNumberSequenceProvider">Type of number sequence provider; implied from parameter.</typeparam>
        /// <param name="options">Typed number sequence options instance.</param>
        /// <returns>A typed number sequence provider instance.</returns>
        public TNumberSequenceProvider GetProvider<TNumberSequenceProvider>(INumberSequenceOptions<TNumberSequenceProvider> options)
            where TNumberSequenceProvider : class, INumberSequenceProvider
        {
            TNumberSequenceProvider result = _providers.SingleOrDefault(provider => provider is TNumberSequenceProvider) as TNumberSequenceProvider
                ?? throw new Exception($"Provider not found for options class '{options.GetType().Name}'.");

            return result;
        }

        #endregion

    }
}
