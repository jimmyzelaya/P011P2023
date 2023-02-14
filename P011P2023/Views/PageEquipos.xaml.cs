using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using System.IO;

namespace P011P2023.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEquipos : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile photo = null;
        public PageEquipos()
        {
            InitializeComponent();
        }


        private String traeImagenToBase64()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] fotobyte = memory.ToArray();

                    string Base64String = Convert.ToBase64String(fotobyte);
                    return Base64String;
                }
            }
            return null;
        }

        private byte[] traeImagenTobyte()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] fotobyte = memory.ToArray();
                    
                    return fotobyte;
                }
            }
            return null;
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            var equi = new Models.Equipos
            {
                Nombre = nombre.Text,
                Fundacion = fundacion.Date,
                Correo = correo.Text,
                Categoria = categoria.SelectedItem.ToString(),
                Logo = traeImagenTobyte()
            };

           if(await App.Dbequipos.StoreEquipo(equi) > 0)
            {
                await DisplayAlert("AVISO", "Equipo Ingresado con Exito", "OK");
            }
            else
            {
                await DisplayAlert("AVISO", "Equipo No Se Pudo Ingresar", "OK");
            }
        }

        private async void btnFoto_Clicked(object sender, EventArgs e)
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "AppEquipos",
                Name = "Foto.jpg",
                SaveToAlbum= true
            });

            if(photo!= null)
            {
                Foto.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
        }
        }
    }
}