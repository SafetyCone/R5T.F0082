using System;
using System.Linq;
using System.Threading.Tasks;

using R5T.F0082.F000;
using R5T.T0221;
using R5T.T0246;


namespace R5T.F0082.Construction
{
    [ScriptsMarker]
    public partial interface IScripts : IScriptsMarker
    {
        /// <summary>
        /// Result: Found 4893 project file paths in 1.0844156 seconds.
        /// </summary>
        /// <remarks>
        /// Uses the canonical project file location (in solution directory child directories).
        /// </remarks>
        public async Task Get_ProjectFilePaths()
        {
            var outputTextFilePath = Instances.FilePaths._Strings.Output_Text_FilePath;
            var projectFilePathsTextFilePath = @"C:\Temp\Project File Paths.txt";

            var repositoriesDirectoryPaths = Instances.RepositoriesDirectoryPathsSets.All_Internal;

            var projectFilePaths = Instances.TimingOperator.MeasureDuration(
                () =>
                {
                    var projectFilePaths = Instances.CodeFileSystemOperator.Get_ProjectFilePaths(
                        OverloadToken<RepositoriesDirectoryPath>.Instance,
                        repositoriesDirectoryPaths)
                        .Now();

                    return projectFilePaths;
                },
                out var duration);

            var lines = Instances.EnumerableOperator.New<string>()
                .Append($"Found {projectFilePaths.Length} project file paths in {duration.TotalSeconds} seconds.")
                .Append(Instances.Strings.Empty)
                .Append("Searched repositories directory paths:")
                .Append(Instances.Strings.Empty)
                .Append(repositoriesDirectoryPaths)
                .Append(Instances.Strings.Empty)
                .Append("Project file paths:")
                .Append(Instances.Strings.Empty)
                .Append(projectFilePaths
                    .OrderAlphabetically());

            await Instances.FileOperator.Write_Lines(
                outputTextFilePath,
                lines);

            await Instances.FileOperator.Write_Lines(
                projectFilePathsTextFilePath,
                projectFilePaths);

            Instances.NotepadPlusPlusOperator.Open(
                outputTextFilePath,
                projectFilePathsTextFilePath);
        }

        /// <summary>
        /// Result: Found 4929 project file paths (via solution directory child directory search) in 3.259187 seconds.
        /// </summary>
        public async Task Display_ProjectFilePaths_ViaSolutionChildAndGrandChildDirectoriesSearch()
        {
            var outputTextFilePath = Instances.FilePaths._Strings.Output_Text_FilePath;
            var projectFilePathsTextFilePath = @"C:\Temp\Project File Paths-Solution Child and Grandchild Directories Search.txt";

            var repositoriesDirectoryPaths = Instances.RepositoriesDirectoryPathsSets.All_Internal;

            var projectFilePaths = Instances.TimingOperator.MeasureDuration(
                () =>
                {
                    var projectFilePaths = Instances.CodeFileSystemOperator._Implementations.Enumerate_ProjectFilePaths_ViaSolutionChildAndGrandchildDirectoriesSearch(
                        OverloadToken<RepositoriesDirectoryPath>.Instance,
                        repositoriesDirectoryPaths)
                        .Now();

                    return projectFilePaths;
                },
                out var duration);

            var lines = Instances.EnumerableOperator.New<string>()
                .Append($"Found {projectFilePaths.Length} project file paths (via solution directory child directory search) in {duration.TotalSeconds} seconds.")
                .Append(Instances.Strings.Empty)
                .Append("Searched repositories directory paths:")
                .Append(Instances.Strings.Empty)
                .Append(repositoriesDirectoryPaths)
                .Append(Instances.Strings.Empty)
                .Append("Project file paths:")
                .Append(Instances.Strings.Empty)
                .Append(projectFilePaths
                    .OrderAlphabetically());

            await Instances.FileOperator.Write_Lines(
                outputTextFilePath,
                lines);

            await Instances.FileOperator.Write_Lines(
                projectFilePathsTextFilePath,
                projectFilePaths);

            Instances.NotepadPlusPlusOperator.Open(
                outputTextFilePath,
                projectFilePathsTextFilePath);
        }

        /// <summary>
        /// Result: there are some projects that are in solution grand-child directory paths,
        /// but also some projects that are in /bin directories (these are the sample project files that are copied to output directories by projects with a dependency on R5T.Z0008).
        /// </summary>
        /// <remarks>
        /// => Don't include /bin directories in the full search.
        /// </remarks>
        public async Task List_MissingProjects()
        {
            var allProjectFilePaths_TextFilePath = @"C:\Temp\Project File Paths.txt";
            //var solutionChildDirectoryOnlyProjectFilePaths_TextFilePath = @"C:\Temp\Project File Paths-Solution Child Directories Search.txt";
            var solutionChildAndGrandchildDirectoryOnlyProjectFilePaths_TextFilePath = @"C:\Temp\Project File Paths-Solution Child and Grandchild Directories Search.txt";

            var outputTextFilePath = Instances.FilePaths.OutputTextFilePath;

            var allProjectFilePaths = await Instances.FileOperator.ReadAllLines(allProjectFilePaths_TextFilePath);
            //var solutionChildDirectoryOnlyProjectFilePaths = await Instances.FileOperator.ReadAllLines(solutionChildDirectoryOnlyProjectFilePaths_TextFilePath);
            var solutionChildAndGrandchildDirectoryOnlyProjectFilePaths = await Instances.FileOperator.ReadAllLines(solutionChildAndGrandchildDirectoryOnlyProjectFilePaths_TextFilePath);

            var missingProjectFilePaths = allProjectFilePaths
                //.Except(solutionChildDirectoryOnlyProjectFilePaths)
                .Except(solutionChildAndGrandchildDirectoryOnlyProjectFilePaths)
                // Filter out the /bin directory project file paths.
                .Where(projectFilePath => !projectFilePath.Contains(@"\bin\"))
                // Filter out example project files.
                .Where(projectFilePath => !projectFilePath.Contains(@"\Files\"))
                .Now();

            await Instances.FileOperator.Write_Lines(
                outputTextFilePath.Value,
                missingProjectFilePaths);

            Instances.NotepadPlusPlusOperator.Open(outputTextFilePath.Value);
        }

        /// <summary>
        /// Result: Found 4891 project file paths (via solution directory child directory search) in 0.985099 seconds.
        /// </summary>
        public async Task Display_ProjectFilePaths_ViaSolutionChildDirectoriesSearch()
        {
            var outputTextFilePath = Instances.FilePaths._Strings.Output_Text_FilePath;
            var projectFilePathsTextFilePath = @"C:\Temp\Project File Paths-Solution Child Directories Search.txt";

            var repositoriesDirectoryPaths = Instances.RepositoriesDirectoryPathsSets.All_Internal;

            var projectFilePaths = Instances.TimingOperator.MeasureDuration(
                () =>
                {
                    var projectFilePaths = Instances.CodeFileSystemOperator._Implementations.Enumerate_ProjectFilePaths_ViaSolutionChildDirectoriesSearch(
                        OverloadToken<RepositoriesDirectoryPath>.Instance,
                        repositoriesDirectoryPaths)
                        .Now();

                    return projectFilePaths;
                },
                out var duration);

            var lines = Instances.EnumerableOperator.New<string>()
                .Append($"Found {projectFilePaths.Length} project file paths (via solution directory child directory search) in {duration.TotalSeconds} seconds.")
                .Append(Instances.Strings.Empty)
                .Append("Searched repositories directory paths:")
                .Append(Instances.Strings.Empty)
                .Append(repositoriesDirectoryPaths)
                .Append(Instances.Strings.Empty)
                .Append("Project file paths:")
                .Append(Instances.Strings.Empty)
                .Append(projectFilePaths
                    .OrderAlphabetically());

            await Instances.FileOperator.Write_Lines(
                outputTextFilePath,
                lines);

            await Instances.FileOperator.Write_Lines(
                projectFilePathsTextFilePath,
                projectFilePaths);

            Instances.NotepadPlusPlusOperator.Open(
                outputTextFilePath,
                projectFilePathsTextFilePath);
        }

        /// <summary>
        /// Result: Found 5116 project file paths (via direct files search in each repository directory) in 29.0180363 seconds.
        /// </summary>
        public async Task Display_ProjectFilePaths_ViaRepositoryDirectorySearch()
        {
            var outputTextFilePath = Instances.FilePaths._Strings.Output_Text_FilePath;
            var projectFilePathsTextFilePath = @"C:\Temp\Project File Paths.txt";

            var repositoriesDirectoryPaths = Instances.RepositoriesDirectoryPathsSets.All_Internal;

            var progressWriter = Console.Out;

            var projectFilePaths = Instances.TimingOperator.MeasureDuration(
                () =>
                {
                    var projectFilePaths = Instances.CodeFileSystemOperator._Implementations.Enumerate_ProjectFilePaths_ViaRepositoryDirectorySearch(
                        OverloadToken<RepositoriesDirectoryPath>.Instance,
                        repositoriesDirectoryPaths,
                        progressWriter)
                        .Now();

                    return projectFilePaths;
                },
                out var duration);

            var lines = Instances.EnumerableOperator.New<string>()
                .Append($"Found {projectFilePaths.Length} project file paths (via direct files search in each repository directory) in {duration.TotalSeconds} seconds.")
                .Append(Instances.Strings.Empty)
                .Append("Searched repositories directory paths:")
                .Append(Instances.Strings.Empty)
                .Append(repositoriesDirectoryPaths)
                .Append(Instances.Strings.Empty)
                .Append("Project file paths:")
                .Append(Instances.Strings.Empty)
                .Append(projectFilePaths
                    .OrderAlphabetically());

            await Instances.FileOperator.Write_Lines(
                outputTextFilePath,
                lines);

            await Instances.FileOperator.Write_Lines(
                projectFilePathsTextFilePath,
                projectFilePaths);

            Instances.NotepadPlusPlusOperator.Open(
                outputTextFilePath,
                projectFilePathsTextFilePath);
        }

        public async Task Display_ProjectDirectorPaths_InSolutionDirectory_WithoutProjectFile()
        {
            var outputTextFilePath = Instances.FilePaths._Strings.Output_Text_FilePath;

            var repositoriesDirectoryPaths = Instances.RepositoriesDirectoryPathsSets.All_Internal;

            var projectDirectoryPaths = Instances.TimingOperator.MeasureDuration(
                () =>
                {
                    var projectDirectoryPaths_AllChildDirectories = Instances.CodeFileSystemOperator._Implementations.Enumerate_ProjectDirectoryPaths_AllChildDirectories_ExceptHidden(
                        OverloadToken<RepositoriesDirectoryPath>.Instance,
                        repositoriesDirectoryPaths)
                        .Now();

                    var projectDirectoryPaths_WithProjectFile = Instances.CodeFileSystemOperator._Implementations.Enumerate_ProjectDirectoryPaths_ChildDirectories_WithProjectFile(
                        OverloadToken<RepositoriesDirectoryPath>.Instance,
                        repositoriesDirectoryPaths)
                        .Now();

                    var exceptionalProjectDirectoryPaths = projectDirectoryPaths_AllChildDirectories
                        .Except(projectDirectoryPaths_WithProjectFile)
                        .Now();

                    return exceptionalProjectDirectoryPaths;
                },
                out var duration);

            var lines = Instances.EnumerableOperator.New<string>()
                .Append($"Found {projectDirectoryPaths.Length} exceptional project directory paths that are child directories of solution directories, but do not contain a project file, in {duration.TotalSeconds} seconds.")
                .Append(Instances.Strings.Empty)
                .Append("Searched repositories directory paths:")
                .Append(Instances.Strings.Empty)
                .Append(repositoriesDirectoryPaths)
                .Append(Instances.Strings.Empty)
                .Append("Project directory paths:")
                .Append(Instances.Strings.Empty)
                .Append(projectDirectoryPaths
                    .OrderAlphabetically());

            await Instances.FileOperator.Write_Lines(
                outputTextFilePath,
                lines);

            Instances.NotepadPlusPlusOperator.Open(
                outputTextFilePath);
        }

        /// <summary>
        /// Result: Found 4840 project directory paths (assuming all child-directories of solution directories are project directories) in 1.1976122 seconds.
        /// </summary>
        public async Task Display_ProjectDirectoryPaths_ChildDirectoriesOfSolutionDirectory_WithProjectFile()
        {
            var outputTextFilePath = Instances.FilePaths._Strings.Output_Text_FilePath;

            var repositoriesDirectoryPaths = Instances.RepositoriesDirectoryPathsSets.All_Internal;

            var projectDirectoryPaths = Instances.TimingOperator.MeasureDuration(
                () =>
                {
                    var projectDirectoryPaths = Instances.CodeFileSystemOperator._Implementations.Enumerate_ProjectDirectoryPaths_ChildDirectories_WithProjectFile(
                        OverloadToken<RepositoriesDirectoryPath>.Instance,
                        repositoriesDirectoryPaths)
                        .Now();

                    return projectDirectoryPaths;
                },
                out var duration);

            var lines = Instances.EnumerableOperator.New<string>()
                .Append($"Found {projectDirectoryPaths.Length} project directory paths (assuming all child-directories of solution directories are project directories) in {duration.TotalSeconds} seconds.")
                .Append(Instances.Strings.Empty)
                .Append("Searched repositories directory paths:")
                .Append(Instances.Strings.Empty)
                .Append(repositoriesDirectoryPaths)
                .Append(Instances.Strings.Empty)
                .Append("Project directory paths:")
                .Append(Instances.Strings.Empty)
                .Append(projectDirectoryPaths
                    .OrderAlphabetically());

            await Instances.FileOperator.Write_Lines(
                outputTextFilePath,
                lines);

            Instances.NotepadPlusPlusOperator.Open(
                outputTextFilePath);
        }

        /// <summary>
        /// Result: Found 4903 project directory paths (assuming all child-directories of solution directories are project directories) in 0.5204243 seconds.
        /// </summary>
        public async Task Display_ProjectDirectoryPaths_AllChildDirectoryPathsOfSolutionDirectory()
        {
            var outputTextFilePath = Instances.FilePaths._Strings.Output_Text_FilePath;

            var repositoriesDirectoryPaths = Instances.RepositoriesDirectoryPathsSets.All_Internal;

            var projectDirectoryPaths = Instances.TimingOperator.MeasureDuration(
                () =>
                {
                    var projectDirectoryPaths = Instances.CodeFileSystemOperator._Implementations.Enumerate_ProjectDirectoryPaths_AllChildDirectories_ExceptHidden(
                        OverloadToken<RepositoriesDirectoryPath>.Instance,
                        repositoriesDirectoryPaths)
                        .Now();

                    return projectDirectoryPaths;
                },
                out var duration);

            var lines = Instances.EnumerableOperator.New<string>()
                .Append($"Found {projectDirectoryPaths.Length} project directory paths (assuming all child-directories of solution directories are project directories) in {duration.TotalSeconds} seconds.")
                .Append(Instances.Strings.Empty)
                .Append("Searched repositories directory paths:")
                .Append(Instances.Strings.Empty)
                .Append(repositoriesDirectoryPaths)
                .Append(Instances.Strings.Empty)
                .Append("Project directory paths:")
                .Append(Instances.Strings.Empty)
                .Append(projectDirectoryPaths
                    .OrderAlphabetically());

            await Instances.FileOperator.Write_Lines(
                outputTextFilePath,
                lines);

            Instances.NotepadPlusPlusOperator.Open(
                outputTextFilePath);
        }

        public async Task Display_SolutionFilePaths()
        {
            var outputTextFilePath = Instances.FilePaths._Strings.Output_Text_FilePath;

            var repositoriesDirectoryPaths = Instances.RepositoriesDirectoryPathsSets.All_Internal;

            var solutionFilePaths = Instances.TimingOperator.MeasureDuration(
                () =>
                {
                    var solutionFilePaths = Instances.CodeFileSystemOperator.Get_SolutionFilePaths(
                        OverloadToken<RepositoriesDirectoryPath>.Instance,
                        repositoriesDirectoryPaths);

                    return solutionFilePaths;
                },
                out var duration);

            var lines = Instances.EnumerableOperator.New<string>()
                .Append($"Found {solutionFilePaths.Length} solution file paths in {duration.TotalSeconds} seconds.")
                .Append(Instances.Strings.Empty)
                .Append("Searched repositories directory paths:")
                .Append(Instances.Strings.Empty)
                .Append(repositoriesDirectoryPaths)
                .Append(Instances.Strings.Empty)
                .Append("Solution file paths:")
                .Append(Instances.Strings.Empty)
                .Append(solutionFilePaths
                    .OrderAlphabetically());

            await Instances.FileOperator.Write_Lines(
                outputTextFilePath,
                lines);

            Instances.NotepadPlusPlusOperator.Open(
                outputTextFilePath);
        }

        public async Task Display_SolutionDirectoryPaths()
        {
            var outputTextFilePath = Instances.FilePaths._Strings.Output_Text_FilePath;

            var repositoriesDirectoryPaths = Instances.RepositoriesDirectoryPathsSets.All_Internal;

            var solutionDirectoryPaths = Instances.TimingOperator.MeasureDuration(
                () =>
                {
                    var solutionDirectoryPaths = Instances.CodeFileSystemOperator.Get_SolutionDirectoryPaths(
                        OverloadToken<RepositoriesDirectoryPath>.Instance,
                        repositoriesDirectoryPaths);

                    return solutionDirectoryPaths;
                },
                out var duration);

            var lines = Instances.EnumerableOperator.New<string>()
                .Append($"Found {solutionDirectoryPaths.Length} solution directory paths in {duration.TotalSeconds} seconds.")
                .Append(Instances.Strings.Empty)
                .Append("Searched repositories directory paths:")
                .Append(Instances.Strings.Empty)
                .Append(repositoriesDirectoryPaths)
                .Append(Instances.Strings.Empty)
                .Append("Solution directory paths:")
                .Append(Instances.Strings.Empty)
                .Append(solutionDirectoryPaths
                    .OrderAlphabetically());

            await Instances.FileOperator.Write_Lines(
                outputTextFilePath,
                lines);

            Instances.NotepadPlusPlusOperator.Open(
                outputTextFilePath);
        }

        public async Task Display_SolutionsDirectoryPaths()
        {
            var outputTextFilePath = Instances.FilePaths._Strings.Output_Text_FilePath;

            var repositoriesDirectoryPaths = Instances.RepositoriesDirectoryPathsSets.All_Internal;

            var solutionsDirectoryPaths = Instances.TimingOperator.MeasureDuration(
                () =>
                {
                    var solutionsDirectoryPaths = Instances.CodeFileSystemOperator.Get_SolutionsDirectoryPaths(
                        OverloadToken<RepositoriesDirectoryPath>.Instance,
                        repositoriesDirectoryPaths);

                    return solutionsDirectoryPaths;
                },
                out var duration);

            var lines = Instances.EnumerableOperator.New<string>()
                .Append($"Found {solutionsDirectoryPaths.Length} solutions directory paths in {duration.TotalSeconds} seconds.")
                .Append(Instances.Strings.Empty)
                .Append("Searched repositories directory paths:")
                .Append(Instances.Strings.Empty)
                .Append(repositoriesDirectoryPaths)
                .Append(Instances.Strings.Empty)
                .Append("Solutions directory paths:")
                .Append(Instances.Strings.Empty)
                .Append(solutionsDirectoryPaths
                    .OrderAlphabetically());

            await Instances.FileOperator.Write_Lines(
                outputTextFilePath,
                lines);

            Instances.NotepadPlusPlusOperator.Open(
                outputTextFilePath);
        }

        public async Task Display_RepositoryDirectoryPaths()
        {
            var outputTextFilePath = Instances.FilePaths._Strings.Output_Text_FilePath;

            var repositoriesDirectoryPaths = Instances.RepositoriesDirectoryPathsSets.All_Internal;

            var repositoryDirectoryPaths = Instances.TimingOperator.MeasureDuration(
                () =>
                {
                    var repositoryDirectoryPaths = Instances.CodeFileSystemOperator.Get_RepositoryDirectoryPaths(
                        repositoriesDirectoryPaths);

                    return repositoryDirectoryPaths;
                },
                out var duration);

            var lines = Instances.EnumerableOperator.New<string>()
                .Append($"Found {repositoryDirectoryPaths.Length} repository directory paths in {duration.TotalSeconds} seconds.")
                .Append(Instances.Strings.Empty)
                .Append("Searched repositories directory paths:")
                .Append(Instances.Strings.Empty)
                .Append(repositoriesDirectoryPaths)
                .Append(Instances.Strings.Empty)
                .Append("Repository directory paths:")
                .Append(Instances.Strings.Empty)
                .Append(repositoryDirectoryPaths
                    .OrderAlphabetically());

            await Instances.FileOperator.Write_Lines(
                outputTextFilePath,
                lines);

            Instances.NotepadPlusPlusOperator.Open(
                outputTextFilePath);
        }

        public async Task Display_RepositoriesDirectoryPaths()
        {
            var outputTextFilePath = Instances.FilePaths._Strings.Output_Text_FilePath;

            var repositoriesDirectoryPaths = Instances.RepositoriesDirectoryPathsSets.All_Internal;

            var lines = Instances.EnumerableOperator.New<string>()
                .Append($"Found {repositoriesDirectoryPaths.Length} repositories directory paths:")
                .Append(Instances.Strings.Empty)
                .Append(repositoriesDirectoryPaths
                    .OrderAlphabetically());

            await Instances.FileOperator.Write_Lines(
                outputTextFilePath,
                lines);

            Instances.NotepadPlusPlusOperator.Open(
                outputTextFilePath);
        }
    }
}
