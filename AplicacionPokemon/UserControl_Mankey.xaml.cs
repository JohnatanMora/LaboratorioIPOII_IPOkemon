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
    public sealed partial class UserControl_Mankey : UserControl
    {
        public UserControl_Mankey()
        {
            this.InitializeComponent();
        }

        public double Vida
        {
            get { return this.ProgressBarVida.Value; }
            set { this.ProgressBarVida.Value = value; }
        }

        public double Energia
        {
            get { return this.ProgressBarEner.Value; }
            set { this.ProgressBarEner.Value = value; }
        }

        private void AumentarVida(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            double valorActual = ProgressBarVida.Value;
            valorActual += 10;
            if (valorActual > 100)
            {
                valorActual = 100;
            }
            ProgressBarVida.Value = valorActual;
        }

        private void AumentarEnergia(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            double valorActual = ProgressBarEner.Value;
            valorActual += 10;
            if (valorActual > 100)
            {
                valorActual = 100;
            }
            ProgressBarEner.Value = valorActual;
        }

        private void punetazo(object sender, PointerRoutedEventArgs e)
        {
            double valorActualEnergia = ProgressBarEner.Value;
            double valorActualSalud = ProgressBarVida.Value;
            if (valorActualSalud > 0 && valorActualEnergia > 0)
            {
                Storyboard sb_punetazo = (Storyboard)this.Resources["Puñetazo"];
                sb_punetazo.Begin();
                valorActualEnergia = valorActualEnergia - 10;
                ProgressBarEner.Value = valorActualEnergia;
            }
        }

        public void punetazo()
        {
            double valorActualEnergia = ProgressBarEner.Value;
            double valorActualSalud = ProgressBarVida.Value;
            if (valorActualSalud > 0 && valorActualEnergia > 0)
            {
                Storyboard sb_punetazo = (Storyboard)this.Resources["Puñetazo"];
                sb_punetazo.Begin();
                valorActualEnergia = valorActualEnergia - 10;
                ProgressBarEner.Value = valorActualEnergia;
            }
        }

        private void lati(object sender, PointerRoutedEventArgs e)
        {
            double valorActualEnergia = ProgressBarEner.Value;
            double valorActualSalud = ProgressBarVida.Value;
            if (valorActualSalud > 0 && valorActualEnergia > 0)
            {
                Storyboard sb_latigazo = (Storyboard)this.Resources["Latigazo"];
                sb_latigazo.Begin();
                valorActualEnergia = valorActualEnergia - 10;
                ProgressBarEner.Value = valorActualEnergia;
            }
        }

        private void dorm(object sender, PointerRoutedEventArgs e)
        {
            double valorActualSalud = ProgressBarVida.Value;
            double valorActualEnerg = ProgressBarEner.Value;
            if (valorActualSalud >= 0)
            {
                Storyboard sb_dorm = (Storyboard)this.Resources["Descansar"];
                sb_dorm.Begin();
                valorActualSalud = valorActualSalud + 30;
                valorActualEnerg = valorActualEnerg + 25;
                ProgressBarVida.Value = valorActualSalud;
                ProgressBarEner.Value = valorActualEnerg;
            }
        }
        private void golpeImaginario(object sender, PointerRoutedEventArgs e)
        {
            double valorActualSalud = ProgressBarVida.Value;
            if (valorActualSalud > 0)
            {

                valorActualSalud = valorActualSalud - 10;
                ProgressBarVida.Value = valorActualSalud;
            }
            else
            {
                Storyboard sb_ko = (Storyboard)this.Resources["KO"];
                sb_ko.Begin();
            }
        }

        private void esquivos(object sender, PointerRoutedEventArgs e)
        {
            double valorActualEnergia = ProgressBarEner.Value;
            double valorActualSalud = ProgressBarVida.Value;
            if (valorActualSalud > 0 && valorActualEnergia > 0)
            {
                Storyboard sb_esquivar = (Storyboard)this.Resources["Esquivar"];
                sb_esquivar.Begin();
                valorActualEnergia = valorActualEnergia - 10;
                ProgressBarEner.Value = valorActualEnergia;
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
                    this.punetazos.Visibility = Visibility.Collapsed;
                    this.aranaño.Visibility = Visibility.Collapsed;
                    this.esquivo.Visibility = Visibility.Collapsed;
                    this.recuperar.Visibility = Visibility.Collapsed;
                }
                else
                {
                    this.punetazos.Visibility = Visibility.Visible;
                    this.aranaño.Visibility = Visibility.Visible;
                    this.esquivo.Visibility = Visibility.Visible;
                    this.recuperar.Visibility = Visibility.Visible;
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
                if (!verFondo) this.fondoPokemon.Visibility = Visibility.Collapsed;
                else this.fondoPokemon.Visibility = Visibility.Visible;
            }

        }

        private bool verNombre = true;

        public bool Nombre
        {
            get { return verNombre = true; }
            set
            {
                this.verNombre = value;
                if (!verNombre) this.mankey.Visibility = Visibility.Collapsed;
                else this.mankey.Visibility = Visibility.Visible;
            }
        }

    }
}
