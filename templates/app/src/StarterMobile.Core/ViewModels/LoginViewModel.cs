using System;
using System.Reactive;
using System.Runtime.Serialization;

using ReactiveUI;

using Splat;

namespace StarterMobile.Core.ViewModels
{

    [DataContract]
    public class LoginViewModel : ReactiveObject, ILoginViewModel
    {
        [IgnoreDataMember] private string _password;
        [IgnoreDataMember] private string _username;

        public LoginViewModel(IScreen hostScreen = null)
        {
            HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();
            
            var canLogin = this.WhenAnyValue(x => x.Username, x => x.Password,
                               (username, password) => !String.IsNullOrWhiteSpace(username) && !String.IsNullOrWhiteSpace(password));

            Login = ReactiveCommand.CreateAsyncTask(canLogin, async _ =>
            {
                return Unit.Default;
            });
        }

        [IgnoreDataMember]
        public ReactiveCommand<Unit> Login
        {
            get;
            set;
        }

        [DataMember]
        public string Password
        {
            get { return _password; }
            set { this.RaiseAndSetIfChanged(ref _password, value); }
        }

        [DataMember]
        public string Username
        {
            get { return _username; }
            set { this.RaiseAndSetIfChanged(ref _username, value); }
        }

        [IgnoreDataMember]
        public string UrlPathSegment
        {
            get
            {
                return "Login";
            }
        }

        [IgnoreDataMember]
        public IScreen HostScreen
        {
            get;
            protected set;
        }
    }
}

