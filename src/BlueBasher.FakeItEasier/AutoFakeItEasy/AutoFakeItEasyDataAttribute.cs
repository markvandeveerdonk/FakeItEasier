// <copyright file="AutoFakeItEasyDataAttribute.cs" company="BlueBasher">
// Copyright (c) BlueBasher. All rights reserved.
// </copyright>

namespace BlueBasher.FakeItEasier.AutoFakeItEasy
{
    using System;
    using BlueBasher.FakeItEasier.AutoFakeItEasy.SpecimenBuilders;
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
        /// <param name="useStrictFakes">if set to <c>true</c> [use strict fakes].</param>
        /// <remarks>
        /// This constructor overload initializes the <see cref="P:Ploeh.AutoFixture.Xunit.AutoDataAttribute.Fixture" /> to an instance of
        /// <see cref="P:Ploeh.AutoFixture.Xunit.AutoDataAttribute.Fixture" />.
        /// </remarks>
        public AutoFakeItEasyDataAttribute(bool useStrictFakes)
            : base(new Fixture())
        {
            if (useStrictFakes)
            {
                this.Fixture.Customize(new AutoFakeItEasyCustomization(new FakeItEasyStrictSpecimenBuilder()));
            }
            else
            {
                this.Fixture.Customize(new AutoFakeItEasyCustomization());
            }

            this.Fixture.Customize(new DefaultCustomization());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoFakeItEasyDataAttribute" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor overload initializes the <see cref="P:Ploeh.AutoFixture.Xunit.AutoDataAttribute.Fixture" /> to an instance of
        /// <see cref="P:Ploeh.AutoFixture.Xunit.AutoDataAttribute.Fixture" />.
        /// </remarks>
        public AutoFakeItEasyDataAttribute()
            : this(false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoFakeItEasyDataAttribute" /> class.
        /// </summary>
        /// <param name="useStrictFakes">if set to <c>true</c> [use strict fakes].</param>
        /// <param name="specimenBuilders">The specimen builders.</param>
        public AutoFakeItEasyDataAttribute(bool useStrictFakes, params Type[] specimenBuilders)
            : this(useStrictFakes)
        {
            this.Fixture.Customize(new CustomSpecimenBuildersCustomization(specimenBuilders));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoFakeItEasyDataAttribute"/> class.
        /// </summary>
        /// <param name="specimenBuilders">The specimen builders.</param>
        public AutoFakeItEasyDataAttribute(params Type[] specimenBuilders)
            : this(false, specimenBuilders)
        {
        }
    }
}
