using CompanyManager;

public class Program
{
    private static void Main()
    {
       Company.InitCompanies();


        while (true)
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
            Company selected = Company.SelectCompany();
            selected.PerfomOption(input);
        }
    }
}