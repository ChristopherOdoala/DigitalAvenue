﻿using System;
using System.Threading.Tasks;

namespace SalesManagementApp.Core.Dapper.Interfaces
{
    // <summary>
    /// Extensions for <see cref="Task"/>
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        /// Wait for the task to complete and rethrow original exceptions
        /// </summary>
        /// <param name="instance">Current instance</param>
        public static void WaitSync(this Task instance)
        {
            
            instance.Wait();
        }

        /// <summary>
        /// Crates a task that will complete when all the task objects in <paramref name="tasks"/> has completed. Original exceptons are rethrown.
        /// </summary>
        /// <param name="instance">Current instance</param>
        /// <param name="tasks">The tasks to wait for completion</param>
        public static void WhenAllSync(this Task instance, params Task[] tasks)
        {
            Exception exceptionInThread = null;
            try
            {
                Task.WhenAll(tasks);
            }
            catch (AggregateException aggregateException)
            {
                aggregateException.Handle((exc) =>
                {
                    exceptionInThread = exc;
                    return true;
                });
            }

            if (exceptionInThread != null)
            {
                throw exceptionInThread;
            }
        }
    }
}