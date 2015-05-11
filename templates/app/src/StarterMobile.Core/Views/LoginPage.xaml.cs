using System;
using System.Collections.Generic;

using StarterMobile.Core.ViewModels;

using ReactiveUI;

using Xamarin.Forms;

namespace StarterMobile.Core.Views
{
    public partial class LoginPage : ContentPage, IViewFor<LoginViewModel>
    {
        public static readonly BindableProperty ViewModelProperty = 
            BindableProperty.Create<LoginPage, LoginViewModel>(x => x.ViewModel, default(LoginViewModel), BindingMode.OneWay);

        public LoginPage()
        {
            InitializeComponent();

            this.Bind(ViewModel, vm => vm.Username, v => v.Username.Text);
            this.Bind(ViewModel, vm => vm.Password, v => v.Password.Text);

            this.BindCommand(ViewModel, vm => vm.Login, v => v.Login);
        }

        public LoginViewModel ViewModel
        {
            get { return (LoginViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (LoginViewModel)value; }
        }
    }
}