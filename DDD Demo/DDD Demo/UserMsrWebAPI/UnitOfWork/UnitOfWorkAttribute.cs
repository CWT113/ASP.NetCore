namespace UserMsrWebAPI.UnitOfWork
{
    /// <summary>
    /// 工作单元
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]//此工作单元只支持方法
    public class UnitOfWorkAttribute : Attribute
    {
        public Type[] DbContextTypes { get; init; }
        public UnitOfWorkAttribute(params Type[] dbContextTypes)
        {
            this.DbContextTypes = dbContextTypes;
        }
    }
}
