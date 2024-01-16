namespace ConsoleApp1;

public class GameEngine
{
    public Unit[] characters = new Unit[2];
    private Random random = new Random();

    public GameEngine(Unit a,Unit b)
    {
        this.characters[0] = a;
        characters[1] = b;
    }
    public void Simulation()
    {

    
        bool isPlayer = true;
        int x,y,tempC;
        char choice;
        Console.WriteLine("-----ARENA-------");
        do
        {
            if (isPlayer)
            {
                Console.WriteLine("-Player's turn-");
                x = 1;
                y = 0;
                do
                {
                    Console.WriteLine("1-Attack | 2-Heal | 3-Ulti");
                    choice = Console.ReadLine()[0];
                } while (choice != '1' && choice != '2' && choice != '3');
            }
            else
            {
                Console.WriteLine("-AI's Turn-");
                x = 0;
                y = 1;
                if (characters[0].getMana() == 3)
                {
                    tempC = random.Next(1, 4);
                    if (tempC == 1)
                    {
                        choice = '1';
                    }
                    else if (tempC == 2)
                    {
                        choice = '2';
                    }
                
                    else
                    {
                        choice = '3';
                    }
                }
                else
                {
                    tempC = random.Next(1, 3);
                    if (tempC == 1)
                    {
                        choice = '1';
                    }
                    else
                    {
                        choice = '2';
                    }
                }
               
            }

            switch (choice)
            {
                case '1':
                    int temp;
                    temp = characters[x].Attack(characters[y]);
                    Console.WriteLine("Player HP: " + characters[1].getHp() + " || Computer HP:" + characters[0].getHp());
                    Console.WriteLine("\t\tPlayer WP: " + characters[1].getMana() + " || Computer WP:" + characters[0].getMana());
                    characters[x].setMana(temp);
                    break;
                case '2':
                    characters[x].Heal();
                    Console.WriteLine("\t\tPlayer HP: " + characters[1].getHp() + " || Computer HP:" + characters[0].getHp());
                    Console.WriteLine("\t\tPlayer WP: " + characters[1].getMana() + " || Computer WP:" + characters[0].getMana());
                    break;
                case '3':
                    if (characters[x].getMana() >= 3)
                    {
                        characters[x].Ulti(characters[y]);
                        Console.WriteLine("\t\tPlayer HP: " + characters[1].getHp() + " || Computer HP:" + characters[0].getHp());
                        Console.WriteLine("\t\tPlayer WP: " + characters[1].getMana() + " || Computer WP:" + characters[0].getMana());
                    }
                    else
                    {
                        Console.WriteLine("Ulti is not ready yet!");
                    }
                    break;
                
            }

            if (isPlayer == true)
            {
                isPlayer = false;
            }
            else
            {
                isPlayer = true;
            }
            x = x == 1 ? 0 : 1;
            y = y == 1 ? 0 : 1;
        } while (characters[x].getHp() > 0 && characters[y].getHp() > 0);

        System.Threading.Thread.Sleep(5000);
        Console.Clear();
        
        if (characters[0].getHp() <= 0)
        {
            
            Console.WriteLine("\t\t----PLAYER WINS----");
        }
        else
        {
            Console.WriteLine("\t\t----AI WINS----");
        }
    }
}