using Microsoft.Win32;
using System;
using System.IO;
using System.Net;

namespace Filever
{
    class Program
    {
        public class EnvInfo
        {
            private static string getRegistryValue(string keyname, string valuename)
                => Registry.GetValue(keyname, valuename, "").ToString();

            public static string os_version { get; }
                = Environment.OSVersion.VersionString;

            public static string os_product_name { get; }
                = getRegistryValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");

            public static string os_release { get; }
                = getRegistryValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ReleaseId");

            public static string os_build { get; }
                = getRegistryValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild");

            public static string os_bit { get; }
                = Environment.Is64BitOperatingSystem ? "64 bit" : "32 bit";

            public static string process_bit { get; }
                = Environment.Is64BitProcess ? "64 bit" : "32 bit";

            public static string framework_version { get; }
                = Environment.Version.ToString();

            public static string registry_framework_version { get; }
                = getRegistryValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full", "Version");

            public static string registry_framework_release { get; }
                = getRegistryValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full", "Release");

            public static string host_name { get; }
                = Dns.GetHostName();

            public static string machine_name { get; }
                = Environment.MachineName;
        }

        static void Main(string[] args)
        {
            Console.WriteLine( "{0} {1} {2} build:{3}",
                EnvInfo.os_product_name,
                EnvInfo.os_bit,
                EnvInfo.os_release,
                EnvInfo.os_build
                );
            if (args.Length == 0)
            {
                TextReader input;
                input = Console.In;
                Proc(input.ReadLine());
                input.Dispose();
            }
            else
            {
                foreach (var path in args)
                {
                    Proc(path);
                }
                //var path = args[0];
            }


        }

        private static void Proc(string path)
        {
            if (System.IO.File.Exists(path) == false)
            {
                Console.WriteLine(@"File Not Found {0}", path);
                Console.WriteLine(@"please exist file path.");
                return;
            }
            //NOTEPAD.EXEのFileVersionInfoオブジェクトを取得する
            System.Diagnostics.FileVersionInfo vi = System.Diagnostics.FileVersionInfo.GetVersionInfo(path);

            //Console.WriteLine("ProductName:{0}", vi.ProductName);
            Console.WriteLine("{0} {1}", vi.OriginalFilename, vi.FileVersion);
            //Console.WriteLine("FileVersion:{0}", vi.FileVersion);


            ////バージョン番号
            //Console.WriteLine("FileVersion:{0}", vi.FileVersion);
            ////メジャーバージョン番号
            //Console.WriteLine("FileMajorPart:{0}", vi.FileMajorPart);
            ////マイナバージョン番号
            //Console.WriteLine("FileMinorPart:{0}", vi.FileMinorPart);
            ////プライベートパート番号
            //Console.WriteLine("FilePrivatePart:{0}", vi.FilePrivatePart);
            ////ビルド番号
            //Console.WriteLine("FileBuildPart:{0}", vi.FileBuildPart);
            ////プライベートバージョン
            //Console.WriteLine("PrivateBuild:{0}", vi.PrivateBuild);
            ////スペシャルビルド
            //Console.WriteLine("SpecialBuild:{0}", vi.SpecialBuild);

            ////説明
            //Console.WriteLine("FileDescription:{0}", vi.FileDescription);
            ////著作権
            //Console.WriteLine("LegalCopyright:{0}", vi.LegalCopyright);
            ////会社名
            //Console.WriteLine("CompanyName:{0}", vi.CompanyName);
            ////コメント
            //Console.WriteLine("Comments:{0}", vi.Comments);
            ////内部名
            //Console.WriteLine("InternalName:{0}", vi.InternalName);
            ////言語
            //Console.WriteLine("Language:{0}", vi.Language);
            ////商標
            //Console.WriteLine("LegalTrademarks:{0}", vi.LegalTrademarks);
            ////オリジナルファイル名
            //Console.WriteLine("OriginalFilename:{0}", vi.OriginalFilename);

            ////製品名
            //Console.WriteLine("ProductName:{0}", vi.ProductName);
            ////製品バージョン
            //Console.WriteLine("ProductVersion:{0}", vi.ProductVersion);
            ////製品メジャーバージョン番号
            //Console.WriteLine("ProductMajorPart:{0}", vi.ProductMajorPart);
            ////製品マイナバージョン番号
            //Console.WriteLine("ProductMinorPart:{0}", vi.ProductMinorPart);
            ////製品プライベートバージョン番号
            //Console.WriteLine("ProductPrivatePart:{0}", vi.ProductPrivatePart);
            ////製品ビルド番号
            //Console.WriteLine("ProductBuildPart:{0}", vi.ProductBuildPart);

            ////デバッグ情報があるか
            //Console.WriteLine("IsDebug:{0}", vi.IsDebug);
            ////パッチされているか
            //Console.WriteLine("IsPatched:{0}", vi.IsPatched);
            ////プレリリースか
            //Console.WriteLine("IsPreRelease:{0}", vi.IsPreRelease);
            ////スペシャルビルドか
            //Console.WriteLine("IsSpecialBuild:{0}", vi.IsSpecialBuild);
        }
    }
}
