using System;
using System.Linq;

using R5T.F0033;
using R5T.F0035;
using R5T.T0132;
using R5T.Z0015;
using R5T.Z0022;


namespace R5T.F0082.Construction
{
	[FunctionalityMarker]
	public partial interface ITry : IFunctionalityMarker
	{
        public void GetAllProjectFilePaths()
        {
            LoggingOperator.Instance.InConsoleLoggerContext_Synchronous(
                nameof(GetAllProjectDirectoryPaths),
                logger =>
                {
                    var repositoriesDirectoryPaths = RepositoriesDirectoryPaths.Instance.AllOfMine;

                    var projectFilePaths = FileSystemOperator.Instance.GetAllProjectFilePaths_FromRepositoriesDirectoryPaths(
                        repositoriesDirectoryPaths,
                        logger)
                        .OrderAlphabetically()
                        .Now();

                    NotepadPlusPlusOperator.Instance.WriteLinesAndOpen(
                        FilePaths.Instance.OutputTextFilePath,
                        projectFilePaths);
                });
        }

        public void GetAllProjectDirectoryPaths()
        {
            LoggingOperator.Instance.InConsoleLoggerContext_Synchronous(
                nameof(GetAllProjectDirectoryPaths),
                logger =>
                {
                    var repositoriesDirectoryPaths = RepositoriesDirectoryPaths.Instance.AllOfMine;

                    var projectDirectoryPaths = FileSystemOperator.Instance.GetAllProjectDirectoryPaths_FromRepositoriesDirectoryPaths(
                        repositoriesDirectoryPaths,
                        logger)
                        .OrderAlphabetically()
                        .Now();

                    NotepadPlusPlusOperator.Instance.WriteLinesAndOpen(
                        FilePaths.Instance.OutputTextFilePath,
                        projectDirectoryPaths);
                });
        }

        public void GetAllSolutionDirectoryPaths()
        {
            LoggingOperator.Instance.InConsoleLoggerContext_Synchronous(
                nameof(GetAllSolutionDirectoryPaths),
                logger =>
                {
                    var repositoriesDirectoryPaths = RepositoriesDirectoryPaths.Instance.AllOfMine;

                    var solutionDirectoryPaths = FileSystemOperator.Instance.GetAllSolutionDirectoryPaths_FromRepositoriesDirectoryPaths(
                        repositoriesDirectoryPaths,
                        logger)
                        .OrderAlphabetically()
                        .Now();

                    NotepadPlusPlusOperator.Instance.WriteLinesAndOpen(
                        FilePaths.Instance.OutputTextFilePath,
                        solutionDirectoryPaths);
                });
        }

        public void GetAllRepositoryDirectoryPaths()
		{
			LoggingOperator.Instance.InConsoleLoggerContext_Synchronous(
				nameof(GetAllRepositoryDirectoryPaths),
				logger =>
				{
					var repositoriesDirectoryPaths = RepositoriesDirectoryPaths.Instance.AllOfMine;

					var enumerateRepositoryDirectoryPaths = FileSystemOperator.Instance.GetAllRepositoryDirectoryPaths(
						repositoriesDirectoryPaths,
						logger);

					var repositoryDirectoryPaths = enumerateRepositoryDirectoryPaths
						.OrderAlphabetically()
						.Now();

					NotepadPlusPlusOperator.Instance.WriteLinesAndOpen(
						FilePaths.Instance.OutputTextFilePath,
                        repositoryDirectoryPaths);
				});
		}
    }
}