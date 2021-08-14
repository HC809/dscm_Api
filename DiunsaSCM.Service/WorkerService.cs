using System;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Data;
using Hangfire;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Service
{
    public class WorkerService : IWorkerService
    {
        private readonly IBackgroundJobClient _backgroundJobs;
        private DiunsaSCMContext _diunsaSCMContext;
        public WorkerService(IBackgroundJobClient backgroundJobs, DiunsaSCMContext diunsaSCMContext)
        {
            _backgroundJobs = backgroundJobs;
            _diunsaSCMContext = diunsaSCMContext;
        }

        public void Enqueue(System.Linq.Expressions.Expression<Action> methodCall)
        {
            _backgroundJobs.Enqueue(methodCall);
        }

        public void ScheduleJobs() {
            /*RecurringJob.AddOrUpdate( () => this.ExcuteSP_SCM_GetERPShipmentLogEntry(),
                Cron.Hourly);

            RecurringJob.AddOrUpdate(() => this.ExcuteSP_SCM_SendToWMS(),
                Cron.Hourly);*/

        }

        public void ExcuteSP_SCM_GetERPShipmentLogEntry() {
            this.ExecuteSP("dbo.SP_SCM_GetERPShipmentLogEntry");
        }

        public void ExcuteSP_SCM_SendToWMS()
        {
            this.ExecuteSP("dbo.SP_SCM_SendToWMS");
        }

        public void ExecuteSP(string storeProcedure)
        {
            _diunsaSCMContext.Database.ExecuteSqlRaw(storeProcedure);
        }
    }
}
