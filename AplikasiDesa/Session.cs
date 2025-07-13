namespace AplikasiDesa
{
    public static class Session1
    {
        public static string LoggedInUser { get; set; }
        public static string LoggedInUserName { get; set; }

        // Added security properties
        public static int UserId { get; set; }
        public static string SessionToken { get; set; }
        public static DateTime SessionExpiry { get; set; }

        public static bool IsSessionValid()
        {
            return !string.IsNullOrEmpty(SessionToken) &&
                   DateTime.Now < SessionExpiry;
        }

        public static void ClearSession()
        {
            LoggedInUser = null;
            LoggedInUserName = null;
            UserId = 0;
            SessionToken = null;
            SessionExpiry = DateTime.MinValue;
        }
    }
}
