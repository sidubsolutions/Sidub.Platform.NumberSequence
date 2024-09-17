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

using Microsoft.Extensions.DependencyInjection;
using Sidub.Platform.NumberSequence;
using Sidub.Platform.NumberSequence.Providers.RandomValue;
using Sidub.Platform.NumberSequence.Providers.Sequential;
using Sidub.Platform.NumberSequence.Providers.UniqueIdentifier;
using Sidub.Platform.NumberSequence.Services;

namespace NumberSequence.Test
{

    [TestClass]
    public class NumberSequenceTest
    {

        #region Read-only members

        private readonly INumberSequenceService _numberSequenceService;

        #endregion

        #region Constructors

        public NumberSequenceTest()
        {
            // initialize dependency injection environment...
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSidubNumberSequence();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            _numberSequenceService = serviceProvider.GetService<INumberSequenceService>()
                ?? throw new Exception("INumberSequence not initialized.");

        }

        #endregion

        [TestMethod]
        public async Task RandomNumberSequenceTest01()
        {
            var options = new RandomNumberSequenceOptions(10);
            var provider = _numberSequenceService.GetProvider(options);
            var result = await provider.GetValue<string>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.Value.Length);
        }

        [TestMethod]
        public async Task RandomNumberSequenceTest02()
        {
            var options = new RandomNumberSequenceOptions(3);
            var provider = _numberSequenceService.GetProvider(options);
            var result = await provider.GetValue<short>(options);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task RandomNumberSequenceTest03()
        {
            var options = new RandomNumberSequenceOptions(5);
            var provider = _numberSequenceService.GetProvider(options);
            var result = await provider.GetValue<int>(options);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task RandomNumberSequenceTest04()
        {
            var options = new RandomNumberSequenceOptions(7);
            var provider = _numberSequenceService.GetProvider(options);
            var result = await provider.GetValue<long>(options);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task UniqueIdentifierSequenceTest01()
        {
            var options = new GuidNumberSequenceOptions();
            var provider = _numberSequenceService.GetProvider(options);
            var result = await provider.GetValue<string>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual(Guid.Parse(result.Value).ToString("B"), result.Value);
        }

        [TestMethod]
        public async Task SequentialStringNumberSequenceTest01()
        {
            // configure an in-memory state provider for the sequential number provider, set width to 5...
            var sequentialProvider = new SequentialNumberSequenceInMemoryStringStateProvider(5);
            var options = new SequentialNumberSequenceOptions<string>(sequentialProvider);
            var provider = _numberSequenceService.GetProvider(options);

            // retrieve number sequence value...
            var result = await provider.GetValue<string>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual("00000", result.Value);

            // retrieve number sequence value...
            result = await provider.GetValue<string>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual("00001", result.Value);
        }

        [TestMethod]
        public async Task SequentialStringNumberSequenceTest02()
        {
            // configure an in-memory state provider for the sequential number provider, set width to 5...
            var sequentialProvider = new SequentialNumberSequenceInMemoryStringStateProvider(5);
            var options = new SequentialNumberSequenceOptions<string>(sequentialProvider);
            var provider = _numberSequenceService.GetProvider(options);

            // retrieve number sequence value...
            var result = await provider.GetValue<string>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual("00000", result.Value);

            // retrieve number sequence value...
            result = await provider.GetValue<string>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual("00001", result.Value);

            // iterate 33 times to reach the end of the first character limit...
            for (var i = 0; i < 34; i++)
                result = await provider.GetValue<string>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual("0000z", result.Value);

            // perform another iteration, this should reset the last character to 0, and increment the next power up by one...
            result = await provider.GetValue<string>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual("00010", result.Value);

            // iterate 33 times to reach the end of the first character limit...
            for (var i = 0; i < 35; i++)
                result = await provider.GetValue<string>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual("0001z", result.Value);

            // perform another iteration, this should reset the last character to 0, and increment the next power up by one...
            result = await provider.GetValue<string>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual("00020", result.Value);

        }

        [TestMethod]
        public async Task SequentialStringNumberSequenceTest03()
        {
            // configure an in-memory state provider for the sequential number provider, set width to 5...
            var sequentialProvider = new SequentialNumberSequenceInMemoryStringStateProvider(5);

            // set current value near the end of available sequences...
            await sequentialProvider.SetCurrentValue(new NumberSequenceValue<string>("zzzz0"));

            var options = new SequentialNumberSequenceOptions<string>(sequentialProvider);
            var provider = _numberSequenceService.GetProvider(options);

            // retrieve number sequence value...
            var result = await provider.GetValue<string>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual("zzzz1", result.Value);

            // iterate 33 times to reach the end of the first character limit...
            for (var i = 0; i < 34; i++)
                result = await provider.GetValue<string>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual("zzzzz", result.Value);

            // retrieve number sequence value, this should throw an exception...
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () => await provider.GetValue<string>(options));
        }

        [TestMethod]
        public async Task SequentialShortNumberSequenceTest01()
        {
            var sequentialProvider = new SequentialNumberSequenceInMemoryShortStateProvider();
            var options = new SequentialNumberSequenceOptions<short>(sequentialProvider);
            var provider = _numberSequenceService.GetProvider(options);

            // retrieve number sequence value...
            var result = await provider.GetValue<short>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Value);

            // retrieve number sequence value...
            result = await provider.GetValue<short>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Value);
        }

        [TestMethod]
        public async Task SequentialShortNumberSequenceTest02()
        {
            var sequentialProvider = new SequentialNumberSequenceInMemoryShortStateProvider();
            var options = new SequentialNumberSequenceOptions<short>(sequentialProvider);
            var provider = _numberSequenceService.GetProvider(options);

            // retrieve number sequence value...
            var result = await provider.GetValue<short>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Value);

            // retrieve number sequence value...
            result = await provider.GetValue<short>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Value);

            // iterate the number sequence...
            for (var i = 0; i < 99; i++)
            {
                result = await provider.GetValue<short>(options);
            }

            Assert.IsNotNull(result);
            Assert.AreEqual(100, result.Value);
        }

        [TestMethod]
        public async Task SequentialIntNumberSequenceTest01()
        {
            var sequentialProvider = new SequentialNumberSequenceInMemoryIntStateProvider();
            var options = new SequentialNumberSequenceOptions<int>(sequentialProvider);
            var provider = _numberSequenceService.GetProvider(options);

            // retrieve number sequence value...
            var result = await provider.GetValue<int>(options);
            short expected;

            expected = 0;
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Value);

            // retrieve number sequence value...
            result = await provider.GetValue<int>(options);

            expected = 1;
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.Value);
        }

        [TestMethod]
        public async Task SequentialIntNumberSequenceTest02()
        {
            var sequentialProvider = new SequentialNumberSequenceInMemoryIntStateProvider();
            var options = new SequentialNumberSequenceOptions<int>(sequentialProvider);
            var provider = _numberSequenceService.GetProvider(options);

            // retrieve number sequence value...
            var result = await provider.GetValue<int>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Value);

            // retrieve number sequence value...
            result = await provider.GetValue<int>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Value);

            // iterate the number sequence...
            for (var i = 0; i < 99; i++)
            {
                result = await provider.GetValue<int>(options);
            }

            Assert.IsNotNull(result);
            Assert.AreEqual(100, result.Value);
        }

        [TestMethod]
        public async Task SequentialLongNumberSequenceTest01()
        {
            var sequentialProvider = new SequentialNumberSequenceInMemoryLongStateProvider();
            var options = new SequentialNumberSequenceOptions<long>(sequentialProvider);
            var provider = _numberSequenceService.GetProvider(options);

            // retrieve number sequence value...
            var result = await provider.GetValue<long>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Value);

            // retrieve number sequence value...
            result = await provider.GetValue<long>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual(1L, result.Value);
        }

        [TestMethod]
        public async Task SequentialLongNumberSequenceTest02()
        {
            var sequentialProvider = new SequentialNumberSequenceInMemoryLongStateProvider();
            var options = new SequentialNumberSequenceOptions<long>(sequentialProvider);
            var provider = _numberSequenceService.GetProvider(options);

            // retrieve number sequence value...
            var result = await provider.GetValue<long>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Value);

            // retrieve number sequence value...
            result = await provider.GetValue<long>(options);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Value);

            // iterate the number sequence...
            for (var i = 0; i < 99; i++)
            {
                result = await provider.GetValue<long>(options);
            }

            Assert.IsNotNull(result);
            Assert.AreEqual(100L, result.Value);
        }

    }

}
