﻿#pragma checksum "C:\Users\PARA MSI\OneDrive\Escritorio\PokemonGrupal\Grupo\AplicacionPokemon (2)\AplicacionPokemon\AplicacionPokemon\CombatePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3EDF47ED9487860416029823FB693AB32F6277AC8B8322C794442190191E664C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AplicacionPokemon
{
    partial class CombatePage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // CombatePage.xaml line 31
                {
                    this.fv_jugador1 = (global::Windows.UI.Xaml.Controls.FlipView)(target);
                }
                break;
            case 3: // CombatePage.xaml line 37
                {
                    this.fv_jugador2 = (global::Windows.UI.Xaml.Controls.FlipView)(target);
                }
                break;
            case 4: // CombatePage.xaml line 42
                {
                    this.btn_jug1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btn_jug1).Click += this.btn_jug1_Click;
                }
                break;
            case 5: // CombatePage.xaml line 43
                {
                    this.btn_jug2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btn_jug2).Click += this.btn_jug2_Click;
                }
                break;
            case 6: // CombatePage.xaml line 44
                {
                    this.controles_jug1 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 7: // CombatePage.xaml line 59
                {
                    this.controles_jug2 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 8: // CombatePage.xaml line 68
                {
                    this.btn_ataque_jug2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btn_ataque_jug2).Click += this.btn_atacar2_Click;
                }
                break;
            case 9: // CombatePage.xaml line 69
                {
                    this.btn_curar_jug2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btn_curar_jug2).Click += this.btn_curar2_Click;
                }
                break;
            case 10: // CombatePage.xaml line 70
                {
                    this.btn_energia_jug2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btn_energia_jug2).Click += this.btn_subirEnergia2_Click;
                }
                break;
            case 11: // CombatePage.xaml line 71
                {
                    this.btn_rendirse_jug2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 12: // CombatePage.xaml line 53
                {
                    this.btn_ataque_jug1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btn_ataque_jug1).Click += this.btn_atacar1_Click;
                }
                break;
            case 13: // CombatePage.xaml line 54
                {
                    this.btn_curar_jug1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btn_curar_jug1).Click += this.btn_curar1_Click;
                }
                break;
            case 14: // CombatePage.xaml line 55
                {
                    this.btn_energia_jug1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btn_energia_jug1).Click += this.btn_subirEnergia1_Click;
                }
                break;
            case 15: // CombatePage.xaml line 56
                {
                    this.btn_rendirse_jug1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 0.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

