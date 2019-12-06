using System;
using System.Threading;

namespace UnitTestingExamples.Providers
{
    /// <summary>
    /// DateTime povider, which provide access for getting actual datetime.
    /// </summary>
    public class DateTimeProvider : IDisposable
    {
        private static AsyncLocal<DateTime?> _injectedDateTime = new AsyncLocal<DateTime?>();

        private DateTimeProvider()
        {
        }

        /// <summary>
        /// Gets DateTime now.
        /// </summary>
        /// <value>
        /// The DateTime now.
        /// </value>
        public static DateTime Now
            => _injectedDateTime.Value ?? DateTime.Now;

        /// <summary>
        /// Injects the actual date time.
        /// </summary>
        /// <param name="actualDateTime">The actual date time.</param>
        public static IDisposable InjectActualDateTime(DateTime actualDateTime)
        {
            _injectedDateTime.Value = actualDateTime;

            return new DateTimeProvider();
        }

        public void Dispose()
        {
            _injectedDateTime.Value = null;
        }
    }
}
