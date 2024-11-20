using System.Reflection;
using System.Runtime.InteropServices;

internal class Program
{
    public delegate void Stampa(int n, int x);

    public static void StampaNumero(int n, int z)
    {
        System.Console.WriteLine(n - z);
    }
    public static void ProdottoNumero(int n, int z)
    {
        System.Console.WriteLine(n * z);
    }



    public class Studente
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }



    //Classe LINQ
    class Student
    {
        public int StudentID { get; set; }
        public string? StudentName { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return string.Format($"[StudentID = {StudentID}, StudentName = {StudentName}, Age = {Age}]");
        }



    public delegate double Lambda(double n1, double n2);

    public delegate bool Teenager (Studente s);

    static void Main(string[] args)
    {
        //I Delegates --> invece di richiamare direttamente il medoto assegno quel metodo a una variabile di tipo delegato che fa da "metodo" anch'essa 
        Stampa stampa = StampaNumero;

        StampaNumero(100, 40);
        stampa(1000, 400);
        stampa(1250, 340);
        stampa(500, 40);

        //posso assegnare alla stessa variabile diversi metodi per cambiare il suo comportamento all'interno del programma

        stampa = ProdottoNumero;
        stampa(1000, 400);
        stampa(600, 4);

        //posso anche dichiararlo in questo modo 

        Stampa s1;
        s1 = new Stampa(StampaNumero);

        s1(100, 10);

        //Le lambda expressions

        Lambda l1 = (x, y) => x - y; //sono come una riduzione del metodo , nelle parentesi passo i parametri e dopo la => metto la return 

        var result = l1(10, 34);
        System.Console.WriteLine(result);

        l1 = (x, y) => x * y; //in base a cio che gli dico di returnare , lui si adatta e si trasforma , è come modificare un metodo 
        result = l1(10, 2);
        System.Console.WriteLine(result);

        //Esempio Studente

        //verificare se uno studente è maggiorenne oppure no 

        Teenager ragazzo = delegate (Studente s)
        {
            return s.Age > 12 && s.Age < 20 ;
        };

        Studente studente= new() {Age = 25};

        System.Console.WriteLine(ragazzo(studente));



        //LINQ 


        Student[] studentArray =
            {
                new () { StudentID = 1, StudentName = "John", Age = 18},
                new () { StudentID = 2, StudentName = "Steve",  Age = 21},
                new () { StudentID = 3, StudentName = "Bill",  Age = 25},
                new () { StudentID = 4, StudentName = "Ram" , Age = 20},
                new () { StudentID = 5, StudentName = "Ron" , Age = 31},
                new () { StudentID = 6, StudentName = "Chris",  Age = 17},
                new () { StudentID = 7, StudentName = "Rob", Age = 19},
            };
            foreach (Student student in studentArray)
            {
                if ( student.Age > 12 && student.Age < 20 )
                {
                    System.Console.WriteLine($"{student.StudentName}  is a teenager because he is {student.Age}");
                }
            }  

            //Secondo Metodo 

            List<Student> studentiTeenager = new ();

             foreach (Student student in studentArray)
            {
                if ( student.Age > 12 && student.Age < 20 )
                {
                    studentiTeenager.Add(student);
                }
            }  

            studentiTeenager.ForEach(c => Console.WriteLine(c.StudentName));


    }
    }
}
