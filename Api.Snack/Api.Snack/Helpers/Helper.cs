namespace Api.Snack.Helpers
{
    public static class Helper
    {
        public static decimal ConvertToPrice(string input)
        {
            bool hasDecimal = false;

            var priceStr = new String(input
                .Where(
                x =>
                {
                    if (char.IsDigit(x))
                        return true;

                    if (x == '.' && !hasDecimal)
                    {
                        hasDecimal = true;
                        return true;
                    }

                    return false;
                })
                .ToArray());

            var price = decimal.Parse(priceStr);

            price = Math.Truncate(price * 100) / 100;

            return price;
        }
    }
}