using System;


namespace R5T.F0082.Construction
{
    public static class Instances
    {
        public static F000.ICodeFileSystemOperator CodeFileSystemOperator => F000.CodeFileSystemOperator.Instance;
        public static L0066.IEnumerableOperator EnumerableOperator => L0066.EnumerableOperator.Instance;
        public static L0066.IFileOperator FileOperator => L0066.FileOperator.Instance;
        public static Z0063.IFilePaths FilePaths => Z0063.FilePaths.Instance;
        public static F0033.INotepadPlusPlusOperator NotepadPlusPlusOperator => F0033.NotepadPlusPlusOperator.Instance;
        public static Z0022.IRepositoriesDirectoryPathsSets RepositoriesDirectoryPathsSets => Z0022.RepositoriesDirectoryPathsSets.Instance;
        public static L0066.IStrings Strings => L0066.Strings.Instance;
        public static F0103.ITimingOperator TimingOperator => F0103.TimingOperator.Instance;
    }
}