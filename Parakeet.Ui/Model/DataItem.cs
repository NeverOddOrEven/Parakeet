namespace HelloWorld.Model
{
    public class DataItem
    {
        public DataItem(string v)
        {
            Title = v;
        }

        public string Title { get; internal set; }
    }
}