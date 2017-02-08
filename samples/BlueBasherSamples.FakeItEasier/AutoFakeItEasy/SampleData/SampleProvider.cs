// <copyright file="SampleProvider.cs" company="BlueBasher">
// Copyright (c) BlueBasher. All rights reserved.
// </copyright>

namespace BlueBasherSamples.FakeItEasier.AutoFakeItEasy.SampleData
{
    /// <summary>
    /// A Sample Provider
    /// </summary>
    public class SampleProvider
    {
        private readonly ISampleService sampleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SampleProvider"/> class.
        /// </summary>
        /// <param name="sampleService">The sample service.</param>
        public SampleProvider(ISampleService sampleService)
        {
            this.sampleService = sampleService;
        }

        /// <summary>
        /// Executes the sample.
        /// </summary>
        public void ExecuteSample()
        {
            if (this.sampleService.CanExecute)
            {
                this.sampleService.Execute();
            }
        }

        /// <summary>
        /// Executes the sample with parameter.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A string</returns>
        public string ExecuteSampleWithParam(string value)
        {
            if (this.sampleService.CanExecute)
            {
                return this.sampleService.ExecuteWithParam(value);
            }

            return string.Empty;
        }

        /// <summary>
        /// Executes the sample with dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A string</returns>
        public string ExecuteSampleWithDto(SampleDto value)
        {
            if (this.sampleService.CanExecute)
            {
                return this.sampleService.ExecuteWithDto(value);
            }

            return string.Empty;
        }
    }
}
