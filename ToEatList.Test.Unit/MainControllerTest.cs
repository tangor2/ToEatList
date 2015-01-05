using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Tangor.ToEatList
{
    [TestClass]
    public class MainControllerTest
    {
        [TestMethod]
        public void MainController_Ctor_Test()
        {
            MainController controller = new MainController();

            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void MainController_Ctor_FormIsNotNull_Test()
        {
            MainController controller = new MainController();

            Assert.IsNotNull(controller.Form);
        }

        [TestMethod]
        public void MainController_Ctor_IsUserLoggedIn()
        {
            MainController controller = new MainController();
            
            Assert.IsFalse(controller.IsUserLoggedIn);
        }

        [TestMethod]
        public void Login_Test()
        {
            MainController controller = new MainController();

            controller.Login("testUser", "testPass");

            Assert.IsTrue(controller.IsUserLoggedIn);
        }

        [TestMethod]
        public void Login_FalsePass_Test()
        {
            MainController controller = new MainController();

            controller.Login("testUser", "falsePass");

            Assert.IsFalse(controller.IsUserLoggedIn);
        }

        [TestMethod]
        public void Login_OtherUser_Test()
        {
            MainController controller = new MainController();

            controller.Login("testUser2", "otherPass");

            Assert.IsTrue(controller.IsUserLoggedIn);
        }

        [TestMethod]
        public void Login_OtherUser_FalsePass_Test()
        {
            MainController controller = new MainController();

            controller.Login("testUser2", "otherFalsePass");

            Assert.IsFalse(controller.IsUserLoggedIn);
        }

        [TestMethod]
        public void Login_LoginByForm_Test()
        {
            IMainForm form = MockRepository.GenerateStub<IMainForm>();

            MainController controller = new MainController(form);

            form.Raise(x => x.UserLogin += null, "testUser", "testPass");

            Assert.IsTrue(controller.IsUserLoggedIn);
        }

        [TestMethod]
        public void Login_LoginByForm_FailTest()
        {
            IMainForm form = MockRepository.GenerateStub<IMainForm>();

            MainController controller = new MainController(form);

            form.Raise(x => x.UserLogin += null, "testUser", "falsePass");

            Assert.IsFalse(controller.IsUserLoggedIn);
        }

        [TestMethod]
        public void Dispose_FormOnClosedEventRemoved_Test()
        {
            IMainForm form = MockRepository.GenerateStub<IMainForm>();

            MainController controller = new MainController(form);

            form.Raise(x => x.MainFormClosed += null, form, EventArgs.Empty);

            form.Expect(x => x.MainFormClosed -= null);
        }

        [TestMethod]
        public void Dispose_UserLoginEventRemoved_Test()
        {
            IMainForm form = MockRepository.GenerateStub<IMainForm>();

            MainController controller = new MainController(form);

            form.Raise(x => x.MainFormClosed += null, form, EventArgs.Empty);

            form.Expect(x => x.UserLogin -= null);
        }

    }
}
