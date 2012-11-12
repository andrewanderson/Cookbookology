using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Awa.Testing
{
    public static class EnumerableAssert
    {
        /// <summary>
        /// Assert that two lists contain the exact same members in the same order.
        /// </summary>
        public static void AreEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual) 
        {
            var e = expected.GetEnumerator();
            var a = actual.GetEnumerator();

            while (e.MoveNext() && a.MoveNext())
            {
                Assert.IsTrue((e.Current == null && a.Current == null) || e.Current.Equals(a.Current));
            }

            Assert.IsFalse(e.MoveNext() || a.MoveNext());
        }
    }
}
