using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Prototype.Droid.AndroidRenderer;
using Prototype.Render;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Xamarin.Forms.Color;

[assembly: ExportRenderer(typeof(GradientStack), typeof(GradientStackRenderer))]

namespace Prototype.Droid.AndroidRenderer
{
    public class GradientStackRenderer : VisualElementRenderer<StackLayout>
    {
        private Color StartColor { get; set; }
        private Color EndColor { get; set; }
        private bool IsVertical { get; set; }

        public GradientStackRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                // Unsubscribe from event handlers and cleanup any resources
            }

            if (e.NewElement != null)
            {
                // Configure the native control and subscribe to event handlers
                var stack = e.NewElement as GradientStack;
                this.StartColor = stack.StartColor;
                this.EndColor = stack.EndColor;
                this.IsVertical = stack.IsVertical;
            }
        }

        protected override void DispatchDraw(Canvas canvas)
        {
            LinearGradient linearGradient;
            if (IsVertical)
            {
                linearGradient = new Android.Graphics.LinearGradient(0, 0, 0, Height,
                 this.StartColor.ToAndroid(),
                 this.EndColor.ToAndroid(),
                 Android.Graphics.Shader.TileMode.Mirror);
            }
            else
            {
                linearGradient = new Android.Graphics.LinearGradient(0, 0, 0, Width,
                this.StartColor.ToAndroid(),
                this.EndColor.ToAndroid(),
                Android.Graphics.Shader.TileMode.Mirror);
            }
            Paint paint = new Android.Graphics.Paint()
            {
                Dither = true,
            };
            paint.SetShader(linearGradient);
            canvas.DrawPaint(paint);
            base.DispatchDraw(canvas);
        }
    }
}