using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
/* Vamos a realizar una clase llamada Raíces, donde representaremos los valores de una ecuación de 2º grado.
Tendremos los 3 coeficientes como atributos, llamémosles a, b y c.
Hay que insertar estos 3 valores para construir el objeto.
Las operaciones que se podrán hacer son las siguientes:
obtenerRaices(): imprime las 2 posibles soluciones
obtenerRaiz(): imprime una única raíz, que será cuando solo tenga una solución posible.
getDiscriminante(): devuelve el valor del discriminante (double), el discriminante tiene la siguiente fórmula, (b^2)-4* a* c
tieneRaices() : devuelve un booleano indicando si tiene dos soluciones, para que esto ocurra, el discriminante debe ser mayor o igual que 0.
tieneRaiz() : devuelve un booleano indicando si tiene una única solución, para que esto ocurra, el discriminante debe ser igual que 0.
calcular() : mostrará por consola las posibles soluciones que tiene nuestra ecuación, en caso de no existir solución, mostrarlo también.
Fórmula ecuación 2º grado: (-b±√((b^2)-(4* a* c)))/(2* a)
Solo varía el signo delante de -b*/
namespace EOPAM_07
{
    class raices
    {
        int A = 0;
        int B = 0;
        int C = 0;


        public raices(int a, int b, int c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }

        public void obtenerRaices()
        {
            int resultadoMas = Convert.ToInt32((-1 * B + Math.Sqrt(B * B - 4 * A * C)) / 2 * A);
            int resultadoMenos = Convert.ToInt32((-1 * B - Math.Sqrt(B * B - 4 * A * C)) / 2 * A);
            Console.WriteLine($"raiz numero uno {resultadoMas}, raiz numero dos {resultadoMenos}");
        }

        public void obtenerRaiz()
        {
            int resultadoMas = Convert.ToInt32((-1 * B + Math.Sqrt(B * B - 4 * A * C)) / 2 * A);
            Console.WriteLine($" unica raiz: {resultadoMas}");
        }

        public double getDiscriminante()
        {
            double discri = (B * B - 4 * A * C);
            return discri;
        }

        public bool tieneRaices()
        {
            if (getDiscriminante() > 0)
            {
                return true;
            }
            return false;
        }
                
        public bool tieneRaiz() 
        {
            return (getDiscriminante() == 0) ? true : false;
        }

        public void Calcular()
        {
            if (tieneRaiz() )
            {
                obtenerRaiz();
            }

            else if(tieneRaices())
            {
                obtenerRaices();
            }

            else Console.WriteLine("no tiene raices");
        }


    }
    internal class Program
    {
       static void Main(string[] args)
        {
            raices Raiz = new raices(3, 6, 3);

            Raiz.Calcular();

            Console.ReadKey();
        }
    }
}
