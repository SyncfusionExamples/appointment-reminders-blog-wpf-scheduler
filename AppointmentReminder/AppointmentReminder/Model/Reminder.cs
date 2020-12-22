﻿using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentReminder
{
    public class Reminder : NotificationObject
    {
        /// <summary>
        /// Gets or sets the value indicating whether the reminder is dismissed or not. 
        /// </summary>
        private bool dismissed;

        /// <summary>
        /// Gets or sets the value to display reminder alert before appointment start time.
        /// </summary>
        private TimeSpan timeInterval;

        /// <summary>
        /// Gets or sets the value indicating whether the reminder is dismissed or not. 
        /// </summary>
        public bool Dismissed
        {
            get { return dismissed; }
            set
            {
                dismissed = value;
                this.RaisePropertyChanged("Dismissed");
            }
        }

        /// <summary>
        /// Gets or sets the value to display reminder alert before appointment start time.
        /// </summary>
        public TimeSpan TimeInterval
        {
            get { return timeInterval; }
            set
            {
                timeInterval = value;
                this.RaisePropertyChanged("TimeInterval");
            }
        }
    }
}
