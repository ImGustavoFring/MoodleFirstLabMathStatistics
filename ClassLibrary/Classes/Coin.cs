namespace ClassLibrary.Classes
{
    public static class Coin
    {
      public static int Flip()
        {
            return new Random().Next(0,2);
        }
    }
}
