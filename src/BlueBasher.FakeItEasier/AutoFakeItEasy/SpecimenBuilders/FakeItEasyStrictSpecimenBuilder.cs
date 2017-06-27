// <copyright file="FakeItEasyStrictSpecimenBuilder.cs" company="BlueBasher">
// Copyright (c) BlueBasher. All rights reserved.
// </copyright>

namespace BlueBasher.FakeItEasier.AutoFakeItEasy.SpecimenBuilders
{
    using System;
    using System.Reflection;
    using FakeItEasy;
    using Ploeh.AutoFixture.Kernel;

    /// <summary>
    /// Specimen builder that creates strict fakes
    /// </summary>
    public class FakeItEasyStrictSpecimenBuilder : ISpecimenBuilder
    {
        /// <summary>
        /// Creates a new specimen based on a request.
        /// </summary>
        /// <param name="request">The request that describes what to create.</param>
        /// <param name="context">A context that can be used to create other specimens.</param>
        /// <returns>
        /// The requested specimen if possible; otherwise a <see cref="T:Ploeh.AutoFixture.Kernel.NoSpecimen" /> instance.
        /// </returns>
        /// <exception cref="ArgumentNullException">context</exception>
        /// <remarks>
        /// <para>
        /// The <paramref name="request" /> can be any object, but will often be a
        /// <see cref="T:System.Type" /> or other <see cref="T:System.Reflection.MemberInfo" /> instances.
        /// </para>
        /// <para>
        /// Note to implementers: Implementations are expected to return a
        /// <see cref="T:Ploeh.AutoFixture.Kernel.NoSpecimen" /> instance if they can't satisfy the request.
        /// </para>
        /// </remarks>
        public object Create(object request, ISpecimenContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (request as Type == null
                || !this.IsSatisfiedBy(request))
            {
                return new NoSpecimen();
            }

            var fakeFactoryMethod = this.GetType()
                .GetMethod("CreateStrictFake", BindingFlags.Instance | BindingFlags.NonPublic)
                .MakeGenericMethod((Type)request);

            var fake = fakeFactoryMethod.Invoke(this, new object[0]);

            return fake;
        }

        /// <summary>
        /// Determines whether [is satisfied by] [the specified request].
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        ///   <c>true</c> if [is satisfied by] [the specified request]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsSatisfiedBy(object request)
        {
            var t = request as Type;
            return (t != null) && (t.IsAbstract || t.IsInterface);
        }

        private T CreateStrictFake<T>()
        {
            return A.Fake<T>(s => s.Strict());
        }
    }
}
