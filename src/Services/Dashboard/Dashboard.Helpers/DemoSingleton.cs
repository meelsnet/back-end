namespace Dashboard.Helpers
{
    public class DemoSingleton
    {
        private static DemoSingleton instance;

        private DemoSingleton() { }

        public static DemoSingleton Instance => instance ??= new DemoSingleton();

        public bool Demo { get; set; }
    }
}