// <copyright file="SampleAssertProviderTest.cs" company="BlueBasher">
// Copyright (c) BlueBasher. All rights reserved.
// </copyright>

namespace BlueBasherSamples.FakeItEasier.Assert.Sample
{
    using System;
    using BlueBasher.FakeItEasier.Assert;
    using SampleData;
    using Xunit;

    /// <summary>
    /// Test the SampleAssertProvider
    /// </summary>
    public class SampleAssertProviderTest
    {
        /// <summary>
        /// Samples the assert provider execute with single exception succeeds.
        /// </summary>
        [Fact]
        public void SampleAssertProvider_ExecuteWithSingleException_Succeeds()
        {
            var sampleAssertProvider = new SampleAssertProvider();

            AssertAsync.Throws<InvalidOperationException>(
                sampleAssertProvider.ExecuteWithSingleException);
        }

        /// <summary>
        /// Samples the assert provider execute with multiple exceptions succeeds.
        /// </summary>
        [Fact]
        public void SampleAssertProvider_ExecuteWithMultipleExceptions_Succeeds()
        {
            var sampleAssertProvider = new SampleAssertProvider();

            AssertAsync.Throws<AggregateException>(
                sampleAssertProvider.ExecuteWithMultipleExceptions);
        }
    }
}
