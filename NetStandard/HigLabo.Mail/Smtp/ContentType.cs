using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if !NETFX_CORE && !SILVERLIGHT
using Microsoft.Win32;
using System.Security.Permissions;
#endif

namespace HigLabo.Net.Smtp
{
    public class ContentType
    {
        private static Dictionary<String, String> _FileExtensions = new Dictionary<String, String>();
        public static Dictionary<String, String> FileExtensions
        {
            get { return _FileExtensions; }
        }

        private String _Value = "";

        public String Name { get; set; }
        public String Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
                var index = value.IndexOf("/", StringComparison.OrdinalIgnoreCase);
                if (index > -1)
                {
                    this.MainValue = value.Substring(0, index);
                    if (index < value.Length - 1)
                    {
                        this.SubValue = value.Substring(index + 1, value.Length - (index + 1));
                    }
                }
            }
        }
        public String MainValue { get; private set; }
        public String SubValue { get; private set; }
        public String Boundary { get; set; }
        public String Charset
        {
            get
            {
                if (this.CharsetEncoding == null) { return ""; }
                return this.CharsetEncoding.WebName;
            }
        }
        public Encoding CharsetEncoding { get; set; }
        public Boolean IsText
        {
            get { return String.Equals(this.MainValue, "text", StringComparison.OrdinalIgnoreCase); }
        }
        public Boolean IsHtml
        {
            get
            {
                return String.Equals(this.MainValue, "text", StringComparison.OrdinalIgnoreCase) &&
                    String.Equals(this.SubValue, "html", StringComparison.OrdinalIgnoreCase);
            }
        }
        public Boolean IsMultipart
        {
            get { return String.Equals(this.MainValue, "multipart", StringComparison.OrdinalIgnoreCase); }
        }
        public List<SmtpMailHeaderParameter> Parameters { get; private set; }

        static ContentType()
        {
            InitializeGeneratedFileExtensions();
            InitializeFileExtensions();
        }
        private static void InitializeGeneratedFileExtensions()
        {
            var d = ContentType.FileExtensions;
            //Generated
            d[".3g2"] = "video/3gpp2";
            d[".3gp"] = "video/3gpp";
            d[".ac3"] = "audio/vnd.dolby.dd-raw";
            d[".acrobatsecuritysettings"] = "application/vnd.adobe.acrobat-security-settings";
            d[".adts"] = "audio/vnd.dlna.adts";
            d[".aiff"] = "audio/x-aiff";
            d[".application"] = "application/x-ms-application";
            d[".asx"] = "video/x-ms-asf-plugin";
            d[".au"] = "audio/basic";
            d[".avi"] = "video/x-msvideo";
            d[".bmp"] = "image/bmp";
            d[".cat"] = "vnd.ms-pki.seccat";
            d[".cer"] = "x-x509-ca-cert";
            d[".contact"] = "text/x-ms-contact";
            d[".crl"] = "pkix-crl";
            d[".css"] = "text/css";
            d[".doc"] = "application/msword";
            d[".docm"] = "application/vnd.ms-word.document.macroEnabled.12";
            d[".docx"] = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            d[".dotm"] = "application/vnd.ms-word.template.macroEnabled.12";
            d[".dotx"] = "application/vnd.openxmlformats-officedocument.wordprocessingml.template";
            d[".dvr-ms"] = "video/x-ms-dvr";
            d[".dwfx"] = "model/vnd.dwfx+xps";
            d[".easmx"] = "model/vnd.easmx+xps";
            d[".ec3"] = "audio/ec3";
            d[".edrwx"] = "model/vnd.edrwx+xps";
            d[".emf"] = "image/x-emf";
            d[".eprtx"] = "model/vnd.eprtx+xps";
            d[".fdf"] = "application/vnd.fdf";
            d[".fif"] = "application/fractals";
            d[".gif"] = "image/gif";
            d[".grv"] = "application/vnd.groove-injector";
            d[".gsa"] = "application/vnd.groove-space-archive";
            d[".gta"] = "application/vnd.groove-tool-archive";
            d[".gz"] = "application/x-gzip";
            d[".hqx"] = "application/mac-binhex40";
            d[".hta"] = "application/hta";
            d[".htc"] = "text/x-component";
            d[".htm"] = "text/html";
            d[".ico"] = "image/x-icon";
            d[".ics"] = "text/calendar";
            d[".iqy"] = "text/x-ms-iqy";
            d[".jnlp"] = "application/x-java-jnlp-file";
            d[".jpg"] = "image/pjpeg";
            d[".jtx"] = "application/x-jtx+xps";
            d[".latex"] = "application/x-latex";
            d[".lzh"] = "application/x-lzh-compressed";
            d[".m3u"] = "audio/x-mpegurl";
            d[".m4a"] = "audio/mp4";
            d[".man"] = "application/x-troff-man";
            d[".mdb"] = "application/msaccess";
            d[".mdi"] = "image/vnd.ms-modi";
            d[".mid"] = "midi/mid";
            d[".mov"] = "video/quicktime";
            d[".mp3"] = "audio/x-mpg";
            d[".mp4"] = "video/mp4";
            d[".mpeg"] = "video/x-mpeg2a";
            d[".mpf"] = "application/vnd.ms-mediapackage";
            d[".nix"] = "application/x-mix-transfer";
            d[".odc"] = "text/x-ms-odc";
            d[".odp"] = "application/vnd.oasis.opendocument.presentation";
            d[".ods"] = "application/vnd.oasis.opendocument.spreadsheet";
            d[".odt"] = "application/vnd.oasis.opendocument.text";
            d[".osdx"] = "application/opensearchdescription+xml";
            d[".oxps"] = "application/oxps";
            d[".p10"] = "pkcs10";
            d[".p12"] = "x-pkcs12";
            d[".p7b"] = "x-pkcs7-certificates";
            d[".p7c"] = "application/pkcs7-mime";
            d[".p7m"] = "pkcs7-mime";
            d[".p7r"] = "x-pkcs7-certreqresp";
            d[".p7s"] = "pkcs7-signature";
            d[".pdf"] = "application/pdf";
            d[".pdfxml"] = "application/vnd.adobe.pdfxml";
            d[".pdx"] = "application/vnd.adobe.pdx";
            d[".pko"] = "vnd.ms-pki.pko";
            d[".png"] = "image/x-png";
            d[".potm"] = "application/vnd.ms-powerpoint.template.macroEnabled.12";
            d[".potx"] = "application/vnd.openxmlformats-officedocument.presentationml.template";
            d[".ppam"] = "application/vnd.ms-powerpoint.addin.macroEnabled.12";
            d[".ppsm"] = "application/vnd.ms-powerpoint.slideshow.macroEnabled.12";
            d[".ppsx"] = "application/vnd.openxmlformats-officedocument.presentationml.slideshow";
            d[".ppt"] = "application/x-mspowerpoint";
            d[".pptm"] = "application/x-mspowerpoint.macroEnabled.12";
            d[".pptx"] = "application/x-mspowerpoint.12";
            d[".ps"] = "application/postscript";
            d[".rels"] = "application/vnd.ms-package.relationships+xml";
            d[".rqy"] = "text/x-ms-rqy";
            d[".sit"] = "application/x-stuffit";
            d[".sldm"] = "application/vnd.ms-powerpoint.slide.macroEnabled.12";
            d[".sldx"] = "application/vnd.openxmlformats-officedocument.presentationml.slide";
            d[".spl"] = "application/futuresplash";
            d[".sql"] = "text/plain";
            d[".sst"] = "vnd.ms-pki.certstore";
            d[".stl"] = "vnd.ms-pki.stl";
            d[".svg"] = "image/svg+xml";
            d[".swf"] = "application/x-shockwave-flash";
            d[".tar"] = "application/x-tar";
            d[".tgz"] = "application/x-compressed";
            d[".thmx"] = "application/vnd.ms-officetheme";
            d[".tif"] = "image/tiff";
            d[".tts"] = "video/vnd.dlna.mpeg-tts";
            d[".vcf"] = "text/x-vcard";
            d[".vcg"] = "application/vnd.groove-vcard";
            d[".vdx"] = "application/vnd.ms-visio.viewer";
            d[".vsi"] = "application/ms-vsi";
            d[".vsto"] = "application/x-ms-vsto";
            d[".wav"] = "audio/x-wav";
            d[".wax"] = "audio/x-ms-wax";
            d[".wdp"] = "image/vnd.ms-photo";
            d[".website"] = "application/x-mswebsite";
            d[".wm"] = "video/x-ms-wm";
            d[".wma"] = "audio/x-ms-wma";
            d[".wmd"] = "application/x-ms-wmd";
            d[".wmf"] = "image/x-wmf";
            d[".wmv"] = "video/x-ms-wmv";
            d[".wmx"] = "video/x-ms-wmx";
            d[".wmz"] = "application/x-ms-wmz";
            d[".wpl"] = "application/vnd.ms-wpl";
            d[".wsc"] = "text/scriptlet";
            d[".wtv"] = "video/wtv";
            d[".wvx"] = "video/x-ms-wvx";
            d[".xaml"] = "application/xaml+xml";
            d[".xbap"] = "application/x-ms-xbap";
            d[".xdp"] = "application/vnd.adobe.xdp+xml";
            d[".xfd"] = "application/vnd.adobe.xfd+xml";
            d[".xfdf"] = "application/vnd.adobe.xfdf";
            d[".xht"] = "application/xhtml+xml";
            d[".xlam"] = "application/vnd.ms-excel.addin.macroEnabled.12";
            d[".xls"] = "application/x-msexcel";
            d[".xlsb"] = "application/vnd.ms-excel.sheet.binary.macroEnabled.12";
            d[".xlsm"] = "application/vnd.ms-excel.sheet.macroEnabled.12";
            d[".xlsx"] = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            d[".xltm"] = "application/vnd.ms-excel.template.macroEnabled.12";
            d[".xltx"] = "application/vnd.openxmlformats-officedocument.spreadsheetml.template";
            d[".xml"] = "text/xml";
            d[".xps"] = "application/xps";
            d[".z"] = "application/x-compress";
            d[".zip"] = "application/zip";

        }
        private static void InitializeFileExtensions()
        {
            var d = FileExtensions;

            d[".txt"] = "text/plain";
            d[".html"] = "text/html";
            d[".png"] = "image/png";
            d[".mpg"] = "video/mpeg";
        }
        public ContentType(String value)
        {
            this.Value = value;
            this.CharsetEncoding = Encoding.UTF8;
            this.Parameters = new List<SmtpMailHeaderParameter>();
        }
        public void SetProperty(System.Net.Mime.ContentType contentType)
        {
            var ct = this;

            ct.Boundary = contentType.Boundary;
            var encoding = TryCreateEncoding(contentType.CharSet);
            if (encoding != null)
            {
                ct.CharsetEncoding = encoding;
            }
            foreach (String key in contentType.Parameters.Keys)
            {
                ct.Parameters.Add(new SmtpMailHeaderParameter(key, contentType.Parameters[key].ToString()));
            }
        }
        public void SetProperty(Mime.ContentType contentType)
        {
            var ct = this;

            ct.Value = contentType.Value;
            ct.Boundary = contentType.Boundary;
            var encoding = TryCreateEncoding(contentType.Charset);
            if (encoding != null)
            {
                ct.CharsetEncoding = encoding;
            }
            foreach (var p in contentType.Parameters)
            {
                if (String.IsNullOrEmpty(p.Key) == true ||
                    String.Equals(p.Key, "name", StringComparison.OrdinalIgnoreCase) == true ||
                    String.Equals(p.Key, "boundary", StringComparison.OrdinalIgnoreCase) == true)
                { continue; }
                ct.Parameters.Add(new SmtpMailHeaderParameter(p.Key, p.Value));
            }
        }
        private Encoding TryCreateEncoding(String encoding)
        {
            if (String.IsNullOrEmpty(encoding) == true) { return null; }

            try
            {
                return Encoding.GetEncoding(encoding);
            }
            catch { }
            return null;
        }
        public override string ToString()
        {
            return this.Value;
        }
        public static String GetContentType(String extension)
        {
            String s = extension.ToLower();
            if (ContentType.FileExtensions.ContainsKey(s) == true)
            {
                return ContentType.FileExtensions[s];
            }
            return "application/octet-stream";
        }
    }
}
