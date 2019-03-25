// <copyright file="InlineAutoFakeItEasyDataAttribute.cs" company="BlueBasher">
// Copyright (c) BlueBasher. All rights reserved.
// </copyright>

namespace BlueBasher.FakeItEasier.AutoFakeItEasy
{
    using System;
    using AutoFixture.Xunit2;
    using Xunit;
    using Xunit.Sdk;

    /// <summary>
    /// Method for having inline method parameters.
    /// Remainder parameters that are not supplied will be automatically faked.
    /// </summary>
    public sealed class InlineAutoFakeItEasyDataAttribute : CompositeDataAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineAutoFakeItEasyDataAttribute" /> class.
        /// </summary>
        /// <param name="fakeCreationMode">The fake creation mode.</param>
        /// <param name="specimenBuilder1">The specimen builder1.</param>
        /// <param name="values">The values.</param>
        public InlineAutoFakeItEasyDataAttribute(FakeCreationMode fakeCreationMode, Type specimenBuilder1, params object[] values)
            : base(new DataAttribute[]
            {
                new InlineDataAttribute(values),
                new AutoFakeItEasyDataAttribute(fakeCreationMode, specimenBuilder1)
            })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineAutoFakeItEasyDataAttribute" /> class.
        /// </summary>
        /// <param name="fakeCreationMode">The fake creation mode.</param>
        /// <param name="specimenBuilder1">The specimen builder1.</param>
        /// <param name="specimenBuilder2">The specimen builder2.</param>
        /// <param name="values">The values.</param>
        public InlineAutoFakeItEasyDataAttribute(FakeCreationMode fakeCreationMode, Type specimenBuilder1, Type specimenBuilder2, params object[] values)
            : base(new DataAttribute[]
            {
                new InlineDataAttribute(values),
                new AutoFakeItEasyDataAttribute(fakeCreationMode, specimenBuilder1, specimenBuilder2)
            })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineAutoFakeItEasyDataAttribute" /> class.
        /// </summary>
        /// <param name="fakeCreationMode">The fake creation mode.</param>
        /// <param name="specimenBuilder1">The specimen builder1.</param>
        /// <param name="specimenBuilder2">The specimen builder2.</param>
        /// <param name="specimenBuilder3">The specimen builder3.</param>
        /// <param name="values">The values.</param>
        public InlineAutoFakeItEasyDataAttribute(FakeCreationMode fakeCreationMode, Type specimenBuilder1, Type specimenBuilder2, Type specimenBuilder3, params object[] values)
            : base(new DataAttribute[]
            {
                new InlineDataAttribute(values),
                new AutoFakeItEasyDataAttribute(fakeCreationMode, specimenBuilder1, specimenBuilder2, specimenBuilder3)
            })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineAutoFakeItEasyDataAttribute" /> class.
        /// </summary>
        /// <param name="fakeCreationMode">The fake creation mode.</param>
        /// <param name="specimenBuilder1">The specimen builder1.</param>
        /// <param name="specimenBuilder2">The specimen builder2.</param>
        /// <param name="specimenBuilder3">The specimen builder3.</param>
        /// <param name="specimenBuilder4">The specimen builder4.</param>
        /// <param name="values">The values.</param>
        public InlineAutoFakeItEasyDataAttribute(FakeCreationMode fakeCreationMode, Type specimenBuilder1, Type specimenBuilder2, Type specimenBuilder3, Type specimenBuilder4, params object[] values)
            : base(new DataAttribute[]
            {
                new InlineDataAttribute(values),
                new AutoFakeItEasyDataAttribute(fakeCreationMode, specimenBuilder1, specimenBuilder2, specimenBuilder3, specimenBuilder4)
            })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineAutoFakeItEasyDataAttribute" /> class.
        /// </summary>
        /// <param name="fakeCreationMode">The fake creation mode.</param>
        /// <param name="specimenBuilder1">The specimen builder1.</param>
        /// <param name="specimenBuilder2">The specimen builder2.</param>
        /// <param name="specimenBuilder3">The specimen builder3.</param>
        /// <param name="specimenBuilder4">The specimen builder4.</param>
        /// <param name="specimenBuilder5">The specimen builder5.</param>
        /// <param name="values">The values.</param>
        public InlineAutoFakeItEasyDataAttribute(FakeCreationMode fakeCreationMode, Type specimenBuilder1, Type specimenBuilder2, Type specimenBuilder3, Type specimenBuilder4, Type specimenBuilder5, params object[] values)
            : base(new DataAttribute[]
            {
                new InlineDataAttribute(values),
                new AutoFakeItEasyDataAttribute(fakeCreationMode, specimenBuilder1, specimenBuilder2, specimenBuilder3, specimenBuilder4, specimenBuilder5)
            })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineAutoFakeItEasyDataAttribute" /> class.
        /// </summary>
        /// <param name="fakeCreationMode">The fake creation mode.</param>
        /// <param name="values">The values.</param>
        public InlineAutoFakeItEasyDataAttribute(FakeCreationMode fakeCreationMode, params object[] values)
            : base(new DataAttribute[]
            {
                new InlineDataAttribute(values),
                new AutoFakeItEasyDataAttribute(fakeCreationMode)
            })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InlineAutoFakeItEasyDataAttribute"/> class.
        /// </summary>
        /// <param name="values">The values.</param>
        public InlineAutoFakeItEasyDataAttribute(params object[] values)
            : this(FakeCreationMode.Loose, values)
        {
        }
    }
}
