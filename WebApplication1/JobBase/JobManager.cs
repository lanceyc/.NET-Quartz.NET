﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.JobWork;

namespace WebApplication1.JobBase
{
    public class JobManager
    {
        public static void State()
        {
            //开启调度
            JobBase.Scheduler.Start();

            // 第一个参数是你要执行的工作(job)  第二个参数是这个工作所对应的触发器(Trigger)(例如:几秒或几分钟执行一次)
            JobBase.AddSchedule(new JobServer<AddMassagejob>(),
                new AddMasagerTriggerServer().AddMasagerTrigger(), "每隔一分钟向文本中写入文字", "消息工作");

            //JobBase.AddSchedule(new JobServer<DiscountedShopJob>(),
            //    new DiscountedShopTriggerServer().GoodsDisCountTrigger(), "每月的最后一天10.15开启打折活动", "折扣活动");

        }
    }
}