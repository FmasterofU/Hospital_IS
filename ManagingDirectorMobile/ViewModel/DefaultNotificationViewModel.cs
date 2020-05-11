using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ManagingDirectorMobile.ViewModel
{
    public class Notification
    {
        public string Name { get; set; }
        public int Type { get; set; }
    }
    class DefaultNotificationViewModel : INotifyPropertyChanged
    {
        public string NotificationCount { get { return notifications.Count().ToString(); } }
        public ObservableCollection<Notification> notifications { get; set; }

        public DefaultNotificationViewModel()
        {
            notifications = new ObservableCollection<Notification>();
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void addNotification()
        {
            notifications.Add(new Notification() { Name = "OH NO", Type = 3 });
            OnPropertyChanged("NotificationCount");
        }
    }
}
