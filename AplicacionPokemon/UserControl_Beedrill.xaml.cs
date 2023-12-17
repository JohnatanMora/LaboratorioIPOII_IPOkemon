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
    public sealed partial class UserControl_Beedrill : UserControl
    {
        DispatcherTimer miRelojVida;
        DispatcherTimer miRelojEnergia;
        public UserControl_Beedrill()
        {
            this.InitializeComponent();
            miRelojVida = new DispatcherTimer();
            miRelojEnergia = new DispatcherTimer();
            if (Vida <= 30)
            {
                HeridaCabeza.Visibility = Visibility.Visible;
                HeridaCuerpo.Visibility = Visibility.Visible;
                HeridaAla.Visibility = Visibility.Visible;
            }
        }

        public double Vida
        {
            get { return this.pbHealth.Value; }
            set { this.pbHealth.Value = value; }
        }

        private bool verBarraVida = true;

        public bool BarraVida
        {
            get { return verBarraVida = true; }
            set
            {
                this.verBarraVida = value;
                if (!verBarraVida) this.gridGeneral.RowDefinitions[0].Height = new GridLength(0);
                else this.gridGeneral.RowDefinitions[0].Height = new GridLength(10,
               GridUnitType.Star);
            }

        }

        public double Energia
        {
            get { return this.pbEnergy.Value; }
            set { this.pbEnergy.Value = value; }
        }

        private bool verBarraEnergia = true;

        public bool BarraEnergia
        {
            get { return verBarraEnergia = true; }
            set
            {
                this.verBarraEnergia = value;
                if (!verBarraEnergia) this.gridGeneral.RowDefinitions[1].Height = new GridLength(0);
                else this.gridGeneral.RowDefinitions[1].Height = new GridLength(10,
               GridUnitType.Star);
            }

        }

        internal void dormir()
        {
            {
                Storyboard sb_dormir = (Storyboard)this.Resources["Descansar"];
                sb_dormir.Begin();
                espiral_ojo_der.Visibility = Visibility.Collapsed;
                espiral_ojo_izq.Visibility = Visibility.Collapsed;
                if (Vida < 100)
                {
                    Vida = Vida + 5;
                    if (Vida >= 100)
                    {
                        Vida = 100;
                    }
                    if (Vida > 30)
                    {
                        HeridaAla.Visibility = Visibility.Collapsed;
                        HeridaCabeza.Visibility = Visibility.Collapsed;
                        HeridaCuerpo.Visibility = Visibility.Collapsed;
                    }
                }

                if (Energia < 100)
                {
                    Energia = Energia + 20;
                    if (Energia >= 100)
                    {
                        Energia = 100;
                    }
                }
            }
        }

        private bool verBotones = true;

        public bool Botones
        {
            get { return verBotones = true; }
            set
            {
                this.verBotones = value;
                if (!verBotones) this.grid_botones.Visibility = Visibility.Collapsed;
                else this.grid_botones.Visibility = Visibility.Visible;
            }

        }

        private bool verFondo = true;

        public bool Fondo
        {
            get { return verFondo = true; }
            set
            {
                this.verFondo = value;
                if (!verFondo) this.imagen_fondo.Visibility = Visibility.Collapsed;
                else this.imagen_fondo.Visibility = Visibility.Visible;
            }

        }

        private bool verNombre = true;

        public bool Nombre
        {
            get { return verNombre = true; }
            set
            {
                this.verNombre = value;
                if (!verNombre) this.nombre_pokemon.Visibility = Visibility.Collapsed;
                else this.nombre_pokemon.Visibility = Visibility.Visible;
            }

        }

        private void pocimaVida(object sender, PointerRoutedEventArgs e)
        {
            espiral_ojo_der.Visibility = Visibility.Collapsed;
            espiral_ojo_izq.Visibility = Visibility.Collapsed;
            miRelojVida.Interval = TimeSpan.FromMilliseconds(100);
            miRelojVida.Tick += subirVida;
            miRelojVida.Start();
            imPotionHealth.Opacity = 0.1;
        }

        public void subirVida(object sender, object e)
        {
            pbHealth.Value += 0.2;
            if (Vida > 30)
            {
                HeridaAla.Visibility = Visibility.Collapsed;
                HeridaCuerpo.Visibility = Visibility.Collapsed;
                HeridaCabeza.Visibility = Visibility.Collapsed;
                Ojos_parpados.Visibility = Visibility.Collapsed;
                espiral_ojo_izq.Visibility = Visibility.Collapsed;
                espiral_ojo_der.Visibility = Visibility.Collapsed;
            }
            if (pbHealth.Value >= 100)
            {
                miRelojVida.Stop();
                imPotionHealth.Opacity = 1;
            }
        }

        private void pocimaEnergia(object sender, PointerRoutedEventArgs e)
        {
            miRelojEnergia.Interval = TimeSpan.FromMilliseconds(100);
            miRelojEnergia.Tick += subirEnergia;
            miRelojEnergia.Start();
            imPotionEnergy.Opacity = 0.1;
            imPotionEnergy.IsTapEnabled = false;
        }

        private void subirEnergia(object sender, object e)
        {
            pbEnergy.Value += 0.2;
            if (pbEnergy.Value >= 100)
            {
                miRelojEnergia.Stop();
                imPotionEnergy.Opacity = 1;
                imPotionEnergy.IsTapEnabled = true;
            }
        }

        private void ataque(object sender, PointerRoutedEventArgs e)
        {
            if ((Vida <= 0))
            {
                Storyboard sb_cansado_vida = (Storyboard)this.Resources["Cansado_Sin_Vida"];
                sb_cansado_vida.Begin();
            }
            else if ((Energia < 10))
            {
                Storyboard sb_cansado = (Storyboard)this.Resources["Cansado_Sin_Energia"];
                sb_cansado.Begin();
            }
            else
            {
                Storyboard sb_ataque = (Storyboard)this.Resources["Atacar"];
                sb_ataque.Begin();
                Energia = Energia - 10;
            }

        }

        public void ataque()
        {
            if ((Vida <= 0))
            {
                Storyboard sb_cansado_vida = (Storyboard)this.Resources["Cansado_Sin_Vida"];
                sb_cansado_vida.Begin();

            }
            else if ((Energia < 10))
            {
                Storyboard sb_cansado = (Storyboard)this.Resources["Cansado_Sin_Energia"];
                sb_cansado.Begin();
            }
            else
            {
                Storyboard sb_ataque = (Storyboard)this.Resources["Atacar"];
                sb_ataque.Begin();
                Energia = Energia - 10;
            }

        }

        private void protegerse(object sender, PointerRoutedEventArgs e)
        {
            if ((Vida <= 0))
            {
                Storyboard sb_cansado = (Storyboard)this.Resources["Cansado_Sin_Vida"];
                sb_cansado.Begin();
            }
            else
            {
                Storyboard sb_defensa = (Storyboard)this.Resources["Protegerse"];
                sb_defensa.Begin();
                Vida = Vida - 10;
                if ((Vida <= 30))
                {
                    HeridaCabeza.Visibility = Visibility.Visible;
                    HeridaCuerpo.Visibility = Visibility.Visible;
                    HeridaAla.Visibility = Visibility.Visible;
                }
                if (Vida <= 0)
                {
                    Vida = 0;
                    Ojos_parpados.Visibility = Visibility.Visible;
                    espiral_ojo_izq.Visibility = Visibility.Visible;
                    espiral_ojo_der.Visibility = Visibility.Visible;
                }
            }

        }

        private void volar(object sender, PointerRoutedEventArgs e)
        {
            if ((Vida <= 0))
            {
                Storyboard sb_cansado_vida = (Storyboard)this.Resources["Cansado_Sin_Vida"];
                sb_cansado_vida.Begin();
            }
            else if ((Energia < 5))
            {
                Storyboard sb_cansado = (Storyboard)this.Resources["Cansado_Sin_Energia"];
                sb_cansado.Begin();
            }
            else
            {
                Storyboard sb_v = (Storyboard)this.Resources["Volar"];
                Storyboard sb_v_c = (Storyboard)this.Resources["Volar_Cansado"];

                if ((Energia <= 30))
                {
                    sb_v_c.Begin();
                }
                else
                {
                    sb_v.Begin();
                }
                Energia = Energia - 5;
            }

        }

        private void dormir(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sb_dormir = (Storyboard)this.Resources["Descansar"];
            sb_dormir.Begin();
            espiral_ojo_der.Visibility = Visibility.Collapsed;
            espiral_ojo_izq.Visibility = Visibility.Collapsed;
            if (Vida < 100)
            {
                Vida = Vida + 5;
                if (Vida >= 100)
                {
                    Vida = 100;
                }
                if (Vida > 30)
                {
                    HeridaAla.Visibility = Visibility.Collapsed;
                    HeridaCabeza.Visibility = Visibility.Collapsed;
                    HeridaCuerpo.Visibility = Visibility.Collapsed;
                }
            }

            if (Energia < 100)
            {
                Energia = Energia + 20;
                if (Energia >= 100)
                {
                    Energia = 100;
                }
            }
        }


        private void mano_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
        }

        private void flecha_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Windows.UI.Xaml.Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
        }
    }
}
