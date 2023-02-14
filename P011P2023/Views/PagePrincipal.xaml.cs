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
    public partial class PagePrincipal : ContentPage
    {
        public PagePrincipal()
        {
            InitializeComponent();
        }

        private void ListaEquipos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var elemento = e.CurrentSelection;
        }

        //LISTA ITEMS
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ListaEquipos.ItemsSource = await App.Dbequipos.ListaEquipos();
        }

        //AGREGAR ITEMS
        private async void toolAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageEquipos());
        }

        //Eliminar ITEMS
        private async void toolEliminar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageEquipos());
        }

        //ACTUALIZAR ITEMS LIST
        private async void toolActualizar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageEquipos());
        }

        //IR A MAPA
        private async void toolMapa_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageMaps());
        }
    }
}