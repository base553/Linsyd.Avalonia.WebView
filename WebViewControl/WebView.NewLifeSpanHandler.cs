using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xilium.CefGlue.Common.Handlers;
using Xilium.CefGlue;

namespace WebViewControl {
    public partial class WebView {

        public class NewLifeSpanHandler : LifeSpanHandler {

            private WebView OwnerWebView { get; }

            public NewLifeSpanHandler(WebView webView) {
                OwnerWebView = webView;
            }

            protected override bool OnBeforePopup(CefBrowser browser, CefFrame frame, string targetUrl, string targetFrameName, CefWindowOpenDisposition targetDisposition, bool userGesture, CefPopupFeatures popupFeatures, CefWindowInfo windowInfo, ref CefClient client, CefBrowserSettings settings, ref CefDictionaryValue extraInfo, ref bool noJavascriptAccess) {
                if (UrlHelper.IsChromeInternalUrl(targetUrl)) {
                    return false;
                }

                if (Uri.IsWellFormedUriString(targetUrl, UriKind.RelativeOrAbsolute)) {
                    var uri = new Uri(targetUrl);
                    if (!uri.IsAbsoluteUri) {
                        // turning relative urls into full path to avoid that someone runs custom command lines
                        targetUrl = new Uri(new Uri(frame.Url), uri).AbsoluteUri;
                    }
                } else {
                    return false; // if the url is not well formed let's use the browser to handle the things
                }

                try {

                    OwnerWebView.TabAtOldOpened(frame.Url, targetUrl);
                    OwnerWebView.LoadUrl(targetUrl, MainFrameName);
                } catch {
                    return false;
                }

                return true;
            }
        }
    }
}
