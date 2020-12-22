using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace AppointmentReminder
{
    public class AppointmentReminderBehavior : Behavior<SfScheduler>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.ReminderAlertOpening += OnReminderAlertOpening;
        }

        private async void OnReminderAlertOpening(object sender, ReminderAlertOpeningEventArgs e)
        {
            await Task.Run(() =>
            {
                foreach (var reminder in e.Reminders)
                {
                    Outlook.Application application = new Outlook.Application();
                    Outlook.MailItem eMail = (Outlook.MailItem)application.CreateItem(Outlook.OlItemType.olMailItem);
                    eMail.Subject = reminder.Appointment.Subject + " reminder alert";
                    eMail.To = "abc@outlook.com";
                    eMail.Body = reminder.Appointment.Subject + " - " + reminder.Appointment.ActualStartTime.ToString();
                    eMail.Importance = Outlook.OlImportance.olImportanceNormal;
                    eMail.Send();
                }
            });
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.ReminderAlertOpening -= OnReminderAlertOpening;
        }
    }
}
