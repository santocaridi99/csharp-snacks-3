////Se volete verificare la velocità di una parte del codice
//double microseconds = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
//Console.WriteLine("microseconds: {0}", microseconds);

//var start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
//codice
//codice
//codice
//var end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);

//end-start => numero di microsecondi impiegati per eseguire il codice

/* Assegnazione
 - Costruire una lista (li) di 1000 numeri casuali compresi tra 0 e 999 incluso
 - Costruire un SortedSet (ssi) contenente i numeri già presenti in lista
 - Costruire un vettore di booleani (vb) inizialmente tutti a false, lungo 1000, 
   che per ogni intero n presente in lista vale vb[n]=true

 - calcolare quanto tempo impiegate per eseguire il seguente codice
     - per 10000 volte
        - genera n, numero casuale tra 0 e 999
        - verifica se n è presente nel vettore vb (quindi if vb[n] == true). Non dovete stampare nulla

 - calcolare quanto tempo impiegate per eseguire il seguente codice
     - per 10000 volte
        - genera n, numero casuale tra 0 e 999
        - verifica se n è presente nella lista li (quindi li.find...). Non dovete stampare nulla

 - calcolare quanto tempo impiegate per eseguire il seguente codice
     - per 10000 volte
        - genera n, numero casuale tra 0 e 999
        - verifica se n è presente nell'insieme ordinato ssi (quindi ssi.find...). Non dovete stampare nulla

Infine, stampare i tre tempi in secondi

Opzionale: stampare il numero di ricerche/secondo.
           stampare i tempi di costruzione dei singoli elementi (vettore, lista, sortedset)
            (cioè quanto tempo impiegate a inserire i dati nella struttura dati)
*/

Random rng = new Random();

List<int> li_base = new List<int>();

var start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
for (int i = 0; i < 1000; i++)
{
    li_base.Add(rng.Next(0, 1000));
}
var end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
//Console.WriteLine(end - start);

//Costruzione della lista
start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
List<int> li = new List<int>();
foreach (int n in li_base)
{
    li.Add(n);
}
end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
Console.WriteLine("Tempo di insert in una lista: {0}", end - start);

//-calcolare quanto tempo impiegate per eseguire il seguente codice
//     - per 10000 volte
//        - prende in sequenza i numeri presenti in lista base
//          - verifica se n è presente nella lista li (quindi li.find...). Non dovete stampare nulla

int trovati = 0;
int nontrovati = 0;
start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
for (int i = 0; i < 10000; ++i)
{
    foreach (int n in li_base)
    {
        //n è presente nella lista li?
        if (li.Contains(n))
            trovati++;
        else
            nontrovati++;
    }
}
end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
Console.WriteLine("Tempo di 10000 ricerche di 1000 elementi in una lista: {0}", end - start);
Console.WriteLine("Trovati: {0}", trovati);


//Ora voglio utilizzare un vettore
//Costruzione del vettore
start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
int[] vi = new int[1000];

int posv = 0;
foreach (int n in li_base)
{
    vi[posv++] = n;
}
end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
Console.WriteLine("Tempo di insert in un vettore: {0}", end - start);


trovati = 0;
nontrovati = 0;
start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
for (int i = 0; i < 10000; ++i)
{
    foreach (int n in li_base)
    {
        //n è presente nel vettore vi?
        //vi[3, 7, 1, 9, 8, 7, 6, 5, 4, 120, ....]
        //for (int pos=0; pos < 1000; ++pos)
        //    if (vi[pos] == n)
        //    {
        //        //l'ho trovato
        //        trovati++;
        //        break;
        //    }
        if (vi.Contains(n))
            trovati++;
        else
            nontrovati++;
    }
}
end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
Console.WriteLine("Tempo di 10000 ricerche di 1000 elementi in un vettore: {0}", end - start);
Console.WriteLine("Trovati: {0}", trovati);




//Ora voglio utilizzare un vettore
//Costruzione del vettore
start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
bool[] vb = new bool[1000];  //sta tutto a false


//li_base = new List<int> { 6, 12, 99, 101, 456 };
foreach (int n in li_base)
{
    vb[n] = true;
}
end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
Console.WriteLine("Tempo di insert in un vettore: {0}", end - start);


trovati = 0;
nontrovati = 0;
start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
for (int i = 0; i < 10000; ++i)
{
    foreach (int n in li_base)
    {
        if (vb[n])
            trovati++;
        else
            nontrovati++;
    }
}
end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
Console.WriteLine("Tempo di 10000 ricerche di 1000 elementi in un vettore booleno: {0}", end - start);
Console.WriteLine("Trovati: {0}", trovati);



//Ora voglio utilizzare un sorted set
//Costruzione del set
start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
SortedSet<int> ssi = new SortedSet<int>();


foreach (int n in li_base)
{
    ssi.Add(n);
}
end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
Console.WriteLine("Tempo di insert in un ss: {0}", end - start);


trovati = 0;
nontrovati = 0;
start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
for (int i = 0; i < 10000; ++i)
{
    foreach (int n in li_base)
    {
        if (ssi.Contains(n))
            trovati++;
        else
            nontrovati++;
    }
}
end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
Console.WriteLine("Tempo di 10000 ricerche di 1000 elementi in un sorted set: {0}", end - start);
Console.WriteLine("Trovati: {0}", trovati);



//!!!LA ricerca in un insieme ordinato è logaritmica
///Se l'insieme contien N elementi, il tempo di ricerca oppure
///il numero di operazioni eseguite per la ricerca è pari a O(log(N));
///
///La ricerca in un insieme sequenziale (non ordinato) è lineare
///Se l'insieme contiene N elementi, il tempo di ricerca oppure
///il numero di operazioni eseguite per la ricerca è pari a O(N);