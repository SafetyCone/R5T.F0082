using System;

using R5T.T0131;


namespace R5T.F0082
{
	[DraftValuesMarker]
	public partial interface IDirectoryNames : IDraftValuesMarker
	{
		public string Source => "source";
		public string VisualStudioSolutionHidden => this._vs;
#pragma warning disable IDE1006 // Naming Styles
        public string _vs => ".vs";
#pragma warning restore IDE1006 // Naming Styles
    }
}