using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using Xamarin.Forms;

namespace Agenda_Azure_Gallo
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application

            MobileServiceClient client;
            IMobileServiceTable<agendagallo> tabla;
            client = new MobileServiceClient(Conexion.ApplicationURL);
            tabla = client.GetTable<agendagallo>();
            Label titulo = new Label()
            {
                Text = "Inserta datos"
            };

            Entry nombre = new Entry();
            Entry apellido = new Entry();
            Entry telefono = new Entry();


            Button enviar = new Button()
            {
                Text = "enviar datos"
            };
            enviar.Clicked += async (sender, args) =>
            {
                var datos = new agendagallo { Name = nombre.Text, Ape = apellido.Text, Tel = telefono.Text };
                if (datos.Id == null)
                {
                    await tabla.InsertAsync(datos);
                }
                else
                {
                    await tabla.UndeleteAsync(datos);
                }
            };
            var layout = new StackLayout();
            layout.Children.Add(titulo);
            layout.Children.Add(nombre);
            layout.Children.Add(apellido);
            layout.Children.Add(telefono);
            layout.Children.Add(enviar);

            MainPage = new ContentPage()
            {
                Content = layout
            };

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
