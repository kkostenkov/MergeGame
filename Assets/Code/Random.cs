namespace Merge
{
    public interface IRandomProvider
    {
        int Next(int max);
    }
    
    public class Random : IRandomProvider
    {
        private readonly System.Random random = new System.Random();  
        
        public int Next(int max)
        {
            return random.Next(max);
        }
    }
}