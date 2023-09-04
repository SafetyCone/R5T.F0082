using System;
using System.Collections.Generic;

using R5T.T0131;
using R5T.T0159;

using SystemFileSystemOperator = R5T.F0000.FileSystemOperator;


namespace R5T.F0082
{
	[ValuesMarker]
	public partial interface IFileSystemOperator : IValuesMarker
	{
		public IEnumerable<string> GetAllRepositoryDirectoryPaths(
			IEnumerable<string> repositoriesDirectoryPaths,
            ITextOutput textOutput)
		{
			foreach (var repositoriesDirectoryPath in repositoriesDirectoryPaths)
			{
				textOutput.WriteInformation($"Processing repositories directory:\n\t{repositoriesDirectoryPath}");

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
            ITextOutput textOutput)
        {
            foreach (var repositoryDirectoryPath in repositoryDirectoryPaths)
            {
                textOutput.WriteInformation($"Processing repository directory:\n\t{repositoryDirectoryPath}");

                var solutionDirectoryPath = F0002.PathOperator.Instance.GetDirectoryPath(
                    repositoryDirectoryPath,
                    DirectoryNames.Instance.Source);

                // Only if the solution directory exists should it be returned.
                if(SystemFileSystemOperator.Instance.DirectoryExists(solutionDirectoryPath))
                {
				    yield return solutionDirectoryPath;
                }
            }
        }

        public IEnumerable<string> GetAllSolutionDirectoryPaths_FromRepositoriesDirectoryPaths(
            IEnumerable<string> repositoriesDirectoryPaths,
            ITextOutput textOutput)
		{
			var repositoryDirectoryPaths = this.GetAllRepositoryDirectoryPaths(
				repositoriesDirectoryPaths,
				textOutput);

			var solutionDirectoryPaths = this.GetAllSolutionDirectoryPaths(
				repositoryDirectoryPaths,
				textOutput);

			return solutionDirectoryPaths;
		}

        public IEnumerable<string> GetAllSolutionFilePaths(
            IEnumerable<string> solutionDirectoryPaths,
            ITextOutput textOutput)
        {
            foreach (var solutionDirectoryPath in solutionDirectoryPaths)
            {
                textOutput.WriteInformation($"Processing solution directory:\n\t{solutionDirectoryPath}");

                var solutionFilePaths = SystemFileSystemOperator.Instance.FindChildFilesInDirectoryByFileExtension(
                    solutionDirectoryPath,
                    FileExtensions.Instance.SolutionFile);

                foreach (var solutionFilePath in solutionFilePaths)
                {
                    yield return solutionFilePath;
                }
            }
        }

        public IEnumerable<string> GetAllSolutionFilePaths_FromRepositoriesDirectoryPaths(
            IEnumerable<string> repositoriesDirectoryPaths,
            ITextOutput textOutput)
        {
            var solutionDirectoryPaths = this.GetAllSolutionDirectoryPaths_FromRepositoriesDirectoryPaths(
                 repositoriesDirectoryPaths,
                 textOutput);

            var solutionFilePaths = this.GetAllSolutionFilePaths(
                solutionDirectoryPaths,
                textOutput);

            return solutionFilePaths;
        }

        public IEnumerable<string> GetAllProjectDirectoryPaths(
            IEnumerable<string> solutionDirectoryPaths,
            ITextOutput textOutput)
        {
            foreach (var solutionDirectoryPath in solutionDirectoryPaths)
            {
                textOutput.WriteInformation($"Processing solution directory:\n\t{solutionDirectoryPath}");

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
            ITextOutput textOutput)
        {
            var solutionDirectoryPaths = this.GetAllSolutionDirectoryPaths_FromRepositoriesDirectoryPaths(
                repositoriesDirectoryPaths,
                textOutput);

            var projectDirectoryPaths = this.GetAllProjectDirectoryPaths(
                solutionDirectoryPaths,
                textOutput);

            return projectDirectoryPaths;
        }

        public IEnumerable<string> GetAllProjectFilePaths(
            IEnumerable<string> projectDirectoryPaths,
            ITextOutput textOutput)
        {
            foreach (var projectDirectoryPath in projectDirectoryPaths)
            {
                textOutput.WriteInformation($"Processing project directory:\n\t{projectDirectoryPath}");

                var projectFilePaths = SystemFileSystemOperator.Instance.EnumerateChildFilePaths(
                    projectDirectoryPath,
                    F0000.SearchPatternGenerator.Instance.Files_WithExtension(
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
            ITextOutput textOutput)
        {
            var projectDirectoryPaths = this.GetAllProjectDirectoryPaths_FromRepositoriesDirectoryPaths(
                repositoriesDirectoryPaths,
                textOutput);

            var projectFilePaths = this.GetAllProjectFilePaths(
                projectDirectoryPaths,
                textOutput);

            return projectFilePaths;
        }
    }
}