using System.DirectoryServices;
using System.Linq;
using Microsoft.Web.Administration;

// Copyright 2011 (c) Planet Software Pty Ltd. This work is
// licenced under the Creative Commons Attribution 2.5 Australia License. To view
// a copy of this licence, visit http://creativecommons.org/licences/by/2.5/au
using System;
using System.DirectoryServices;
using System.Linq;
using Microsoft.Web.Administration;

namespace IISCA
{
    using Microsoft.Web.Administration;

    public static class ExtensionMethods
    {
        private const string IISEntry = "IIS://localhost/W3SVC/";
        private const string Root = "/root";
        private const string Path = "Path";

        public static string PhysicalPath(this Site site)
        {
            if (site == null) { throw new ArgumentNullException("site"); }

            var root = site.Applications.Where(a => a.Path == "/").Single();
            var vRoot = root.VirtualDirectories.Where(v => v.Path == "/")
                .Single();

            // Can get environment variables, so need to expand them
            return Environment.ExpandEnvironmentVariables(vRoot.PhysicalPath);
        }

        public static string PhysicalPath(this DirectoryEntry site)
        {
            if (site == null) { throw new ArgumentNullException("site"); }

            string path;

            using (DirectoryEntry de = new DirectoryEntry(IISEntry
                + site.Name + Root))
            {
                path = de.Properties[Path].Value.ToString();
            }

            return path;
        }
    }
}