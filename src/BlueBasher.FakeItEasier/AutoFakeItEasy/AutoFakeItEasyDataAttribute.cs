// <copyright file="AutoFakeItEasyDataAttribute.cs" company="BlueBasher">
// Copyright (c) BlueBasher. All rights reserved.
// </copyright>

namespace BlueBasher.FakeItEasier.AutoFakeItEasy
{
    using System;
    using AutoFixture;
    using AutoFixture.AutoFakeItEasy;
    using AutoFixture.Xunit2;
    using BlueBasher.FakeItEasier.AutoFakeItEasy.SpecimenBuilders;
    using Customizations;

    /// <summary>
    /// Attribute for having faked method parameters.
    /// </summary>
    public sealed class AutoFakeItEasyDataAttribute : AutoDataAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoFakeItEasyDataAttribute" /> class.
        /// </summary>
        /// <param name="fakeCreationMode">The fake creation mode.</param>
        /// <remarks>
        /// This constructor overload initializes the <see cref="P:AutoFixture.Xunit.AutoDataAttribute.Fixture" /> to an instance of
        /// <see cref="P:AutoFixture.Xunit.AutoDataAttribute.Fixture" />.
        /// </remarks>
        public AutoFakeItEasyDataAttribute(FakeCreationMode fakeCreationMode)
            : base(() => { return CreateFixture(fakeCreationMode); })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoFakeItEasyDataAttribute" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor overload initializes the <see cref="P:AutoFixture.Xunit.AutoDataAttribute.Fixture" /> to an instance of
        /// <see cref="P:AutoFixture.Xunit.AutoDataAttribute.Fixture" />.
        /// </remarks>
        public AutoFakeItEasyDataAttribute()
            : this(FakeCreationMode.Loose)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoFakeItEasyDataAttribute" /> class.
        /// </summary>
        /// <param name="fakeCreationMode">The fake creation mode.</param>
        /// <param name="specimenBuilders">The specimen builders.</param>
        public AutoFakeItEasyDataAttribute(FakeCreationMode fakeCreationMode, params Type[] specimenBuilders)
            : base(() => { return CreateFixture(fakeCreationMode, specimenBuilders); })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoFakeItEasyDataAttribute"/> class.
        /// </summary>
        /// <param name="specimenBuilders">The specimen builders.</param>
        public AutoFakeItEasyDataAttribute(params Type[] specimenBuilders)
            : this(FakeCreationMode.Loose, specimenBuilders)
        {
        }

        private static IFixture CreateFixture(FakeCreationMode fakeCreationMode, params Type[] specimenBuilders)
        {
            var fixture = new Fixture();

            if (fakeCreationMode == FakeCreationMode.Strict)
            {
                var autoFakeItEasyCustomization = new AutoFakeItEasyCustomization
                {
                    Relay = new FakeItEasyStrictSpecimenBuilder()
                };

                fixture.Customize(autoFakeItEasyCustomization);
            }
            else
            {
                fixture.Customize(new AutoFakeItEasyCustomization());
            }

            fixture.Customize(new DefaultCustomization());

            if (specimenBuilders != null && specimenBuilders.Length > 0)
            {
                fixture.Customize(new CustomSpecimenBuildersCustomization(specimenBuilders));
            }

            return fixture;
        }
    }
}
