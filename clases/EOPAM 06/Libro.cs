using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    internal class Libro
    {
        bool ISBN;
        string titulo;
        string autor;
        int num_pag;

        public Libro() { }

        public Libro(bool ISBN, string titulo, string autor, int num_pag)
        {
            this.ISBN = ISBN;
            this.titulo = titulo;
            this.autor = autor;
            this.num_pag = num_pag;
        }

        public bool ISBNN { get { return this.ISBN; } set { this.ISBN = value; } }

        public string Titulo { get { return this.titulo; } set { this.titulo = value; } }

        public string Autor { get { return this.autor; } set { this.autor = value; } }

        public int Numeropag { get { return this.num_pag; } set { this.num_pag = value; } }


        public string Mostrar() {
            return $" El libro {titulo} {(ISBN == true ? "con" : "sin")}ISBN , escrito por {autor}, tiene {num_pag} paginas";
        }

        public Libro comparar(Libro lib)
        {
            if (this.num_pag > lib.num_pag)
            {
                return this;
            }
            return lib;
        }
    }

}
