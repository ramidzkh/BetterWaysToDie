using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using NLog;
using SharpILMixins.Processor;
using SharpILMixins.Processor.Utils;
using SharpILMixins.Processor.Workspace;

namespace ModLauncher
{
    internal static class Program
    {
        private const string WorkDir =
            "/run/media/haydenv/Data/SteamLibrary/steamapps/common/7 Days To Die/.betterwaystodie";

        private const string OutputDir =
            "/run/media/haydenv/Data/SteamLibrary/steamapps/common/7 Days To Die/7DaysToDie_Data/Managed";

        private const string MixinAssemblyFile =
            "/home/haydenv/RiderProjects/BetterWaysToDie2/BetterWaysToDie/bin/Debug/net40/BetterWaysToDie.dll";

        private static Logger Logger { get; } = LoggerUtils.LogFactory.GetLogger(nameof(Program));

        private static void Main(string[] args)
        {
            Logger.Info("Applying Mixins");
            File.Delete(Path.Combine(OutputDir, "Assembly-CSharp.dll"));

            var workspace = new MixinWorkspace(new FileInfo(MixinAssemblyFile),
                new DirectoryInfo(WorkDir),
                new MixinWorkspaceSettings(
                    OutputDir,
                    DumpTargetType.None,
                    outputSuffix: ""
                )
            );
            workspace.Apply();

            Logger.Info("Running Game");

            var process = Process.Start(new ProcessStartInfo
            {
                FileName = "steam",
                Arguments = "steam://rungameid/251570",
                UseShellExecute = true
            });

            process.WaitForExit();
            Environment.Exit(process.ExitCode);
        }
    }
}
