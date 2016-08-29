using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace NASAapp.Services
{
    public class NavigationService : INavigationService
    {
        private static object _syncObject = new object();
        private static NavigationService _instance;
        private static Frame _frame;

        private NavigationService() { }

        public bool CanGoBack()
        {
            if (_frame == null)
            {
                throw new Exception("Frame is not registered");
            }
            return _frame.CanGoBack;
        }

        public bool Navigate(Type page, object parameter)
        {
            if (_frame == null)
            {
                throw new Exception("Frame is not registered");
            }
            if (page == null)
            {
                throw new ArgumentException("Page can't be null");
            }
            return _frame.Navigate(page, parameter);
        }

        public void GoBack()
        {
            if (_frame == null)
            {
                throw new Exception("Frame is not registered");
            }
            _frame.GoBack();
        }

        public static NavigationService Instance
        {
            get
            {
                lock (_syncObject)
                {
                    if (_instance == null)
                    {
                        _instance = new NavigationService();
                    }
                    return _instance;
                }
            }
        }

        public static void RegisterFrame(Frame frame)
        {
            if (frame == null)
            {
                throw new ArgumentException("Frame can't be null");
            }

            _frame = frame;
        }
    }

    public interface INavigationService
    {
        bool CanGoBack();
        bool Navigate(Type page, object parameter);
        void GoBack();
    }
}
