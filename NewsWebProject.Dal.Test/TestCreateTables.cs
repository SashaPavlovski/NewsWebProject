using NewsWebProject.Model.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebProject.Dal.Test
{
    [TestFixture]
    internal class TestCreateTables
    {
        [Test]
        [Category("DataBase")]
        public void IfCreatedDB()
        {
            List<TBUsers> tBUsers = CeateTables.Data.Users.ToList();

            Assert.That(tBUsers, !Is.Null);
        }
    }
}
