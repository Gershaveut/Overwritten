using System;

namespace Overwritten
{
    public static class Util
    {
        public static string ArgTextName(string text)
        {
            return text.Split('=')[0].Remove(0, 2);
        }

        public static string ArgTextValue(string text)
        {
            return text.Split('=')[1];
        }

        public static bool ArgTextValueBool(string text)
        {
            return Convert.ToBoolean(text.Split('=')[1]);
        }

        public static string ArgBoolName(string text)
        {
            return text.Remove(0, 1);
        }
    }
}
