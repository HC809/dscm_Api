using System;
namespace DiunsaSCM.Core.Services
{
    public interface IWorkerService
    {
        void Enqueue(System.Linq.Expressions.Expression<Action> methodCall);
        void ScheduleJobs();
    }
}
