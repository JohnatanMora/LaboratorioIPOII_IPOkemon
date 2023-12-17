using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class Combate1J : Page
    {
        UserControl_Beedrill fv_beedrill_seleccionado1;
        UserControl_Beedrill fv_beedrill_seleccionado2;
        UserControl_Mankey fv_mankey_seleccionado1;
        UserControl_Mankey fv_mankey_seleccionado2;
        UserControl_Squirtle fv_squirtle_seleccionado1;
        UserControl_Squirtle fv_squirtle_seleccionado2;
        int turno;

        public Combate1J()
        {
            this.InitializeComponent();
        }

        private async void btn_jug1_Click(object sender, RoutedEventArgs e)
        {
            fv_jugador1.IsEnabled = false;
            if (fv_jugador1.SelectedIndex == 0)
            {
                fv_beedrill_seleccionado1 = fv_jugador1.SelectedItem as UserControl_Beedrill;
            }
            else if (fv_jugador1.SelectedIndex == 1)
            {
                fv_mankey_seleccionado1 = fv_jugador1.SelectedItem as UserControl_Mankey;
            }
            else if (fv_jugador1.SelectedIndex == 2)
            {
                fv_squirtle_seleccionado1 = fv_jugador1.SelectedItem as UserControl_Squirtle;
            }
            btn_jug1.Visibility = Visibility.Collapsed;
            if (fv_jugador1.IsEnabled == false & fv_jugador2.IsEnabled == false)
            {
                turno = sorteo_inicio();
                if (turno == 1)
                {
                    bloqueo_jug2();
                }
                else
                {
                    bloqueo_jug1();
                    await Task.Delay(3000);
                    turno_maquina();
                }
            }
        }

        private async void btn_jug2_Click(object sender, RoutedEventArgs e)
        {
            fv_jugador2.IsEnabled = false;
            if (fv_jugador2.SelectedIndex == 0)
            {
                fv_beedrill_seleccionado2 = fv_jugador2.SelectedItem as UserControl_Beedrill;
            }
            else if (fv_jugador2.SelectedIndex == 1)
            {
                fv_mankey_seleccionado2 = fv_jugador2.SelectedItem as UserControl_Mankey;
            }
            else if (fv_jugador2.SelectedIndex == 2)
            {
                fv_squirtle_seleccionado2 = fv_jugador2.SelectedItem as UserControl_Squirtle;
            }
            btn_jug2.Visibility = Visibility.Collapsed;
            if (fv_jugador1.IsEnabled == false & fv_jugador2.IsEnabled == false)
            {
                turno = sorteo_inicio();
                if (turno == 1)
                {
                    bloqueo_jug2();
                }
                else
                {
                    bloqueo_jug1();
                    await Task.Delay(3000);
                    turno_maquina();
                }
            }
        }

        private async void btn_atacar1_Click(object sender, RoutedEventArgs e)
        {
            if (fv_jugador1.SelectedIndex == 0 & fv_jugador2.SelectedIndex == 0)
            {
                fv_beedrill_seleccionado1.ataque();
                fv_beedrill_seleccionado2.Vida -= calcular_dano();
                controles_jug1.Visibility = Visibility.Collapsed;
                jug1_espera.Text = "El jugador 1 ha decidido atacar.";
                jug1_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                if (fv_beedrill_seleccionado2.Vida <= 0)
                {
                    fondo_combate.Visibility = Visibility.Visible;
                    mensaje_victoria.Text = "El jugador 1 ha ganado el combate.";
                    mensaje_victoria.Visibility = Visibility.Visible;
                }
                else
                {
                    bloqueo_jug1();
                    turno_maquina();
                    await Task.Delay(3000);
                }
            }
            else if (fv_jugador1.SelectedIndex == 0 & fv_jugador2.SelectedIndex == 1)
            {
                fv_beedrill_seleccionado1.ataque();
                fv_mankey_seleccionado2.Vida -= calcular_dano();
                controles_jug1.Visibility = Visibility.Collapsed;
                jug1_espera.Text = "El jugador 1 ha decidido atacar.";
                jug1_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                if (fv_mankey_seleccionado2.Vida <= 0)
                {
                    fondo_combate.Visibility = Visibility.Visible;
                    mensaje_victoria.Text = "El jugador 1 ha ganado el combate.";
                    mensaje_victoria.Visibility = Visibility.Visible;
                }
                else
                {
                    bloqueo_jug1();
                    turno_maquina();
                    await Task.Delay(3000);
                }
            }
            else if (fv_jugador1.SelectedIndex == 0 & fv_jugador2.SelectedIndex == 2)
            {
                fv_beedrill_seleccionado1.ataque();
                fv_squirtle_seleccionado2.Vida -= calcular_dano();
                controles_jug1.Visibility = Visibility.Collapsed;
                jug1_espera.Text = "El jugador 1 ha decidido atacar.";
                jug1_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                if (fv_squirtle_seleccionado2.Vida <= 0)
                {
                    fondo_combate.Visibility = Visibility.Visible;
                    mensaje_victoria.Text = "El jugador 1 ha ganado el combate.";
                    mensaje_victoria.Visibility = Visibility.Visible;
                }
                else
                {
                    bloqueo_jug1();
                    turno_maquina();
                    await Task.Delay(3000);
                }
            }
            else if (fv_jugador1.SelectedIndex == 1 & fv_jugador2.SelectedIndex == 0)
            {
                fv_mankey_seleccionado1.punetazo();
                fv_beedrill_seleccionado2.Vida -= calcular_dano();
                controles_jug1.Visibility = Visibility.Collapsed;
                jug1_espera.Text = "El jugador 1 ha decidido atacar.";
                jug1_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                if (fv_beedrill_seleccionado2.Vida <= 0)
                {
                    fondo_combate.Visibility = Visibility.Visible;
                    mensaje_victoria.Text = "El jugador 1 ha ganado el combate.";
                    mensaje_victoria.Visibility = Visibility.Visible;
                }
                else
                {
                    bloqueo_jug1();
                    turno_maquina();
                    await Task.Delay(3000);
                }
            }
            else if (fv_jugador1.SelectedIndex == 1 & fv_jugador2.SelectedIndex == 1)
            {
                fv_mankey_seleccionado1.punetazo();
                fv_mankey_seleccionado2.Vida -= calcular_dano();
                controles_jug1.Visibility = Visibility.Collapsed;
                jug1_espera.Text = "El jugador 1 ha decidido atacar.";
                jug1_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                if (fv_mankey_seleccionado2.Vida <= 0)
                {
                    fondo_combate.Visibility = Visibility.Visible;
                    mensaje_victoria.Text = "El jugador 1 ha ganado el combate.";
                    mensaje_victoria.Visibility = Visibility.Visible;
                }
                else
                {
                    bloqueo_jug1();
                    turno_maquina();
                    await Task.Delay(3000);
                }
            }
            else if (fv_jugador1.SelectedIndex == 1 & fv_jugador2.SelectedIndex == 2)
            {
                fv_mankey_seleccionado1.punetazo();
                fv_squirtle_seleccionado2.Vida -= calcular_dano();
                controles_jug1.Visibility = Visibility.Collapsed;
                jug1_espera.Text = "El jugador 1 ha decidido atacar.";
                jug1_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                if (fv_squirtle_seleccionado2.Vida <= 0)
                {
                    fondo_combate.Visibility = Visibility.Visible;
                    mensaje_victoria.Text = "El jugador 1 ha ganado el combate.";
                    mensaje_victoria.Visibility = Visibility.Visible;
                }
                else
                {
                    bloqueo_jug1();
                    turno_maquina();
                    await Task.Delay(3000);
                }
            }
            else if (fv_jugador1.SelectedIndex == 2 & fv_jugador2.SelectedIndex == 0)
            {
                fv_squirtle_seleccionado1.button_pistolaAgua();
                fv_beedrill_seleccionado2.Vida -= calcular_dano();
                controles_jug1.Visibility = Visibility.Collapsed;
                jug1_espera.Text = "El jugador 1 ha decidido atacar.";
                jug1_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                if (fv_beedrill_seleccionado2.Vida <= 0)
                {
                    fondo_combate.Visibility = Visibility.Visible;
                    mensaje_victoria.Text = "El jugador 1 ha ganado el combate.";
                    mensaje_victoria.Visibility = Visibility.Visible;
                }
                else
                {
                    bloqueo_jug1();
                    turno_maquina();
                    await Task.Delay(3000);
                }
            }
            else if (fv_jugador1.SelectedIndex == 2 & fv_jugador2.SelectedIndex == 1)
            {
                fv_squirtle_seleccionado1.button_pistolaAgua();
                fv_mankey_seleccionado2.Vida -= calcular_dano();
                controles_jug1.Visibility = Visibility.Collapsed;
                jug1_espera.Text = "El jugador 1 ha decidido atacar.";
                jug1_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                if (fv_mankey_seleccionado2.Vida <= 0)
                {
                    fondo_combate.Visibility = Visibility.Visible;
                    mensaje_victoria.Text = "El jugador 1 ha ganado el combate.";
                    mensaje_victoria.Visibility = Visibility.Visible;
                }
                else
                {
                    bloqueo_jug1();
                    turno_maquina();
                    await Task.Delay(3000);
                }
            }
            else if (fv_jugador1.SelectedIndex == 2 & fv_jugador2.SelectedIndex == 2)
            {
                fv_squirtle_seleccionado1.button_pistolaAgua();
                fv_squirtle_seleccionado2.Vida -= calcular_dano();
                controles_jug1.Visibility = Visibility.Collapsed;
                jug1_espera.Text = "El jugador 1 ha decidido atacar.";
                jug1_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                if (fv_squirtle_seleccionado2.Vida <= 0)
                {
                    fondo_combate.Visibility = Visibility.Visible;
                    mensaje_victoria.Text = "El jugador 1 ha ganado el combate.";
                    mensaje_victoria.Visibility = Visibility.Visible;
                }
                else
                {
                    bloqueo_jug1();
                    turno_maquina();
                    await Task.Delay(3000);
                }
            }
        }

        private async void btn_curar1_Click(object sender, RoutedEventArgs e)
        {
            if (fv_jugador1.SelectedIndex == 0)
            {
                if (fv_beedrill_seleccionado1.Vida > 75)
                {
                    fv_beedrill_seleccionado1.Vida = 100;
                }
                else
                {
                    fv_beedrill_seleccionado1.Vida += 25;
                }
                controles_jug1.Visibility = Visibility.Collapsed;
                jug1_espera.Text = "El jugador 1 ha decidido curarse.";
                jug1_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug1();
                turno_maquina();
                await Task.Delay(3000);

            }
            else if (fv_jugador1.SelectedIndex == 1)
            {
                if (fv_mankey_seleccionado1.Vida > 75)
                {
                    fv_mankey_seleccionado1.Vida = 100;
                }
                else
                {
                    fv_mankey_seleccionado1.Vida += 25;
                }
                controles_jug1.Visibility = Visibility.Collapsed;
                jug1_espera.Text = "El jugador 1 ha decidido curarse.";
                jug1_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug1();
                turno_maquina();
                await Task.Delay(3000);
            }
            else if (fv_jugador1.SelectedIndex == 2)
            {
                if (fv_squirtle_seleccionado1.Vida > 75)
                {
                    fv_squirtle_seleccionado1.Vida = 100;
                }
                else
                {
                    fv_squirtle_seleccionado1.Vida += 25;
                }
                controles_jug1.Visibility = Visibility.Collapsed;
                jug1_espera.Text = "El jugador 1 ha decidido curarse.";
                jug1_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug1();
                turno_maquina();
                await Task.Delay(3000);
            }
        }

        private async void btn_subirEnergia1_Click(object sender, RoutedEventArgs e)
        {
            if (fv_jugador1.SelectedIndex == 0)
            {
                if (fv_beedrill_seleccionado1.Energia > 75)
                {
                    fv_beedrill_seleccionado1.Energia = 100;
                }
                else
                {
                    fv_beedrill_seleccionado1.Energia += 25;
                }
                controles_jug1.Visibility = Visibility.Collapsed;
                jug1_espera.Text = "El jugador 1 ha decidido subir la energía.";
                jug1_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug1();
                turno_maquina();
                await Task.Delay(3000);
            }
            else if (fv_jugador1.SelectedIndex == 1)
            {
                if (fv_mankey_seleccionado1.Energia > 75)
                {
                    fv_mankey_seleccionado1.Energia = 100;
                }
                else
                {
                    fv_mankey_seleccionado1.Energia += 25;
                }
                controles_jug1.Visibility = Visibility.Collapsed;
                jug1_espera.Text = "El jugador 1 ha decidido subir la energía.";
                jug1_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug1();
                turno_maquina();
                await Task.Delay(3000);
            }
            else if (fv_jugador1.SelectedIndex == 2)
            {
                if (fv_squirtle_seleccionado1.Energia > 75)
                {
                    fv_squirtle_seleccionado1.Energia = 100;
                }
                else
                {
                    fv_squirtle_seleccionado1.Energia += 25;
                }
                controles_jug1.Visibility = Visibility.Collapsed;
                jug1_espera.Text = "El jugador 1 ha decidido subir la energía.";
                jug1_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug1();
                turno_maquina();
                await Task.Delay(3000);
            }
        }

        private async void atacar2()
        {
            if (fv_jugador2.SelectedIndex == 0 & fv_jugador1.SelectedIndex == 0)
            {
                fv_beedrill_seleccionado2.ataque();
                fv_beedrill_seleccionado1.Vida -= calcular_dano();
                jug2_espera.Text = "La máquina ha decidido atacar.";
                jug2_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                if (fv_beedrill_seleccionado1.Vida <= 0)
                {
                    fondo_combate.Visibility = Visibility.Visible;
                    mensaje_victoria.Text = "La máquina ha ganado el combate.";
                    mensaje_victoria.Visibility = Visibility.Visible;
                }
                else
                {
                    bloqueo_jug2();
                }
            }
            else if (fv_jugador2.SelectedIndex == 0 & fv_jugador1.SelectedIndex == 1)
            {
                fv_beedrill_seleccionado2.ataque();
                fv_mankey_seleccionado1.Vida -= calcular_dano();
                jug2_espera.Text = "La máquina ha decidido atacar.";
                jug2_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                if (fv_mankey_seleccionado1.Vida <= 0)
                {
                    fondo_combate.Visibility = Visibility.Visible;
                    mensaje_victoria.Text = "La máquina ha ganado el combate.";
                    mensaje_victoria.Visibility = Visibility.Visible;
                }
                else
                {
                    bloqueo_jug2();
                }
            }
            else if (fv_jugador2.SelectedIndex == 0 & fv_jugador1.SelectedIndex == 2)
            {
                fv_beedrill_seleccionado2.ataque();
                fv_squirtle_seleccionado1.Vida -= calcular_dano();
                jug2_espera.Text = "La máquina ha decidido atacar.";
                jug2_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                if (fv_squirtle_seleccionado1.Vida <= 0)
                {
                    fondo_combate.Visibility = Visibility.Visible;
                    mensaje_victoria.Text = "La máquina ha ganado el combate.";
                    mensaje_victoria.Visibility = Visibility.Visible;
                }
                else
                {
                    bloqueo_jug2();
                }
            }
            else if (fv_jugador2.SelectedIndex == 1 & fv_jugador1.SelectedIndex == 0)
            {
                fv_mankey_seleccionado2.punetazo();
                fv_beedrill_seleccionado1.Vida -= calcular_dano();
                jug2_espera.Text = "La máquina ha decidido atacar.";
                jug2_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                if (fv_beedrill_seleccionado1.Vida <= 0)
                {
                    fondo_combate.Visibility = Visibility.Visible;
                    mensaje_victoria.Text = "La máquina ha ganado el combate.";
                    mensaje_victoria.Visibility = Visibility.Visible;
                }
                else
                {
                    bloqueo_jug2();
                }
            }
            else if (fv_jugador2.SelectedIndex == 1 & fv_jugador1.SelectedIndex == 1)
            {
                fv_mankey_seleccionado2.punetazo();
                fv_mankey_seleccionado1.Vida -= calcular_dano();
                jug2_espera.Text = "La máquina ha decidido atacar.";
                jug2_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                if (fv_mankey_seleccionado1.Vida <= 0)
                {
                    fondo_combate.Visibility = Visibility.Visible;
                    mensaje_victoria.Text = "La máquina ha ganado el combate.";
                    mensaje_victoria.Visibility = Visibility.Visible;
                }
                else
                {
                    bloqueo_jug2();
                }
            }
            else if (fv_jugador2.SelectedIndex == 1 & fv_jugador1.SelectedIndex == 2)
            {
                fv_mankey_seleccionado2.punetazo();
                fv_squirtle_seleccionado1.Vida -= calcular_dano();
                jug2_espera.Text = "La máquina ha decidido atacar.";
                jug2_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                if (fv_squirtle_seleccionado1.Vida <= 0)
                {
                    fondo_combate.Visibility = Visibility.Visible;
                    mensaje_victoria.Text = "La máquina ha ganado el combate.";
                    mensaje_victoria.Visibility = Visibility.Visible;
                }
                else
                {
                    bloqueo_jug2();
                }
            }
            else if (fv_jugador2.SelectedIndex == 2 & fv_jugador1.SelectedIndex == 0)
            {
                fv_squirtle_seleccionado2.button_pistolaAgua();
                fv_beedrill_seleccionado1.Vida -= calcular_dano();
                jug2_espera.Text = "La máquina ha decidido atacar.";
                jug2_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                if (fv_beedrill_seleccionado1.Vida <= 0)
                {
                    fondo_combate.Visibility = Visibility.Visible;
                    mensaje_victoria.Text = "La máquina ha ganado el combate.";
                    mensaje_victoria.Visibility = Visibility.Visible;
                }
                else
                {
                    bloqueo_jug2();
                }
            }
            else if (fv_jugador2.SelectedIndex == 2 & fv_jugador1.SelectedIndex == 1)
            {
                fv_squirtle_seleccionado2.button_pistolaAgua();
                fv_mankey_seleccionado1.Vida -= calcular_dano();
                jug2_espera.Text = "La máquina ha decidido atacar.";
                jug2_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                if (fv_mankey_seleccionado1.Vida <= 0)
                {
                    fondo_combate.Visibility = Visibility.Visible;
                    mensaje_victoria.Text = "La máquina ha ganado el combate.";
                    mensaje_victoria.Visibility = Visibility.Visible;
                }
                else
                {
                    bloqueo_jug2();
                }
            }
            else if (fv_jugador2.SelectedIndex == 2 & fv_jugador1.SelectedIndex == 2)
            {
                fv_squirtle_seleccionado2.button_pistolaAgua();
                fv_squirtle_seleccionado1.Vida -= calcular_dano();
                jug2_espera.Text = "La máquina ha decidido atacar.";
                jug2_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                if (fv_squirtle_seleccionado1.Vida <= 0)
                {
                    fondo_combate.Visibility = Visibility.Visible;
                    mensaje_victoria.Text = "La máquina ha ganado el combate.";
                    mensaje_victoria.Visibility = Visibility.Visible;
                }
                else
                {
                    bloqueo_jug2();
                }
            }
        }

        public async void curar2()
        {
            if (fv_jugador2.SelectedIndex == 0)
            {
                if (fv_beedrill_seleccionado2.Vida > 75)
                {
                    fv_beedrill_seleccionado2.Vida = 100;
                }
                else
                {
                    fv_beedrill_seleccionado2.Vida += 25;
                }
                jug2_espera.Text = "La máquina ha decidido curarse.";
                jug2_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug2();

            }
            else if (fv_jugador2.SelectedIndex == 1)
            {
                if (fv_mankey_seleccionado2.Vida > 75)
                {
                    fv_mankey_seleccionado2.Vida = 100;
                }
                else
                {
                    fv_mankey_seleccionado2.Vida += 25;
                }
                jug2_espera.Text = "La máquina ha decidido curarse.";
                jug2_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug2();
            }
            else if (fv_jugador2.SelectedIndex == 2)
            {
                if (fv_squirtle_seleccionado2.Vida > 75)
                {
                    fv_squirtle_seleccionado2.Vida = 100;
                }
                else
                {
                    fv_squirtle_seleccionado2.Vida += 25;
                }
                jug2_espera.Text = "La máquina ha decidido curarse.";
                jug2_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug2();
            }
        }

        public async void subirEnergia2()
        {
            if (fv_jugador2.SelectedIndex == 0)
            {
                if (fv_beedrill_seleccionado2.Energia > 75)
                {
                    fv_beedrill_seleccionado2.Energia = 100;
                }
                else
                {
                    fv_beedrill_seleccionado2.Energia += 25;
                }
                jug2_espera.Text = "La máquina ha decidido subir la energía.";
                jug2_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug2();
            }
            else if (fv_jugador2.SelectedIndex == 1)
            {
                if (fv_mankey_seleccionado2.Energia > 75)
                {
                    fv_mankey_seleccionado2.Energia = 100;
                }
                else
                {
                    fv_mankey_seleccionado2.Energia += 25;
                }
                jug2_espera.Text = "La máquina ha decidido subir la energía.";
                jug2_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug2();
            }
            else if (fv_jugador2.SelectedIndex == 2)
            {
                if (fv_squirtle_seleccionado2.Energia > 75)
                {
                    fv_squirtle_seleccionado2.Energia = 100;
                }
                else
                {
                    fv_squirtle_seleccionado2.Energia += 25;
                }
                jug2_espera.Text = "La máquina ha decidido subir la energía.";
                jug2_espera.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                bloqueo_jug2();
            }

        }

        public int sorteo_inicio()
        {
            Random r = new Random();
            int num = r.Next(1, 3);
            return num;
        }

        public void bloqueo_jug1()
        {
            controles_jug1.Visibility = Visibility.Collapsed;
            jug1_espera.Text = "Turno de la máquina, espera tu turno.";
            jug1_espera.Visibility = Visibility.Visible;
            jug2_espera.Visibility = Visibility.Collapsed;
        }

        public void bloqueo_jug2()
        {
            jug2_espera.Text = "Turno del jugador 1, espera tu turno.";
            jug2_espera.Visibility = Visibility.Visible;
            jug1_espera.Visibility = Visibility.Collapsed;
            controles_jug1.Visibility = Visibility.Visible;
        }

        private void btn_rendirse1_Click(object sender, RoutedEventArgs e)
        {
            fondo_combate.Visibility = Visibility.Visible;
            mensaje_victoria.Text = "La máquina ha ganado el combate.";
            mensaje_victoria.Visibility = Visibility.Visible;
        }

        public int calcular_dano()
        {
            int dano = 0;
            Random r = new Random();
            int num = r.Next(1, 100);
            if (num < 45)
            {
                dano = 20;
            }
            else if (num <= 90)
            {
                dano = (int)Math.Round((double)num / 3);
            }
            else
            {
                dano = 40;
            }
            return dano;
        }

        public void turno_maquina()
        {
            Random r = new Random();
            int num = r.Next(1, 4);
            if (fv_jugador2.SelectedIndex == 0)
            {
                if (fv_beedrill_seleccionado2.Vida > 30 & fv_beedrill_seleccionado2.Energia > 30)
                {
                    atacar2();
                }
                else if (fv_beedrill_seleccionado2.Vida <= 30)
                {
                    curar2();
                }
                else
                {
                    subirEnergia2();
                }
            }
            else if (fv_jugador2.SelectedIndex == 1)
            {
                if (fv_mankey_seleccionado2.Vida > 30 & fv_mankey_seleccionado2.Energia > 30)
                {
                    atacar2();
                }
                else if (fv_mankey_seleccionado2.Vida <= 30)
                {
                    curar2();
                }
                else
                {
                    subirEnergia2();
                }
            }
            else
            {
                if (fv_squirtle_seleccionado2.Vida > 30 & fv_squirtle_seleccionado2.Energia > 30)
                {
                    atacar2();
                }
                else if (fv_squirtle_seleccionado2.Vida <= 30)
                {
                    curar2();
                }
                else
                {
                    subirEnergia2();
                }
            }
            /*switch (num)
            {
                case 1:
                    atacar2();
                    break;
                case 2:
                    curar2();
                    break;
                case 3:
                    subirEnergia2();
                    break;

            }*/
        }

    }
}
