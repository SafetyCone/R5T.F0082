using System;

using R5T.T0131;


namespace R5T.F0082
{
	[ValuesMarker]
	public partial interface IDirectoryNames : IValuesMarker
	{
#pragma warning disable IDE1006 // Naming Styles
        private Z0071.Z002.IDirectoryNames _Common => Z0071.Z002.DirectoryNames.Instance;
        private Z0072.Z002.IDirectoryNames _Unopinionated => Z0072.Z002.DirectoryNames.Instance;
#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="Z0071.Z002.IDirectoryNames.Repository_Source_DirectoryName"/>
        public string Repository_Source_DirectoryName => _Common.Repository_Source_DirectoryName;

        /// <inheritdoc cref="Z0072.Z002.IDirectoryNames.VisualStudio_Solution_HiddenDirectoryName"/>
		public string VisualStudio_Solution_HiddenDirectoryName => _Unopinionated.VisualStudio_Solution_HiddenDirectoryName;
    }
}