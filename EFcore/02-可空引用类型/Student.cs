using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_可空引用类型
{
    #region 方式一：增加 ?
    //public class Student
    //{
    //    public string? Name { get; set; }
    //    public string? Number { get; set; }
    //}
    #endregion

    #region 方式二：使用构造函数赋值
    //public class Student
    //{
    //    public string Name { get; set; }
    //    public string Number { get; set; }
    //    public Student(string name,string number)
    //    {
    //        this.Name = name;
    //        this.Number = number;
    //    }
    //}
    #endregion

    #region 方式三：添加默认值
    //public class Student
    //{
    //    public string Name { get; set; } = "sunny";
    //    public string Number { get; set; } = "123456";
    //}
    #endregion
}
