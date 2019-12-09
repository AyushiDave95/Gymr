using System;
using Xamarin.Forms;

namespace Gymr.CustomeControl
{
    public class ExtendedViewCell
    {
       
            public static readonly BindableProperty SelectedBackgroundColorProperty =
                BindableProperty.Create("SelectedBackgroundColor",
                                        typeof(Color),
                                        typeof(ExtendedViewCell),
                                        Color.Default);

            public Color SelectedBackgroundColor
            {
                get { return (Color)GetValue(SelectedBackgroundColorProperty); }
                set { SetValue(SelectedBackgroundColorProperty, value); }
            }

        private Color GetValue(BindableProperty selectedBackgroundColorProperty)
        {
            throw new NotImplementedException();
        }
    }

}
