using App2.ViewModels;
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using App2.ConvertClass;
using System.Globalization;
using System.Windows.Input;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Zkouska : ContentPage
    {

        public ZkouskaViewModel viewModel;
        public Zkouska()
        {
            TableConverter tableCo = new TableConverter();

            viewModel = new ZkouskaViewModel();
            viewModel.LoadItemsCommand.Execute(null);


            SfButton[] sfButtons = new SfButton[viewModel.Stolies.Count];
            int counter = 0;
            foreach (var item in viewModel.Stolies)
            {
                sfButtons[counter] = new SfButton()
                {
                    Style = (Style)tableCo.Convert(item, null, this, CultureInfo.CurrentCulture),
                    BindingContext = item,
                    Text = item.Id.ToString(),
                    PressedBackgroundColor = Color.Blue,

                };
                sfButtons[counter].Clicked += Zkouska_Clicked;
                counter++;

            }
            int zbytek;
            int quotient = Math.DivRem(viewModel.Stolies.Count, 3, out zbytek);



            Frame[] frame = new Frame[quotient];
            int counters = 0;
            for (int i = 0; i < quotient; i++)
            {

                frame[i] = new Frame()
                {
                    Style = (Style)Application.Current.Resources["TableFrame"],
                    Content = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = { sfButtons[counters], sfButtons[counters + 1], sfButtons[counters + 2] }
                    }
                };
                counters += 3;

            }
            var s = new StackLayout();
            for (int i = 0; i < frame.Length; i++)
            {
                s.Children.Add(frame[i]);
            }
            Content = s;



        }

        private void Zkouska_Clicked(object sender, EventArgs e)
        {
            var Value = (SfButton)sender;
           

        }



    }
}

