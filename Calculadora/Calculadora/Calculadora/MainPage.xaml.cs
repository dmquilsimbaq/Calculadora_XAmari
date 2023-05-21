using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculadora
{
    public partial class MainPage : ContentPage
    {
        public String operacion = "";
        public double numUno = 0, numdos=0, numRes=0;
        bool punto = false, unoDeci =false, dosDeci = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private void CadenaValores(String operador)
        {
            bool validarLbl = lblNumro.Text.GetType() != operacion.GetType();
            bool validarSpn = spnPrimero.Text.GetType() != operacion.GetType();
            if (numRes != 0 || (validarLbl && validarSpn) || (validarLbl || validarSpn))
                unoDeci = true;
            if (unoDeci)
                numUno = double.Parse(lblNumro.Text);
            else
                numUno = int.Parse(lblNumro.Text);
            spnPrimero.Text = numUno + " ";
            lblNumro.Text = "0";
            spnSegundo.Text = operador;
            operacion = operador;
            punto = false;

        }

        private bool Lleno()
        {
            bool lleno = false;
            if (spnPrimero.Text == "" && spnSegundo.Text == "")
                lleno = true;
            return lleno;
        }   

        private void IngresarNumero (String num)
        {
            if(lblNumro.Text == "0" && num != ".")
                lblNumro.Text = num;
            else
                lblNumro.Text += num;
        }

        private void Btn_limpiar(Object sender, EventArgs e)
        {
            numUno = 0;
            numdos = 0;
            numRes = 0;
            spnPrimero.Text = "";
            spnSegundo.Text = "";
            spntercero.Text = "";
            lblNumro.Text = "0";
            punto = false;
        }
        private void Btn_igual(Object sender, EventArgs e)
        {
            if (spnPrimero.Text != "" && spnSegundo.Text != "")
            {
                spntercero.Text = " " + lblNumro.Text;
                if (dosDeci)
                    numdos = double.Parse(lblNumro.Text);
                else
                    numdos = int.Parse(spntercero.Text);
                if (operacion == "+")
                {
                    numRes = numUno + numdos;
                    lblNumro.Text = numRes + "";
                }
                else if (operacion == "-")
                {
                    numRes = numUno - numdos;
                    lblNumro.Text = numRes + "";
                }
                else if (operacion == "*")
                {
                    numRes = numUno * numdos;
                    lblNumro.Text = numRes + "";
                }
                else 
                {
                    if (numdos == 0)
                        numdos = 1;
                    numRes = numUno / numdos;
                    lblNumro.Text = numRes + "";
                }
                numUno = 0;
                numdos = 0;
                numRes = 0;
                operacion = "/";
                unoDeci = false;
                dosDeci = false;
            }
            Console.WriteLine(spnPrimero.Text, spnSegundo.Text, spntercero.Text);
        }
        //operadores
        private void Btn_sumar(Object sender, EventArgs e)
        {
            CadenaValores("+");
            if (!Lleno())
                spntercero.Text = "";
        }
        private void Btn_restar(Object sender, EventArgs e)
        {
            CadenaValores("-");
            if (!Lleno())
                spntercero.Text = "";
        }
        private void Btn_dividir(Object sender, EventArgs e)
        {
            CadenaValores("/");
            if (!Lleno())
                spntercero.Text = "";
        }
        private void Btn_multiplicar(Object sender, EventArgs e)
        {
            CadenaValores("x");
            if (!Lleno())
                spntercero.Text = "";
        }

        //Numeros
        private void ClickCero(Object sender, EventArgs e)
        {
            if(lblNumro.Text != "0")
                IngresarNumero("0");
        }
        private void ClickUno(Object sender, EventArgs e)
        {
            IngresarNumero("1");
        }
        private void ClickDos(Object sender, EventArgs e)
        {
            IngresarNumero("2");
        }
        private void ClickTres(Object sender, EventArgs e)
        {
            IngresarNumero("3");
        }
        private void ClickCuatro(Object sender, EventArgs e)
        {
            IngresarNumero("4");
        }
        private void ClickCinco(Object sender, EventArgs e)
        {
            IngresarNumero("5");
        }
        private void ClickSeis(Object sender, EventArgs e)
        {
            IngresarNumero("6");
        }
        private void ClickSiete(Object sender, EventArgs e)
        {
            IngresarNumero("7");
        }
        private void ClickOcho(Object sender, EventArgs e)
        {
            IngresarNumero("8");
        }
        private void ClickNueve(Object sender, EventArgs e)
        {
            IngresarNumero("9");
        }
        private void ClickPunto(Object sender, EventArgs e)
        {
            if (!punto)
            {
                IngresarNumero(".");
                punto = true;
            }
            if (operacion == "/")
                unoDeci = true;
            else
                dosDeci = true;
        }
    }
}
