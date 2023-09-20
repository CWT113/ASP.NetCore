using FluentValidation;
using Identity;
using Microsoft.AspNetCore.Identity;

namespace FluentValidation的基本使用;

public class AddNewUserRequestValidate : AbstractValidator<AddNewUserRequest>
{
    public AddNewUserRequestValidate(UserManager<MyUser> userManager)
    {
        //用户名
        RuleFor(d => d.Name)
            .NotNull()
            .Length(3, 6)
            .MustAsync(async (d, _) => await userManager.FindByNameAsync(d) == null)//查询数据库，看用户名是否已存在
            .WithMessage("用户名已存在！");
            //.WithMessage("用户名需在 3~6 位之间！");

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
