using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace PiratedLauncher
{
    internal class Checker
    {
        private static Query query = new Query();
        public static async Task<bool> CheckKey(string key)
        {
            query.Initialize();
            var url = $""; //saving on memory lol. I DONT PRAY FOR THESE BAGUETTES I PRAY FOR BETTER DAYS

            try
            {
                string jsonResponse = await query.FetchDataAsync(url);
                if (!string.IsNullOrEmpty(jsonResponse))
                {
                    JObject json = JObject.Parse(jsonResponse);
                    return true; // me no key. key bad.
                }
            }
            catch (AggregateException ex)
            {
                var errorMessage = "Key validation failed:\n";
                foreach (var innerEx in ex.InnerExceptions)
                {
                    errorMessage += $"- {innerEx.Message}\n";
                }
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Request error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}
