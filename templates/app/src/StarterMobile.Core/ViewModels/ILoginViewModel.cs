using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

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
