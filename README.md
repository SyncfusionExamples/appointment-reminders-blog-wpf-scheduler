# Introducing appointment reminders in WPF Scheduler (SfScheduler)

Syncfusion WPF scheduler control dispense you with appointment reminder support, which alerts you for an appointment with a reminder window with complete data-binding support. Besides, you can also send reminder message through SMS or email with the help of external packages to keep track on the appointments.

**Adding reminder alert for an appointment**

It’s simple to add a reminder to the appointment in Scheduler control. You can create the SchedulerReminder with time interval to specify when to alert the reminder window using ReminderTimeInterval property and it can be binded in the ScheduleAppointment using Reminders API. 

**Creating business object for reminder**

The resource view provides MVVM ([model- view-viewmodel](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93viewmodel))-friendly features with complete data-binding support. This allows you to create custom data objects for reminder and bind it into appointment of Scheduler control by using the mapping technique.

You can create custom data objects for reminder with the required field TimeInterval and Dismissed. It can be mapped to the equivalent properties in the [ReminderMapping](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Scheduler.AppointmentMapping.html#Syncfusion_UI_Xaml_Scheduler_AppointmentMapping_ReminderMapping) API in the [AppointmentMapping](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Scheduler.AppointmentMapping.html) class.

You can create Reminders property in the custom data objects for appointments and it can be mapped to the equivalent property in the AppointmentMapping API in the Scheduler class. You can refer this [link](https://help.syncfusion.com/wpf/scheduler/appointments#scheduler-item-source-and-mapping) to know more about the custom data objects for appointments.

``` c#
    /// <summary>
    /// Represents custom data properties for reminder. 
    /// </summary>
    public class Reminder
    {
        public bool Dismissed { get; set; }
        public TimeSpan TimeInterval { get; set; }
    }
```

``` c#
    /// <summary>
    /// Represents custom data properties for appointment. 
    /// </summary>
    public class Event 
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool IsAllDay { get; set; }
        public string EventName { get; set; }
        public string Notes { get; set; }
        public Brush Color { get; set; }
        public object RecurrenceId { get; set; }
        public object Id { get; set; }
        public string RecurrenceRule { get; set; }
        public ObservableCollection<DateTime> RecurrenceExceptions { get; set; }
        public ObservableCollection<Reminder> Reminders { get; set; }
    }
```

``` c#
    /// <summary>
    /// Represents custom data properties for reminder. 
    /// </summary>
    public class Reminder
    {
        public bool Dismissed { get; set; }
        public TimeSpan TimeInterval { get; set; }
    }
```

``` c#
    var event = new Event();
    event.From = DateTime.Now.Date.AddDays(-2).AddHours(10);
    event.To = DateTime.Now.Date.AddDays(-2).AddHours(11);
    event.Color = new SolidColorBrush(Color.FromArgb(0XFF, 0XA2, 0XC1, 0X39));
    event.EventName = "Business Meeting"; 
    event.Reminders = new ObservableCollection<Reminder>
    {
        new Reminder { TimeInterval = new TimeSpan(0, 15, 0)},
    };
```

``` xml   
        <syncfusion:SfScheduler x:Name="Schedule" 
                                ItemsSource="{Binding Events}"
                                EnableReminder="True"
                                DisplayDate="{Binding DisplayDate}"
                                ViewType="{Binding ElementName=viewtypecombobox, Path=SelectedValue,Mode=TwoWay}">
            <syncfusion:SfScheduler.AppointmentMapping>
                <syncfusion:AppointmentMapping
                    Subject="EventName"
                    StartTime="From"
                    EndTime="To"
                    Id="Id"
                    AppointmentBackground="Color"
                    IsAllDay="IsAllDay"
                    StartTimeZone="StartTimeZone"
                    EndTimeZone="EndTimeZone"
                    RecurrenceExceptionDates="RecurrenceExceptions"
                    RecurrenceRule="RecurrenceRule"
                    RecurrenceId="RecurrenceId"
                    Reminders="Reminders">
                    <syncfusion:AppointmentMapping.ReminderMapping>
                        <syncfusion:ReminderMapping IsDismissed="Dismissed"
                                                    ReminderTimeInterval="TimeInterval"/>
                    </syncfusion:AppointmentMapping.ReminderMapping>
                </syncfusion:AppointmentMapping>
            </syncfusion:SfScheduler.AppointmentMapping>
        </syncfusion:SfScheduler>
```

![SchedulerAppointmentReminder](https://github.com/SyncfusionExamples/appointment-reminders-blog-wpf-scheduler/blob/main/ScreenShot/scheduler-appointment-reminder.png)

**Sending reminder alert as email message to outlook**

You can send reminder message through email to Microsoft Outlook with the help of [Microsoft.Office.Interop.Outlook package](https://docs.microsoft.com/en-us/dotnet/api/microsoft.office.interop.outlook?view=outlook-pia) and [ReminderAlertOpening](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Scheduler.SfScheduler.html#Syncfusion_UI_Xaml_Scheduler_SfScheduler_ReminderAlertOpening) event in scheduler control to keep track on the appointments. Scheduler notifies by the ReminderAlertOpening event when appearing in the reminder window. 

Create [MailItem](https://docs.microsoft.com/en-us/office/vba/api/outlook.mailitem) using Microsoft.Office.Interop.Outlook application, and send reminder alert email to the corresponding email id with the appointment subject and description. You can refer this [link](https://docs.microsoft.com/en-us/visualstudio/vsto/working-with-mail-items?view=vs-2019) to know more about the MailItem. 

``` c#
    this.scheduler.ReminderAlertOpening += OnReminderAlertOpening;
```

``` c#
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
```
 

