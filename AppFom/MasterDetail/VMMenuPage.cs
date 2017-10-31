using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using AppFom.Pages;
using Xamarin.Forms;

namespace AppFom.MasterDetail
{
    public class VMMenuPage : INotifyPropertyChanged
    {

        #region Vars & Properties

        private INavigation Navigation;

        #endregion

        #region Implementa NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {

            if (PropertyChanged != null)
            {

                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Contructors

        public VMMenuPage(INavigation navigation)
        {
            this.Navigation = navigation;
            Start_LoadDefault();
        }

        #endregion

        #region Bindeos


        private Command command_Close;
        public const string Command_ClosePropertyName = "Command_Close";
        public Command Command_Close
        {
            get
            {
                return command_Close ?? (command_Close = new Command(async () => await ExecuteCommandClose()));
            }
        }

        private ImageSource source_Photo;
        public const string Source_PhotoPropertyName = "Source_Photo";
        public ImageSource Source_Photo
        {
            get { return source_Photo; }
            set { source_Photo = value; }
        }


        #endregion

        #region Methods

        async void Start_LoadDefault()
        {
            Debug.WriteLine("Construir Main");

            //source_Photo = string.IsNullOrEmpty(Look.Globals.URLPHOTOSUTOM) ? ImageSource.FromResource("GoodLook.Images.114.png") : Look.Globals.URLPHOTOSUTOM;
            //OnPropertyChanged(Source_PhotoPropertyName);
        }



        async Task ExecuteCommandClose()
        {
            //var x = await Fom.Dialogs.DisplayCautionMessageCloseSession();
            //if (x)
            //{
            // Limpiamos objeto que contengan info de la sesion               
            //Application.Current.MainPage = new NavigationPage(new PageTest());
            //}

            App.Current.MainPage = new NavigationPage(new PageLogin());
        }


        #endregion
    }
}