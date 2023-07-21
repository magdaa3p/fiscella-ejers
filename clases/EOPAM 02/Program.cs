using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
/*
Haz una clase llamada Persona que siga las siguientes condiciones:
Sus atributos son: nombre, edad, DNI, sexo (H hombre, M mujer), peso y altura. No queremos que se accedan directamente a ellos. Piensa que modificador de acceso es el más adecuado, también su tipo. Si quieres añadir algún atributo puedes hacerlo.
Por defecto, todos los atributos menos el DNI serán valores por defecto según su tipo (0 números, cadena vacía para String, etc.). Sexo sera hombre por defecto, usa una constante para ello.
Se implantaran varios constructores:
Un constructor por defecto.
Un constructor con el nombre, edad y sexo, el resto por defecto.
Un constructor con todos los atributos como parámetro.
Los métodos que se implementarán son:
calcularIMC(): calculará si la persona está en su peso ideal (peso en kg/(altura^2  en m)), si esta fórmula devuelve un valor menor que 20, la función devuelve un -1, si devuelve un número entre 20 y 25 (incluidos), significa que está por debajo de su peso ideal la función devuelve un 0  y si devuelve un valor mayor que 25 significa que tiene sobrepeso, la función devuelve un 1. Te recomiendo que uses constantes para devolver estos valores.
esMayorDeEdad(): indica si es mayor de edad, devuelve un booleano.
comprobarSexo(char sexo): comprueba que el sexo introducido es correcto. Si no es correcto, será H. No será visible al exterior.
generaDNI(): genera un número aleatorio de 8 cifras, genera a partir de este su número su letra correspondiente. Este método será invocado cuando se construya el objeto. Puedes dividir el método para que te sea más fácil. No será visible al exterior.
Métodos set de cada parámetro, excepto de DNI.
Ahora, crea una clase ejecutable que haga lo siguiente:
Pide por teclado el nombre, la edad, sexo, peso y altura.
Crea 3 objetos de la clase anterior, el primer objeto obtendrá las anteriores variables pedidas por teclado, el segundo objeto obtendrá todos los anteriores menos el peso y la altura y el último por defecto, para este último utiliza los métodos set para darle a los atributos un valor.
Para cada objeto, deberá comprobar si está en su peso ideal, tiene sobrepeso o por debajo de su peso ideal con un mensaje.
Indicar para cada objeto si es mayor de edad.
Por último, mostrar la información de cada objeto.
Puedes usar métodos en la clase ejecutable, para que os sea mas fácil.
*/
namespace EOPAM_02
{
    class Persona
    {
        const char hombre = (char)72;

        private string nombre = "";
        private int edad = 0;
        private string dni = "0";
        private char sexo = hombre;
        private float peso = 0;
        private float altura = 0;

        private Random randi = new Random();
        public Persona()
        {

        }

        public Persona(string nombre, int edad, char sexo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = ComprobarSexo(sexo);


            this.dni = GenerarDni();
        }

        public Persona(string nombre, int edad, char sexo, float peso, float altura)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = ComprobarSexo(sexo);
            this.peso = peso;
            this.altura = altura;

            this.dni = GenerarDni();
        }

        public float CalcularIMC()
        {
            return peso / (altura * altura);
        }

        public bool MayorEdad()
        {
            return edad >= 18 ? true : false;
        }

        public char ComprobarSexo(char sexo)
        {
            return (sexo == (char)77 || sexo == (char)72) ? sexo : (char)72;
        }

        public string GenerarDni()
        {
            if (!(ComprobarSexo(this.sexo) == (char)72 || ComprobarSexo(this.sexo) == (char)77))
            {
                this.sexo = randi.Next(6, 8) == 6 ? (char)72 : (char)77;
            }

            return randi.Next(10000000, 100000000).ToString();
        }

        public string Mostrar()
        {
            return $"Nombre: {nombre}, Edad: {edad}, Dni: {dni}, Sexo: {sexo}, Peso: {peso}, Altura: {altura}";
        }

        public string Nombre { get { return nombre; } set { nombre = value; } }

        public int Edad { get { return edad; } set { edad = value; } }

        public char Sexo { get { return sexo; } set { sexo = value; } }

        public float Peso { get { return peso; } set { peso = value; } }

        public float Altura { get { return altura; } set { altura = value; } }
    }


    internal class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("ingrese su nombre");
            string nomb = Console.ReadLine();

            Console.WriteLine("ingrese su edad");
            int edad = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("ingrese su peso");
            float peso = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("ingrese su altura");
            float altura = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("ingrese su sexo, M para mujer, H para hombre");
            char sexo = Convert.ToChar(Console.ReadLine());

            Persona vacio = new Persona();
            Persona medio = new Persona(nomb, edad, sexo);
            Persona full = new Persona(nomb, edad, sexo, peso, altura);
            List<Persona> personas = new List<Persona>();


            personas.Add(full);
            personas.Add(medio);
            personas.Add(vacio);
            Console.Clear();

            foreach (Persona per in personas)
            {
                float IMC = per.CalcularIMC();

                Console.WriteLine(per.Mostrar());

                if (IMC < 20)
                {
                    Console.Write("Esta persona deberia comer más");
                }
                else if (IMC >= 20 && IMC <= 25)
                {
                    Console.Write("Esta persona esta en su forma mas optima");
                }
                else if (IMC > 25)
                {
                    Console.Write("Esta persona deberia comer menos");
                }
                else
                {
                    Console.Write("No se proporciono informacion de peso y/o altura");
                }

                if (per.MayorEdad())
                {
                    Console.WriteLine(" Ademas, esta persona es mayor de edad \n\n");
                }
                else
                {
                    Console.WriteLine(" Ademas, esta persona NO es mayor de edad\n\n");
                }
            }

            Console.ReadKey();
        }
    }
}