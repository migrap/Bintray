using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;
using System.IO;

namespace Bintray {
    public static partial class Extensions {
        internal static Task<T> ReadAsAsync<T>(this Task<HttpResponseMessage> message, params MediaTypeFormatter[] formatters) {
            var response = message
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsAsync<T>(formatters);
        }

        internal static Task<string> ReadAsStringAsync(this Task<HttpResponseMessage> message) {
            var response = message
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsStringAsync();
        }

        internal static Task<Stream> ReadAsStreamAsync(this Task<HttpResponseMessage> message) {
            var response = message
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsStreamAsync();
        }

        internal static Task<T> ReadAsAsync<T>(this HttpResponseMessage message, MediaTypeFormatter formatter) {
            return message.Content.ReadAsAsync<T>(formatter);
        }

        internal static Task<T> ReadAsAsync<T>(this HttpContent content, MediaTypeFormatter formatter) {
            return content.ReadAsAsync<T>(new[] { formatter });            
        }

        internal static void ContinueOrCancel(this CancellationTokenSource self) {
            self.Token.ContinueOrCancel();
        }
        internal static void ContinueOrCancel(this CancellationToken self) {
            if(self.IsCancellationRequested) {
                self.ThrowIfCancellationRequested();
            }
        }

        internal static string FormatWith(this string format, params object[] args) {
            return string.Format(format, args);
        }

        internal static Uri ToUri(this string value) {
            return new Uri(value, UriKind.RelativeOrAbsolute);
        }

        public static T Cast<T>(this object self, T example) {
            foreach(var pi in self.GetType().GetRuntimeProperties()) {
                example.GetType().GetRuntimeProperties().Where(p => p.Name.Equals(pi.Name, StringComparison.InvariantCultureIgnoreCase)).First().SetValue(example, pi.GetValue(self));
            }
            return example;
        }

        public static T Cast<T>(this object self) {
            var ret = (T)Activator.CreateInstance<T>();

            foreach(var pi in self.GetType().GetRuntimeProperties()) {
                ret.GetType().GetRuntimeProperties().Where(p => p.Name.Equals(pi.Name, StringComparison.InvariantCultureIgnoreCase)).First().SetValue(ret, pi.GetValue(self));
            }
            return ret;
        }

        internal static Task<HttpResponseMessage> SendAsync(this HttpClient client, HttpMethod method, string address, params object[] args) {
            var request = new HttpRequestMessage {
                Method = HttpMethod.Get,
                RequestUri = address.FormatWith(args).ToUri()
            };
            return client.SendAsync(request);
        }
    }
}
