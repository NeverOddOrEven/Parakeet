using FluentNHibernate.Testing;
using Microsoft.VisualStudio.TestTools.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.QualityTools.UnitTestFramework;
using System;
using Parakeet.Data.Entities;

namespace Parakeet.Data.Tests.PersistenceMappings
{
    [TestClass]
    public class RoleMap
    {
        [TestMethod]
        public void CanCorrectlyRolePerson() {
            NHibernateSessionHandler.InitForUnitTest();
            new PersistenceSpecification<Role>(NHibernateSessionHandler.SessionFactory.OpenSession())
                .CheckProperty(x => x.Name, "Some test string")
                .CheckProperty(x => x.Description, "other test string")
                .VerifyTheMappings();
        }
    }
}
