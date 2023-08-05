using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;


/*crear una clase Libro que contenga los siguientes atributos:
– ISBN
– Título
– Autor
– Número de páginas
Crear sus respectivos métodos get y set correspondientes para cada atributo. Crear el método que muestre la información relativa al libro con el siguiente formato:
«El libro con ISBN creado por el autor tiene páginas»
En el fichero main, crear 2 objetos Libro (los valores que se quieran) y mostrarlos por pantalla.
Por último, indicar cuál de los 2 tiene más páginas. */

namespace EOPAM_06
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Libro libro = new Libro(true, "martin firro", "chavelo", 399);
            Libro libro2 = new Libro(false, "un buen libro", "un buen autor", 151);

            Console.WriteLine(libro.Mostrar());
            Console.WriteLine(libro2.Mostrar());

            Console.WriteLine((libro.comparar(libro2)).Titulo);
            Console.ReadKey();
          
        }
    }
}
