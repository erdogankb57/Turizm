// See https://aka.ms/new-console-template for more information

int i = 0;
while (i<1000)
{
    Console.WriteLine(i.ToString());

    System.Threading.Thread.Sleep(1000);
}
