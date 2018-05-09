// <copyright file="StringLengthSpecimenBuilder.cs" company="BlueBasher">
// Copyright (c) BlueBasher. All rights reserved.
// </copyright>

namespace BlueBasher.FakeItEasier.AutoFakeItEasy.SpecimenBuilders
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AutoFixture.Kernel;
    using Base;

    /// <summary>
    /// SpecimenBuilder that creates a <see cref="string"/> taking an optional <see cref="StringLengthAttribute"/> in account.
    /// </summary>
    public class StringLengthSpecimenBuilder : SpecimenBuilderBase
    {
        /// <summary>
        /// Creates a new <see cref="string"/> specimen based on a request.
        /// </summary>
        /// <param name="request">The request that describes what to create.</param>
        /// <param name="context">A context that can be used to create other specimens.</param>
        /// <returns>
        /// The requested specimen if possible; otherwise a <see cref="T:AutoFixture.Kernel.NoSpecimen" /> instance.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">context</exception>
        /// <remarks>
        ///   <para>
        /// The <paramref name="request" /> can be any object, but will often be a
        ///   <see cref="T:System.Type" /> or other <see cref="T:System.Reflection.MemberInfo" /> instances.
        ///   </para>
        ///   <para>
        /// Note to implementers: Implementations are expected to return a
        ///   <see cref="T:AutoFixture.Kernel.NoSpecimen" /> instance if they can't satisfy the request.
        ///   </para>
        /// </remarks>
        public override object Create(object request, ISpecimenContext context)
        {
            if (!this.IsRequestForType(request, typeof(string)))
            {
                return new NoSpecimen();
            }

            // Check StringLength
            var stringLengths = this.GetCustomAttributeData<StringLengthAttribute>(request).ToList();
            if (!stringLengths.Any())
            {
                return new NoSpecimen();
            }

            var maxLength = (int)stringLengths.Single().ConstructorArguments.First().Value;
            var value = string.Format("{0}{1}", this.GetRequestName(request), Guid.NewGuid());
            if (value.Length > maxLength)
            {
                value = value.Substring(0, maxLength);
            }

            return value;
        }
    }
}
