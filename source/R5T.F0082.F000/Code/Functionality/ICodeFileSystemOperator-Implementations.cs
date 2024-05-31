using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using R5T.T0132;
using R5T.T0221;


namespace R5T.F0082.F000.Implementations
{
    [FunctionalityMarker]
    public partial interface ICodeFileSystemOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        private static Internal.ICodeFileSystemOperator _Internal => Internal.CodeFileSystemOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public IEnumerable<string> Enumerate_ProjectFilePaths_ViaSolutionChildAndGrandchildDirectoriesSearch(
            OverloadToken<RepositoriesDirectoryPath> repositoriesDirectoryPathToken,
            IEnumerable<string> repositoriesDirectoryPaths)
        {
            var solutionDirectoryPaths = Instances.CodeFileSystemOperator.Enumerate_SolutionDirectoryPaths(
                repositoriesDirectoryPathToken,
                repositoriesDirectoryPaths)
                .Now();

            var output = this.Enumerate_ProjectFilePaths_ViaSolutionChildAndGrandchildDirectoriesSearch(
                OverloadToken<SolutionDirectoryPath>.Instance,
                solutionDirectoryPaths);

            return output;
        }

        public IEnumerable<string> Enumerate_ProjectFilePaths_ViaSolutionChildAndGrandchildDirectoriesSearch(
            OverloadToken<SolutionDirectoryPath> solutionDirectoryPathToken,
            string solutionDirectoryPath)
        {
            var output = _Internal.If_Exists_ElseEmpty(
                solutionDirectoryPath,
                solutionDirectoryPath =>
                {
                    var directoryPathsToSearch = Instances.FileSystemOperator.Enumerate_ChildAndGrandchildDirectoryPaths(
                        solutionDirectoryPath);

                    var projectFilePaths = Instances.FileSystemOperator.Enumerate_ChildFilePaths_ByFileExtension(
                        Instances.FileExtensions.csproj,
                        directoryPathsToSearch);

                    return projectFilePaths;
                });

            return output;
        }

        public IEnumerable<string> Enumerate_ProjectFilePaths_ViaSolutionChildAndGrandchildDirectoriesSearch(
            OverloadToken<SolutionDirectoryPath> solutionDirectoryPathToken,
            IEnumerable<string> solutionDirectoryPaths)
            => solutionDirectoryPaths
                .SelectMany(solutionDirectoryPath => this.Enumerate_ProjectFilePaths_ViaSolutionChildAndGrandchildDirectoriesSearch(
                    solutionDirectoryPathToken,
                    solutionDirectoryPath));

        public IEnumerable<string> Enumerate_ProjectFilePaths_ViaSolutionChildDirectoriesSearch(
            OverloadToken<RepositoriesDirectoryPath> repositoriesDirectoryPathToken,
            IEnumerable<string> repositoriesDirectoryPaths)
        {
            var solutionDirectoryPaths = Instances.CodeFileSystemOperator.Get_SolutionDirectoryPaths(
                repositoriesDirectoryPathToken,
                repositoriesDirectoryPaths);

            var output = this.Enumerate_ProjectFilePaths_ViaSolutionChildDirectoriesSearch(
                solutionDirectoryPaths);

            return output;
        }

        /// <summary>
        /// Enumerates Visual Studio project files in the solution directory.
        /// </summary>
        /// <remarks>
        /// <mechanism>
        /// Assumes that Visual Studio project (<inheritdoc cref="Z0072.Z000.IFileExtensions.csproj" path="descendant::value"/>) files
        /// are only located in child-directories of a solution directories.
        /// </mechanism>
        /// </remarks>
        public IEnumerable<string> Enumerate_ProjectFilePaths_ViaSolutionChildDirectoriesSearch(string solutionDirectoryPath)
        {
            var output = _Internal.If_Exists_ElseEmpty(
                solutionDirectoryPath,
                solutionDirectoryPath =>
                {
                    var childDirectoryPaths = Instances.FileSystemOperator.Enumerate_ChildDirectoryPaths(solutionDirectoryPath);

                    var output = childDirectoryPaths
                        .SelectMany(childDirectoryPath =>
                        {
                            var projectFilePaths = Instances.FileSystemOperator.Enumerate_ChildFilePaths_ByFileExtension(
                                childDirectoryPath,
                                Instances.FileExtensions.csproj);

                            return projectFilePaths;
                        })
                        ;

                    return output;
                });

            return output;
        }

        public IEnumerable<string> Enumerate_ProjectFilePaths_ViaSolutionChildDirectoriesSearch(
            string[] solutionDirectoryPaths,
            TextWriter outputWriter)
        {
            var index = 1;
            var count = solutionDirectoryPaths.Length;

            var output = solutionDirectoryPaths
                .SelectMany(solutionDirectoryPath =>
                {
                    outputWriter.WriteLine($"{index++} of {count}:\n\t{solutionDirectoryPath}");

                    try
                    {
                        var output = this.Enumerate_ProjectFilePaths_ViaSolutionChildDirectoriesSearch(solutionDirectoryPath);
                        return output;
                    }
                    catch (DirectoryNotFoundException)
                    {
                        outputWriter.Write($"NOT FOUND: {solutionDirectoryPath}");

                        return Instances.EnumerableOperator.Empty<string>();
                    }
                })
                ;

            return output;
        }

        /// <inheritdoc cref="Enumerate_ProjectFilePaths_ViaSolutionChildDirectoriesSearch(string)"/>
        public IEnumerable<string> Enumerate_ProjectFilePaths_ViaSolutionChildDirectoriesSearch(
            string[] solutionDirectoryPaths)
        {
            var output = solutionDirectoryPaths
                .SelectMany(solutionDirectoryPath =>
                {
                    try
                    {
                        var output = this.Enumerate_ProjectFilePaths_ViaSolutionChildDirectoriesSearch(solutionDirectoryPath);
                        return output;
                    }
                    catch (DirectoryNotFoundException)
                    {
                        return Instances.EnumerableOperator.Empty<string>();
                    }
                })
                ;

            return output;
        }

        public string[] Get_ProjectFilePaths_ViaSolutionChildDirectoriesSearch(
            string[] solutionDirectoryPaths,
            TextWriter outputWriter)
        {
            var output = this.Enumerate_ProjectFilePaths_ViaSolutionChildDirectoriesSearch(
                solutionDirectoryPaths,
                outputWriter)
                .Now();

            return output;
        }

        /// <summary>
        /// Gets Visual Studio project files in the solution directories.
        /// <para><inheritdoc cref="Enumerate_ProjectFilePaths_ViaSolutionChildDirectoriesSearch(string[])" path="descendant::mechanism"/></para>
        /// </summary>
        public string[] Get_ProjectFilePaths_ViaSolutionChildDirectoriesSearch(
            string[] solutionDirectoryPaths)
        {
            var output = this.Enumerate_ProjectFilePaths_ViaSolutionChildDirectoriesSearch(
                solutionDirectoryPaths)
                .Now();

            return output;
        }

        public string[] Get_ProjectFilePaths_ViaRepositoryDirectorySearch(
            IEnumerable<string> repositoryDirectoryPaths)
        {
            var output = this.Enumerate_ProjectFilePaths_ViaRepositoryDirectorySearch(
                repositoryDirectoryPaths)
                .Now();

            return output;
        }

        public string[] Get_ProjectFilePaths_ViaRepositoryDirectorySearch(
            string[] repositoryDirectoryPaths,
            TextWriter outputWriter)
        {
            var output = this.Enumerate_ProjectFilePaths_ViaRepositoryDirectorySearch(
                repositoryDirectoryPaths,
                outputWriter)
                .Now();

            return output;
        }

        /// <summary>
        /// Search for all project files (.csproj) files, from a repository directory.
        /// </summary>
        public IEnumerable<string> Enumerate_ProjectFilePaths_ViaRepositoryDirectorySearch(
            string repositoryDirectoryPath)
        {
            var output = Instances.FileSystemOperator.Enumerate_DescendantFilePaths_ByFileExtension(
                repositoryDirectoryPath,
                Instances.FileExtensions.csproj);

            return output;
        }

        public IEnumerable<string> Enumerate_ProjectFilePaths_ViaRepositoryDirectorySearch(
            IEnumerable<string> repositoryDirectoryPaths)
        {
            var output = repositoryDirectoryPaths
                .SelectMany(this.Enumerate_ProjectFilePaths_ViaRepositoryDirectorySearch)
                ;

            return output;
        }

        public IEnumerable<string> Enumerate_ProjectFilePaths_ViaRepositoryDirectorySearch(
            string[] repositoryDirectoryPaths,
            TextWriter progressWriter)
        {
            var index = 1;
            var count = repositoryDirectoryPaths.Length;

            var output = repositoryDirectoryPaths
                .SelectMany(repositoryDirectoryPath =>
                {
                    progressWriter.WriteLine($"{index++} of {count}:\n\t{repositoryDirectoryPath}");

                    var output = this.Enumerate_ProjectFilePaths_ViaRepositoryDirectorySearch(repositoryDirectoryPath);
                    return output;
                })
                ;

            return output;
        }

        public IEnumerable<string> Enumerate_ProjectFilePaths_ViaRepositoryDirectorySearch(
            OverloadToken<RepositoryDirectoryPath> repositoryDirectoryPathToken,
            IList<string> repositoryDirectoryPaths,
            TextWriter progressWriter)
        {
            var index = 1;
            var count = repositoryDirectoryPaths.Count;

            var output = repositoryDirectoryPaths
                .SelectMany(repositoryDirectoryPath =>
                {
                    progressWriter.WriteLine($"{index++} of {count}:\n\t{repositoryDirectoryPath}");

                    var output = this.Enumerate_ProjectFilePaths_ViaRepositoryDirectorySearch(repositoryDirectoryPath);
                    return output;
                })
                ;

            return output;
        }

        public IEnumerable<string> Enumerate_ProjectFilePaths_ViaRepositoryDirectorySearch(
            OverloadToken<RepositoryDirectoryPath> repositoryDirectoryPathToken,
            IEnumerable<string> repositoryDirectoryPaths,
            TextWriter progressWriter)
            => this.Enumerate_ProjectFilePaths_ViaRepositoryDirectorySearch(
                repositoryDirectoryPathToken,
                repositoryDirectoryPaths
                    .Now(),
                progressWriter);

        public IEnumerable<string> Enumerate_ProjectFilePaths_ViaRepositoryDirectorySearch(
            OverloadToken<RepositoriesDirectoryPath> repositoryDirectoryPathToken,
            IEnumerable<string> repositoriesDirectoryPaths,
            TextWriter progressWriter)
        {
            var repositoryDirectoryPaths = Instances.CodeFileSystemOperator.Get_RepositoryDirectoryPaths(
                repositoriesDirectoryPaths);

            var output = this.Enumerate_ProjectFilePaths_ViaRepositoryDirectorySearch(
                OverloadToken<RepositoryDirectoryPath>.Instance,
                repositoryDirectoryPaths,
                progressWriter);

            return output;
        }

        /// <summary>
        /// BAD (returns .vs hidden directories).
        /// Implementation assuming all directories inside a solution directory are project directories
        /// (as opposed to supporting documents or data directories).
        /// </summary>
        [Bad("Returns .vs directories (Visual Studio-specific hidden directories) as well.")]
        public IEnumerable<string> Enumerate_ProjectDirectoryPaths_AllChildDirectories(string solutionDirectoryPath)
        {
            var output = _Internal.If_Exists_ElseEmpty(
                solutionDirectoryPath,
                Instances.FileSystemOperator.Enumerate_ChildDirectoryPaths);

            return output;
        }

        /// <summary>
        /// Implementation assuming all directories inside a solution directory (except hidden directories) are project directories
        /// (as opposed to supporting documents or data directories).
        /// </summary>
        [Bad("Returns .vscode, TestResults, packages, and directories (Visual Studio-specific hidden directories) as well.")]
        public IEnumerable<string> Enumerate_ProjectDirectoryPaths_AllChildDirectories_ExceptHidden(
            OverloadToken<SolutionDirectoryPath> solutionDirectoryPathToken,
            string solutionDirectoryPath)
        {
            var output = _Internal.If_Exists_ElseEmpty(
                solutionDirectoryPath,
                Instances.FileSystemOperator.Enumerate_ChildDirectoryPaths_ExcludingHidden);

            return output;
        }

        /// <inheritdoc cref="Enumerate_ProjectDirectoryPaths_AllChildDirectories_ExceptHidden(OverloadToken{SolutionDirectoryPath}, string)"/>
        public IEnumerable<string> Enumerate_ProjectDirectoryPaths_AllChildDirectories_ExceptHidden(string solutionDirectoryPath)
            => this.Enumerate_ProjectDirectoryPaths_AllChildDirectories_ExceptHidden(
                OverloadToken<SolutionDirectoryPath>.Instance,
                solutionDirectoryPath);

        /// <inheritdoc cref="Enumerate_ProjectDirectoryPaths_AllChildDirectories_ExceptHidden(OverloadToken{SolutionDirectoryPath}, string)"/>
        public IEnumerable<string> Enumerate_ProjectDirectoryPaths_AllChildDirectories_ExceptHidden(
            OverloadToken<RepositoriesDirectoryPath> repositoriesDirectoryPathToken,
            IEnumerable<string> repositoriesDirectoryPaths)
        {
            var solutionDirectoryPaths = Instances.CodeFileSystemOperator.Enumerate_SolutionDirectoryPaths(
                OverloadToken<RepositoriesDirectoryPath>.Instance,
                repositoriesDirectoryPaths);

            var projectDirectoryPaths = solutionDirectoryPaths
                .SelectMany(solutionDirectoryPath =>
                    this.Enumerate_ProjectDirectoryPaths_AllChildDirectories_ExceptHidden(
                        solutionDirectoryPath)
                )
                .Now();

            return projectDirectoryPaths;
        }

        /// <summary>
        /// Implementation assuming all directories inside a solution directory, which contain at least one project file, are project directories.
        /// </summary>
        public IEnumerable<string> Enumerate_ProjectDirectoryPaths_ChildDirectories_WithProjectFile(
            OverloadToken<SolutionDirectoryPath> solutionDirectoryPathToken,
            string solutionDirectoryPath)
        {
            var output = _Internal.If_Exists_ElseEmpty(
                solutionDirectoryPath,
                solutionDirectoryPath =>
                {
                    var allChildDirectoryPaths = Instances.FileSystemOperator.Enumerate_ChildDirectoryPaths(solutionDirectoryPath);

                    var output = allChildDirectoryPaths
                        .Where(directoryPath =>
                            Instances.FileSystemOperator.Enumerate_ChildFilePaths_ByFileExtension(
                                directoryPath,
                                Instances.FileExtensions.csproj)
                            .Any()
                        )
                        ;

                    return output;
                });

            return output;
        }

        /// <inheritdoc cref="Enumerate_ProjectDirectoryPaths_ChildDirectories_WithProjectFile(OverloadToken{SolutionDirectoryPath}, string)"/>
        public IEnumerable<string> Enumerate_ProjectDirectoryPaths_ChildDirectories_WithProjectFile(string solutionDirectoryPath)
            => this.Enumerate_ProjectDirectoryPaths_ChildDirectories_WithProjectFile(
                OverloadToken<SolutionDirectoryPath>.Instance,
                solutionDirectoryPath);

        /// <inheritdoc cref="Enumerate_ProjectDirectoryPaths_ChildDirectories_WithProjectFile(OverloadToken{SolutionDirectoryPath}, string)"/>
        public IEnumerable<string> Enumerate_ProjectDirectoryPaths_ChildDirectories_WithProjectFile(
            OverloadToken<RepositoriesDirectoryPath> repositoriesDiretoryPathToken,
            IEnumerable<string> repositoriesDirectoryPaths)
        {
            var solutionDirectoryPaths = Instances.CodeFileSystemOperator.Enumerate_SolutionDirectoryPaths(
                OverloadToken<RepositoriesDirectoryPath>.Instance,
                repositoriesDirectoryPaths);

            var projectDirectoryPaths = solutionDirectoryPaths
                .SelectMany(solutionDirectoryPath =>
                    this.Enumerate_ProjectDirectoryPaths_ChildDirectories_WithProjectFile(
                        solutionDirectoryPath)
                )
                .Now();

            return projectDirectoryPaths;
        }

        /// <summary>
        /// Implementation assuming only a single solutions directory inside the repository directory, with the directory name
        /// </summary>
        public IEnumerable<string> Enumerate_SolutionsDirectoryPaths_SourceDirectory(string repositoryDirectoryPath)
        {
            var sourceDirectoryPath = Instances.PathOperator.Get_DirectoryPath(
                repositoryDirectoryPath,
                Instances.DirectoryNames.Repository_Source_DirectoryName);

            var output = Instances.EnumerableOperator.From(sourceDirectoryPath);
            return output;
        }

        /// <summary>
        /// Implemenation assuming that solutions do not have their own directories within the solutions directory,
        /// but are directly contained within the solutions directory.
        /// </summary>
        public IEnumerable<string> Enumerate_SolutionDirectoryPaths(string solutionsDirectoryPath)
        {
            var output = Instances.EnumerableOperator.From(solutionsDirectoryPath);
            return output;
        }

        /// <summary>
        /// Implementation assuming there can be multiple solution files in a solution directory.
        /// </summary>
        public IEnumerable<string> Enumerate_SolutionFilePaths(string solutionDirectoryPath)
        {
            var output = _Internal.If_Exists_ElseEmpty(
                solutionDirectoryPath,
                solutionDirectoryPath => Instances.FileSystemOperator.Enumerate_ChildFilePaths_ByFileExtension(
                    solutionDirectoryPath,
                    Instances.FileExtensions.sln));

            return output;
        }
    }
}
