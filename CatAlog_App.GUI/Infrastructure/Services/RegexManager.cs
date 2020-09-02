using System.Text.RegularExpressions;

namespace CatAlog_App.GUI.Infrastructure.Services
{
    /// <summary>
    /// Contains regular expression templates and methods
    /// </summary>
    public static class RegexManager
    {
        public const string HttpPattern =
            @"(http|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";

        /// <summary>
        /// Checking whether the path is an html link
        /// </summary>
        /// <param name="path">Path to compare</param>
        /// <returns>Result</returns>
        public static bool IsUrl(string path) => 
            Regex.IsMatch(path, HttpPattern, RegexOptions.Compiled);
    }
}
