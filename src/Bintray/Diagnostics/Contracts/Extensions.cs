using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bintray.Diagnostics.Contracts {
    public static partial class Extensions {
        public static void CheckNotNull<T>(this T value) where T : class {
            if(null == value) {
                throw new ArgumentNullException("value");
            }
            NullChecker<T>.Check(value);
        }
    }
}