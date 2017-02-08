// <copyright file="AutoFakeItEasyDataAttribute.cs" company="BlueBasher">
// Copyright (c) BlueBasher. All rights reserved.
// </copyright>

namespace BlueBasher.FakeItEasier.AutoFakeItEasy
{
    using System;
    using Customizations;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.AutoFakeItEasy;
    using Ploeh.AutoFixture.Xunit2;

    /// <summary>
    /// Attribute for having faked method parameters.
    /// </summary>
    public sealed class AutoFakeItEasyDataAttribute : AutoDataAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoFakeItEasyDataAttribute" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor overload initializes the <see cref="P:Ploeh.AutoFixture.Xunit.AutoDataAttribute.Fixture" /> to an instance of
        /// <see cref="P:Ploeh.AutoFixture.Xunit.AutoDataAttribute.Fixture" />.
        /// </remarks>
        public AutoFakeItEasyDataAttribute()
            : base(new Fixture())
        {
            this.Fixture.Customize(new AutoFakeItEasyCustomization());
            this.Fixture.Customize(new DefaultCustomization());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoFakeItEasyDataAttribute"/> class.
        /// </summary>
        /// <param name="specimenBuilders">The specimen builders.</param>
        public AutoFakeItEasyDataAttribute(params Type[] specimenBuilders)
            : this()
        {
            this.Fixture.Customize(new CustomSpecimenBuildersCustomization(specimenBuilders));
        }
    }
}
