using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.F0082.F000.Internal
{
    [FunctionalityMarker]
    public partial interface ICodeFileSystemOperator : IFunctionalityMarker
    {
        /// <summary>
        /// If the directory path exists, evaluate the function.
        /// Else, return an empty enumerable.
        /// </summary>
        /// <remarks>
        /// In searching the file-system, we frequently want to evaulate a function only if the directory path for it exists.
        /// </remarks>
        public IEnumerable<string> If_Exists_ElseEmpty(
            string directoryPath,
            Func<string, IEnumerable<string>> function)
        {
            var directoryExists = Instances.FileSystemOperator.Exists_Directory(directoryPath);

            var output = directoryExists
                ? function(directoryPath)
                : Instances.EnumerableOperator.Empty<string>()
                ;

            return output;
        }
    }
}
