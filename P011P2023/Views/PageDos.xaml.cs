using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P011P2023.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageDos : ContentPage
    {
        public PageDos()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lbnombre.Text = "Jimmy";
        }
    }
}