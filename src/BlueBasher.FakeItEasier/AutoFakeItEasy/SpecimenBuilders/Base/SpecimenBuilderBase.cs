// <copyright file="SpecimenBuilderBase.cs" company="BlueBasher">
// Copyright (c) BlueBasher. All rights reserved.
// </copyright>

namespace BlueBasher.FakeItEasier.AutoFakeItEasy.SpecimenBuilders.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Ploeh.AutoFixture.Kernel;

    /// <summary>
    /// Base class for all <see cref="ISpecimenBuilder"/>
    /// </summary>
    public abstract class SpecimenBuilderBase : ISpecimenBuilder
    {
        /// <summary>
        /// Creates a new specimen based on a request.
        /// </summary>
        /// <param name="request">The request that describes what to create.</param>
        /// <param name="context">A context that can be used to create other specimens.</param>
        /// <returns>
        /// The requested specimen if possible; otherwise a <see cref="T:Ploeh.AutoFixture.Kernel.NoSpecimen" /> instance.
        /// </returns>
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
        public virtual object Create(object request, ISpecimenContext context)
        {
            return new NoSpecimen();
        }

        /// <summary>
        /// Gets the name of the request using the <see cref="PropertyInfo"/> or <see cref="ParameterInfo"/>.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The request name</returns>
        protected string GetRequestName(object request)
        {
            var paramInfo = request as ParameterInfo;
            if (paramInfo != null)
            {
                return paramInfo.Name;
            }

            var propInfo = request as PropertyInfo;
            if (propInfo != null)
            {
                return propInfo.Name;
            }

            return string.Empty;
        }

        /// <summary>
        /// Determines whether the request is for the given type.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="type">The type.</param>
        /// <returns>Boolean indicating if the request is for this type.</returns>
        protected bool IsRequestForType(object request, Type type)
        {
            if (request as Type == type)
            {
                return true;
            }

            var paramInfo = request as ParameterInfo;
            var propInfo = request as PropertyInfo;

            return (paramInfo != null && paramInfo.ParameterType == type)
                    || (propInfo != null && propInfo.PropertyType == type);
        }

        /// <summary>
        /// Gets the custom attribute data.
        /// </summary>
        /// <typeparam name="T">The Attribute to check for.</typeparam>
        /// <param name="request">The request.</param>
        /// <returns>A list of CustomAttributes</returns>
        protected IEnumerable<CustomAttributeData> GetCustomAttributeData<T>(object request)
            where T : Attribute
        {
            var paramInfo = request as ParameterInfo;
            if (paramInfo != null)
            {
                return paramInfo.GetCustomAttributesData().Where(c => c.AttributeType == typeof(T));
            }

            var propInfo = request as PropertyInfo;
            if (propInfo != null)
            {
                return propInfo.GetCustomAttributesData().Where(c => c.AttributeType == typeof(T));
            }

            return new List<CustomAttributeData>();
        }
    }
}
