using System;
using Innovt.Core.Exceptions;
using NUnit.Framework;
using OnDemandWatch.Domain.Accounts;
using OnDemandWatch.Domain.CloudProviders;

namespace OnDemandWatch.Domain.Tests
{
    [TestFixture]
    public class AccountTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void CreateThrowExceptionWhenNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => AccountFactory.Create(null!));
        }

        [Test]
        public void CreateThrowExceptionWhenNameIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => AccountFactory.Create(string.Empty));
        }

        [Test]
        public void CreateShouldInitializeId()
        {
            var actualName = "Innovt";
            var account = AccountFactory.Create(actualName);

            Assert.IsNotNull(account);
            Assert.That(Guid.Empty, Is.Not.EqualTo(account.Id));
            Assert.That(actualName, Is.EqualTo(account.Name));
        }


        [Test]
        public void AddUserThrowExceptionWhenEmailOrNameAreNullOrEmpty()
        {
            var account = AccountFactory.Create("Innovt");


            Assert.Throws<ArgumentNullException>(() => account.AddUser(null!, "michel"), "email");
            Assert.Throws<ArgumentNullException>(() => account.AddUser(string.Empty, "michel"), "email");

            Assert.Throws<ArgumentNullException>(() => account.AddUser("email", ""), "name");
            Assert.Throws<ArgumentNullException>(() => account.AddUser("email", string.Empty), "name");
        }


        [Test]
        public void AddUserThrowExceptionWhenUserAlreadyExist()
        {
            var account = AccountFactory.Create("Innovt");


            try
            {
                account.AddUser("michel", "michel");
                Assert.Fail();
            }
            catch (BusinessException e)
            {
                Assert.IsNotNull(e);
                Assert.IsTrue(e.Message.Contains("Invalid e-mail address"));
            }
        }

        [Test]
        public void AddUser()
        {
            var account = AccountFactory.Create("Innovt");

            account.AddUser("michel@innovt.com.br", "michel");

            Assert.IsNotNull(account.Users);
            Assert.That(1, Is.EqualTo(account.Users!.Count));
        }


        [Test]
        public void AddCloudAccountThrowExceptionWhenParametersAreNull()
        {
            var account = AccountFactory.Create("Innovt");

            Assert.Throws<ArgumentNullException>(() => account.AddCloudAccount(string.Empty, string.Empty, null!));
            Assert.Throws<ArgumentNullException>(() => account.AddCloudAccount("12346", string.Empty, null!));
            Assert.Throws<ArgumentNullException>(() => account.AddCloudAccount("12346", "production", null!));
            Assert.Throws<ArgumentNullException>(() => account.AddCloudAccount("12346", "", new Aws()));

        }

        [Test]
        public void AddCloudAccountThrowExceptionWhenAccountAlreadyExist()
        {
            var account = AccountFactory.Create("Innovt");

            var accountId = "4545465465";

            account.AddCloudAccount(accountId, "Production", new Aws());

            Assert.Throws<BusinessException>(() => account.AddCloudAccount(accountId, "Production", new Aws()), "Cloud account already exists.");
        }

        [Test]
        public void AddCloudAccount()
        {
            var account = AccountFactory.Create("Innovt");

            account.AddCloudAccount("4545465465", "Production", new Aws());

            Assert.IsNotNull(account.Accounts);
            Assert.That(1, Is.EqualTo(account?.Accounts?.Count));
        }
    }
}