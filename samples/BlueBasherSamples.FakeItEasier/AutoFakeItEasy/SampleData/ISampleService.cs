// <copyright file="ISampleService.cs" company="BlueBasher">
// Copyright (c) BlueBasher. All rights reserved.
// </copyright>

namespace BlueBasherSamples.FakeItEasier.AutoFakeItEasy.SampleData
{
    /// <summary>
    /// A Sample Service Interface
    /// </summary>
    public interface ISampleService
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance can execute.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance can execute; otherwise, <c>false</c>.
        /// </value>
        bool CanExecute { get; set; }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        void Execute();

        /// <summary>
        /// Executes the with parameter.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A string</returns>
        string ExecuteWithParam(string value);

        /// <summary>
        /// Executes the with dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A string</returns>
        string ExecuteWithDto(SampleDto value);
    }
}
