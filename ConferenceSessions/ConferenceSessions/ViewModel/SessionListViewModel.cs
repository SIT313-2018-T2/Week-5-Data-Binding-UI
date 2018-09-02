using ConferenceSessions.Model;
using ConferenceSessions.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace ConferenceSessions.View
{
    public class SessionListViewModel
    {
        public class SessionListViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            private INavigation _navigation;
            public List<Session> Session { get; set; }
            public SessionListViewModel(INavigation navigation)
            {
                _navigation = navigation;
                Session = new List<Session>(SessionData.Get());
            }
            private Session _SessionSelected;
            public Session SessionSelected
            {
                get { return _SessionSelected; }
                set
                {
                    if (_SessionSelected != value)
                    {
                        _SessionSelected = value;
                        if ((_SessionSelected != null))
                        {
                            _navigation.PushAsync(new SessionDetailPage(_SessionSelected));
                        }
                    }
                }
            }
        }
    }
}
