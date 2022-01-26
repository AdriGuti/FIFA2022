using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mundial
{
    class Jugador:Persona
    {
        double valor;
        double salari;
        int rating;
        int velocitat;
        int xut;
        int passada;
        int regat;
        int defensa;
        int forca;
        int stamina;
        string posicio;
        public string Posicio
        {
            get { return posicio; }
        }
        public double Valor
        {
            get { return valor; }
        }
        public double Salari
        {
            get { return salari; }
        }
        public int Rating
        {
            get { return rating; }
        }
        public Jugador():base()
        {
            var guid = Guid.NewGuid();
            var justNumbers = new String(guid.ToString().Where(Char.IsDigit).ToArray());
            var seed = int.Parse(justNumbers.Substring(0, 4));
            Random random = new Random(seed);
            valor = random.Next(0,200000)*1000;
            salari = random.Next(0,1000)*10000;
            rating = random.Next(0, 100);
            //Aixo el que fa es que posa unes estadistiques 30 punts amunt o abaix del rating aleatori que
            //li hagi tocat. Ho faig aixi perque abans habia fet que cada estadistica fos un random del 1 al
            //100 i despres el rating la mitjana. El que pasaba es que el rating sempre quedaba al voltant de
            //50. D'aquesta manera es genera mes dispersio
            if (rating < 30)
            {
                velocitat = random.Next(0, rating+30);
                xut = random.Next(0, rating+30);
                passada = random.Next(0, rating+30);
                regat = random.Next(0, rating+30);
                defensa = random.Next(0, rating+30);
                stamina = random.Next(0, rating+30);
            }else if (rating > 70)
            {
                velocitat = random.Next(rating-30, 100);
                xut = random.Next(rating-30, 100);
                passada = random.Next(rating-30, 100);
                regat = random.Next(rating-30, 100);
                defensa = random.Next(rating-30, 100);
                stamina = random.Next(rating-30, 100);
            }
            else
            {
                velocitat = random.Next(rating-30, rating + 30);
                xut = random.Next(rating-30, rating + 30);
                passada = random.Next(rating-30, rating + 30);
                regat = random.Next(rating-30, rating + 30);
                defensa = random.Next(rating-30, rating + 30);
                stamina = random.Next(rating-30, rating + 30);
            }
            SetRatingAndPosition();
        }
        public Jugador(double valor, double salari):this()
        {
            this.valor = valor;
            this.salari = salari;
            SetRatingAndPosition();
        }
        public Jugador(int velocitat, int xut, int passada, int regat, int defensa, int forca):this()
        {
            this.velocitat = velocitat;
            this.xut = xut;
            this.passada = passada;
            this.regat = regat;
            this.defensa = defensa;
            this.forca = forca;
            SetRatingAndPosition();
        }
        public Jugador(double valor, double salari, int rating, int velocitat, int xut, int passada, int regat, int defensa, int forca):this(valor, salari)
        {
            this.velocitat = velocitat;
            this.xut = xut;
            this.passada = passada;
            this.regat = regat;
            this.defensa = defensa;
            this.forca = forca;
            SetRatingAndPosition();
        }
        public void MostraJugador()
        {
            Console.WriteLine(this.ToString());
        }
        public override string ToString()
        {
            string stringJugador = "\tNom:"+base.Nom+
                "\n\tCognom:"+base.Cognom+
                "\n\tValor:" + valor +
                "\n\tSalari:" + salari +
                "\n\tRating:" + rating +
                "\n\tVelocitat:" + velocitat +
                "\n\tXut:" + xut +
                "\n\tPassada:" + passada +
                "\n\tRegat:" + regat +
            "\n\tDefensa:" + defensa +
            "\n\tforca:" + forca;
            return stringJugador;
        }
        //En funcio de les estadistiques randoms del jugador, s'escull amb quina posició tindrà més mitjana
        //i se li assigna aquella posicio i rating
        void SetRatingAndPosition()
        {
            int tempRating, max;
            string tempPosicio;
            tempRating = (int)(0.6 * defensa + 0.3 * forca + 0.1 * Math.Max(passada, velocitat));
            max = tempRating;
            tempPosicio = "Central";

            tempRating = (int)(0.2 * defensa + 0.3 * velocitat + 0.3 * passada + 0.2 * regat);
            if (tempRating > max) tempPosicio = "Lateral";

            tempRating = (int)(0.5 * defensa + 0.3 * Math.Max(passada, forca) + 0.2 * Math.Max(regat, velocitat));
            if (tempRating > max) tempPosicio = "Pivot";

            tempRating = (int)(0.4 * passada + 0.1 * forca + 0.3 * Math.Max(regat, velocitat) + 0.2 * Math.Max(defensa, xut));
            if (tempRating > max) tempPosicio = "Interior";

            tempRating = (int)(0.4 * regat + 0.4 * Math.Max(passada, velocitat) + 0.2 * xut);
            if (tempRating > max) tempPosicio = "MitjaPunta";

            tempRating = (int)(0.5 * xut + 0.3 * Math.Max(regat, passada) + 0.2 * Math.Max(forca, velocitat));
            if (tempRating > max) tempPosicio = "Davanter";

            tempRating = (int)(0.4 * regat + 0.3 * velocitat + Math.Max(0.3 * passada, 0.3 * xut));
            if (tempRating > max) tempPosicio = "Extrem";

            this.rating = max;
            this.posicio = tempPosicio;
        }
    }
}
