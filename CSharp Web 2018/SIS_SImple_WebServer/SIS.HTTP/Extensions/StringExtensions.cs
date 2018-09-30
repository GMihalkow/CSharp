namespace SIS.HTTP.Extensions
{
    public class StringExtensions
    {
        public static string Capitalize(string text)
        {
            string updatedText = string.Empty;

            for (int index = 0; index < text.Length; index++)
            {
                if (index == 0)
                {
                    updatedText += text[index].ToString().ToUpper();

                }
                else
                {
                    updatedText += text[index].ToString().ToLower();
                }


            }
            return updatedText;
        }
    }
}
