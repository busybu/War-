using System;

Random rand = new Random();

int Defensores = 10;
int Atacantes = 100;
int qtBatalha = 0;
int winAtack = 0;
int winDef = 0;
Queue<int> defensores = new Queue<int>();
Queue<int> atacantes= new Queue<int>();

void lockParallelForRun()
{
    Parallel.For(0, 500, i =>
    {
        lock(rand)
        {
            Game(Defensores, Atacantes);
            
        }
    });
}
string Game(int totalDefensores, int totalAtacantes)
{
    while(totalDefensores != 0 && totalAtacantes > 1)
    {
        GenerateDice(defensores, Defensores);
        GenerateDice(atacantes, Atacantes);

        if(totalDefensores >= 3 && totalAtacantes >= 3)
        {
            qtBatalha = 3;
        } 
        else 
        {
            qtBatalha = totalDefensores < totalAtacantes ? totalDefensores : totalAtacantes;
            qtBatalha = qtBatalha % 2 == 0 ? 2 : 1;
        }

        Battle(defensores, atacantes);
        totalDefensores = defensores.Count();
        totalAtacantes = atacantes.Count();
        DequeueGroup(defensores);
        DequeueGroup(atacantes);
    }

    string vencedor = totalDefensores > totalAtacantes ? "Defensores" : "Atacantes"; 
    return vencedor;
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

    for(int i = 0; i < qtBatalha; i++)
    {
        if(newDef[i] < newAtack[i])
        {
            atack.Enqueue(newAtack[i]);
        }
        else
        {
            def.Enqueue(newDef[i]);
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

    return newGroup;
}