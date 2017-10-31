using System;
using AppFom.Components;
using AppFom.iOS.Renderers;
using CoreAnimation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace AppFom.iOS.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var borderLayer = new CALayer();
                borderLayer.MasksToBounds = true;
                borderLayer.Frame = new CoreGraphics.CGRect(0f, Frame.Height, Frame.Width, 1f);
                Control.Layer.BorderColor = UIColor.DarkGray.CGColor;
                borderLayer.BorderWidth = 1.0f;

                Control.BorderStyle = UITextBorderStyle.None;
                Control.Layer.AddSublayer(borderLayer);

            }
        }
    }
}
