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
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace AplicacionPokemon
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Capturar : Page
    {
        UserControl_Beedrill fv_beedrill_seleccionado1;
        UserControl_Mankey fv_mankey_seleccionado1;
        UserControl_Squirtle fv_squirtle_seleccionado1;
        private int vida;

        public Capturar()
        {
            this.InitializeComponent();
        }

        private void btn_elegir_captura_click(object sender, RoutedEventArgs e)
        {
            {
                fv_pokemon_captura.IsEnabled = false;
                if (fv_pokemon_captura.SelectedIndex == 0)
                {
                    fv_beedrill_seleccionado1 = fv_pokemon_captura.SelectedItem as UserControl_Beedrill;
                }
                else if (fv_pokemon_captura.SelectedIndex == 1)
                {
                    fv_mankey_seleccionado1 = fv_pokemon_captura.SelectedItem as UserControl_Mankey;
                }
                else if (fv_pokemon_captura.SelectedIndex == 2)
                {
                    fv_squirtle_seleccionado1 = fv_pokemon_captura.SelectedItem as UserControl_Squirtle;
                }
                btn_elegir_captura.Visibility = Visibility.Collapsed;
                controles_captura.Visibility = Visibility.Visible;
            }
        }
        private void btn_atacar_Click(object sender, RoutedEventArgs e)
        {
            if (fv_pokemon_captura.SelectedIndex == 0)
            {
                fv_beedrill_seleccionado1.Vida -= 20;
                if (fv_beedrill_seleccionado1.Vida <= 0)
                {
                    fv_beedrill_seleccionado1.dormir();
                    controles_captura.Visibility = Visibility.Collapsed;
                    txt_debilitado.Visibility = Visibility.Visible;
                }

            }
            else if (fv_pokemon_captura.SelectedIndex == 1) {
                fv_mankey_seleccionado1.Vida -= 20;
                if (fv_mankey_seleccionado1.Vida <= 0)
                {
                    controles_captura.Visibility = Visibility.Collapsed;
                    txt_debilitado.Visibility = Visibility.Visible;
                }
            }
            else if(fv_pokemon_captura.SelectedIndex == 2)
            {
                fv_squirtle_seleccionado1.Vida -= 20;
                if (fv_squirtle_seleccionado1.Vida <= 0)
                {
                    fv_squirtle_seleccionado1.button_derrotado();
                    controles_captura.Visibility = Visibility.Collapsed;
                    txt_debilitado.Visibility = Visibility.Visible;
                }
            }

        }  

        public bool calcularCaptura(double vida)
        {
            double probabilidad = calcularProbabilidad(vida);
            Random random = new Random();
            double num = random.NextDouble();

            if (num <= probabilidad)
                return true;
            else
                return false;
        }

        public double calcularProbabilidad(double vida)
        {
            double probabilidad;

            if (vida >= 75)
            {
                probabilidad = 0.3;
            }
            else if (vida >= 50)
            {
                probabilidad = 0.5;
            }
            else if (vida >= 25)
            {
                probabilidad = 0.7;
            }
            else
            {
                probabilidad = 0.9;
            }

            return probabilidad;
        }

        public void capturado()
        {

            controles_captura.Visibility = Visibility.Collapsed;
            txt_capturado.Visibility = Visibility.Visible;

        }

        private void btn_capturar_click(object sender, RoutedEventArgs e)
        {

            if (fv_pokemon_captura.SelectedIndex == 0)
            {
                if (calcularCaptura(fv_beedrill_seleccionado1.Vida) == true)
                {
                    capturado();
                }

            }
            else if (fv_pokemon_captura.SelectedIndex == 1)
            {
                if (calcularCaptura(fv_mankey_seleccionado1.Vida) == true)
                {
                    capturado();
                }
            }
            else if (fv_pokemon_captura.SelectedIndex == 2)
            {
                if (calcularCaptura(fv_squirtle_seleccionado1.Vida) == true)
                {
                    capturado();
                }
            }

        }
        private void btn_huir_click(object sender, RoutedEventArgs e)
        {
            controles_captura.Visibility = Visibility.Collapsed;
            txt_huido.Visibility = Visibility.Visible;
        }


    }
}
