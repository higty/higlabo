using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.IO;

namespace HigLabo.Mime.Test
{
    [TestClass]
    public class MailAddressTest
    {
        [TestMethod]
        public void MailAddress_Basic1()
        {
            MailAddress m = null;

            m = MailAddress.TryCreate("bill@microsoft.com");
            Assert.AreEqual("bill@microsoft.com", m.Value);
            Assert.AreEqual("bill", m.UserName);
            Assert.AreEqual("microsoft.com", m.DomainName);

            m = MailAddress.TryCreate("<bill@microsoft.com>");
            Assert.AreEqual("bill@microsoft.com", m.Value);
            Assert.AreEqual("bill", m.UserName);
            Assert.AreEqual("microsoft.com", m.DomainName);

            m = MailAddress.TryCreate("Bill Gate <bill@microsoft.com>");
            Assert.AreEqual("Bill Gate", m.DisplayName);
            Assert.AreEqual("bill@microsoft.com", m.Value);
            Assert.AreEqual("bill", m.UserName);
            Assert.AreEqual("microsoft.com", m.DomainName);

            m = MailAddress.TryCreate("\"Bill Gate\" <bill@microsoft.com>");
            Assert.AreEqual("Bill Gate", m.DisplayName);
            Assert.AreEqual("bill@microsoft.com", m.Value);
            Assert.AreEqual("bill", m.UserName);
            Assert.AreEqual("microsoft.com", m.DomainName);

            m = MailAddress.TryCreate("鈴木一郎 <suzuki@microsoft.com>");
            Assert.AreEqual("鈴木一郎", m.DisplayName);
            Assert.AreEqual("suzuki@microsoft.com", m.Value);
            Assert.AreEqual("suzuki", m.UserName);
            Assert.AreEqual("microsoft.com", m.DomainName);
        }
        [TestMethod]
        public void MailAddressCollection_Basic1()
        {
            MailAddressCollection mc = null;
            MailAddress m = null;

            mc = new MailAddressCollection("bill@microsoft.com");
            m = mc.MailAddresses[0];
            Assert.AreEqual("bill@microsoft.com", m.Value);
            Assert.AreEqual("bill", m.UserName);
            Assert.AreEqual("microsoft.com", m.DomainName);

        }
    }
}
