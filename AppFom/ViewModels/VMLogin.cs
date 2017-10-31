using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AppFom.Helpers;
using AppFom.Implementations;
using AppFom.Interfaces;
using AppFom.MasterDetail;
using Xamarin.Forms;

namespace AppFom.ViewModels
{
    public class VMLogin : ViewModelMaster
    {
        #region Vars & Properties

        private readonly IOperationServices Services;

        #endregion


        public VMLogin(INavigation navigation)
        {
            this.Navigation = navigation;
            Services = new OperationServices();
        }

        private string textUser;
        public string TextUser
        {
            get { return textUser; }
            set { SetProperty(ref textUser, value); }
        }

        private string textPsw;
        public string TextPsw
        {
            get { return textPsw; }
            set { SetProperty(ref textPsw, value); }
        }


        Command commandSignIn;
        public const string CommandSignInPropertyName = "CommandSignIn";
        public Command CommandSignIn
        {
            get
            {
                return commandSignIn ??
                    (commandSignIn = new Command(async () => await ExecuteCommandSignIn()));
            }
        }

        async Task ExecuteCommandSignIn()
        {
            Debug.WriteLine("SignIn");

            //CHECK LOGIN
            //var obj = new { usuario = textUser, password = textPsw };
            //var result = await Services.CheckLogin(obj);

            await Navigation.PushModalAsync(new RootPage());
        }



    }
}
