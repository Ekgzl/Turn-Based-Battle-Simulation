namespace ConsoleApp1;

public class Unit
{
    private int currentHp;
    private int firstHp;
    private int attackPower;
    private int healPower;
    private string unitName;
    private int mana = 0;
    private Random random;
    
    public Unit(int firstHp, int attackPower, int healPower, string unitName)
    {
        this.firstHp = firstHp;
        this.attackPower = attackPower;
        this.healPower = healPower;
        this.unitName = unitName;
        this.random = new Random();
        this.currentHp = firstHp;
    }

    public int getMana()
    {
        return mana;
    }

    public void setMana(int givenDamage)
    {
        mana++;
    }
    public int getHp()
    {
        return currentHp;
    }

    public int Attack(Unit other)
    {
        double rng = random.NextDouble();
        rng = rng / 2 + 0.75f;
        int randDamage = (int)(this.attackPower * rng);
        other.currentHp -= randDamage;
        Console.WriteLine("Given Damage:" + randDamage + "\n");
        return randDamage;
    }

    public void Heal()
    {
        int randHealing = random.Next(3, 7);
        this.currentHp += randHealing;
        Console.WriteLine("Character " + randHealing + " healed.\n");
    }

    public void Ulti(Unit other)
    {
        double rng = random.NextDouble();
        rng = rng / 1 + 1.5f;
        int randDamage = (int)(this.attackPower * rng);
        other.currentHp -= randDamage;
        Console.WriteLine("Ulti Given Damage:" + randDamage + "\n");
        mana = 0;
    }
}