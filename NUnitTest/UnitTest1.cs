using NUnit.Framework;
using MemberLogin.Controllers.api;
using MemberLogin.Models.Service;
namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            //測試Query
            var rtn = new Sys_userService().Query();
            Assert.NotNull(rtn);
        }

        [Test]
        public void Test2()
        {
            //測試新增
            var rtn = new Sys_userService().Insert(new MemberLogin.Models.EF.sys_user { id = 999, Name = "testAcc", Password = "adam", Level = 1 });
            Assert.True(rtn == 1);
        }

        [Test]
        public void Test3()
        {
            //測試更新
            var rtn = new Sys_userService().Update(new MemberLogin.Models.EF.sys_user { id = 999, Name = "testAcc", Password = "adambb", Level = 1 });
            Assert.True(rtn == 1);
        }

        [Test]
        public void Test4()
        {
            //測試刪除
            var rtn = new Sys_userService().Delete(999);
            Assert.True(rtn == 1);
        }
    }
}