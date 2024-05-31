using System;


namespace R5T.F0082.Construction
{
    public class Scripts : IScripts
    {
        #region Infrastructure

        public static IScripts Instance { get; } = new Scripts();


        private Scripts()
        {
        }

        #endregion
    }
}
