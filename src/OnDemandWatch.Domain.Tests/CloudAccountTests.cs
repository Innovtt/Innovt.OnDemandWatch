using System;
using Innovt.Core.Exceptions;
using NUnit.Framework;
using OnDemandWatch.Domain.Accounts;
using OnDemandWatch.Domain.CloudProviders;

namespace OnDemandWatch.Domain.Tests
{
    [TestFixture]
    public class CloudAccountTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddTagThrowExceptionWhenKeyAndValueIsNull()
        {
            var cloudAccount = CloudAccountFactory.Create("123546", "Production", new Aws());
            
            Assert.Throws<ArgumentNullException>(() => cloudAccount.AddTag(null!, null!));
            Assert.Throws<ArgumentNullException>(() => cloudAccount.AddTag(string.Empty, null!));
            Assert.Throws<ArgumentNullException>(() => cloudAccount.AddTag("env", null!));
        }


        [Test]
        public void AddTagThrowExceptionWhenKeyAlreadyExist()
        {
            var cloudAccount = CloudAccountFactory.Create("123546", "Production", new Aws());

            var key = "env";

            cloudAccount.AddTag(key, "prod");

            Assert.Throws<BusinessException>(() => cloudAccount.AddTag("env", "prod"), $"Key {key} already exist.");
        }
        
        [Test]
        public void AddTag()
        {
            var cloudAccount = CloudAccountFactory.Create("123546", "Production", new Aws());
            
            cloudAccount.AddTag("env", "prod");

            Assert.IsNotNull(cloudAccount.Tags);
            Assert.That(1, Is.EqualTo(cloudAccount?.Tags?.Count));
        }

        [Test]
        public void RemoveTagThrowExceptionWhenKeyIsNull()
        {
            var cloudAccount = CloudAccountFactory.Create("123546", "Production", new Aws());

            Assert.Throws<ArgumentNullException>(() => cloudAccount.RemoveTag(null!));
            Assert.Throws<ArgumentNullException>(() => cloudAccount.RemoveTag(string.Empty));
        }

        [Test]
        public void RemoveTagThrowExceptionWhenKeyDoesNotExist()
        {
            var cloudAccount = CloudAccountFactory.Create("123546", "Production", new Aws());

            Assert.Throws<BusinessException>(() => cloudAccount.RemoveTag("env"), $"Key env doesn't exist.");
        }

        [Test]
        public void RemoveTag()
        {
            var cloudAccount = CloudAccountFactory.Create("123546", "Production", new Aws());
            
            cloudAccount.AddTag("env", "prod");

            cloudAccount.RemoveTag("env");
            
            Assert.That(0, Is.EqualTo(cloudAccount?.Tags?.Count));
        }
    }
}