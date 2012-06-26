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
