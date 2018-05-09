// <copyright file="FakeCreationMode.cs" company="BlueBasher">
// Copyright (c) BlueBasher. All rights reserved.
// </copyright>

namespace BlueBasher.FakeItEasier.AutoFakeItEasy
{
    /// <summary>
    /// The type of fakes to create
    /// See https://fakeiteasy.readthedocs.io/en/stable/strict-fakes/
    /// </summary>
    public enum FakeCreationMode
    {
        /// <summary>
        /// Create 'loose mocking' fakes
        /// </summary>
        Loose,

        /// <summary>
        /// Create strict fakes
        /// </summary>
        Strict
    }
}
