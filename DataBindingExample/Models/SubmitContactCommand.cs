using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace DataBindingExample.Models {
    public class SubmitContactCommand : ICommand {

        public event EventHandler CanExecuteChanged;
        private void OnCanExecuteChanged() {
            if (CanExecuteChanged != null) CanExecuteChanged(this, new EventArgs());
        }

        private readonly Contact contact;
        private bool canExecute;

        public SubmitContactCommand(Contact contact) {
            this.contact = contact;
            this.contact.PropertyChanged += ContactPropertyChanged;
        }

        void ContactPropertyChanged(object sender, PropertyChangedEventArgs e) {
            if (canExecute == contact.IsValid) return;
            canExecute = contact.IsValid;
            OnCanExecuteChanged();
        }

        public void Execute(object parameter) {
            Debug.WriteLine("Contact Submitted: " + contact);
        }

        public bool CanExecute(object parameter) {
            return canExecute;
        }
    }
}