namespace CRUDWithADODotNet.Utility
{
    public static class ApplicationConnectionString
    {
        private static string constr = "ServerInformation";
        public static string DBCS { get => constr; }
    }
}
