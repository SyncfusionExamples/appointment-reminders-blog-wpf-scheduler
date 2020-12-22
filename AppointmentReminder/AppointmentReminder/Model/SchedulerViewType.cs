using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentReminder
{
    /// <summary>
    /// Represents model class for SchedulerViewType.
    /// </summary>
    public class SchedulerViewType
    {
        /// <summary>
        /// Gets or sets SchedulerViewType diplay member path.
        /// </summary>
        public string ViewTypeDisplayMemberPath { get; set; }

        /// <summary>
        /// Gets or sets SchedulerViewType value member path.
        /// </summary>
        public string ViewType { get; set; }
    }
}
