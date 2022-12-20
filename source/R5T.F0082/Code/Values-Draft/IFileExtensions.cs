using System;

using R5T.T0131;


namespace R5T.F0082
{
	[DraftValuesMarker]
	public partial interface IFileExtensions : IDraftValuesMarker,
		F0050.IFileExtensions
	{
		public string CSharpProject => "csproj";
	}
}