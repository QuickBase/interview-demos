using QuickBase.Demo.EntityFrameworkCore;

namespace QuickBase.Demo.TestBase.TestData
{
    public class TestDataBuilder
    {
        private readonly DemoDbContext _context;

        public TestDataBuilder(DemoDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}