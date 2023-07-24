using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace EPOAM_04
{
    class Electrodomestico
    {
        private const int precioBase = 100;

        private int precio = precioBase;
        private string color = "blanco";
        private char consumoEnergetico = (char)70;
        private int peso = 5;

        public int PrecioBase { get { return this.precio; } set { this.precio = value; } }

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

        public virtual void PrecioFinal()
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

    class Lavadora : Electrodomestico
    {
        private const int cargaBase = 5;

        int carga = cargaBase;

        public Lavadora() { }

        public Lavadora(int precio, int peso) : base(precio, peso)
        {

        }

        public Lavadora(int precio, string color, char consumoEnergetico, int peso, int carga) : base(precio, color, consumoEnergetico, peso)
        {
            this.carga = carga;
        }

        public int Carga { get { return carga; } }

        public override void PrecioFinal()
        {
            base.PrecioFinal();

            if (carga >= 30)
            {
                PrecioBase += 50;
            }
        }
    }

    class Television : Electrodomestico {
       
        private int resolucion = 20;
        private bool sintonizadorTDT = false;

        public Television() { }

        public Television(int precio, int peso) : base(precio, peso) { }

        public Television(int precioBase, string color, char consumoEnergetico, int peso, int resolucion, bool sintonizadorTDT) : base(precioBase, color, consumoEnergetico, peso){
            this.resolucion = resolucion; 
            this.sintonizadorTDT = sintonizadorTDT;
        }
            
        public int Resolucion { get { return this.resolucion; } }

        public bool SintonizadorTDT { get { return sintonizadorTDT; } }

        public override void PrecioFinal()
        {
            base.PrecioFinal();
            if ( Resolucion > 40){
                PrecioBase += (PrecioBase / 100) * 30;
            }

            if (SintonizadorTDT){
                PrecioBase += 50;
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args) {
            Electrodomestico[] array = new Electrodomestico[10];
            array[0] = new Television(3, 5);
            array[1] = new Lavadora();
            array[2] = new Lavadora(3, "negro", (char)72, 5, 6);
            array[3] = new Television(5, 1);
            array[4] = new Electrodomestico(5, 1);
            array[5] = new Lavadora(352, "blanca", (char)53, 15, 943);
            array[6] = new Television(500, "amarilla", (char)70, 23, 50, true);
            array[7] = new Television(500, "amarilla", (char)70, 23, 50, false);
            array[8] = new Television(500, "amarilla", (char)70, 23, 3, false);
            array[9] = new Television(500, "roja", (char)72, 23, 3, false);

            int preciotele = 0;
            int preciolavadora = 0;
            int preciotodo = 0;

            for (int i = 0; i < array.Length; i++)
            {
                array[i].PrecioFinal();
            }

            for (int i = 0; i < array.Length; i++)
            {
                preciotele += array[i] is Television ? array[i].PrecioBase : 0;
                preciolavadora += array[i] is Lavadora ? array[i].PrecioBase : 0;
                preciotodo += array[i].PrecioBase;

            }

            Console.WriteLine($"el precio de los televisores es de {preciotele}");
            Console.WriteLine($"el precio de las lavadoras es de {preciolavadora}");
            Console.WriteLine($"el precio total es de {preciotodo}");

            Console.ReadKey();




        }
    }
}
