using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Prototype.Render
{
    public class GradientStack : StackLayout
    {
        public Color StartColor
        {
            get { return (Color)GetValue(StartColorProperty); }
            set { SetValue(StartColorProperty, value); }
        }

        public static readonly BindableProperty StartColorProperty = BindableProperty.Create(
                                                      propertyName: nameof(StartColor),
                                                      returnType: typeof(Color),
                                                      declaringType: typeof(GradientStack),
                                                      defaultValue: Color.White,
                                                      defaultBindingMode: BindingMode.TwoWay);

        public Color EndColor
        {
            get { return (Color)GetValue(EndColorProperty); }
            set { SetValue(EndColorProperty, value); }
        }

        public static readonly BindableProperty EndColorProperty = BindableProperty.Create(
                                                     propertyName: nameof(EndColor),
                                                     returnType: typeof(Color),
                                                     declaringType: typeof(GradientStack),
                                                     defaultValue: Color.Black,
                                                     defaultBindingMode: BindingMode.TwoWay);

        public bool IsVertical
        {
            get { return (bool)GetValue(IsVerticalProperty); }
            set { SetValue(IsVerticalProperty, value); }
        }

        public static readonly BindableProperty IsVerticalProperty = BindableProperty.Create(
                                                     propertyName: nameof(EndColor),
                                                     returnType: typeof(bool),
                                                     declaringType: typeof(GradientStack),
                                                     defaultValue: true,
                                                     defaultBindingMode: BindingMode.TwoWay);
    }
}