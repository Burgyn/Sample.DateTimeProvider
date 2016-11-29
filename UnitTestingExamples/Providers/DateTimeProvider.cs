using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingExamples.Providers
{
    /// <summary>
    /// DateTime povider, which provide access for getting actual datetime.
    /// </summary>
    public class DateTimeProvider : IDisposable
    {
        [ThreadStatic]
        private static DateTime? _injectedDateTime;

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
        {
            get
            {
                return _injectedDateTime ?? DateTime.Now;
            }
        }

        /// <summary>
        /// Injects the actual date time.
        /// </summary>
        /// <param name="actualDateTime">The actual date time.</param>
        public static IDisposable InjectActualDateTime(DateTime actualDateTime)
        {
            _injectedDateTime = actualDateTime;

            return new DateTimeProvider();
        }

        public void Dispose()
        {
            _injectedDateTime = null;
        }
    }
}
