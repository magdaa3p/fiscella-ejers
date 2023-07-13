using System;                           //Seccion Using, todo namespace que se ponga aqui no necesitará ser llamado de vuelta cada que queramos utilizar sus clases y funciones
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magda                         //Namespace, todo archivo dentro de esta solucion con el mismo namespace va a trabajar con las mismas clases, en caso de no estar en el mismo namespace. esas clases no existirán
{   
    public class Pepe {                 //Clase pepe, es un tipo de dato que se lo podemos asignar a un objeto que creemos, adentro tiene datos, esta clase en particular tiene un id
        public int Id = 0;              //una edad y un nombre. Adentro tambien tiene un METODO que muestra todos sus datos, se pone string en vez de void porque queremos que devuelva un string. 
        public int edad = 10;
        public string nombre = "pepe";

        public string mostrarInfo() {
            return $"{nombre} tiene {edad} años, su ID es {Id}";  //metodo mostrarInfo, todo Pepe que creemos va a tener este metodo y va a mostrar los datos de ese pepe en particular
        }
    }

    internal class Program                                             //Clase Program, toda funcion declarada aqui dentro debe iniciar con STATIC
    {
        static public void hola(Pepe elchico) {                        //Funcion hola(), ejecuta estas 4 lineas de codigo cada vez que es llamada, requiere que se pase un objeto
            Console.WriteLine("hola");                                 //pepe por su parentesis y llama al metodo mostrarInfo() de ese pepe para que muestre sus datos en el 
            Console.WriteLine("como estan");                           //Console.WriteLine()
            Console.WriteLine("les presento a este empleado");
            Console.WriteLine(elchico.mostrarInfo());
        } 

        static void Main(string[] args) {                               //Clase ejecutable 
            Pepe pep = new Pepe();

            pep.edad = 68;
            pep.nombre = "magda";
            pep.Id = 1;

            Pepe ton = new Pepe();

            ton.Id = 2;

            hola(pep);
            hola(ton);

            Console.ReadKey(true);                      //necesario parar el codigo de una manera, no olvidar el console.ReadKey en caso de necesitarlo.
        }
    }
}
