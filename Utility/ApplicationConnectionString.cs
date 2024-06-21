namespace CRUDWithADODotNet.Utility
{
    public static class ApplicationConnectionString
    {
        private static string constr = "Server=103.16.222.73; User ID=WoomUser; Password=WoomUser$pwd1234; Initial Catalog=TEST_DB";
        public static string DBCS { get => constr; }
    }
}
