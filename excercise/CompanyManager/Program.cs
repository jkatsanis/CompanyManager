using CompanyManager;

public static class Program
{
    private static void Main()
    {
        bool quit = false;
        while (!quit)
        {
            Console.Clear();    
            Console.WriteLine("What do u want to do? (Type the option you want to do for example 'Send Product' ");

            int cnt = 'a';
            for (int i = 0; i < Company.s_options.Length; i++)
            {
                string wrl = Convert.ToChar(cnt) + ") " + Company.s_options[i];
                Console.WriteLine(wrl);
                cnt++;
            }
            string input = Console.ReadLine()!;
            if (input != Company.s_options[Company.s_options.Length - 1])
            {
                Company selected = Company.SelectCompany();
                
                selected.PerfomOption(input);
            }
            else
            {
                quit = true;
            }
        }
    }
}