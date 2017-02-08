// <copyright file="SampleProviderTest.cs" company="BlueBasher">
// Copyright (c) BlueBasher. All rights reserved.
// </copyright>

namespace BlueBasherSamples.FakeItEasier.AutoFakeItEasy.Sample
{
    using BlueBasher.FakeItEasier.AutoFakeItEasy;
    using FakeItEasy;
    using SampleData;
    using Xunit;

    /// <summary>
    /// Test for a SampleProvider
    /// </summary>
    public class SampleProviderTest
    {
        /// <summary>
        /// Samples the provider execute succeeds.
        /// </summary>
        /// <param name="sampleService">The sample service.</param>
        [Theory]
        [AutoFakeItEasyData]
        public void SampleProvider_Execute_Succeeds(
            ISampleService sampleService)
        {
            // Arrange
            A.CallTo(() => sampleService.CanExecute)
                .Returns(true);
            var sampleProvider = new SampleProvider(sampleService);

            // Act
            sampleProvider.ExecuteSample();

            // Assert
            A.CallTo(() => sampleService.Execute())
                .MustHaveHappened(Repeated.Exactly.Once);
        }

        /// <summary>
        /// Samples the provider execute with parameter succeeds.
        /// </summary>
        /// <param name="sampleService">The sample service.</param>
        /// <param name="value">The value.</param>
        /// <param name="returnValue">The return value.</param>
        [Theory]
        [AutoFakeItEasyData]
        public void SampleProvider_ExecuteWithParam_Succeeds(
            ISampleService sampleService,
            string value,
            string returnValue)
        {
            // Arrange
            A.CallTo(() => sampleService.CanExecute)
                .Returns(true);
            A.CallTo(() => sampleService.ExecuteWithParam(value))
                .Returns(returnValue);
            var sampleProvider = new SampleProvider(sampleService);

            // Act
            var actual = sampleProvider.ExecuteSampleWithParam(value);

            // Assert
            A.CallTo(() => sampleService.ExecuteWithParam(A<string>.Ignored))
                .MustHaveHappened(Repeated.Exactly.Once);
            Assert.Equal(returnValue, actual);
        }

        /// <summary>
        /// Samples the provider execute with parameters can execute succeeds.
        /// </summary>
        /// <param name="canExecute">if set to <c>true</c> [can execute].</param>
        /// <param name="returnValue">The return value.</param>
        /// <param name="sampleService">The sample service.</param>
        /// <param name="value">The value.</param>
        [Theory]
        [InlineAutoFakeItEasyData(true, "ReturnValueFirst")]
        [InlineAutoFakeItEasyData(false, "")]
        public void SampleProvider_ExecuteWithParams_CanExecute_Succeeds(
            bool canExecute,
            string returnValue,
            ISampleService sampleService,
            string value)
        {
            // Arrange
            A.CallTo(() => sampleService.CanExecute)
                .Returns(canExecute);
            A.CallTo(() => sampleService.ExecuteWithParam(value))
                .Returns(returnValue);
            var sampleProvider = new SampleProvider(sampleService);

            // Act
            var actual = sampleProvider.ExecuteSampleWithParam(value);

            // Assert
            A.CallTo(() => sampleService.ExecuteWithParam(A<string>.Ignored))
                .MustHaveHappened(
                    canExecute
                    ? Repeated.Exactly.Once
                    : Repeated.Never);
            Assert.Equal(returnValue, actual);
        }

        /// <summary>
        /// Samples the provider execute with dto succeeds.
        /// </summary>
        /// <param name="sampleService">The sample service.</param>
        /// <param name="dto">The dto.</param>
        /// <param name="returnValue">The return value.</param>
        [Theory]
        [AutoFakeItEasyData]
        public void SampleProvider_ExecuteWithDto_Succeeds(
            ISampleService sampleService,
            SampleDto dto,
            string returnValue)
        {
            // Arrange
            A.CallTo(() => sampleService.CanExecute)
                .Returns(true);
            A.CallTo(() => sampleService.ExecuteWithDto(dto))
                .Returns(returnValue);
            var sampleProvider = new SampleProvider(sampleService);

            // Act
            var actual = sampleProvider.ExecuteSampleWithDto(dto);

            // Assert
            A.CallTo(() => sampleService.ExecuteWithDto(A<SampleDto>.Ignored))
                .MustHaveHappened(Repeated.Exactly.Once);
            Assert.Equal(returnValue, actual);
        }

        /// <summary>
        /// Samples the provider execute with dto can execute succeeds.
        /// </summary>
        /// <param name="canExecute">if set to <c>true</c> [can execute].</param>
        /// <param name="returnValue">The return value.</param>
        /// <param name="sampleService">The sample service.</param>
        /// <param name="dto">The dto.</param>
        [Theory]
        [InlineAutoFakeItEasyData(true, "ReturnValueFirst")]
        [InlineAutoFakeItEasyData(false, "")]
        public void SampleProvider_ExecuteWithDto_CanExecute_Succeeds(
            bool canExecute,
            string returnValue,
            ISampleService sampleService,
            SampleDto dto)
        {
            // Arrange
            A.CallTo(() => sampleService.CanExecute)
                .Returns(canExecute);
            A.CallTo(() => sampleService.ExecuteWithDto(dto))
                .Returns(returnValue);
            var sampleProvider = new SampleProvider(sampleService);

            // Act
            var actual = sampleProvider.ExecuteSampleWithDto(dto);

            // Assert
            A.CallTo(() => sampleService.ExecuteWithDto(A<SampleDto>.Ignored))
                .MustHaveHappened(
                    canExecute
                    ? Repeated.Exactly.Once
                    : Repeated.Never);
            Assert.Equal(returnValue, actual);
        }
    }
}
