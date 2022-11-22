using System;


namespace R5T.F0082
{
	public class DirectoryNames : IDirectoryNames
	{
		#region Infrastructure

	    public static IDirectoryNames Instance { get; } = new DirectoryNames();

	    private DirectoryNames()
	    {
        }

	    #endregion
	}
}