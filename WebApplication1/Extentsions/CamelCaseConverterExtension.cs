using System.Text;

namespace DoranOfficeBackend.Extentsions
{
    public static class  CamelCaseConverterExtension
    {
        public static string CamelToWords(this  string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            StringBuilder result = new StringBuilder();
            result.Append(input[0]);

            for (int i = 1; i < input.Length; i++)
            {
                if (char.IsUpper(input[i]))
                {
                    result.Append(' ');
                }
                result.Append(input[i]);
            }

            return result.ToString();
        }
    }
}
