namespace Extensions
{
    public static class MyExtensions
    {
        public static void PrintPropsOfObjsInAlist<T>(this List<T> list)
        {
            foreach (var book in list)
            {
                foreach (var prop in book.GetType().GetProperties())
                {
                    Console.Write("{0} : {1}    ", prop.Name, prop.GetValue(book));
                }

                Console.WriteLine();
            }
        }
    }
}