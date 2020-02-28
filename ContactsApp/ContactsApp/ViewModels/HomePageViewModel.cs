using ContactsApp.Models;
using ContactsApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContactsApp.ViewModels
{
   public class HomePageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public ICommand GoAddPageCommand { get; set; }

        public ICommand DeleteElementCommand { get; set; }

        public ICommand EditContactCommand { get; set; }
        public ICommand CallContactCommand { get; set; }
        public ICommand MoreOptionsCommand { get; set; }
        public HomePageViewModel() {

           


            GoAddPageCommand = new Command(async() =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new AddPage(Contacts));

            });

            DeleteElementCommand = new Command<Contact>((param) =>
            {
                Contacts.Remove(param);

            });
            MoreOptionsCommand = new Command<Contact>((param) =>
            {
                MoreOptions(param);
            });

        }
        async void MoreOptions(Contact selectedContact)
        {
            var selectedAction = await App.Current.MainPage.DisplayActionSheet(null, "Cancel", null, "Call", "Edit");

            switch (selectedAction)
            {
                case "Cancel":
                    break;
                case "Call":
                    try
                    {
                        PhoneDialer.Open(selectedContact.Number);
                    }
                    catch (ArgumentNullException anEx)
                    {
                        // Number was null or white space
                        await App.Current.MainPage.DisplayAlert("Error", "Number was empty", "Cancel");
                    }
                    catch (FeatureNotSupportedException ex)
                    {
                        // Phone Dialer is not supported on this device.
                        await App.Current.MainPage.DisplayAlert("Error", "Phone Dialer not supported in this phone", "Cancel");
                    }
                    catch (Exception ex)
                    {
                        // Other error has occurred.
                        await App.Current.MainPage.DisplayAlert("Error", ex.ToString(), "Cancel");
                    }
                    break;
                case "Edit":
                    await App.Current.MainPage.Navigation.PushAsync(new EditPage(selectedContact), false);
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
