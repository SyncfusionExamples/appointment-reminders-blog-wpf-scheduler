using Syncfusion.UI.Xaml.Scheduler;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace AppointmentReminder
{
    public class ReminderViewModel : NotificationObject
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ReminderViewModel" /> class.
        /// </summary>
        public ReminderViewModel()
        {
            this.Events = new ObservableCollection<Event>();
            this.CreateSchedulerAppointments();
            this.SchedulerViewTypes = this.GetSchedulerViewTypes();
            this.DisplayDate = DateTime.Now.Date.AddHours(9);
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets event collection.
        /// </summary>
        public ObservableCollection<Event> Events { get; set; }

        /// <summary>
        /// Gets or sets display date
        /// </summary>
        public DateTime DisplayDate { get; set; }

        /// <summary>
        /// Gets or sets scheduler view type collection
        /// </summary>
        public ObservableCollection<SchedulerViewType> SchedulerViewTypes { get; set; }

        #endregion Properties

        #region CreateSchedulerAppointmentCollection

        /// <summary>
        /// Method to create Scheduler appointment collection
        /// </summary>
        private void CreateSchedulerAppointments()
        {
            this.Events.Add(new Event()
            {
                From = DateTime.Now.Date.AddHours(9),
                To = DateTime.Now.Date.AddHours(10),
                Color = new SolidColorBrush(Color.FromArgb(0XFF, 0X33, 0X99, 0X33)),
                EventName = "Conference",
                Reminders = new ObservableCollection<Reminder>
                {
                    new Reminder { TimeInterval = new TimeSpan(0) },
                }
            });

            this.Events.Add(new Event()
            {
                From = DateTime.Now.Date.AddDays(-2).AddHours(10),
                To = DateTime.Now.Date.AddDays(-2).AddHours(11),
                Color = new SolidColorBrush(Color.FromArgb(0XFF, 0XA2, 0XC1, 0X39)),
                EventName = "Business Meeting",
                Reminders = new ObservableCollection<Reminder>
                {
                    new Reminder { TimeInterval = new TimeSpan(0, 15, 0)},
                }
            });

            this.Events.Add(new Event()
            {
                From = DateTime.Now.Date.AddDays(-3).AddHours(12),
                To = DateTime.Now.Date.AddDays(-3).AddHours(13),
                Color = new SolidColorBrush(Color.FromArgb(0XFF, 0X00, 0XAB, 0XA9)),
                EventName = "Medical check up",
                Reminders = new ObservableCollection<Reminder>
                {
                    new Reminder { TimeInterval = new TimeSpan(1, 0, 0, 0)},
                    new Reminder { TimeInterval = new TimeSpan(2, 0, 0, 0)},
                    new Reminder { TimeInterval = new TimeSpan(3, 0, 0)},
                }
            });

            this.Events.Add(new Event()
            {
                From = DateTime.Now.Date.AddDays(-10).AddHours(15),
                To = DateTime.Now.Date.AddDays(-10).AddHours(16),
                Color = new SolidColorBrush(Color.FromArgb(0XFF, 0XE6, 0X71, 0XB8)),
                EventName = "Project Status Discussion",
                Notes = "provides an opportunity to share information across the whole team.",
                RecurrenceRule = "FREQ=WEEKLY;BYDAY=WE;INTERVAL=1;COUNT=20",
                Reminders = new ObservableCollection<Reminder>
                {
                    new Reminder { TimeInterval = new TimeSpan(0, 15, 0)},
                }
            });

            this.Events.Add(new Event()
            {
                From = DateTime.Now.Date.AddDays(1).AddHours(14),
                To = DateTime.Now.Date.AddDays(1).AddHours(15),
                Color = new SolidColorBrush(Color.FromArgb(0XFF, 0XD8, 0X00, 0X73)),
                EventName = "GoToMeeting",
                Reminders = new ObservableCollection<Reminder>
                {
                    new Reminder { TimeInterval = new TimeSpan(0, 15, 0)},
                }
            });

        }

        #endregion CreateSchedulerAppointmentCollection

        /// <summary>
        /// Method to get all scheduler view types.
        /// </summary>
        /// <returns> Scheduler view type collection as key and value.</returns>
        internal ObservableCollection<SchedulerViewType> GetSchedulerViewTypes()
        {
            var schedulerViewTypes = new ObservableCollection<SchedulerViewType>();
            schedulerViewTypes.Add(new SchedulerViewType() { ViewTypeDisplayMemberPath = "Month", ViewType = "Month" });
            schedulerViewTypes.Add(new SchedulerViewType() { ViewTypeDisplayMemberPath = "Day", ViewType = "Day" });
            schedulerViewTypes.Add(new SchedulerViewType() { ViewTypeDisplayMemberPath = "Week", ViewType = "Week" });
            schedulerViewTypes.Add(new SchedulerViewType() { ViewTypeDisplayMemberPath = "Work Week", ViewType = "WorkWeek" });
            schedulerViewTypes.Add(new SchedulerViewType() { ViewTypeDisplayMemberPath = "Timeline Day", ViewType = "TimelineDay" });
            schedulerViewTypes.Add(new SchedulerViewType() { ViewTypeDisplayMemberPath = "Timeline Week", ViewType = "TimelineWeek" });
            schedulerViewTypes.Add(new SchedulerViewType() { ViewTypeDisplayMemberPath = "Timeline Work Week", ViewType = "TimelineWorkWeek" });
            schedulerViewTypes.Add(new SchedulerViewType() { ViewTypeDisplayMemberPath = "Timeline Month", ViewType = "TimelineMonth" });
            return schedulerViewTypes;
        }
    }
}
