using FluentValidation;

namespace FluentValidation的基本使用;

public class AddNewUserRequestValidate : AbstractValidator<AddNewUserRequest>
{
    public AddNewUserRequestValidate()
    {
        //用户名
        RuleFor(d => d.Name)
            .NotNull()
            .Length(3, 6)
            .WithMessage("用户名需在 3~6 位之间！");

        //邮箱
        RuleFor(d => d.Email)
            .NotNull()
            .EmailAddress()
            .WithMessage("必须是合法的邮箱！")
            .Must(d => d.EndsWith("@qq.com") || d.EndsWith("@163.com"))
            .WithMessage("邮箱必须是QQ邮箱或163邮箱！");

        //密码
        RuleFor(d => d.Password)
            .Equal(d => d.NewPassword)
            .WithMessage("两次密码必须一致！");
    }
}
