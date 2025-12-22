namespace TemplateMongo.Tests.Dao.BasicDaoTests;

using Common.Testing.Mongo;
using TemplateMongo.Dao;
using TemplateMongo.Models;

public abstract class BasicDaoTestsBase : MongoDaoTestsBase<BasicModel, BasicDao>
{
    protected BasicDaoTestsBase()
        : base("basics", (logger, db) => new BasicDao(logger, db))
    {
    }
}
