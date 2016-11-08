using Exceptionless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exceptionless.Configuration;
using System.IO;
using log4net.Config;
using log4net;
using StackExchange.Redis;
//[assembly: Exceptionless("oXX5BJqhS30ni045BqthqJtiSnpB0naMactfmYmI", ServerUrl = "http://localhost:8004")]
namespace ExceptionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo fi = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config"));
            XmlConfigurator.ConfigureAndWatch(fi);
            ILog logger= LogManager.GetLogger(typeof(Program));
            ExceptionlessClient.Default.Startup("oXX5BJqhS30ni045BqthqJtiSnpB0naMactfmYmI");
            //var client = new ExceptionlessClient(c => {
            //    c.ApiKey = "oXX5BJqhS30ni045BqthqJtiSnpB0naMactfmYmI";
            //    c.ServerUrl = "http://localhost:8004";
            //});
            //throw new Exception("test exception " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            IDatabase db = redis.GetDatabase();
            string value = "aaa";
            db.StringSet("mykey", value);
            string value2 = db.StringGet("mykey");
            Console.WriteLine(value2); 
            try
            {
                //throw new Exception("test exception "+DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));
            }
            catch (Exception ex)
            {
                //client.SubmitException(ex);
                //ex.ToExceptionless().Submit();
                //logger.Error(ex);
                //Console.WriteLine("error send");
            }
            Console.ReadKey();
        }
    }
}
