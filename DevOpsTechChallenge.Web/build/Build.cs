using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.CompressionTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using System.IO;
using Colorful;

[CheckBuildProjectConfigurations]
[UnsetVisualStudioEnvironmentVariables]
class Build : NukeBuild
{
    public static int Main () => Execute<Build>(x => x.Publish);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = Configuration.Release;

    [Parameter("The version number for the assemblies, etc.")]
    readonly string Version = "1.1.1.1";

    [Solution] readonly Solution Solution;
    [GitRepository] readonly GitRepository GitRepository;

    AbsolutePath PublishDirectory => RootDirectory / "publish";

    AbsolutePath WebProjectPath => RootDirectory / @"DevOpsTechChallenge.Web\DevOpsTechChallenge.Web.csproj";

    AbsolutePath PublishZipPath => RootDirectory / "DevOpsTechChallenge.Web.zip";

    Target Clean => _ => _
        .Executes(() =>
        {
            EnsureCleanDirectory(PublishDirectory);
            foreach(var directory in Directory.GetDirectories(RootDirectory,"TestResults", SearchOption.AllDirectories))
            {
                EnsureCleanDirectory(directory);
            }
            if(FileExists(PublishZipPath))
            {
                DeleteFile(PublishZipPath);
            }
        });

    Target Restore => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .SetAssemblyVersion(Version)
                .EnableNoRestore());
        });

    Target Test => _ => _
    .DependsOn(Compile)
    .Executes(() =>
    {
        DotNetTest(s => s
            .SetProjectFile(Solution)
            .SetConfiguration(Configuration)
            .SetDataCollector("XPlat Code Coverage")
            .SetLogger("trx")
            .EnableNoRestore()
            .EnableNoBuild());

    });

    Target Publish => _ => _
    .DependsOn(Test)
    .Executes(() =>
    {
        DotNetPublish(s => s
            .SetProject(WebProjectPath)
            .SetConfiguration(Configuration)
            .SetOutput(PublishDirectory)
            .EnableNoRestore()
            .EnableNoBuild());
        CompressZip(PublishDirectory, PublishZipPath, fileMode: FileMode.Create);
    });
}
