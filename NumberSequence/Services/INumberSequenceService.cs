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

#endregion

using Sidub.Platform.NumberSequence.Providers;

namespace Sidub.Platform.NumberSequence.Services
{

    /// <summary>
    /// The number sequence service provides facilitates the generation of values in varying
    /// methodologies (i.e., random, sequential, etc.). The primary purpose of this service
    /// is to provide a typed INumberSequenceProvider instance based on a provided
    /// INumberSequenceOptions<>; the consumer can may then operate against the number sequence
    /// provider to request sequence values.
    /// 
    /// Some providers may be stateless (i.e., guid, random integers / string) and some may be
    /// stateful (i.e., sequential integers / string) which may be backed by various persistent
    /// technologies (i.e., in memory, cache, database or other storage endpoints such as Gremlin,
    /// OData, etc.). Note that some base providers exist outside of the core framework; providers
    /// backed by Sidub platform storage framework are provided through a separate package.
    /// </summary>
    public interface INumberSequenceService
    {

        #region Interface methods

        /// <summary>
        /// Gets the number sequence provider based on the provided options.
        /// </summary>
        /// <typeparam name="TNumberSequenceProvider">The type of the number sequence provider.</typeparam>
        /// <param name="options">The options for the number sequence provider.</param>
        /// <returns>The instance of the number sequence provider.</returns>
        TNumberSequenceProvider GetProvider<TNumberSequenceProvider>(INumberSequenceOptions<TNumberSequenceProvider> options)
            where TNumberSequenceProvider : class, INumberSequenceProvider;

        #endregion

    }
}
