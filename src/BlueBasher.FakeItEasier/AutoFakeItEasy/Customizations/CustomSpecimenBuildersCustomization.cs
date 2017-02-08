// <copyright file="CustomSpecimenBuildersCustomization.cs" company="BlueBasher">
// Copyright (c) BlueBasher. All rights reserved.
// </copyright>

namespace BlueBasher.FakeItEasier.AutoFakeItEasy.Customizations
{
    using System;
    using System.Linq;
    using BlueBasher.FakeItEasier.AutoFakeItEasy.SpecimenBuilders;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Kernel;

    /// <summary>
    /// Adds custom SpecimenBuilders
    /// </summary>
    public class CustomSpecimenBuildersCustomization : ICustomization
    {
        private readonly Type[] specimenBuilders;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomSpecimenBuildersCustomization"/> class.
        /// </summary>
        /// <param name="specimenBuilders">The custom specimen builders.</param>
        public CustomSpecimenBuildersCustomization(params Type[] specimenBuilders)
        {
            this.specimenBuilders = specimenBuilders;
        }

        /// <summary>
        /// Adds the custom customization.
        /// These include :
        /// <see cref="StringLengthSpecimenBuilder"/>
        /// <see cref="StreamSpecimenBuilder"/>
        /// </summary>
        /// <param name="fixture">The fixture to customize.</param>
        public void Customize(IFixture fixture)
        {
            foreach (var specimenBuilder in
                this.specimenBuilders
                    .Where(specimenBuilder =>
                        specimenBuilder.GetInterfaces().Any(i => i == typeof(ISpecimenBuilder))))
            {
                fixture.Customizations.Add(Activator.CreateInstance(specimenBuilder) as ISpecimenBuilder);
            }
        }
    }
}
