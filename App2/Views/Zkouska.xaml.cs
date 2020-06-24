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
using Syncfusion.XForms.Border;
using Syncfusion.XForms.TabView;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Zkouska : ContentPage
    {

        public ZkouskaViewModel viewModel;
        public Zkouska()
        {
            SfTabView sfTabView1 = new SfTabView();
            
            
            TableConverter tableCo = new TableConverter();
   
           
            viewModel = new ZkouskaViewModel();
            viewModel.LoadItemsCommand.Execute(null);


            SfButton[] sfButtons = new SfButton[viewModel.Stolies.Count];
            int counter = 0;
            foreach (var item in viewModel.Stolies)
            {
                SfBorder sfBorder = new SfBorder { BorderWidth = 2, BorderColor = Color.Chocolate, WidthRequest = 2 };
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




            Frame[] frame;
            if (zbytek > 0) { frame = new Frame[quotient + 1]; } else
            {
                frame = new Frame[quotient];
            }


            int counters = 0;
            /*    for (int i = 0; i < quotient; i++)
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

                }*/
            for (int i = 0; i < quotient; i++)
            {
                frame[i] = CreateFrime(counters,sfButtons,null);
                counters += 3;
                if(quotient-1==i)
                {
                    frame[i+1] = CreateFrime(counters, sfButtons, zbytek);
                }
            }


                var s = new StackLayout();
     
            for (int i = 0; i < frame.Length; i++)
            {
                s.Children.Add(frame[i]);
            }
            Content = s;



        }

        private async void Zkouska_Clicked(object sender, EventArgs e)
        {
            var Value = (SfButton)sender;

         await   Navigation.PushAsync(new TableCollection(new OrderInfo((Models.Stoly)Value.BindingContext)));
 
           

        }
        /// <summary>
        /// Create Frame based on 
        /// </summary>
        /// <param name="counter"></param>
        /// <param name="sfButtons"></param>
        /// <param name="qutient"></param>
        /// <returns></returns>
        private Frame CreateFrime(int counter, SfButton[] sfButtons, int? qutient)
        {
            if (qutient.HasValue == false)
                return new Frame()
                {
                    Style = (Style)Application.Current.Resources["TableFrame"],
                    Content = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children =
            { sfButtons[counter], sfButtons[counter + 1], sfButtons[counter + 2] }
                    }
                };
             if (qutient.Value == 1)
            {
                return new Frame()
                {
                    Style = (Style)Application.Current.Resources["TableFrame"],
                    Content = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children =
                    { sfButtons[counter],  }
                    }
                }; }

             if (qutient.Value == 2)
            {
                return new Frame()
                {
                    Style = (Style)Application.Current.Resources["TableFrame"],
                    Content = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children =
                    { sfButtons[counter],  }
                    }
                };
            }
            return null;
        }


            }

            
        }

