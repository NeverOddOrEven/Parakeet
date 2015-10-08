using FluentNHibernate.Testing;
using Microsoft.VisualStudio.TestTools.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.QualityTools.UnitTestFramework;
using System;
using Parakeet.Data.Entities;

namespace Parakeet.Data.Tests.PersistenceMappings
{
    [TestClass]
    public class PersonMap
    {
        [TestMethod]
        public void CanCorrectlyMapPerson() {
            NHibernateSessionHandler.InitForUnitTest();
            new PersistenceSpecification<Person>(NHibernateSessionHandler.SessionFactory.OpenSession())
                .CheckProperty(x => x.FirstName, "Test First Name")
                .CheckProperty(x => x.LastName, "Test Last Name")
                .CheckProperty(x => x.HireDate, new DateTime(2000, 08, 01).Date)
                .CheckProperty(x => x.SeparationDate, new DateTime(2000, 08, 31).Date)
                .VerifyTheMappings();
        }
    }
}
