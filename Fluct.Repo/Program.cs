namespace Fluct.Repo
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new Repository<Item>(
                new Item(1, "First", 11),
                new Item(2, "Second", 22),
                new Item(3, "Third", 33)
                );

            var item = repo.GetOneById(2);
            repo.DeleteById(1);
        }
    }
}