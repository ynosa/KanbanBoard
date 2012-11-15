using System;
using System.DirectoryServices;
using System.Globalization;
using Microsoft.Deployment.WindowsInstaller;
using Microsoft.Web.Administration;
using Microsoft.Win32;

namespace IISCA
{
    using System.DirectoryServices;
    using System.Globalization;

    using Microsoft.Win32;

    public static class CustomActions
    {
        #region Private Constants
        private const string IISEntry = "IIS://localhost/W3SVC";
        private const string SessionEntry = "WEBSITE";
        private const string ServerBindings = "ServerBindings";
        private const string ServerComment = "ServerComment";
        private const string CustomActionException = "CustomActionException: ";
        private const string IISRegKey = @"Software\Microsoft\InetStp";
        private const string MajorVersion = "MajorVersion";
        private const string IISWebServer = "iiswebserver";
        private const string GetComboContent = "select * from ComboBox";
        private const string AvailableSites
            = "select * from AvailableWebSites";
        private const string SpecificSite
            = "Select * from AvailableWebSites where WebSiteID=";
        #endregion

        #region Custom Action Methods
        [CustomAction]
        public static ActionResult GetWebSites(Session session)
        {
            ActionResult result = ActionResult.Failure;

            try
            {
                if (session == null) { throw new ArgumentNullException("session"); }

                View comboBoxView = session.Database.OpenView(GetComboContent);
                View availableWSView = session.Database.OpenView(AvailableSites);

                if (IsIIS7Upwards)
                {
                    GetWebSitesViaWebAdministration(comboBoxView, availableWSView);
                }
                else
                {
                    GetWebSitesViaMetabase(comboBoxView, availableWSView);
                }

                result = ActionResult.Success;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    session.Log(CustomActionException + ex.ToString());
                }
            }

            return result;
        }

        [CustomAction]
        public static ActionResult UpdatePropsWithSelectedWebSite(Session session)
        {
            ActionResult result = ActionResult.Failure;

            try
            {
                if (session == null) { throw new ArgumentNullException("session"); }

                string selectedWebSiteId = session[SessionEntry];
                session.Log("CA: Found web site id: " + selectedWebSiteId);

                using (View availableWebSitesView = session.Database.OpenView(
                    SpecificSite + selectedWebSiteId))
                {
                    availableWebSitesView.Execute();

                    using (Record record = availableWebSitesView.Fetch())
                    {
                        if ((record[1].ToString()) == selectedWebSiteId)
                        {
                            session["WEBSITE_ID"] = selectedWebSiteId;
                            session["WEBSITE_DESCRIPTION"] = (string)record[2];
                            session["WEBSITE_PATH"] = (string)record[3];
                            session.DoAction("SetApplicationRootDirectory");
                        }
                    }
                }

                result = ActionResult.Success;
            }
            catch (Exception ex)
            {
                if (session != null)
                {
                    session.Log(CustomActionException + ex.ToString());
                }
            }

            return result;
        }
        #endregion

        #region Private Helper Methods
        private static void GetWebSitesViaWebAdministration(View comboView,
            View availableView)
        {
            using (ServerManager iisManager = new ServerManager())
            {
                int order = 1;

                foreach (Site webSite in iisManager.Sites)
                {
                    string id = webSite.Id.ToString(CultureInfo.InvariantCulture);
                    string name = webSite.Name;
                    string path = webSite.PhysicalPath();

                    StoreSiteDataInComboBoxTable(id, name, path, order++, comboView);
                    StoreSiteDataInAvailableSitesTable(id, name, path, availableView);
                }
            }
        }

        private static void GetWebSitesViaMetabase(View comboView, View availableView)
        {
            using (DirectoryEntry iisRoot = new DirectoryEntry(IISEntry))
            {
                int order = 1;

                foreach (DirectoryEntry webSite in iisRoot.Children)
                {
                    if (webSite.SchemaClassName.ToLower(CultureInfo.InvariantCulture)
                        == IISWebServer)
                    {
                        string id = webSite.Name;
                        string name = webSite.Properties[ServerComment].Value.ToString();
                        string path = webSite.PhysicalPath();

                        StoreSiteDataInComboBoxTable(id, name, path, order++, comboView);
                        StoreSiteDataInAvailableSitesTable(id, name, path, availableView);
                    }
                }
            }
        }

        private static void StoreSiteDataInComboBoxTable(string id, string name,
            string physicalPath, int order, View comboView)
        {
            Record newComboRecord = new Record(5);
            newComboRecord[1] = SessionEntry;
            newComboRecord[2] = order;
            newComboRecord[3] = id;
            newComboRecord[4] = name;
            newComboRecord[5] = physicalPath;
            comboView.Modify(ViewModifyMode.InsertTemporary, newComboRecord);
        }

        private static void StoreSiteDataInAvailableSitesTable(string id, string name,
            string physicalPath, View availableView)
        {
            Record newWebSiteRecord = new Record(3);
            newWebSiteRecord[1] = id;
            newWebSiteRecord[2] = name;
            newWebSiteRecord[3] = physicalPath;
            availableView.Modify(ViewModifyMode.InsertTemporary, newWebSiteRecord);
        }

        // determines if IIS7 upwards is installed so we know whether to use metabase
        private static bool IsIIS7Upwards
        {
            get
            {
                bool isV7Plus = false;

                using (RegistryKey iisKey = Registry.LocalMachine.OpenSubKey(IISRegKey))
                {
                    isV7Plus = (int)iisKey.GetValue(MajorVersion) >= 7;
                }

                return isV7Plus;
            }
        }

        #endregion
    }
}