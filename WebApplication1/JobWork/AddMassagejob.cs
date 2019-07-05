using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication1.JobWork
{
    public class AddMassagejob : IJob
    {

       async Task IJob.Execute(IJobExecutionContext context)
        {
          await  Task.Run(() =>
            {
                var reportDirectory = string.Format("~/QuartzLog/{0}/", DateTime.Now.ToString("yyyy-MM-dd"));
                reportDirectory = System.Web.Hosting.HostingEnvironment.MapPath(reportDirectory);
                if (!Directory.Exists(reportDirectory))
                {
                    Directory.CreateDirectory(reportDirectory);
                }

                var dailyReportFullPath = string.Format("{0}text_{1}.log", reportDirectory, DateTime.Now.Day);
                var logContent = string.Format("{0}-{1}-{2}", DateTime.Now, "滴 Quartz定时任务每一分钟执行一次，今天你跑步了吗？", Environment.NewLine);
                if (logContent == null)
                {
                    JobExecutionException jobex = new JobExecutionException("写入失败");

                }
                File.AppendAllText(dailyReportFullPath, logContent);

            });
           // return Task.FromResult(true);
        }
   
    }
}