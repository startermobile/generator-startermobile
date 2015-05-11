using System;
using System.Reactive;
using System.Runtime.Serialization;

using ReactiveUI;

using Splat;

namespace StarterMobile.Core.ViewModels
{
    [DataContract]
    public class LoadingViewModel : ReactiveObject, ILoadingViewModel
    {
        public LoadingViewModel(IScreen hostScreen = null)
        {
            HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();

            IsAuthenticated = ReactiveCommand.CreateAsyncTask();
            
            IsAuthenticated.Subscribe(x =>
            {
                HostScreen.Router.NavigateAndReset.Execute(new LoginViewModel());
            });
        }

        [IgnoreDataMember]
        public ReactiveCommand<Unit> IsAuthenticated
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public string UrlPathSegment
        {
            get { return "Loading..."; }
        }

        [IgnoreDataMember]
        public IScreen HostScreen
        {
            get;
            protected set;
        }
    }
}

