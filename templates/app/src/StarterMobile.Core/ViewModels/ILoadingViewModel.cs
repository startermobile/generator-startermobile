using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;

using ReactiveUI;

using Splat;


namespace StarterMobile.Core.ViewModels
{
    public interface ILoadingViewModel : IRoutableViewModel, IEnableLogger
    {
        ReactiveCommand<Unit> IsAuthenticated { get; set; }
    }
}

