namespace Goblins.Core.Items
{
    public class Rock : Item
    {
        bool broken = false;    
        public void Break()
        {
            if (broken) 
                throw new InvalidOperationException("This rock is already broken");

            broken = true;
        }
    }
}
