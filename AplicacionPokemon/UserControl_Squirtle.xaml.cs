using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace AplicacionPokemon
{
    public sealed partial class UserControl_Squirtle : UserControl
    {
        DispatcherTimer dtTime_v;
        DispatcherTimer dtTime_e;
        bool animating = false;
        public UserControl_Squirtle()
        {
            this.InitializeComponent();
        }

        public double Vida
        {
            get { return this.b_vida.Value; }
            set { this.b_vida.Value = value; }
        }

        public double Energia
        {
            get { return this.b_energia.Value; }
            set { this.b_energia.Value = value; }
        }
        private void usePotionRed(object sender, PointerRoutedEventArgs e)
        {
            dtTime_v = new DispatcherTimer();
            dtTime_v.Interval = TimeSpan.FromMilliseconds(100);
            dtTime_v.Tick += increaseHealth;
            dtTime_v.Start();
            this.p_vida.Opacity = 0.5;
        }
        private void increaseHealth(object sender, object e)
        {
            this.b_vida.Value += 0.2;
            if (b_vida.Value >= 100)
            {
                this.dtTime_v.Stop();
                this.p_vida.Opacity = 1;
            }
        }
        private void usePotionYellow(object sender, PointerRoutedEventArgs e)
        {
            dtTime_e = new DispatcherTimer();
            dtTime_e.Interval = TimeSpan.FromMilliseconds(100);
            dtTime_e.Tick += increaseEnergy;
            dtTime_e.Start();
            this.p_energia.Opacity = 0.5;
        }
        private void increaseEnergy(object sender, object e)
        {
            this.b_energia.Value += 0.2;
            if (b_energia.Value >= 100)
            {
                this.dtTime_e.Stop();
                this.p_energia.Opacity = 1;
            }
        }

        internal void button_derrotado()
        {
            if (!animating)
            {
                animating = true;
                Storyboard sb = (Storyboard)this.Resources["Derrotado"];
                sb.Completed += (s, args) => { animating = false; };
                sb.Begin();
            }
        }

        private void button_colazo(object sender, RoutedEventArgs e)
        {
            if (!animating)
            {
                animating = true;
                Storyboard sb = (Storyboard)this.Resources["Colazo"];
                sb.Completed += (s, args) => { animating = false; };
                sb.Begin();
            }
        }

        private void button_pistolaAgua(object sender, RoutedEventArgs e)
        {
            if (!animating)
            {
                animating = true;
                Storyboard sb = (Storyboard)this.Resources["PistolaAgua"];
                sb.Completed += (s, args) => { animating = false; };
                sb.Begin();
            }
        }

        public void button_pistolaAgua()
        {
            if (!animating)
            {
                animating = true;
                Storyboard sb = (Storyboard)this.Resources["PistolaAgua"];
                sb.Completed += (s, args) => { animating = false; };
                sb.Begin();
            }
        }

        private void button_dormido(object sender, RoutedEventArgs e)
        {
            if (!animating)
            {
                animating = true;
                Storyboard sb = (Storyboard)this.Resources["Dormido"];
                sb.Completed += (s, args) => { animating = false; };
                sb.Begin();
            }
        }

        private void button_cansado(object sender, RoutedEventArgs e)
        {
            if (!animating)
            {
                animating = true;
                Storyboard sb = (Storyboard)this.Resources["Cansado"];
                sb.Completed += (s, args) => { animating = false; };
                sb.Begin();
            }
        }

        private void button_derrotado(object sender, RoutedEventArgs e)
        {
            if (!animating)
            {
                animating = true;
                Storyboard sb = (Storyboard)this.Resources["Derrotado"];
                sb.Completed += (s, args) => { animating = false; };
                sb.Begin();
            }
        }

        private void button_burbuja(object sender, RoutedEventArgs e)
        {
            if (!animating)
            {
                animating = true;
                Storyboard sb = (Storyboard)this.Resources["Burbuja"];
                sb.Completed += (s, args) => { animating = false; };
                sb.Begin();
            }
        }

        private bool verBotones = true;

        public bool Botones
        {
            get { return verBotones = true; }
            set
            {
                this.verBotones = value;
                if (!verBotones)
                {
                    this.boton_burbuja.Visibility = Visibility.Collapsed;
                    this.boton_cansado.Visibility = Visibility.Collapsed;
                    this.boton_colazo.Visibility = Visibility.Collapsed;
                    this.boton_derrotado.Visibility = Visibility.Collapsed;
                    this.boton_dormido.Visibility = Visibility.Collapsed;
                    this.boton_pistolaAgua.Visibility = Visibility.Collapsed;
                }
                else
                {
                    this.boton_burbuja.Visibility = Visibility.Visible;
                    this.boton_cansado.Visibility = Visibility.Visible;
                    this.boton_colazo.Visibility = Visibility.Visible;
                    this.boton_derrotado.Visibility = Visibility.Visible;
                    this.boton_dormido.Visibility = Visibility.Visible;
                    this.boton_pistolaAgua.Visibility = Visibility.Visible;
                }
            }

        }

        private bool verFondo = true;

        public bool Fondo
        {
            get { return verFondo = true; }
            set
            {
                this.verFondo = value;
                if (!verFondo) this.fondo.Visibility = Visibility.Collapsed;
                else this.fondo.Visibility = Visibility.Visible;
            }

        }

        private bool verNombre = true;

        public bool Nombre
        {
            get { return verNombre = true; }
            set
            {
                this.verNombre = value;
                if (!verNombre) this.nombre.Visibility = Visibility.Collapsed;
                else this.nombre.Visibility = Visibility.Visible;
            }

        }
    }
}
