using System;


namespace R5T.F0082.F000
{
    public static class Instances
    {
        public static ICodeFileSystemOperator CodeFileSystemOperator => F000.CodeFileSystemOperator.Instance;
        public static Z0071.Z002.IDirectoryNames DirectoryNames => Z0071.Z002.DirectoryNames.Instance;
        public static L0066.IEnumerableOperator EnumerableOperator => L0066.EnumerableOperator.Instance;
        public static Z0072.Z000.IFileExtensions FileExtensions => Z0072.Z000.FileExtensions.Instance;
        public static L0066.IFileSystemOperator FileSystemOperator => L0066.FileSystemOperator.Instance;
        public static L0066.IPathOperator PathOperator => L0066.PathOperator.Instance;
    }
}