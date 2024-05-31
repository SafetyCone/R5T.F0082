using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;
using R5T.T0221;


namespace R5T.F0082.F000
{
    [FunctionalityMarker]
    public partial interface ICodeFileSystemOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Implementations.ICodeFileSystemOperator _Implementations => Implementations.CodeFileSystemOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        #region Repository Directory Paths

        public IEnumerable<string> Enumerate_RepositoryDirectoryPaths(
            IEnumerable<string> repositoriesDirectoryPaths)
            => repositoriesDirectoryPaths
                .SelectMany(repositoriesDirectoryPath => this.Enumerate_RepositoryDirectoryPaths(repositoriesDirectoryPath))
                ;

        public IEnumerable<string> Enumerate_RepositoryDirectoryPaths(
            params string[] repositoriesDirectoryPaths)
            => this.Enumerate_RepositoryDirectoryPaths(
                repositoriesDirectoryPaths.AsEnumerable());

        public IEnumerable<string> Enumerate_RepositoryDirectoryPaths(string repositoriesDirectoryPath)
            => Instances.FileSystemOperator.Enumerate_ChildDirectoryPaths(repositoriesDirectoryPath);

        public string[] Get_RepositoryDirectoryPaths(string repositoriesDirectoryPath)
            => this.Enumerate_RepositoryDirectoryPaths(repositoriesDirectoryPath)
                .Now();

        public string[] Get_RepositoryDirectoryPaths(
            IEnumerable<string> repositoriesDirectoryPaths)
            => this.Enumerate_RepositoryDirectoryPaths(repositoriesDirectoryPaths)
                .Now();

        public string[] Get_RepositoryDirectoryPaths(
            params string[] repositoriesDirectoryPaths)
            => this.Get_RepositoryDirectoryPaths(
                repositoriesDirectoryPaths.AsEnumerable());

        #endregion

        #region Solutions Directory Paths

        public IEnumerable<string> Enumerate_SolutionsDirectoryPaths(
            OverloadToken<RepositoryDirectoryPath> repositoryDirectoryPathToken,
            string repositoryDirectoryPath)
            => _Implementations.Enumerate_SolutionsDirectoryPaths_SourceDirectory(repositoryDirectoryPath);

        public IEnumerable<string> Enumerate_SolutionsDirectoryPaths(
            OverloadToken<RepositoryDirectoryPath> repositoryDirectoryPathToken,
            IEnumerable<string> repositoryDirectoryPaths)
            => repositoryDirectoryPaths
                .SelectMany(this.Enumerate_SolutionsDirectoryPaths)
                ;

        public IEnumerable<string> Enumerate_SolutionsDirectoryPaths(
            OverloadToken<RepositoryDirectoryPath> repositoryDirectoryPathToken,
            params string[] repositoryDirectoryPaths)
            => this.Enumerate_SolutionsDirectoryPaths(
                repositoryDirectoryPaths.AsEnumerable());

        public IEnumerable<string> Enumerate_SolutionsDirectoryPaths(string repositoryDirectoryPath)
            => this.Enumerate_SolutionsDirectoryPaths(
                OverloadToken<RepositoryDirectoryPath>.Instance,
                repositoryDirectoryPath);

        public IEnumerable<string> Enumerate_SolutionsDirectoryPaths(IEnumerable<string> repositoryDirectoryPaths)
            => this.Enumerate_SolutionsDirectoryPaths(
                OverloadToken<RepositoryDirectoryPath>.Instance,
                repositoryDirectoryPaths);

        public IEnumerable<string> Enumerate_SolutionsDirectoryPaths(params string[] repositoryDirectoryPaths)
            => this.Enumerate_SolutionsDirectoryPaths(
                OverloadToken<RepositoryDirectoryPath>.Instance,
                repositoryDirectoryPaths);


        public string[] Get_SolutionsDirectoryPaths(
            OverloadToken<RepositoryDirectoryPath> repositoryDirectoryPathToken,
            string repositoryDirectoryPath)
            => this.Enumerate_SolutionsDirectoryPaths(repositoryDirectoryPath)
                .Now();

        public string[] Get_SolutionsDirectoryPaths(
            OverloadToken<RepositoryDirectoryPath> repositoryDirectoryPathToken,
            IEnumerable<string> repositoryDirectoryPaths)
            => this.Enumerate_SolutionsDirectoryPaths(repositoryDirectoryPaths)
                .Now();

        public string[] Get_SolutionsDirectoryPaths(
            OverloadToken<RepositoryDirectoryPath> repositoryDirectoryPathToken,
            params string[] repositoryDirectoryPaths)
            => this.Get_SolutionsDirectoryPaths(
                repositoryDirectoryPaths.AsEnumerable());

        public string[] Get_SolutionsDirectoryPaths(string repositoryDirectoryPath)
            => this.Get_SolutionsDirectoryPaths(
                OverloadToken<RepositoryDirectoryPath>.Instance,
                repositoryDirectoryPath);

        public string[] Get_SolutionsDirectoryPaths(IEnumerable<string> repositoryDirectoryPaths)
            => this.Get_SolutionsDirectoryPaths(
                OverloadToken<RepositoryDirectoryPath>.Instance,
                repositoryDirectoryPaths);

        public string[] Get_SolutionsDirectoryPaths(params string[] repositoryDirectoryPaths)
            => this.Get_SolutionsDirectoryPaths(
                OverloadToken<RepositoryDirectoryPath>.Instance,
                repositoryDirectoryPaths);


        public IEnumerable<string> Enumerate_SolutionsDirectoryPaths(
            OverloadToken<RepositoriesDirectoryPath> repositoriesDirectoryPathToken,
            string repositoriesDirectoryPath)
            => this.Enumerate_SolutionsDirectoryPaths(
                this.Enumerate_RepositoryDirectoryPaths(
                    repositoriesDirectoryPath));

        public IEnumerable<string> Enumerate_SolutionsDirectoryPaths(
            OverloadToken<RepositoriesDirectoryPath> repositoriesDirectoryPathToken,
            IEnumerable<string> repositoriesDirectoryPaths)
            => repositoriesDirectoryPaths
                .SelectMany(repositoriesDirectoryPath => this.Enumerate_SolutionsDirectoryPaths(
                    repositoriesDirectoryPathToken,
                    repositoriesDirectoryPath))
                ;

        public IEnumerable<string> Enumerate_SolutionsDirectoryPaths(
            OverloadToken<RepositoriesDirectoryPath> repositoriesDirectoryPathToken,
            params string[] repositoriesDirectoryPaths)
            => this.Enumerate_SolutionsDirectoryPaths(
                repositoriesDirectoryPathToken,
                repositoriesDirectoryPaths.AsEnumerable());

        public string[] Get_SolutionsDirectoryPaths(
            OverloadToken<RepositoriesDirectoryPath> repositoriesDirectoryPathToken,
            string repositoriesDirectoryPath)
            => this.Enumerate_SolutionsDirectoryPaths(
                repositoriesDirectoryPathToken,
                repositoriesDirectoryPath)
                .Now();

        public string[] Get_SolutionsDirectoryPaths(
            OverloadToken<RepositoriesDirectoryPath> repositoriesDirectoryPathToken,
            IEnumerable<string> repositoryDirectoryPaths)
            => this.Enumerate_SolutionsDirectoryPaths(
                repositoriesDirectoryPathToken,
                repositoryDirectoryPaths)
                .Now();

        public string[] Get_SolutionsDirectoryPaths(
            OverloadToken<RepositoriesDirectoryPath> repositoriesDirectoryPathToken,
            params string[] repositoryDirectoryPaths)
            => this.Get_SolutionsDirectoryPaths(
                repositoriesDirectoryPathToken,
                repositoryDirectoryPaths.AsEnumerable());

        #endregion

        #region Solution Directory Paths

        public IEnumerable<string> Enumerate_SolutionDirectoryPaths(string solutionsDirectoryPath)
            => this.Enumerate_SolutionDirectoryPaths(
                OverloadToken<SolutionsDirectoryPath>.Instance,
                solutionsDirectoryPath);

        public IEnumerable<string> Enumerate_SolutionDirectoryPaths(IEnumerable<string> solutionsDirectoryPaths)
            => this.Enumerate_SolutionDirectoryPaths(
                solutionsDirectoryPaths,
                OverloadToken<SolutionsDirectoryPath>.Instance);

        public IEnumerable<string> Enumerate_SolutionDirectoryPaths(params string[] solutionsDirectoryPaths)
            => this.Enumerate_SolutionDirectoryPaths(
                OverloadToken<SolutionsDirectoryPath>.Instance,
                solutionsDirectoryPaths);

        public IEnumerable<string> Enumerate_SolutionDirectoryPaths(
            OverloadToken<SolutionsDirectoryPath> solutionsDirectoryPathToken,
            string solutionsDirectoryPath)
            => _Implementations.Enumerate_SolutionDirectoryPaths(solutionsDirectoryPath);

        public IEnumerable<string> Enumerate_SolutionDirectoryPaths(
            IEnumerable<string> solutionsDirectoryPaths,
            OverloadToken<SolutionsDirectoryPath> solutionsDirectoryPathToken)
            => solutionsDirectoryPaths
                .SelectMany(solutionsDirectoryPath => this.Enumerate_SolutionDirectoryPaths(
                    solutionsDirectoryPathToken,
                    solutionsDirectoryPath));

        public IEnumerable<string> Enumerate_SolutionDirectoryPaths(
            OverloadToken<SolutionsDirectoryPath> solutionsDirectoryPathToken,
            params string[] solutionsDirectoryPaths)
            => this.Enumerate_SolutionDirectoryPaths(
                solutionsDirectoryPaths.AsEnumerable(),
                solutionsDirectoryPathToken);

        public IEnumerable<string> Enumerate_SolutionDirectoryPaths(
            OverloadToken<RepositoriesDirectoryPath> repositoriesDirectoryPathToken,
            IEnumerable<string> repositoriesDirectoryPaths)
            => this.Enumerate_SolutionDirectoryPaths(
                this.Enumerate_SolutionsDirectoryPaths(
                    repositoriesDirectoryPathToken,
                    repositoriesDirectoryPaths));

        public string[] Get_SolutionDirectoryPaths(
            OverloadToken<RepositoriesDirectoryPath> repositoriesDirectoryPathToken,
            IEnumerable<string> repositoriesDirectoryPaths)
            => this.Enumerate_SolutionDirectoryPaths(
                repositoriesDirectoryPathToken,
                repositoriesDirectoryPaths)
                .Now();

        #endregion

        #region Solution File Paths

        public IEnumerable<string> Enumerate_SolutionFilePaths(
            OverloadToken<SolutionDirectoryPath> solutionDirectoryPathToken,
            string solutionDirectoryPath)
            => _Implementations.Enumerate_SolutionFilePaths(solutionDirectoryPath);

        public IEnumerable<string> Enumerate_SolutionFilePaths(
            OverloadToken<SolutionDirectoryPath> solutionDirectoryPathToken,
            IEnumerable<string> solutionDirectoryPaths)
            => solutionDirectoryPaths
                .SelectMany(solutionDirectoryPath => this.Enumerate_SolutionFilePaths(
                    solutionDirectoryPathToken,
                    solutionDirectoryPath));

        public IEnumerable<string> Enumerate_SolutionFilePaths(
            OverloadToken<SolutionDirectoryPath> solutionDirectoryPathToken,
            params string[] solutionDirectoryPaths)
            => this.Enumerate_SolutionFilePaths(
                solutionDirectoryPathToken,
                solutionDirectoryPaths.AsEnumerable());

        public IEnumerable<string> Enumerate_SolutionFilePaths(string solutionDirectoryPath)
            => this.Enumerate_SolutionFilePaths(
                OverloadToken<SolutionDirectoryPath>.Instance,
                solutionDirectoryPath);

        public IEnumerable<string> Enumerate_SolutionFilePaths(IEnumerable<string> solutionDirectoryPaths)
            => this.Enumerate_SolutionFilePaths(
                OverloadToken<SolutionDirectoryPath>.Instance,
                solutionDirectoryPaths);

        public IEnumerable<string> Enumerate_SolutionFilePaths(params string[] solutionDirectoryPaths)
            => this.Enumerate_SolutionFilePaths(
                OverloadToken<SolutionDirectoryPath>.Instance,
                solutionDirectoryPaths);

        public IEnumerable<string> Enumerate_SolutionFilePaths(
            OverloadToken<RepositoriesDirectoryPath> repositoriesDirectoryPathToken,
            IEnumerable<string> repositoriesDirectoryPaths)
            => this.Enumerate_SolutionFilePaths(
                this.Enumerate_SolutionDirectoryPaths(
                    repositoriesDirectoryPathToken,
                    repositoriesDirectoryPaths));

        public string[] Get_SolutionFilePaths(
            OverloadToken<RepositoriesDirectoryPath> repositoriesDirectoryPathToken,
            IEnumerable<string> repositoriesDirectoryPaths)
            => this.Enumerate_SolutionFilePaths(
                repositoriesDirectoryPathToken,
                repositoriesDirectoryPaths)
                .Now();

        #endregion

        #region Project Directory Paths

        /// Skip project directory paths, since the best way to determine if a directory is a project directory is whether the directory contains a project file.
        /// So, since you need to find project files to find project directories, just skip straight to project files.

        //public IEnumerable<string> Enumerate_ProjectDirectoryPaths(
        //    OverloadToken<SolutionDirectoryPath> solutionDirectoryPathToken,
        //    string solutionDirectoryPath)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        #region Project Files

        /// <inheritdoc cref="Enumerate_ProjectFilePaths(string)"/>
        public IEnumerable<string> Enumerate_ProjectFilePaths(
            OverloadToken<SolutionDirectoryPath> solutionDirectoryPathToken,
            string solutionDirectoryPath)
            => _Implementations.Enumerate_ProjectFilePaths_ViaSolutionChildDirectoriesSearch(
                solutionDirectoryPath);

        /// <inheritdoc cref="Enumerate_ProjectFilePaths(string)"/>
        public IEnumerable<string> Enumerate_ProjectFilePaths(
            OverloadToken<SolutionDirectoryPath> solutionDirectoryPathToken,
            IEnumerable<string> solutionDirectoryPaths)
            => solutionDirectoryPaths
                .SelectMany(solutionDirectoryPath => this.Enumerate_ProjectFilePaths(
                    solutionDirectoryPathToken,
                    solutionDirectoryPath));

        /// <inheritdoc cref="Enumerate_ProjectFilePaths(string)"/>
        public IEnumerable<string> Enumerate_ProjectFilePaths(
            OverloadToken<SolutionDirectoryPath> solutionDirectoryPathToken,
            params string[] solutionDirectoryPaths)
            => this.Enumerate_ProjectFilePaths(
                solutionDirectoryPathToken,
                solutionDirectoryPaths.AsEnumerable());

        /// <summary>
        /// Enumerates that paths of project files within a solution directory.
        /// </summary>
        /// <remarks>
        /// <mechanism>Uses the canonical project file location convention (project files are located within child directories of the solution directory).</mechanism>
        /// </remarks>
        public IEnumerable<string> Enumerate_ProjectFilePaths(string solutionDirectoryPath)
            => this.Enumerate_ProjectFilePaths(
                OverloadToken<SolutionDirectoryPath>.Instance,
                solutionDirectoryPath);

        /// <inheritdoc cref="Enumerate_ProjectFilePaths(string)"/>
        public IEnumerable<string> Enumerate_ProjectFilePaths(IEnumerable<string> solutionDirectoryPaths)
            => this.Enumerate_ProjectFilePaths(
                OverloadToken<SolutionDirectoryPath>.Instance,
                solutionDirectoryPaths);

        /// <inheritdoc cref="Enumerate_ProjectFilePaths(string)"/>
        public IEnumerable<string> Enumerate_ProjectFilePaths(params string[] solutionDirectoryPaths)
            => this.Enumerate_ProjectFilePaths(
                OverloadToken<SolutionDirectoryPath>.Instance,
                solutionDirectoryPaths);

        /// <summary>
        /// Enumerates the paths of project files within a set of repositories directories.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Enumerate_ProjectFilePaths(string)" path="descendant::mechanism"/>
        /// </remarks>
        public IEnumerable<string> Enumerate_ProjectFilePaths(
            OverloadToken<RepositoriesDirectoryPath> repositoriesDirectoryPathToken,
            IEnumerable<string> repositoriesDirectoryPaths)
            => this.Enumerate_ProjectFilePaths(
                this.Enumerate_SolutionDirectoryPaths(
                    OverloadToken<RepositoriesDirectoryPath>.Instance,
                    repositoriesDirectoryPaths));

        /// <summary>
        /// Gets the paths of project files within a set of repositories directories.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Enumerate_ProjectFilePaths(string)" path="descendant::mechanism"/>
        /// </remarks>
        public string[] Get_ProjectFilePaths(
            OverloadToken<RepositoriesDirectoryPath> repositoriesDirectoryPathToken,
            IEnumerable<string> repositoriesDirectoryPaths)
            => this.Enumerate_ProjectFilePaths(
                repositoriesDirectoryPathToken,
                repositoriesDirectoryPaths)
                .Now();

        /// <inheritdoc cref="Get_ProjectFilePaths(OverloadToken{RepositoriesDirectoryPath}, IEnumerable{string})"/>
        public string[] Get_ProjectFilePaths_ForRepositories(IEnumerable<string> repositoriesDirectoryPaths)
            => this.Get_ProjectFilePaths(
                OverloadToken<RepositoriesDirectoryPath>.Instance,
                repositoriesDirectoryPaths);

        #endregion
    }
}
