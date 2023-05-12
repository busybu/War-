using System;

Random rand = new Random();

int Defensores = 500;
int Atacantes = 1000;
int qtBatalha = 0;
int win = 0;
Queue<int> defensores = new Queue<int>();
Queue<int> atacantes= new Queue<int>();

GenerateDice(defensores, Defensores);
GenerateDice(atacantes, Atacantes);
Game(Defensores, Atacantes);

void Game(int totalDefensores, int totalAtacantes)
{
    while(totalDefensores != 0 && totalAtacantes > 1)
    {
        if(totalDefensores >= 3 && totalAtacantes >= 3)
        {
            qtBatalha = 3;
        } 
        else 
        {
            qtBatalha = totalDefensores < totalAtacantes ? totalDefensores : totalAtacantes;
            qtBatalha = qtBatalha % 2 == 0 ? 2 : 1;
        }
        
        Console.WriteLine("Dados dos defensores nesta rodada:");
        foreach(int s in defensores)
        {
            Console.Write(s+",");
        }
        Console.WriteLine();
        Console.WriteLine("Dados dos atacantes nesta rodada:");
        foreach(int s in atacantes)
        {
            Console.Write(s+",");
        }
        Battle(defensores, atacantes);

        win += 1;

        totalDefensores = defensores.Count();
        totalAtacantes = atacantes.Count();
    }

    string vencedor = totalDefensores > totalAtacantes ? "Defensores" : "Atacantes"; 
    Console.Write($"Sobrou defensores: {totalDefensores}, sobrou atacantes: {totalAtacantes}");
}

int roll() => rand.Next(6) + 1;

void DequeueGroup(Queue<int> groupWar)
{
    while(groupWar.Count != 0)
    {
        groupWar.Dequeue();
    }
        
    
}
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

    Console.WriteLine($"Batalha: {win}");
    for(int i = 0; i < qtBatalha; i++)
    {
        Console.WriteLine($"Luta:{i}");

        if(newDef[i] < newAtack[i])
        {
            atack.Enqueue(newAtack[i]);
            Console.WriteLine($"Ataque ganhou: {newAtack[i]} X {newDef[i]}"); 
        }
        else
        {
            def.Enqueue(newDef[i]);
            Console.WriteLine($"Defensor ganhou: {newDef[i]} X {newAtack[i]}");
        }
    }
    Console.WriteLine();
}

List<int> OrderDice(Queue<int> actualGroup)
{
    List<int> newGroup = new List<int>();


    for(int i = 0; i < qtBatalha; i++)
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
