using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingDirectorMobile.ViewModel
{
    public class Notification
    {
        public string Name { get; set; }
        public int Type { get; set; }
    }
    class DefaultNotificationViewModel
    {
        public string NotificationCount { get { return 1.ToString(); } }
        public List<Notification> notifications { get; set; }

        public DefaultNotificationViewModel()
        {
            notifications = new List<Notification>();
            var kurac = new Notification();
            kurac.Name = "Hydroxychloroquine";
            kurac.Type = -2;
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(new Notification() { Name = "rat", Type=0});
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(new Notification() { Name = "rat", Type = 0 });
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(kurac);
            notifications.Add(kurac);
        }
    }
}
