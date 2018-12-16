using DevExpress.Web.ASPxTreeList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace DevExpress.Web.Demos {
    public class TreeListVirtualModeHelper {
        public static void VirtualModeCreateChildren(TreeListVirtualModeCreateChildrenEventArgs e) {
            string path = e.NodeObject == null ? Request.MapPath("~/") : e.NodeObject.ToString();

            List<string> children = new List<string>();
            if(Directory.Exists(path)) {
                foreach(string name in Directory.GetDirectories(path)) {
                    if(!IsSystemName(name))
                        children.Add(name);
                }
                foreach(string name in Directory.GetFiles(path))
                    if(!IsSystemName(name))
                        children.Add(name);
            }
            e.Children = children;
        }
        public static void VirtualModeNodeCreating(TreeListVirtualModeNodeCreatingEventArgs e) {
            string nodePath = e.NodeObject.ToString();
            e.NodeKeyValue = GetNodeGuid(nodePath);
            e.IsLeaf = !Directory.Exists(nodePath);
            e.SetNodeValue("name", Path.GetFileName(nodePath));
            e.SetNodeValue("date", Directory.GetCreationTime(nodePath));
        }

        static HttpRequest Request { get { return HttpContext.Current.Request; } }
        static Dictionary<string, Guid> Map {
            get {
                const string key = "DX_PATH_GUID_MAP";
                if(HttpContext.Current.Session[key] == null)
                    HttpContext.Current.Session[key] = new Dictionary<string, Guid>();
                return HttpContext.Current.Session[key] as Dictionary<string, Guid>;
            }
        }
        static bool IsSystemName(string name) {
            name = Path.GetFileName(name).ToLower();
            return name.StartsWith("app_") || name == "bin" || name == "obj";
        }
        static Guid GetNodeGuid(string path) {
            if(!Map.ContainsKey(path))
                Map[path] = Guid.NewGuid();
            return Map[path];
        }
    }
}
