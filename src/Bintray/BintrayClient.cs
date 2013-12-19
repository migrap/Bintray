using Bintray.Models;
using Bintray.Net.Http.Formatting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Bintray.Diagnostics.Contracts;
using System.IO;

namespace Bintray {
    public class BintrayClient {
        private BintrayMediaTypeFormatter _formatter = new BintrayMediaTypeFormatter();
        private HttpClient _client;

        public BintrayClient(string address = "https://api.bintray.com", string username = (string)null, string key = (string)null) {
            new { address }.CheckNotNull();

            _client = new HttpClient(new HttpClientHandler()) {
                BaseAddress = address.ToUri()
            };
            _client.DefaultRequestHeaders.Add("Authorization", "Basic {0}".FormatWith(Convert.ToBase64String(Encoding.ASCII.GetBytes("{0}:{1}".FormatWith(username, key)))));
        }

        public Task<Repositories> GetRepositoriesAsync(string subject = (string)null) {
            new { subject }.CheckNotNull();
            return _client.SendAsync(HttpMethod.Get, "repos/{0}".FormatWith(subject))
                .ReadAsAsync<Repositories>(_formatter);
        }

        public Task<Repository> GetRepositoryAsync(string subject = (string)null, string repo = (string)null) {
            new { subject, repo }.CheckNotNull();

            return _client.SendAsync(HttpMethod.Get, "/repos/{0}/{1}", subject, repo)
                .ReadAsAsync<Repository>(_formatter);
        }

        public Task<Packages> GetPackagesAsync(string subject = (string)null, string repo = (string)null) {
            new { subject, repo }.CheckNotNull();

            return _client.SendAsync(HttpMethod.Get, "/repos/{0}/{1}/packages", subject, repo)
                .ReadAsAsync<Packages>(_formatter);
        }

        public Task<Package> GetPackageAsync(string subject = (string)null, string repo = (string)null, string package = (string)null) {
            new { subject, repo, package }.CheckNotNull();

            return _client.SendAsync(HttpMethod.Get, "/packages/{0}/{1}/{2}", subject, repo, package)
                .ReadAsAsync<Package>(_formatter);
        }

        public Task<Models.Version> GetVersionAsync(string subject = (string)null, string repo = (string)null, string package = (string)null, string version = (string)"_latest") {
            new { subject, repo, package, version }.CheckNotNull();

            return _client.SendAsync(HttpMethod.Get, "/packages/{0}/{1}/{2}/versions/{3}", subject, repo, package, version)
                .ReadAsAsync<Models.Version>(_formatter);
        }

        //curl -L -o <FILE.EXT> "http://dl.bintray.com/migrap/generic/<FILE_TARGET_PATH>"
        public Task<Stream> DownloadAsync(string subject = (string)null, string repo = (string)null, string file = (string)null) {
            return _client.SendAsync(HttpMethod.Get, "http://dl.bintray.com/migrap/generic/{0}", file)
                .ReadAsStreamAsync();
        }
    }
}