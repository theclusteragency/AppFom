using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Acr.UserDialogs;
using AppFom.Helpers;
using AppFom.Implementations;
using Xamarin.Forms;

namespace AppFom.CellViews
{
    public class VCActivity : ViewCell
    {
        public VCActivity()
        {
            Actividade Act = new Actividade();

            Tapped += (sender, e) =>
            {
                this.View.BackgroundColor = Color.Transparent;
            };

            var slWrap = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
            };

            var LblActivity = new Label()
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White
            };
            LblActivity.SetBinding(Label.TextProperty, "descripcion");
            slWrap.Children.Add(LblActivity);


            var swActivity = new Switch()
            {
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.Center,
            };
            swActivity.BindingContextChanged += (sender, i) =>
            {
                base.OnBindingContextChanged();
                dynamic c = BindingContext;
                if (c != null)
                {
                    Act = (Actividade)c;

                    if (c.hecha == 1)
                    {
                        swActivity.IsToggled = true;
                    }
                    else
                    {

                        swActivity.IsToggled = false;
                    }
                }
            };

            swActivity.Toggled += async (sender, e) =>
            {
                Act.hecha = swActivity.IsToggled ? 1 : 0;
                await UpdateActivity(Act);
            };
            // TODO UPDATE ACTIVITY AFTER CHECKED IT

            slWrap.Children.Add(swActivity);

            this.View = slWrap;
        }

        public async Task UpdateActivity(Actividade act)
        {

            Debug.WriteLine("Actualizar actividad :" + act.id_actividad);
            try
            {
                var Services = new OperationServices();


                UserDialogs.Instance.ShowLoading();

                var generic = new
                {
                    id_evento_actividad = act.id_actividad,
                    hecho = 1,
                    id_usuario = Fom.Globals.USERFOM.id_usuario
                };
                // Terminar evento
                await Services.UpdStatusActivity(generic);


                UserDialogs.Instance.HideLoading();


            }
            catch (Exception ex)
            {

                Debug.WriteLine("Error en login : " + ex.Message);
                UserDialogs.Instance.HideLoading();
            }
        }
    }

}
