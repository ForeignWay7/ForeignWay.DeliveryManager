using System;
using System.Windows.Controls;

namespace ForeignWay.DeliveryManager.App.Helpers
{
    public class PasswordBoxHelper : IPasswordBoxHelper
    {
        public string GetPasswordFrom(object passwordBoxObject)
        {

            if (passwordBoxObject is PasswordBox passwordBox)
                return passwordBox.Password;

            throw new InvalidCastException($"The passed in object:{passwordBoxObject.GetType()} is not a PasswordBox!");
        }
    }
}