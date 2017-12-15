using Log4Net.EntityLogging;
using System.Collections.Generic;
using System.Data.Common;

namespace LogTesting
{
    public class TestLogModelAppender : EntityAppender<TestLogModel>
    {
        protected override void Save(DbTransaction transaction, List<TestLogModel> items)
        {
            base.Save(transaction, items);
        }
    }
}
