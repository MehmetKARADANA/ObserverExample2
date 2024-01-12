internal class Program
{
    private static void Main(string[] args)
    {
        Comminity ktu = new Comminity("KTU");
        followedclass swe = new Page("Software Engineering");

        User mehmet = new User("Mehmet");
        User derin = new User("Derin");
        User mustafa = new User("Mustafa");

        ktu.AddFollower(mehmet);
        ktu.AddFollower(derin);
        ktu.AddFollower(mustafa);


        ktu.SharePost(new Post("23 April "));

        Console.WriteLine("-----------");
        swe.AddFollower(ktu);

        swe.AddFollower(mehmet);
        swe.AddFollower(derin);
        swe.AddFollower(mustafa);

        swe.SharePost(new Post("29 October "));

    }


    abstract class followedclass
    {
        private string name;

        private List<Observer> observers = new List<Observer>();

        protected followedclass(string name)
        {
            this.name = name;

        }

        public void AddFollower(Observer ob)
        {
            observers.Add(ob);
        }

        public void RemoweFollower(Observer ob)
        {
            observers.Remove(ob);
        }

        public string Name { get => name; set => name = value; }



        public void SharePost(Post p)
        {
            Console.WriteLine("Post Shared {0}", p.Title);
            this.Notify();
            Console.WriteLine("Notification sent to followers.");
        }

        public void Notify()
        {
            foreach (Observer ob in observers)
            {
                ob.notification(this);
            }


        }
    }

    class Comminity : followedclass, Observer
    {
        public Comminity(string name) : base(name)
        {
        }

        public void notification(followedclass fc)
        {
            Console.WriteLine("Hi {0} {1} shared new Post ", Name, fc.Name);
        }

    }

    class Page : followedclass
    {
        public Page(string name) : base(name)
        {
        }
    }


    interface Observer
    {


        public void notification(followedclass fc);

    }

    class User : Observer
    {
        private string name;

        public User(string name)
        {
            this.Name = name;
        }

        public string Name { get => name; set => name = value; }

        public void notification(followedclass fc)
        {
            Console.WriteLine("Hi {0} {1} shared new Post ",Name,fc.Name);
        }
    }

    class Post
    {
        private string title;
        // we can add other atributes
        public Post(string title)
        {
            this.title = title;
        }

        public string Title { get => title; set => title = value; }
    }

}