using DevExpress.Web.ASPxTreeView;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace DevExpress.Web.Demos {
    public class TreeViewVirtualModeHelper {
        const string FileImageUrl = "~/Content/TreeView/FileSystem/file.png";
        const string DirImageUrl = "~/Content/TreeView/FileSystem/directory.png";
        static HttpRequest Request { get { return HttpContext.Current.Request; } }

        public static void CreateChildren(TreeViewVirtualModeCreateChildrenEventArgs e) {
            string parentNodePath = string.IsNullOrEmpty(e.NodeName) ? Request.MapPath("~/") : e.NodeName;
            List<TreeViewVirtualNode> children = new List<TreeViewVirtualNode>();
            if(Directory.Exists(parentNodePath)) {
                foreach(string childPath in Directory.GetDirectories(parentNodePath)) {
                    string childDirName = Path.GetFileName(childPath);
                    if(IsSystemName(childDirName))
                        continue;
                    TreeViewVirtualNode childNode = new TreeViewVirtualNode(childPath, childDirName);
                    childNode.Image.Url = DirImageUrl;
                    children.Add(childNode);
                }
                foreach(string childPath in Directory.GetFiles(parentNodePath)) {
                    string childFileName = Path.GetFileName(childPath);
                    if(IsSystemName(childFileName))
                        continue;
                    TreeViewVirtualNode childNode = new TreeViewVirtualNode(childPath, childFileName);
                    childNode.IsLeaf = true;
                    childNode.Image.Url = FileImageUrl;
                    children.Add(childNode);
                }
            }
            e.Children = children;
        }

        static bool IsSystemName(string name) {
            name = name.ToLower();
            return name.StartsWith("app_") || name == "bin" || name == "obj";
        }
    }
}
