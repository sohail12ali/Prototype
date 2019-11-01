using CoreAnimation;
using CoreGraphics;
using Prototype.iOS.IosRenderer;
using Prototype.Render;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientStack), typeof(GradientStackRenderer))]

namespace Prototype.iOS.IosRenderer
{
    public class GradientStackRenderer : VisualElementRenderer<StackLayout>
    {
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            GradientStack stack = (GradientStack)this.Element;

            CGColor[] cGColors = new CGColor[] { stack.StartColor.ToCGColor(), stack.EndColor.ToCGColor() };
            CAGradientLayer gradientLayer = new CAGradientLayer
            {
                Frame = rect,
                Colors = cGColors
            };

            if (!stack.IsVertical)
            {
                gradientLayer = new CAGradientLayer()
                {
                    StartPoint = new CGPoint(0, 0.5),
                    EndPoint = new CGPoint(1, 0.5),
                };
            }
            NativeView.Layer.InsertSublayer(gradientLayer, 0);
        }
    }
}