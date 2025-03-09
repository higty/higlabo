using System;
using System.Collections.Generic;

public class FileExtensionProcessor
{
    public HashSet<string> TextExtensions { get; init; } = new();
    public HashSet<string> ImageExtensions { get; init; } = new();
    public HashSet<string> VideoExtensions { get; init; } = new();

    public FileExtensionProcessor()
    {
        this.TextExtensions = CreateTextExtensions();
        this.ImageExtensions = CreateImageExtensions();
        this.VideoExtensions = CreateVideoExtensions();
    }
    private HashSet<string> CreateTextExtensions()
    {
        var d = new HashSet<string>
        { 
            //----------------------------------
            // 純粋なテキストファイル／マークアップ系
            //----------------------------------
            ".txt", ".text", ".log", ".rtf",  // RTFは厳密にバイナリ部分を含むが簡易的に含める例
            ".md", ".markdown", ".mkd", ".mdown", ".rst", ".org",
            ".html", ".htm", ".xhtml", ".xml", ".xsd", ".xsl", ".xslt",
            ".json", ".json5", ".jsonc",
            ".yaml", ".yml", ".toml", ".ini", ".conf", ".config",
            ".properties", ".editorconfig",
            ".csv", ".tsv",

            //----------------------------------
            // プログラミング言語のソースコード系
            //----------------------------------
            // C/C++
            ".c", ".cc", ".cpp", ".cxx", ".h", ".hh", ".hpp", ".hxx", ".ino",
            // C#
            ".cs", ".csx",
            // Visual Basic
            ".vb", ".vbx",
            // F#
            ".fs", ".fsi", ".fsx", ".fsscript",
            // Java
            ".java", ".jsp", ".jspx",
            // Kotlin
            ".kt", ".kts",
            // Scala
            ".scala", ".sbt",
            // Groovy
            ".groovy", ".gvy", ".gy", ".gsh",
            // Go
            ".go",
            // Rust
            ".rs",
            // Swift
            ".swift",
            // Objective-C / Objective-C++
            ".m", ".mm",
            // Dart
            ".dart",
            // Erlang
            ".erl", ".hrl",
            // Elixir
            ".ex", ".exs",
            // Haskell
            ".hs",
            // Julia
            ".jl",
            // Lua
            ".lua",
            // R
            ".r", // 大文字拡張子の .R もあり得るが、ToLowerInvariant() で対応
            // Ruby
            ".rb", ".erb",
            // Python
            ".py", ".pyw", ".pyi", ".ipynb",
            // Perl
            ".pl", ".pm", ".t", ".pod",
            // PHP
            ".php", ".php3", ".php4", ".php5", ".php7", ".phtml",
            // JavaScript/TypeScript
            ".js", ".mjs", ".cjs", ".ts", ".mts", ".cts", ".jsx", ".tsx",
            // Shell/Bash
            ".sh", ".bash", ".zsh", ".ksh", ".fish", ".csh", ".tcsh",
            // Batch/Command
            ".bat", ".cmd",
            // SQL
            ".sql", ".psql", ".dbml",
            // Lisp/Clojure系
            ".lisp", ".cl", ".clisp", ".el", ".clj", ".cljc", ".cljs", ".cljx",
            // OCaml
            ".ml", ".mli",
            // Pascal
            ".pas", ".pp",
            // Fortran
            ".f", ".for", ".f90", ".f95",
            // Make/CMake
            ".make", ".mak", ".mk", ".cmake",

            //----------------------------------
            // スクリプト系・設定ファイルなど
            //----------------------------------
            ".ps1", ".psm1", ".psd1",         // PowerShell
            ".gradle",                        // Gradle
            ".chef", ".recipe",               // Chef
            // Git
            ".gitignore", ".gitattributes", ".gitmodules",
            // Docker
            ".dockerignore",
            // Node.js/NPM/Yarn/Pnpm
            ".npmrc", ".yarnrc", ".pnpmrc",
            // その他Lockファイル類
            ".lock",
            // Bower, ESLint, Prettier, Stylelint などのRC系
            ".bowerrc", ".jshintrc", ".jscsrc", ".eslintrc", ".stylelintrc", ".prettierrc",

            //----------------------------------
            // テンプレートエンジン系
            //----------------------------------
            ".jade", ".pug",  // Pug(旧Jade)
            ".haml", ".slim", // HAML, Slim
            ".twig", ".liquid",
            ".mustache", ".handlebars", ".hbs",
            ".erb", ".ejs", ".mjml",
            ".vue", ".svelte", // Vue, Svelte
       
            //----------------------------------
            // CSS系
            //----------------------------------
            ".css", ".scss", ".sass", ".less", 
       
            //----------------------------------
            // LaTeX系
            //----------------------------------
            ".tex", ".latex", ".sty", ".cls", ".bib",

            //----------------------------------
            // その他拡張子
            //----------------------------------
            ".map" // ソースマップ（JSON）
            // 必要に応じてさらに追加してください
        };
        return d;
    }
    private HashSet<string> CreateImageExtensions()
    {
        var d = new HashSet<string>
        {
            // JPEGファミリ
            ".jpg", ".jpeg", ".jpe", ".jfif", ".pjpeg", ".pjp",
            // PNG
            ".png",
            // GIF
            ".gif",
            // BMP
            ".bmp", ".dib",
            // WebP
            ".webp",
            // TIFF
            ".tif", ".tiff",
            // ICO (Windowsアイコン)
            ".ico", 
            // SVG (ベクタ画像)
            ".svg", 
            // HEIF/HEIC
            ".heif", ".heic",
            // AVIF
            ".avif",
            //---------------------------------------------
            // RAW画像フォーマット
            // （環境によっては生ファイル扱いだが、ここでは画像として扱う一例）
            //---------------------------------------------
            ".raw",   // 汎用RAW拡張子
            ".arw",   // Sony
            ".cr2",   // Canon
            ".crw",   // Canon 古い形式
            ".nef",   // Nikon
            ".nrw",   // Nikon
            ".orf",   // Olympus
            ".raf",   // Fujifilm
            ".rw2",   // Panasonic
            ".dng",   // Adobe
            //---------------------------------------------
            // その他の画像・テクスチャ形式
            //---------------------------------------------
            ".psd",   // Photoshop (実質バイナリの要素多めだが画像編集ツールで扱う)
            ".tga",   // Targa
            ".dds",   // DirectDraw Surface
            ".exr",   // OpenEXR (HDR画像)
            ".hdr",   // Radiance HDR
            ".icns",  // macOSアイコン
            // Netpbmファミリ
            ".pbm", ".pgm", ".ppm", ".pnm"
        };
        return d;
    }
    private HashSet<string> CreateVideoExtensions()
    {
        var d = new HashSet<string>
        {
            //---------------------------------------------
            // 最も一般的・主要な動画ファイル拡張子
            //---------------------------------------------
            ".mp4",    // MPEG-4 Part 14
            ".m4v",    // Apple拡張のMPEG-4
            ".mov",    // QuickTime
            ".qt",     // QuickTime
            ".avi",    // Audio Video Interleave
            ".wmv",    // Windows Media Video
            ".asf",    // Advanced Systems Format
            ".flv",    // Flash Video
            ".f4v",    // Flash拡張
            ".webm",   // WebM
            ".mkv",    // Matroska
            ".m3u8",   // HLSのプレイリスト(厳密には動画そのものではないが、映像配信で用いられる)
        
            //---------------------------------------------
            // MPEG系の古いフォーマットやバリエーション
            //---------------------------------------------
            ".mpg", ".mpeg", ".mpe", ".mp2", ".mpv",
            ".ts", ".m2ts", ".mts",  // MPEG-2 TS
            ".m2v",                  // MPEG-2 ビデオのみ
            ".vob",                  // DVD-Video

            //---------------------------------------------
            // 携帯端末系フォーマット
            //---------------------------------------------
            ".3gp", ".3g2",          // 3GPP/3GPP2
        
            //---------------------------------------------
            // RealMedia系
            //---------------------------------------------
            ".rm", ".rmvb",
        
            //---------------------------------------------
            // その他
            //---------------------------------------------
            ".dv",      // DV (Digital Video)
            ".divx",    // DivX
            ".ogv",     // Ogg Theora
            ".ogg",     // Ogg (音声専用の場合もあるが、Theoraビデオを含む場合も)
            ".h264",    // 生のH.264ビデオストリーム
            ".264",     // 同上
            ".yuv",     // 生のYUVフォーマット
            ".mxf",     // Material Exchange Format（プロ向け）
            // 必要に応じて追加してください
        };
        return d;
    }

    public bool IsTextFile(string extension)
    {
        return IsTextFile(extension, StringComparer.OrdinalIgnoreCase);
    }
    public bool IsTextFile(string extension, StringComparer comparer)
    {
        if (string.IsNullOrWhiteSpace(extension))
        {
            return false;
        }
        if (!extension.StartsWith("."))
        {
            extension = "." + extension;
        }
        return this.TextExtensions.Contains(extension, comparer);
    }
    public bool IsImageFile(string extension)
    {
        return IsImageFile(extension, StringComparer.OrdinalIgnoreCase);
    }
    public bool IsImageFile(string extension, StringComparer comparer)
    {
        if (string.IsNullOrWhiteSpace(extension))
        {
            return false;
        }
        if (!extension.StartsWith("."))
        {
            extension = "." + extension;
        }
        return this.ImageExtensions.Contains(extension, comparer);
    }
    public bool IsVideoFile(string extension)
    {
        return IsVideoFile(extension, StringComparer.OrdinalIgnoreCase);
    }
    public bool IsVideoFile(string extension, StringComparer comparer)
    {
        if (string.IsNullOrWhiteSpace(extension))
        {
            return false;
        }
        if (!extension.StartsWith("."))
        {
            extension = "." + extension;
        }
        return this.VideoExtensions.Contains(extension, comparer);
    }
}