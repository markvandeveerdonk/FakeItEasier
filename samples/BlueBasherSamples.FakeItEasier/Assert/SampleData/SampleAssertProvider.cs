// <copyright file="SampleAssertProvider.cs" company="BlueBasher">
// Copyright (c) BlueBasher. All rights reserved.
// </copyright>

namespace BlueBasherSamples.FakeItEasier.Assert.SampleData
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// A sample assert provider
    /// </summary>
    public class SampleAssertProvider
    {
        /// <summary>
        /// Executes the with single exception.
        /// </summary>
        /// <returns>A boolean</returns>
        /// <exception cref="System.InvalidOperationException">Throws since we need an exception</exception>
        public async Task<bool> ExecuteWithSingleException()
        {
            await Task.Delay(100);

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Executes the with multiple exceptions.
        /// </summary>
        /// <returns>A boolean</returns>
        /// <exception cref="System.AggregateException">Throws an AggregateException containing multiple exceptions</exception>
        /// <exception cref="System.ArgumentException">Throws a ArgumentException since we need an exception</exception>
        /// <exception cref="System.InvalidOperationException">Throws a InvalidOperationException ince we need an exception</exception>
        public async Task<bool> ExecuteWithMultipleExceptions()
        {
            await Task.Delay(100);

            throw new AggregateException(
                new ArgumentException(),
                new InvalidOperationException());
        }
    }
}
