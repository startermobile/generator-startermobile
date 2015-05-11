using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;

using ReactiveUI;

using Splat;

namespace StarterMobile.Core.ViewModels
{
    public interface ILoginViewModel : IRoutableViewModel, IEnableLogger
    {
        ReactiveCommand<Unit> Login
        {
            get;
            set;
        }

        string Password
        {
            get;
            set;
        }

        string Username
        {
            get;
            set;
        }
    }
    
}
