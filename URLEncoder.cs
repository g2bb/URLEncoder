using System;
using System.Collections.Generic;
using System.Linq;

namespace URLEncoder {
    class Dictionary {
        static Dictionary<string, string> characterEncodings = new Dictionary<string, string>() {
            {" ", "%20"},
            {"<", "%3C"},
            {">", "%3E"},
            {"#", "%23"},
            {"%", "%25"},
            {"/", "%2F"},
            {"\"", "%22"},
            {";", "%3B"},
            {":", "%3A"},
            {"@", "%40"},
            {"&", "%26"},
            {"=", "%3D"},
            {"+", "%2B"},
            {"$", "%24"},
            {"{", "%7B"},
            {"}", "%7D"},
            {"|", "%7C"},
            {"\\", "%5C"},
            {"^", "%5E"},
            {"[", "%5B"},
            {"]", "%5D"},
            {"`", "%60"},
        };

        static void Main() {
            Console.WriteLine("0========0   Auto URL Encoder   0=======0");
            string project = UserRespond("project");
            string activity = UserRespond("activity");
            Console.WriteLine("\nGenerated URL: https://companyserver.com/content/{0}/files/{1}/{1}Report.pdf", Escape(project), Escape(activity));
            }

        static string UserRespond(string ID) {
            Console.WriteLine("\nPlease enter the name of your {0}:", ID);
            string response = Console.ReadLine();
            while (string.IsNullOrEmpty(response) && !CtrlChar(response)) {
                Console.WriteLine("!INPUT INVALID! You either did not enter any information, or your input contained an invalid character.\nPlease try again:");
                response = Console.ReadLine();
            }
            return response;
        }

        static bool CtrlChar(string response) {
            return response.Any(c => char.IsControl(c));
        }

        static string Escape(string url) {
            return string.Join("", url.Select(c => CharEncoder(c)));
        }

        static string CharEncoder(char c) {
            if (characterEncodings.TryGetValue(c.ToString(), out string encodedCharacter)) {
                return encodedCharacter;
            } else {
                return c.ToString();
            }
        }
    }
}
