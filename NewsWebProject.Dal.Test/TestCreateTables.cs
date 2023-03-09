using NewsWebProject.Model.Tables;
using NUnit.Framework;

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
