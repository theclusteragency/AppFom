using System;
using AppFom.Helpers;
using AppFom.ViewModels;
using Xamarin.Forms;

namespace AppFom.Pages
{
    public class PageSession : ContentPage
    {
        #region Vars & Properties

        private StackLayout SLRoot;

        #endregion


        public PageSession()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var BgLayout = new RelativeLayout();

            var BgImage = new Image { Source = ImageSource.FromResource("AppFom.Images.bg_fom_blue.png"), Aspect = Aspect.AspectFill };

            BgLayout.Children.Add(BgImage,
                              Constraint.Constant(0),
                              Constraint.Constant(0),
                              Constraint.RelativeToParent((Parent) =>
                              {
                                  return Parent.Width;
                              }),
                              Constraint.RelativeToParent((Parent) =>
                              {
                                  return Parent.Height;
                              })
                         );

            var IcoRafaGana = new Image { Source = ImageSource.FromResource("AppFom.Images.ico_fom_rafagana.png") };

            BgLayout.Children.Add(IcoRafaGana,
                                  Constraint.Constant(Fom.Screen.Width / 2 - (548 * .35 / 2)),
                                  Constraint.Constant(Fom.Screen.Height * .25),
                                  Constraint.Constant(548 * .35),
                                  Constraint.Constant(536 * .35)
                         );



            var TgBtnIniSession = new TapGestureRecognizer();
            TgBtnIniSession.SetBinding(TapGestureRecognizer.CommandProperty, "CommandGoLogin");
            var ImgBtnIniSession = new Image
            {
                Source = ImageSource.FromResource("AppFom.Images.btn_fom_inisession.png"),
            };
            ImgBtnIniSession.GestureRecognizers.Add(TgBtnIniSession);

            BgLayout.Children.Add(ImgBtnIniSession,
                                  Constraint.Constant(Fom.Screen.Width / 2 - (671 * .3 / 2)),
                              Constraint.Constant(Fom.Screen.Height * .77),
                              Constraint.Constant(671 * .3),
                              Constraint.Constant(176 * .3)
                         );

            SLRoot = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Spacing = 20
            };

            this.BindingContext = new VMSession(this.Navigation);

            Content = BgLayout;
        }
    }
}


