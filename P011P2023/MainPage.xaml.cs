using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using P011P2023;

namespace P011P2023
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // LLAMAR A LA SEGUNDA PAGINA
        private async void btnsegunda_Clicked(object sender, EventArgs e)
        {
            try
            {
                var estudiante = new Models.Estudiente
                {
                    nombres = nombre.Text,
                    apellidos = apellido.Text,
                    telefono = telefono.Text
                };

                var pagina = new Views.PageDos();
                pagina.BindingContext = estudiante;
                await Navigation.PushAsync(pagina);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
               

            
        }

        // LLAMAR A LA PAGINA EQUIPO
        private async void btnPaginaEquipo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PageEquipos());
        }

        // LLAMAR A LA PAGINA PRINCIPAL
        private async void btnPaginaPrincipal_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PagePrincipal());
        }
        

    }
}
