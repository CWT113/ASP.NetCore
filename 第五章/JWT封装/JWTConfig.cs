namespace JWT封装
{
    public class JWTConfig
    {
        /// <summary>
        /// Key
        /// </summary>
        public string Seckey { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public int ExpireSeconds { get; set; }
    }
}
