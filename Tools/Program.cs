using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using CommandLine;
using NLog;
using SharpILMixins.Processor;
using SharpILMixins.Processor.Utils;
using SharpILMixins.Processor.Workspace;

namespace Tools
{
    [Verb("launch", HelpText = "Apply Mixins and launch the game")]
    internal class LaunchOptions
    {
        [Option('g', "game-location", Required = true, HelpText = "The Steam game location")]
        public string GameLocation { get; set; }

        [Option('b', "build-location", Required = true, HelpText = "The build location")]
        public string BuildLocation { get; set; }
    }

    [Verb("generate", HelpText = "Generate Mixin Targets")]
    internal class GenerateOptions
    {
        [Option('o', "output-location", Required = true, HelpText = "The output location")]
        public string OutputLocation { get; set; }

        [Option('b', "build-location", Required = true, HelpText = "The build location")]
        public string BuildLocation { get; set; }
    }

    internal static class Program
    {
        private static Logger Logger { get; } = LoggerUtils.LogFactory.GetLogger(nameof(Program));

        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<LaunchOptions, GenerateOptions>(args)
                .WithParsed<LaunchOptions>(options =>
                {
                    Logger.Info("Applying Mixins");
                    File.Delete(Path.Combine(options.GameLocation, "7DaysToDie_Data/Managed/Assembly-CSharp.dll"));

                    var workspace = new MixinWorkspace(
                        new FileInfo(Path.Combine(options.BuildLocation, "BetterWaysToDie.dll")),
                        new DirectoryInfo(options.BuildLocation),
                        new MixinWorkspaceSettings(
                            Path.Combine(options.GameLocation, "7DaysToDie_Data/Managed"),
                            DumpTargetType.None
                        )
                    );
                    workspace.Apply();

                    Logger.Info("Running Game");

                    var process = Process.Start(RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                        ? new ProcessStartInfo
                        {
                            FileName = "steam", Arguments = "steam://rungameid/251570", UseShellExecute = true
                        }
                        : new ProcessStartInfo { FileName = "steam://rungameid/251570", UseShellExecute = true });
                    process.WaitForExit();
                    Environment.Exit(process.ExitCode);
                })
                .WithParsed<GenerateOptions>(options =>
                {
                    Logger.Info("Generating targets");
                    var workspace = new MixinWorkspace(
                        new FileInfo(Path.Combine(options.BuildLocation, "BetterWaysToDie.dll")),
                        new DirectoryInfo(options.BuildLocation),
                        new MixinWorkspaceSettings(options.OutputLocation,
                            DumpTargetType.None,
                            isGenerateOnly: GenerationType.HelperCode)
                    );
                    workspace.Apply();
                });
        }
    }
}
