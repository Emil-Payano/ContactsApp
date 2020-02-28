using ContactsApp.Models;
using ContactsApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactsApp.ViewModels
{
    public class EditPageViewModel : INotifyPropertyChanged
    {
        public ICommand EditContactCommand { get; set; }

        public Contact editContact { get; set; } = new Contact();

        public EditPageViewModel(Contact contact)
        {
            editContact.Name = contact.Name;
            editContact.Number = contact.Number;
            EditContactCommand = new Command(() =>
            {
                contact.Name = editContact.Name;
                contact.Number = editContact.Number;

            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
