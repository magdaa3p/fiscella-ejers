using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer_03
{
    class Password
    {
        string contraseña;
        int longitud = 8;

        int mayusculas;
        int minusculas;
        int numeros;

        public Password()
        {
            contraRandom();
        }

        public Password(int longitud)
        {
             this.longitud = longitud;
             contraRandom();
        }

        public bool esFuerte()
        {
            return (mayusculas > 2 && minusculas > 1 && numeros > 5) ? true : false;

        }

        public void contraRandom()
        {
            Random randi = new Random();
            int tiporandom;
            string contra = "";


            for (int i = 0; i < longitud; i++) {
                tiporandom = randi.Next(1, 4);
                switch (tiporandom)
                {
                    case 1:
                        contra = contra + (char)randi.Next(97, 123);
                        mayusculas++;
                        break;

                    case 2:
                        contra = contra + (char)randi.Next(65, 91);
                        minusculas++;
                        break;

                    case 3:
                        contra = contra + randi.Next(0, 10);
                        numeros++;
                        break;
                }
            }
            this.contraseña = contra;
        }

        public string Contraseña {
            get { return contraseña; }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("cuantas contraseñas queres crear?");
            int guardado = Convert.ToInt32(Console.ReadLine());
            Password[] passwords = new Password[guardado];
            int longitudIndividual;

            bool[] fuertes = new bool[guardado];

            for (int i = 0;i < guardado ;i++)
            {
                Console.WriteLine("cual es la longitud de la contraseña?");
                longitudIndividual = Convert.ToInt32(Console.ReadLine());
                passwords[i] = new Password(longitudIndividual);

                fuertes[i] = passwords[i].esFuerte();

                Console.WriteLine($"tu contraseña {passwords[i].Contraseña} y su fortaleza es: {fuertes[i]}");
                
            }

            Console.ReadKey();
        }
    }
}
