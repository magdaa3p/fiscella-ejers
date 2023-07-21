using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace EPOAM_04
{
    class Electrodomestico
    {
        private const int precioBase = 100;

        public int precio = precioBase;
        private string color = "blanco";
        private char consumoEnergetico = (char)70;
        private int peso = 5;

        public int PrecioBase { get { return this.precio; } }

        public string Color { get { return this.color; } }

        public char ConsumoEnergetico { get { return this.consumoEnergetico; } }

        public int Peso { get { return this.peso; } }

        public Electrodomestico(){ }

        public Electrodomestico(int precio, int peso)
        {
            this.precio = precio;
            this.peso = peso;
        }

        public Electrodomestico(int precioBase, string color, char consumoEnergetico, int peso)
        {
            this.precio = precioBase;
            this.color = color;
            this.consumoEnergetico = consumoEnergetico;
            this.peso = peso;
        }

        public bool ComprobarConsumoEnergico(char letra)
        {
            bool valido = false;

            for (int i = 0; i < 6; i++)
            {
                if (letra == Convert.ToChar((LetrasDisponibles)i)) 
                {
                    valido = true; break;
                }
            }


            return valido;
        } 

        public bool ComprobarColor(string color){
            bool valido = false;
            for (int i = 0; i < 5; i++)
            {
                if(color == Convert.ToString((ColoresDisponibles)i))
                {
                    valido = true; 
                }
            }
            return valido;       
        }

        public void PrecioFinal()
        {
            switch (this.consumoEnergetico)
            {
                case (char)65:
                    this.precio += 100;
                    break;
                case (char)66:
                    this.precio += 80;
                    break;
                case (char)67:
                    this.precio += 60;
                    break;
                case (char)68:
                    this.precio += 50;
                    break;
                case (char)69:
                    this.precio += 30;
                    break;
                case (char)70:
                    this.precio += 10;
                    break;
            }

            if (peso >= 0 && peso <= 19)
            {
                precio += 10;
            }
            else if(peso >= 20 && peso <= 49)
            {
                precio += 50;
            }
            else if(peso >= 50 && peso <= 79)
            {
                precio += 80;
            }
            else if(peso >= 80)
            {
                precio += 100;
            }
           
        }
    }

    enum LetrasDisponibles { A, B, C, D, E, F }
    enum ColoresDisponibles { blanco, negro, rojo, azul, gris }


    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
