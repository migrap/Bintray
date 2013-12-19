using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bintray.Diagnostics.Contracts {
    internal static class NullChecker<T> where T : class {
        private static readonly List<Func<T, bool>> _checkers = new List<Func<T, bool>>();
        private static readonly List<string> _names = new List<string>();

        static NullChecker() {
            foreach(var name in typeof(T).GetConstructors()[0].GetParameters().Select(p => p.Name)) {
                _names.Add(name);
                var property = typeof(T).GetProperty(name);

                if(property.PropertyType.IsValueType) {
                    throw new ArgumentException("Property " + property + " is a value type");
                }

                var parameter = Expression.Parameter(typeof(T), "value");
                var accessor = Expression.Property(parameter, property);
                var nullvalue = Expression.Constant(null, property.PropertyType);
                var equality = Expression.Equal(accessor, nullvalue);
                var lambda = Expression.Lambda<Func<T, bool>>(equality, parameter);

                _checkers.Add(lambda.Compile());
            }
        }

        internal static void Check(T value) {
            for(int i = 0; i < _checkers.Count; i++) {
                if(_checkers[i](value)) {
                    throw new ArgumentNullException(_names[i]);
                }
            }
        }
    }
}
