using System;
namespace ResolutionTracker.Utilities
{
    public static class StringExtensions
    {
        public static string RemovePercentageSign(this string text)
        {
            return text.Contains("%") ? text.Replace("%", string.Empty) : text;
        }
    }
}
