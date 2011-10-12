using System.ComponentModel;
using System.Windows.Input;

namespace DataBindingExample.Models {
    public class Contact : INotifyPropertyChanged {

        #region INotifyPropertyChanged Members and Helpers
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Data Properties
        private string dicHandle;
        public string DicHandle {
            get { return dicHandle; }
            set {
                if (dicHandle == value) return;
                dicHandle = value;
                OnPropertyChanged("DicHandle");
            }
        }

        private string email;
        public string Email {
            get { return email; }
            set {
                if (email == value) return;
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string firstName;
        public string FirstName {
            get { return firstName; }
            set {
                if (firstName == value) return;
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string lastName;
        public string LastName {
            get { return lastName; }
            set {
                if (lastName == value) return;
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string phoneNumber;
        public string PhoneNumber {
            get { return phoneNumber; }
            set {
                if (phoneNumber == value) return;
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }
        #endregion

        public ICommand SubmitContact { get; private set; }

        internal bool IsValid {
            get { //simple rules for now
                return !string.IsNullOrWhiteSpace(DicHandle);
            }
        }

        public Contact() {
            SubmitContact = new SubmitContactCommand(this);
        }

        public override string ToString() {
            return string.Format("{0} | {1} {2} | {3} | {4}", DicHandle, FirstName, LastName, Email, PhoneNumber);
        }
    }
}
