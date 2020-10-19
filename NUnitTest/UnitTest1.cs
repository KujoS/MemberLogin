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
            //����Query
            var rtn = new Sys_userService().Query();
            Assert.NotNull(rtn);
        }

        [Test]
        public void Test2()
        {
            //���շs�W
            var rtn = new Sys_userService().Insert(new MemberLogin.Models.EF.sys_user { id = 999, Name = "testAcc", Password = "adam", Level = 1 });
            Assert.True(rtn == 1);
        }

        [Test]
        public void Test3()
        {
            //���է�s
            var rtn = new Sys_userService().Update(new MemberLogin.Models.EF.sys_user { id = 999, Name = "testAcc", Password = "adambb", Level = 1 });
            Assert.True(rtn == 1);
        }

        [Test]
        public void Test4()
        {
            //���էR��
            var rtn = new Sys_userService().Delete(999);
            Assert.True(rtn == 1);
        }
    }
}