using System;

Random rand = new Random();
Queue<int> defensores = new Queue<int>();
Queue<int> atacantes= new Queue<int>();

int qtDefensores = 10;
int qtAtacantes = 10;
int win = 0;

GenerateDice(defensores, qtDefensores);
GenerateDice(atacantes, qtAtacantes);

foreach(int s in defensores)
    {
        Console.WriteLine("Defensores"+s);
    }

foreach(int s in atacantes)
    {
        Console.WriteLine("Ataque"+s);
    }
Battle(defensores,atacantes);
Battle(defensores,atacantes);

int roll() => rand.Next(6) + 1;

void GenerateDice(Queue<int> groupWar, int n)
{
    for(int i = 0; i < n; i++)
    {
        groupWar.Enqueue(roll());
        
    }
    
}

void Battle(Queue<int> def, Queue<int> atack)
{
    
    List<int> newDef = OrderDice(def);
    List<int> newAtack = OrderDice(atack);

    Console.Write($"Batalha: {win}");
    for(int i = 0; i < 3; i++)
    {
        Console.WriteLine($"Luta:{i}");

        if(newDef[i] > newAtack[i] || newDef[i] == newAtack[i])
        {
            def.Enqueue(newDef[i]);
            Console.WriteLine($"Defensor ganhou: {newDef[i]} X {newAtack[i]}");
        }
        else
        {
            atack.Enqueue(newAtack[i]);
            Console.WriteLine($"Ataque ganhou: {newAtack[i]} X {newDef[i]}");
        }
    }
    Console.WriteLine();
}

List<int> OrderDice(Queue<int> actualGroup)
{
    List<int> newGroup = new List<int>();

    for(int i = 0; i < 3; i++)
    {
        newGroup.Add(actualGroup.Peek());
        
        actualGroup.Dequeue();
    }
    newGroup = newGroup.OrderBy(i => -i).ToList();

    Console.Write("Dentro da lista:");
    for(int i = 0; i< newGroup.Count(); i++)
    {
        Console.Write($"{newGroup[i]},");
    }
    return newGroup;
    
}
