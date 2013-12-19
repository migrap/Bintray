using Bintray;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bintray.Diagnostics.Contracts;

namespace Sandbox {
    class Program {
        static void Main(string[] args) {
            var bintray = new BintrayClient();
            //var repos = bintray.GetRepositoriesAsync(subject: "migrap").Result;
            //var repo = bintray.GetRepositoryAsync(subject: "migrap", repo: "generic").Result;
            //var packages = bintray.GetPackagesAsync(subject: "migrap", repo: "generic").Result;
            //var package = bintray.GetPackageAsync(subject: "migrap", repo: "generic", package: "Currant").Result;
            var version = bintray.GetVersionAsync(subject: "migrap", repo: "generic", package: "Currant", version: "1.0.0-Alpha").Result;
        }
    }

    public static partial class Extensions {
        
    }
}
