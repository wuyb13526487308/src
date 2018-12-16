using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxClasses;

namespace DevExpress.Web.Demos {

    public class SourceCodePage {
        public string Title = "";
        public string Code = "";
        public bool Expanded = false;

        public SourceCodePage(string title, string code, bool expanded) {
            Title = title;
            Code = code;
            Expanded = expanded;
        }
    }

    public class FeaturedDemoInfo {
        public string Title = "";
        public string Description = "";
        public string NavigateUrl = "";
        public string ImageUrl = "";
    }

    public static class Utils {
        const string
            CurrentDemoKey = "DXCurrentDemo",
            CurrentThemeCookieKeyPrefix = "DXCurrentTheme",
            DefaultTheme = "DevEx";

        static readonly Dictionary<DemoModel, IEnumerable<SourceCodePage>> sourceCodeCache = new Dictionary<DemoModel, IEnumerable<SourceCodePage>>();
        static readonly object sourceCodeCacheLock = new object();

        static string _codeLanguage;

        static HttpContext Context {
            get { return HttpContext.Current; }
        }

        static HttpRequest Request {
            get { return Context.Request; }
        }

        public static bool IsMvc {
            get { return DemosModel.Current.IsMvc; }
        }
        public static bool IsMvcRazor {
            get { return DemosModel.Current.IsMvcRazor; }
        }

        public static DemoModel CurrentDemo {
            get { return (DemoModel)Context.Items[CurrentDemoKey]; }
        }

        public static string CurrentDemoTitleHtml {
            get { return GetDemoTitleHtml(CurrentDemo); }
        }

        public static IntroPageModel CurrentIntro {
            get { return CurrentDemo as IntroPageModel; }
        }

        public static string CurrentThemeCookieKey {
            get { return CurrentThemeCookieKeyPrefix + DemosModel.Current.Key; }
        }

        public static string CurrentTheme {
            get {
                if(CanChangeTheme && Request.Cookies[CurrentThemeCookieKey] != null)
                    return HttpUtility.UrlDecode(Request.Cookies[CurrentThemeCookieKey].Value);
                return DefaultTheme;
            }
        }

        public static bool IsIntro {
            get { return CurrentIntro != null; }
        }

        public static string GetDemoTitleHtml(DemoModel demo) {
            string result = String.Format("{0} - {1}", demo.Group.Title, demo.Title);
            if(result.Length > 60)
                result = demo.Title;
            return HttpUtility.HtmlEncode(result);
        }

        public static string CodeLanguage {
            get {
                if(_codeLanguage == null) {
                    try {
                        using(FileStream _file = File.OpenRead(Context.Server.MapPath("~/Site.master")))
                        using(TextReader reader = new StreamReader(_file)) {
                            string line = reader.ReadLine();
                            Match match = Regex.Match(line, @"language=""([^""]+)", RegexOptions.IgnoreCase);
                            if(match.Success) {
                                _codeLanguage = match.Groups[1].Value.ToUpper();
                            }
                        }
                    } catch {
                    }
                    if(String.IsNullOrEmpty(_codeLanguage))
                        _codeLanguage = "C#";
                }
                return _codeLanguage;
            }
        }

        public static IEnumerable<SourceCodePage> GetCurrentSourceCodePages() {
            return GetSourceCodePages(CurrentDemo);
        }

        public static IEnumerable<SourceCodePage> GetSourceCodePages(DemoModel demo) {
            lock(sourceCodeCacheLock) {
                if(!sourceCodeCache.ContainsKey(demo))
                    sourceCodeCache[demo] = CreateSourceCodePages(demo);
                return sourceCodeCache[demo];
            }
        }

        static IEnumerable<SourceCodePage> CreateSourceCodePages(DemoModel demo) {
            List<SourceCodePage> result = new List<SourceCodePage>();
            if(IsMvc) {
                foreach(string fileName in demo.SourceFiles) {
                    if(fileName.StartsWith("~/Models/"))
                        AddSourceCodePage(result, string.Format("Model ({0})", Path.GetFileNameWithoutExtension(fileName)), fileName, false);
                }
                string controllerUrl = string.Format("~/Controllers/{0}/{0}Controller.{1}.cs", demo.Group.Key, demo.Key);
                AddSourceCodePage(result, "Controller", controllerUrl, true, false);
                string commonControllerUrl = string.Format("~/Controllers/{0}Controller.cs", demo.Group.Key);
                AddSourceCodePage(result, "Controller (common)", commonControllerUrl, false);
                string viewUrl = string.Format("~/Views/{0}/{1}.{2}", demo.Group.Key, demo.Key, IsMvcRazor ? "cshtml" : "aspx");
                AddSourceCodePage(result, "View", viewUrl, true, false);
                foreach(string fileName in demo.SourceFiles) {
                    if(fileName.StartsWith("~/Views/"))
                        AddSourceCodePage(result, string.Format("View ({0})", Path.GetFileNameWithoutExtension(fileName)), fileName, true);
                }
            }
            else {
                string baseUrl = GenerateWebFormsDemoUrl(demo);
                AddSourceCodePage(result, "ASPX", baseUrl, true);
                AddSourceCodePage(result, "C#", baseUrl + ".cs", CodeLanguage == "C#");
                AddSourceCodePage(result, "VB", baseUrl + ".vb", CodeLanguage == "VB");
                foreach(string fileName in demo.SourceFiles) {
                    AddSourceCodePage(result, Path.GetFileName(fileName), fileName, false);
                }
            }
            return result;
        }

        static void AddSourceCodePage(List<SourceCodePage> list, string title, string url, bool expanded) {
            AddSourceCodePage(list, title, url, expanded, true);
        }
        static void AddSourceCodePage(List<SourceCodePage> list, string title, string url, bool expanded, bool showIfError) {
            string content = string.Empty;
            try {
                content = GetHighlightedFileContent(url);
            } catch {
                content = showIfError ? "Error rendering source code" : string.Empty;
            }
            if(!string.IsNullOrEmpty(content))
                list.Add(new SourceCodePage(title, content, expanded));
        }
        static string GetHighlightedFileContent(string virtualPath) {
            string filePath = GetHighlightedFilePath(virtualPath);
            string text = File.ReadAllText(filePath);
            return CodeFormatter.GetFormattedCode(Path.GetExtension(filePath), text, IsMvc, IsMvcRazor);
        }
        static string GetHighlightedFilePath(string virtualPath) {
            string result = new DirectoryInfo(Context.Server.MapPath("~/")).FullName;
            result = Path.Combine(result, ".Source");
            result = Path.Combine(result, virtualPath.Substring(2));
            if(File.Exists(result))
                return result;

            result = Context.Server.MapPath(virtualPath);
            if(!File.Exists(result))
                result = CorrectSourceFilePath(result);
            return result;
        }

        static string CorrectSourceFilePath(string filePath) {
            string csPathItem = String.Format("{0}cs{0}", Path.DirectorySeparatorChar);
            string vbPathItem = String.Format("{0}vb{0}", Path.DirectorySeparatorChar);
            filePath = filePath.ToLower();
            if(filePath.EndsWith(".cs"))
                return filePath.Replace(vbPathItem, csPathItem);
            if(filePath.EndsWith(".vb"))
                return filePath.Replace(csPathItem, vbPathItem);
            return filePath;
        }

        public static string GetVersionText() {
            string[] parts = AssemblyInfo.Version.Split('.');
            return string.Format("v{0} vol {1}.{2}", 2000 + int.Parse(parts[0]), parts[1], parts[2]);
        }

        public static void RegisterCurrentWebFormsDemo(Page page) {
            string path = page.AppRelativeVirtualPath.Replace("~/", "").Replace(".aspx", "");
            string[] parts = path.Split('/');
            if(parts.Length < 1)
                throw new ArgumentException("Invalid demo URL");

            string groupKey = "";
            string demoKey = "";

            if(parts.Length > 1) {
                groupKey = parts[0];
                demoKey = parts[1];
            } else {
                demoKey = parts[0];
            }

            RegisterCurrentDemo(groupKey, demoKey);
        }

        public static void RegisterCurrentMvcDemo(string controllerName, string actionName) {
            RegisterCurrentDemo(controllerName, actionName);
        }

        static void RegisterCurrentDemo(string groupKey, string demoKey) {
            DemoModel demo = null;
            DemoGroupModel group = DemosModel.Current.FindGroup(groupKey);
            if(group != null)
                demo = group.FindDemo(demoKey);

            if(demo == null)
                demo = CreateBogusDemoModel();

            Context.Items[CurrentDemoKey] = demo;
        }

        static DemoModel CreateBogusDemoModel() {
            DemoGroupModel group = new DemoGroupModel();
            group.Title = "ASP.NET";

            DemoModel result = new DemoModel();
            result.Group = group;
            result.HideSourceCode = true;
            result.Title = "Delivered!";

            return result;
        }

        public static string GetCurrentDemoPageTitle() {
            StringBuilder builder = new StringBuilder();
            builder.Append(CurrentDemo.GetSeoTitle());
            string group = CurrentDemo.Group.SeoTitle;
            if(!string.IsNullOrEmpty(group)) {
                builder.Append(" - ");
                builder.Append(group);
            }
            builder.Append(" - ");
            builder.Append(DemosModel.Current.GetSeoTitle());
            return builder.ToString();
        }

        public static void RegisterCssLink(Page page, string url) {
            RegisterCssLink(page, url, null);
        }

        public static void RegisterCssLink(Page page, string url, string clientId) {
            if(IsMvc)
                throw new NotImplementedException();
            HtmlLink link = new HtmlLink();
            page.Header.Controls.Add(link);
            link.EnableViewState = false;
            link.Attributes["type"] = "text/css";
            link.Attributes["rel"] = "stylesheet";
            if(!string.IsNullOrEmpty(clientId))
                link.Attributes["id"] = clientId;
            link.Href = url;
        }

        public static string GenerateDemoUrl(DemoModel demo) {
            if (!string.IsNullOrEmpty(demo.HighlightedLink))
                return demo.HighlightedLink;
            if(IsMvc)
                return GenerateMvcDemoUrl(demo);
            return GenerateWebFormsDemoUrl(demo);
        }

        static string GenerateWebFormsDemoUrl(DemoModel demo) {
            StringBuilder builder = new StringBuilder("~/");
            if(!string.IsNullOrEmpty(demo.Group.Key)) {
                builder.Append(demo.Group.Key);
                builder.Append("/");
            }
            builder.Append(demo.Key);
            builder.Append(".aspx");
            return builder.ToString();
        }

        static string GenerateMvcDemoUrl(DemoModel demo) {
            StringBuilder builder = new StringBuilder("~/");
            if(!string.IsNullOrEmpty(demo.Group.Key)) {
                builder.Append(demo.Group.Key);
                builder.Append("/");
            }
            builder.Append(demo.Key);
            return builder.ToString();
        }

        public static List<FeaturedDemoInfo> GenerateFeaturedDemos() {
            var result = new List<FeaturedDemoInfo>();
            foreach(var demo in DemosModel.Current.HighlightedDemos) {
                result.Add(new FeaturedDemoInfo {
                    Title = demo.GetHighlightedTitle(),
                    ImageUrl = demo.HighlightedImageUrl,
                    NavigateUrl = GenerateDemoUrl(demo)
                });
            }
            if(Utils.CurrentIntro != null) {
                foreach(var demo in Utils.CurrentIntro.ExternalDemos) {
                    result.Add(new FeaturedDemoInfo {
                        Title = demo.Title,
                        ImageUrl = demo.ImageUrl,
                        NavigateUrl = demo.Url
                    });
                }
            }
            return result;
        }

        public static void EnsureRequestValidationMode() {
            try {
                if(Environment.Version.Major >= 4) {
                    Type type = typeof(WebControl).Assembly.GetType("System.Web.Configuration.RuntimeConfig");
                    MethodInfo getConfig = type.GetMethod("GetConfig", BindingFlags.Static | BindingFlags.NonPublic, null, new Type[] { }, null);
                    object runtimeConfig = getConfig.Invoke(null, null);
                    MethodInfo getSection = type.GetMethod("GetSection", BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(string), typeof(Type) }, null);
                    HttpRuntimeSection httpRuntimeSection = (HttpRuntimeSection)getSection.Invoke(runtimeConfig, new object[] { "system.web/httpRuntime", typeof(HttpRuntimeSection) });
                    FieldInfo bReadOnly = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                    bReadOnly.SetValue(httpRuntimeSection, false);

                    PropertyInfo pi = typeof(HttpRuntimeSection).GetProperty("RequestValidationMode");
                    if(pi != null) {
                        Version version = (Version)pi.GetValue(httpRuntimeSection, null);
                        Version RequiredRequestValidationMode = new Version(2, 0);
                        if(version != null && !Version.Equals(version, RequiredRequestValidationMode)) {
                            pi.SetValue(httpRuntimeSection, RequiredRequestValidationMode, null);
                        }
                    }
                    bReadOnly.SetValue(httpRuntimeSection, true);
                }
            } catch { }
        }

        static bool? _isSiteMode;
        public static bool IsSiteMode {
            get {
                if(!_isSiteMode.HasValue) {
                    _isSiteMode = ConfigurationManager.AppSettings["SiteMode"].Equals("true", StringComparison.InvariantCultureIgnoreCase);
                }
                return _isSiteMode.Value;
            }
        }

        public static string GetReadOnlyMessageHtml() {
            return String.Format(
                "<b>Data modifications are not allowed in the online demo.</b><br />" +
                "If you need to test data editing functionality, please install " +
                "{0} on your machine and run the demo locally.", DemosModel.Current.Title);
        }
        public static string GetReadOnlyMessageText() {
            return String.Format(
                "Data modifications are not allowed in the online demo.\n" +
                "If you need to test data editing functionality, please install \n" +
                "{0} on your machine and run the demo locally.", DemosModel.Current.Title);
        }

        public static void AssertNotReadOnly() {
            if(!IsSiteMode)
                return;
            throw new InvalidOperationException(GetReadOnlyMessageHtml());
        }
        public static void AssertNotReadOnlyText() {
            if (!IsSiteMode)
                return;
            throw new InvalidOperationException(GetReadOnlyMessageText());
        }
        public static bool CanChangeTheme {
            get { return !IsIntro && !IsIE6() && DemosModel.Current.SupportsTheming; }
        }

        public static void InjectDescriptionMeta(Control parent) {
            if(String.IsNullOrEmpty(Utils.CurrentDemo.MetaDescription)) return;

            Page page = parent as Page;
            HtmlHead header = (page != null && page.Header != null) ? page.Header : RenderUtils.FindHead(parent);
            if(header != null) {
                LiteralControl metaControl = new LiteralControl(string.Format("<meta name=\"description\" content=\"{0}\" />", Utils.CurrentDemo.MetaDescription));
                header.Controls.AddAt(0, metaControl);
            }
        }

        public static void InjectIE7CompatModeMeta(Control parent) {
            InjectIECompatModeMeta(parent, 7);
        }
        public static void InjectIEEdgeCompatModeMeta(Control parent) {
            if(RenderUtils.Browser.IsIE)
               ASPxWebControl.SetIECompatibilityModeEdge(parent);
        }
        
        public static void InjectIECompatModeMeta(Control parent, int compatibilityVersion) {
            if(!RenderUtils.Browser.IsIE || RenderUtils.Browser.Version >= 10  || RenderUtils.Browser.Version < compatibilityVersion + 1)
                return;
            ASPxWebControl.SetIECompatibilityMode(compatibilityVersion, parent);
        }

        public static bool IsIE6() {
            return RenderUtils.Browser.IsIE && RenderUtils.Browser.Version < 7;
        }
        
        public static bool IsIE9() {
            return RenderUtils.Browser.IsIE && RenderUtils.Browser.Version > 8;
        }
    }

}
