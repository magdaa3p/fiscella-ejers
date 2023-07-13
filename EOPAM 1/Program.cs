using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Crea una clase llamada Cuenta que tendrá los siguientes atributos: titular y cantidad (puede tener decimales).
El titular será obligatorio y la cantidad es opcional. Crea dos constructores que cumplan lo anterior.
Tendrá dos métodos especiales:
ingresar(double cantidad): se ingresa una cantidad a la cuenta, si la cantidad introducida es negativa, no se hará nada.
retirar(double cantidad): se retira una cantidad a la cuenta, si restando la cantidad actual a la que nos pasan es negativa, la cantidad de la cuenta pasa a ser 0.
*/

namespace EOPAM_1
{
    public class Cuenta {
        string titular;
        double cantidad;

        public Cuenta(string tituNuevo, double cantNuevo = 0) {
            this.titular = tituNuevo;
            this.cantidad = cantNuevo;
        }

        public void ingresar(double cantidad) {
            if (cantidad > 0) {
                this.cantidad += cantidad;
            }
        }

        public void retirar(double cantidad) {
            if (this.cantidad >= cantidad)
            {
                this.cantidad -= cantidad;
            }
            else {
                this.cantidad = 0;
            }
        }

        public double Cantidad{
            get { return this.cantidad; }
        }
        public string Titular {
            get { return this.titular; }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Cuenta cuenta1 = new Cuenta("a", 2.16);
            Cuenta cuenta2 = new Cuenta("a");

            Console.WriteLine($"Saldo total de la cuenta 1: {cuenta1.Cantidad}, nombre de la cuenta 1: {cuenta1.Titular}");
            Console.WriteLine($"Saldo total de la cuenta 2: {cuenta2.Cantidad}, nombre de la cuenta 2: {cuenta2.Titular}");

            Console.ReadKey(true);
        }
    }
}
