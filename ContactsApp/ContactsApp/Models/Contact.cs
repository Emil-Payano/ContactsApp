using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ContactsApp.Models
{
    public class Contact : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
