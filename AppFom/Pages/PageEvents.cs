using System;
using AppFom.CellViews;
using AppFom.Helpers;
using ImageCircle.Forms.Plugin.Abstractions;
using Xamarin.Forms;

namespace AppFom.Pages
{
    public class PageEvents : ContentPage
    {
        #region Vars & Properties

        private StackLayout SlRoot = new StackLayout() { Padding = new Thickness(20) };

        #endregion


        public PageEvents()
        {
            Title = "Mis Eventos";
            //NavigationPage.SetHasNavigationBar(this, false);

            var BgLayout = new RelativeLayout();

            var BgImage = new Image { Source = ImageSource.FromResource("AppFom.Images.bg_fom_blelogin.png"), Aspect = Aspect.AspectFill };

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


            // Contruye pantalla
            ScreenBuilder(SlRoot);
            BgLayout.Children.Add(SlRoot,
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

            // this.BindingContext = new VMAccount(this.Navigation);

            Content = BgLayout;
        }


        public void ScreenBuilder(StackLayout root)
        {

            var slWrap = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Spacing = 20,
                Padding = new Thickness(0, 0, 0, 0)
            };

            var listEvents = new ListView();
            listEvents.BackgroundColor = Color.Transparent;
            listEvents.ItemTemplate = new DataTemplate(typeof(VCEvent));
            //listEvents.SetBinding(ListView.ItemsSourceProperty, "SourceListBranch");
            listEvents.ItemsSource = Fom.Globals.MISEVENTOS;
            //listEvents.SetBinding(ListView.SelectedItemProperty, "SelectedEvents");
            //listEvents.SetBinding(ListView.SelectedItemProperty, "SelectedEvents");
            //listEvents.SetBinding(ListView.IsRefreshingProperty, "IsBusy");
            listEvents.RowHeight = 120;
            listEvents.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                ((ListView)sender).SelectedItem = null;
            };
            listEvents.SeparatorColor = Color.Transparent;

            slWrap.Children.Add(listEvents);

            root.Children.Add(slWrap);

        }

    }
}


