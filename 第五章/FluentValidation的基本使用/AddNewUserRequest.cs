namespace FluentValidation的基本使用
{
    public class AddNewUserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
