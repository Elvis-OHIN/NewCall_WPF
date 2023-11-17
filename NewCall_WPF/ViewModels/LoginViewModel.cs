using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using NewCall_WPF.Repositories;
using NewCall_WPF.Models;

namespace NewCall_WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        //Fields
        private string _identifiant;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private AdminRepository adminRepository;

        //Properties
        public string Identifiant
        {
            get
            {
                return _identifiant;
            }

            set
            {
                _identifiant = value;
                OnPropertyChanged(nameof(Identifiant));
            }
        }

        public SecureString Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }

            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }

            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        //-> Commands
        public ICommand LoginCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        //Constructor
        public LoginViewModel()
        {
            adminRepository = new AdminRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Identifiant) ||Password == null)
                validData = false;
            else
                validData = true;
            return validData;
        }

        private async void ExecuteLoginCommand(object obj)
        {
        
            var isValidadmin = await adminRepository.AuthenticateAdmin(new NetworkCredential(Identifiant, Password));
        
            if (isValidadmin)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Identifiant), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = $"* Vos identifiants de connexion sont incorrects.";
            }
        }

    }
}
