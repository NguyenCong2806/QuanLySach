using SweetAlertSharp;
using SweetAlertSharp.Enums;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace BookManagement.Common
{
    public static class Extend
    {
        /// <summary>
        /// Notification
        /// </summary>
        /// <param name="message"></param>
        /// <param name="offsetx"></param>
        /// <param name="offsety"></param>
        /// <param name="code"></param>
        public static void Notification(string message, double offsetx, double offsety, int code)
        {
            /// <summary>
            /// Notifier
            /// </summary>
            Notifier notifier = new Notifier(cfg =>
            {
                cfg.PositionProvider = new WindowPositionProvider(
                    parentWindow: Application.Current.MainWindow,
                    corner: Corner.TopRight,
                    offsetX: offsetx,
                    offsetY: offsety);

                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(3),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(5));

                cfg.Dispatcher = Application.Current.Dispatcher;
            });

            switch (code)
            {
                case Notice.OK:
                    notifier.ShowSuccess(message);
                    break;

                case Notice.SERVERERROR:
                    notifier.ShowError(message);
                    break;

                case Notice.NOTFOUND:
                    notifier.ShowWarning(message);
                    break;

                default:
                    notifier.ShowInformation(message);
                    break;
            }
        }

        /// <summary>
        /// SweetAlertResults
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        /// <param name="oktext"></param>
        /// <param name="canceltext"></param>
        /// <param name="sweetAlertButton"></param>
        /// <returns></returns>
        public static bool SweetAlertResults(string caption, string message, string oktext, string canceltext, SweetAlertButton sweetAlertButton)
        {
            var alert = new SweetAlert();
            alert.Caption = caption;
            alert.Message = message;
            alert.MsgButton = sweetAlertButton;
            alert.OkText = oktext;
            alert.CancelText = canceltext;

            return alert.ShowDialog()== SweetAlertResult.OK? true: false;
        }

        public static void Pagination(ref bool isEnablePrevious, ref bool isEnableNext, ref int page, int totalpage)
        {
            if (page == 1)
            {
                if (totalpage == page)
                {
                    isEnablePrevious = false;
                    isEnableNext = false;
                    return;
                }
                else
                {
                    isEnablePrevious = false;
                    isEnableNext = true;
                    return;
                }
            }
            if (page == totalpage && page > 1)
            {
                isEnableNext = false;
                isEnablePrevious = true;
                return;
            }
            if (page > 1 && page < totalpage)
            {
                isEnableNext = true;
                isEnablePrevious = true;
                return;
            }
        }

        public static ObservableCollection<T> ToObservableCollection<T>(this IQueryable<T> qnumeration)
        {
            return new ObservableCollection<T>(qnumeration);
        }
    }
}