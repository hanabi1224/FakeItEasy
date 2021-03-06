namespace FakeItEasy
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using FakeItEasy.Core;

    /// <summary>
    /// Provides static methods for accessing fake objects.
    /// </summary>
    public static class Fake
    {
        private static readonly IFakeManagerAccessor FakeManagerAccessor = ServiceLocator.Resolve<IFakeManagerAccessor>();

        /// <summary>
        /// Gets the fake object that manages the faked object.
        /// </summary>
        /// <param name="fakedObject">The faked object to get the manager object for.</param>
        /// <returns>The fake object manager.</returns>
        /// <exception cref="ArgumentException">If <paramref name="fakedObject"/> is not actually a faked object.</exception>
        [DebuggerStepThrough]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "object", Justification = "The term fake object does not refer to the type System.Object.")]
        public static FakeManager GetFakeManager(object fakedObject)
        {
            Guard.AgainstNull(fakedObject, nameof(fakedObject));

            return FakeManagerAccessor.GetFakeManager(fakedObject);
        }

        /// <summary>
        /// Gets all the calls made to the specified fake object.
        /// </summary>
        /// <param name="fakedObject">The faked object.</param>
        /// <returns>A collection containing the calls to the object.</returns>
        /// <exception cref="ArgumentException">The object passed in is not a faked object.</exception>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "object", Justification = "The term fake object does not refer to the type System.Object.")]
        public static IEnumerable<ICompletedFakeObjectCall> GetCalls(object fakedObject)
        {
            Guard.AgainstNull(fakedObject, nameof(fakedObject));

            return FakeManagerAccessor.GetFakeManager(fakedObject).GetRecordedCalls();
        }

        /// <summary>
        /// Clears the configuration of the faked object.
        /// </summary>
        /// <param name="fakedObject">The faked object to clear the configuration of.</param>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "object", Justification = "The term fake object does not refer to the type System.Object.")]
        public static void ClearConfiguration(object fakedObject)
        {
            Guard.AgainstNull(fakedObject, nameof(fakedObject));

            var manager = FakeManagerAccessor.GetFakeManager(fakedObject);
            manager.ClearUserRules();
        }

        /// <summary>
        /// Clears all recorded calls of the faked object.
        /// </summary>
        /// <param name="fakedObject">The faked object to clear the recorded calls of.</param>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "object", Justification = "The term fake object does not refer to the type System.Object.")]
        public static void ClearRecordedCalls(object fakedObject)
        {
            Guard.AgainstNull(fakedObject, nameof(fakedObject));

            var manager = FakeManagerAccessor.GetFakeManager(fakedObject);
            manager.ClearRecordedCalls();
        }

        /// <summary>
        /// Gets the fake manager associated with the proxy, if any.
        /// </summary>
        /// <param name="fakedObject">The proxy to get the manager from.</param>
        /// <returns>The fake manager, or <c>null</c> if <paramref name="fakedObject"/> is not actually a faked object.</returns>
        [DebuggerStepThrough]
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "object", Justification = "The term fake object does not refer to the type System.Object.")]
        internal static FakeManager TryGetFakeManager(object fakedObject)
        {
            Guard.AgainstNull(fakedObject, nameof(fakedObject));

            return FakeManagerAccessor.TryGetFakeManager(fakedObject);
        }
    }
}
