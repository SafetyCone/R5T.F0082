using System;
using System.Threading.Tasks;


namespace R5T.F0082.Construction
{
    class Program
    {
        static async Task Main()
        {
            await Scripts.Instance.Get_ProjectFilePaths();
            //await Scripts.Instance.List_MissingProjects();
            //await Scripts.Instance.Display_ProjectFilePaths_ViaSolutionChildAndGrandChildDirectoriesSearch();
            //await Scripts.Instance.Display_ProjectFilePaths_ViaSolutionChildDirectoriesSearch();
            //await Scripts.Instance.Display_ProjectFilePaths_ViaRepositoryDirectorySearch();
            //await Scripts.Instance.Display_ProjectDirectorPaths_InSolutionDirectory_WithoutProjectFile();
            //await Scripts.Instance.Display_ProjectDirectoryPaths_ChildDirectoriesOfSolutionDirectory_WithProjectFile();
            //await Scripts.Instance.Display_ProjectDirectoryPaths_AllChildDirectoryPathsOfSolutionDirectory();
            //await Scripts.Instance.Display_SolutionFilePaths();
            //await Scripts.Instance.Display_SolutionDirectoryPaths();
            //await Scripts.Instance.Display_SolutionsDirectoryPaths();
            //await Scripts.Instance.Display_RepositoryDirectoryPaths();
            //await Scripts.Instance.Display_RepositoriesDirectoryPaths();

            //Try.Instance.GetAllRepositoryDirectoryPaths();
            //Try.Instance.GetAllSolutionDirectoryPaths();
            //Try.Instance.GetAllProjectDirectoryPaths();
            //Try.Instance.GetAllProjectFilePaths();
        }
    }
}