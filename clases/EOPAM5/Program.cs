using System;
using System.Linq;

namespace EOPAM_05
{
   
    interface IEntregable
    {
        void Entregar();

        void Devolver();

        bool isEntregado();

        string Mostrar();
    }
    class Serie : IEntregable 

    {   
        void IEntregable.Entregar() {
            entregado = true;
        }

        void IEntregable.Devolver() {
            entregado = false;
        }

        bool IEntregable.isEntregado() {
            return entregado;
        }

        public Serie compareTo(Serie a) {
            if (this.temporadas < a.temporadas)
            {
                return a;
            }
                return this;
        }

        string IEntregable.Mostrar()
        {
            return $"({titulo}, {temporadas},  {entregado}, {genero})";
        }

        public const int tempodefecto = 3; 


        private string titulo;
        private int temporadas = tempodefecto;
        public bool entregado = false;
        private string genero = "";
        private string creador = "";

        public Serie() { }

        public Serie(string titulo, string creador)
        {
            this.titulo = titulo;
            this.creador = creador;

        }

        public Serie(string titulo, int temporadas, bool entregado, string genero)
        {
            this.titulo = titulo;
            this.temporadas = temporadas;
            this.entregado = entregado;
            this.genero = genero;
        }

        public string Titulo { get { return this.titulo; } set { this.titulo = value; } }

        public int Tempodefecto { get { return this.temporadas; } set { this.temporadas = value; } }

        public string Genero { get { return this.genero; } set { this.genero = value; } }

        public string Creador { get { return this.creador; } set { this.creador = value; } }
    }

    class Videojuego : IEntregable
    {
        void IEntregable.Entregar(){
            entregado = true;
        }

        void IEntregable.Devolver(){
            entregado = false;
        }

        bool IEntregable.isEntregado() {
            return entregado;       
        }

        public  Videojuego compareTo(Videojuego objetopasado){
            if (this.horasEsti < objetopasado.horasEsti)
            {
                return objetopasado;
            }
                return this;
        }

        string IEntregable.Mostrar()
        {
            return $"({titulo}, {horasesti}, {genero}, {compania})";
        }


        private string titulo = "";
        private int horasEsti = 10;
        public bool entregado = false;
        private string genero = "";
        private string compania = "";

        public Videojuego() { }

        public Videojuego(string titulo, int horasesti)
        {
            this.titulo = titulo; 
            this.horasEsti = horasesti; 
        }

        public Videojuego(string titulo, int horasesti, string genero, string compania)
        {
            this.titulo = titulo;  
            this.horasEsti = horasesti;
            this.genero = genero;   
            this.compania = compania;
        }

        public string Titulo { get { return this.titulo; } set { this.titulo = value; } }

        public int horasesti { get { return this.horasEsti; } set { this.horasEsti = value; } }

        public string Genero { get { return this.genero; } set { this.genero = value; } }

        public string Compania { get { return this.compania; } set { this.compania  = value; } }

    }


    internal class Program
    {
        /*indica que el Videojuego tiene más horas estimadas y la serie con mas temporadas. Muestran en pantalla con toda su información*/
        static void Main(string[] args)
        {
            Serie[] series = new Serie[5];
            Videojuego[] videojuegos = new Videojuego[5];

            Videojuego MayorVideo = new Videojuego();
            Serie mayorSerie = new Serie();

            series[0] = new Serie("pepe", "tobias");
            series[1] = new Serie("magdacoin", "magda");
            series[2] = new Serie("minecraft", "GASPAR");
            series[3] = new Serie("barbie", "azul");
            series[4] = new Serie("panflines", 5, true, "comedia");

            videojuegos[0] = new Videojuego("fortnite", 4770);
            videojuegos[1] = new Videojuego("brawhalla", 5000);
            videojuegos[2] = new Videojuego("csgo", 1512, "shooter", "valve");
            videojuegos[3] = new Videojuego("rocket league", 1116);
            videojuegos[4] = new Videojuego("darksoul", 15115);

            ((IEntregable)series[0]).Entregar();  //casting = trasnformar algo a algo, lo que hago aca es llamar una funcion 
            ((IEntregable)series[0]).Entregar();

            ((IEntregable)videojuegos[3]).Entregar();
            ((IEntregable)videojuegos[4]).Entregar();

            Console.WriteLine($"series entregadas {series.Count(p => p.entregado == true)}");
            Console.WriteLine($"videojuegos entragados {series.Count(p => p.entregado == true)}");

            for (int i = 0; i < 5; i++)
            {
                mayorSerie = mayorSerie.compareTo(series[i]);
                MayorVideo = MayorVideo.compareTo(videojuegos[i]);   
            }

            Console.WriteLine($"serie con mas temporadas: {mayorSerie.Titulo}");
            Console.WriteLine($"videojuego con mas horas: {MayorVideo.Titulo}");

            Console.WriteLine(((IEntregable)mayorSerie).Mostrar());
            Console.WriteLine(((IEntregable)MayorVideo).Mostrar());

            Console.ReadKey();
        }
    }
}
