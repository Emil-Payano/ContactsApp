using ContactsApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactsApp.ViewModels
{
    public class AddPageViewModel : INotifyPropertyChanged
    {
        public Contact Contact1 { get; set; } = new Contact();

        public ICommand AddContact { get; set; }
       
        public AddPageViewModel(ObservableCollection<Contact> contacts) {
           

            AddContact = new Command(() =>
            {
                try
                {
                    contacts.Add(Contact1);


                }
                catch(Exception e)
                {
                    Debug.WriteLine(e.ToString());

                }
            });

 

        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
