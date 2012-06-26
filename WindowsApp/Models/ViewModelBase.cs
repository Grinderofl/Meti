using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WindowsApp.Models
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public string DisplayName { get; set; }
        public bool ThrowOnInvalidPropertyname { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public abstract void Dispose();

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        /// <summary>
        /// Verifies the name of the property.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            if(TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;
                if(ThrowOnInvalidPropertyname)
                    throw new Exception(msg);
                Debug.Fail(msg);
            }
        }
    }
}
