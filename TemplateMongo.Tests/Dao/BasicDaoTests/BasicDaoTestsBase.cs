using TemplateMongo.Dao;
using TemplateMongo.Models;
using Common.Testing.Mongo;

namespace TemplateMongo.Tests.Dao.BasicDaoTests;

public abstract class BasicDaoTestsBase : MongoDaoTestsBase<BasicModel, BasicDao>
{
    protected BasicDaoTestsBase()
        : base("basics", (logger, db) => new BasicDao(logger, db))
    {
    }
}
