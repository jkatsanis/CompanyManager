using CompanyManager;

public class Program
{
    public static bool s_quit = false;
    private static void Main()
    {

        while (!Program.s_quit)
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
                Program.s_quit = true;
            }
        }
    }
}