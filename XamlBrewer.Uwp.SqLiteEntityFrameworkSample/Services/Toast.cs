namespace Mvvm.Services
{
    using Windows.Data.Xml.Dom;
    using Windows.UI.Notifications;

    /// <summary>
    /// Issues Toast Notifications.
    /// </summary>
    public static class Toast
    {
        /// <summary>
        /// Shows the specified text in a toast.
        /// </summary>
        public static void Show(string text)
        {
            Toast.Show(text, null);
        }

        /// <summary>
        /// Shows a toast with an info icon.
        /// </summary>
        public static void ShowInfo(string text)
        {
            Toast.Show(text, "ms-appx:///Assets/Toasts/Wink.png");
        }

        /// <summary>
        /// Shows a toast with a warning icon.
        /// </summary>
        public static void ShowWarning(string text)
        {
            Toast.Show(text, "ms-appx:///Assets/Toasts/Worried.png");
        }

        /// <summary>
        /// Shows a toast with an error icon.
        /// </summary>
        /// <param name="text">The text.</param>
        public static void ShowError(string text)
        {
            Toast.Show(text, "ms-appx:///Assets/Toasts/Confused.png");
        }

        /// <summary>
        /// Shows a toast with the specified text and icon.
        /// </summary>
        private static void Show(string text, string imagePath)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(text));

            if (!string.IsNullOrEmpty(imagePath))
            {
                XmlNodeList toastImageAttributes = toastXml.GetElementsByTagName("image");
                ((XmlElement)toastImageAttributes[0]).SetAttribute("src", imagePath);
            }

            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}

