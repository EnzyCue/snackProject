namespace Api.Snack.Helpers
{
    public static class Helper
    {
        public static string TakeDigits(string input)
        {
            
            return new String(input
                .Where(x => char.IsDigit(x))
                .ToArray());
        }
    }
}
