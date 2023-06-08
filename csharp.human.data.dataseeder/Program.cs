namespace csharp.human.data.dataseeder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Seeder.Seed();
            using(var db = new DataContext())
            {
                db.Authors.ToList().ForEach(x => {
                    Console.WriteLine(x.Email);
                });
            }
        }
    }
}