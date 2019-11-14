using System.Configuration;

namespace Api
{
    public static class Helper
    {
        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;

    }
}