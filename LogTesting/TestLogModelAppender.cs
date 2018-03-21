using Log4Net.EntityLogging;
using System.Collections.Generic;

namespace LogTesting
{
    public class TestLogModelAppender : EntityAppender<TestLogModel>
    {
        protected override void Save(List<TestLogModel> items)
        {
            base.Save(items);
        }
    }
}
