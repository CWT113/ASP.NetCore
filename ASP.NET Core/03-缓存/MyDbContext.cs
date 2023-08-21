namespace _03_缓存
{
    public class MyDbContext
    {
        public static Task<Books?> GetBookAsync(long Id)
        {
            var result = GetBook(Id);
            return Task.FromResult(result);
        }

        public static Books? GetBook(long Id)
        {
            switch (Id)
            {
                case 1:
                    return new Books(1, "活着");
                case 2:
                    return new Books(2, "细雨中呼喊");
                case 3:
                    return new Books(1, "许三观卖血记");
                default:
                    return null;
            }
        }
    }
}
