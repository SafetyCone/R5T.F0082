using System;
using System.Collections.Generic;

using Microsoft.Extensions.Logging;

using R5T.T0131;

using SystemFileSystemOperator = R5T.F0000.FileSystemOperator;


namespace R5T.F0082
{
	[ValuesMarker]
	public partial interface IFileSystemOperator : IValuesMarker
	{
		public IEnumerable<string> GetAllRepositoryDirectoryPaths(
			IEnumerable<string> repositoriesDirectoryPaths,
			ILogger logger)
		{
			foreach (var repositoriesDirectoryPath in repositoriesDirectoryPaths)
			{
				logger.LogInformation($"Processing repositories directory:\n\t{repositoriesDirectoryPath}");

				var repositoryDirectoryPaths = SystemFileSystemOperator.Instance.EnumerateAllChildDirectoryPaths(
					repositoriesDirectoryPath)
					;

				foreach (var repositoryDirectoryPath in repositoryDirectoryPaths)
				{
					yield return repositoryDirectoryPath;
				}
			}
        }

        public IEnumerable<string> GetAllSolutionDirectoryPaths(
            IEnumerable<string> repositoryDirectoryPaths,
            ILogger logger)
        {
            foreach (var repositoryDirectoryPath in repositoryDirectoryPaths)
            {
                logger.LogInformation($"Processing repository directory:\n\t{repositoryDirectoryPath}");

                var solutionDirectoryPath = F0002.PathOperator.Instance.GetDirectoryPath(
                    repositoryDirectoryPath,
                    DirectoryNames.Instance.Source);

                // Only if the solution directory exists should it be returned.
                if(F0000.FileSystemOperator.Instance.DirectoryExists(solutionDirectoryPath))
                {
				    yield return solutionDirectoryPath;
                }
            }
        }

        public IEnumerable<string> GetAllSolutionDirectoryPaths_FromRepositoriesDirectoryPaths(
            IEnumerable<string> repositoriesDirectoryPaths,
            ILogger logger)
		{
			var repositoryDirectoryPaths = this.GetAllRepositoryDirectoryPaths(
				repositoriesDirectoryPaths,
				logger);

			var solutionDirectoryPaths = this.GetAllSolutionDirectoryPaths(
				repositoryDirectoryPaths,
				logger);

			return solutionDirectoryPaths;
		}

        public IEnumerable<string> GetAllProjectDirectoryPaths(
            IEnumerable<string> solutionDirectoryPaths,
            ILogger logger)
        {
            foreach (var solutionDirectoryPath in solutionDirectoryPaths)
            {
                logger.LogInformation($"Processing solution directory:\n\t{solutionDirectoryPath}");

                var projectDirectoryPaths = SystemFileSystemOperator.Instance.EnumerateAllChildDirectoryPaths(
                    solutionDirectoryPath)
                    ;

                foreach (var projectDirectoryPath in projectDirectoryPaths)
                {
                    // Do not include the .vs directory.
                    var isVsDirectoryPath = F0002.PathOperator.Instance.DirectoryNameOfDirectoryPathIs(
                        projectDirectoryPath,
                        DirectoryNames.Instance._vs);

                    if(!isVsDirectoryPath)
                    {
                        yield return projectDirectoryPath;
                    }
                }
            }
        }

        public IEnumerable<string> GetAllProjectDirectoryPaths_FromRepositoriesDirectoryPaths(
            IEnumerable<string> repositoriesDirectoryPaths,
            ILogger logger)
        {
            var solutionDirectoryPaths = this.GetAllSolutionDirectoryPaths_FromRepositoriesDirectoryPaths(
                repositoriesDirectoryPaths,
                logger);

            var projectDirectoryPaths = this.GetAllProjectDirectoryPaths(
                solutionDirectoryPaths,
                logger);

            return projectDirectoryPaths;
        }

        public IEnumerable<string> GetAllProjectFilePaths(
            IEnumerable<string> projectDirectoryPaths,
            ILogger logger)
        {
            foreach (var projectDirectoryPath in projectDirectoryPaths)
            {
                logger.LogInformation($"Processing project directory:\n\t{projectDirectoryPath}");

                var projectFilePaths = SystemFileSystemOperator.Instance.EnumerateChildFilePaths(
                    projectDirectoryPath,
                    F0000.SearchPatternGenerator.Instance.AllFilesWithExtension(
                        FileExtensions.Instance.CSharpProject))
                    ;

                foreach (var projectFilePath in projectFilePaths)
                {
                    yield return projectFilePath;
                }
            }
        }

        public IEnumerable<string> GetAllProjectFilePaths_FromRepositoriesDirectoryPaths(
            IEnumerable<string> repositoriesDirectoryPaths,
            ILogger logger)
        {
            var projectDirectoryPaths = this.GetAllProjectDirectoryPaths_FromRepositoriesDirectoryPaths(
                repositoriesDirectoryPaths,
                logger);

            var projectFilePaths = this.GetAllProjectFilePaths(
                projectDirectoryPaths,
                logger);

            return projectFilePaths;
        }
    }
}