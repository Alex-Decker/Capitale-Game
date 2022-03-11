// See https://aka.ms/new-console-template for more information
using Capitale_Game;

Console.WriteLine("!!! Bienvenu dans le jeu de capitale");
List<Pays> donnees = new List<Pays>()
{
    new Pays("Cameroun", "Yaounde", "Afrique"),
    new Pays("France", "Paris", "Europe"),
    new Pays("Chine", "Pekin", "Asie"),
    new Pays("mali", "Bamako", "Afrique"),
    new Pays("Tchad", "Ndjamena", "Afrique"),
    new Pays("benin", "Porto-novo", "Afrique"),
    new Pays("allemagne", "berlin", "Europe"),
    new Pays("maroc", "rabat", "Afrique"),
    new Pays("russie", "moscou", "Europe"),
    new Pays("Bolivie", "Sucre", "Amerique"),
    new Pays("Mexique", "Mexico", "Amerique")
};

Console.WriteLine("Veillez choisir votre niveau ");
Console.WriteLine("1. pour niveau 1 ( un continent )");
Console.WriteLine("2. pour niveau 2 ( deux continent  ");
Console.WriteLine("3. pour niveau 3 ( trois continent  )");
Console.WriteLine("4. pour niveau 4 ( toute la terre ) ");
Console.WriteLine("5. professionnel ");
var rep_menu = Console.ReadLine();
var pivo = true;
List<string> resultats = new List<string>();
switch (rep_menu)
{
    case "1":
        Console.Write(" Entrez le continent avec lequel vous voulez jouer :");

        resultats.Add(Jeux(Tri(donnees, Console.ReadLine().Trim()), 1));
        break;
    case "2":
        Console.Write(" Entrez les continent avec lequel vous voulez jouer ( separer par une virgule) :");
        string[] cont_choisi = Console.ReadLine().Split(',');
        resultats.Add(Jeux(Tri(donnees, cont_choisi[0].Trim(), cont_choisi[1].Trim()), 2));
        break;
    case "3":
        List<string> Continents = new List<string>()
        {
            "Afrique",
            "Asie",
            "Europe",
            "Amerique",
            "Oceanie"
        };
        List<string> vss = new List<string>();
        vss = trois_cont_al();

        resultats.Add(Jeux(Tri(donnees, vss[0], vss[1], vss[2]), 3));
        break;
    case "4":
        resultats.Add(Jeux(Trenfert(donnees), 4));
        break;
    case "5":
        resultats.Add(Jeux(Trenfert(donnees), 5));
        break;
    default:
        break;
}
foreach (var item in donnees)
{
    Console.WriteLine(item.Nom);
}
#region
//while (pivo)
//{
//    donnees.Add(new Pays("Cameroun", "Yaounde", "Afrique"));
//    donnees.Add(new Pays("France", "Paris", "Europe"));
//    donnees.Add(new Pays("Chine", "Pekin", "Asie"));
//    donnees.Add(new Pays("mali", "Bamako", "Afrique"));
//    donnees.Add(new Pays("Tchad", "Ndjamena", "Afrique"));
//    donnees.Add(new Pays("benin", "Porto-novo", "Afrique"));
//    donnees.Add(new Pays("allemagne", "berlin", "Europe"));
//    donnees.Add(new Pays("maroc", "rabat", "Afrique"));
//    donnees.Add(new Pays("russie", "moscou", "Europe"));
//    donnees.Add(new Pays("Bolivie", "Sucre", "Amerique"));
//    donnees.Add(new Pays("Mexique", "Mexico", "Amerique"));
//    Random rnd = new Random();
//    int point = 0;
//    var total = 0;
//    while (donnees.Count > 0)
//    {
//        total++;
//        int moto = int.Parse(rnd.NextInt64(donnees.Count).ToString());
//        int question = int.Parse(rnd.NextInt64(2).ToString());
//        if (question == 0)
//        {
//            Console.Write("Entrez la capitale de " + donnees[moto].Nom + " :");
//            var reponse = Console.ReadLine();
//            var bonne_rep = donnees[moto].Capitale;
//            if (bonne_rep.ToLower() == reponse.ToLower())
//            {
//                Console.WriteLine("bravo");
//                point++;
//            }
//            else
//            {
//                Console.WriteLine("oupse faux");
//            }
//        }
//        else
//        {
//            Console.Write("Entrez le pays dont la capitale de " + donnees[moto].Capitale + " :");
//            var reponse = Console.ReadLine();
//            var bonne_rep = donnees[moto].Nom;
//            if (bonne_rep.ToLower() == reponse.ToLower())
//            {
//                Console.WriteLine("bravo");
//                point++;
//            }
//            else
//            {
//                Console.WriteLine("oupse faux");
//            }
//        }

//        donnees.Remove(donnees[moto]);
//    }
//    Console.WriteLine("Votre total est de : " + point + " / " + total);
//    Console.Write("Voulez-vous continuer ???  [ O / N ]");
//    var continue_rep = Console.ReadLine();
//    if (continue_rep.ToLower() == "o")
//    {
//        pivo = true;
//        point = 0;
//    }
//    else
//    {
//        pivo = false;
//    }
//}
#endregion
string Jeux(List<Pays> populations, int niveau)
{
    var bonne_rep = "";
    int pivo_niveau;
    if (niveau == 1 || niveau == 2)
        pivo_niveau = 1;
    else if (niveau == 3 || niveau == 4)
        pivo_niveau = 2;
    else
        pivo_niveau = 4;

    Random rnd = new Random();
    int point = 0;
    var rater = 0;
    while (populations.Count > 0)
    {
        int index = int.Parse(rnd.NextInt64(populations.Count).ToString());
        int question = int.Parse(rnd.NextInt64(pivo_niveau).ToString());
        if (question == 0)
        {
            Console.Write("Entrez la capitale de " + populations[index].Nom + " :");
            bonne_rep = populations[index].Capitale;
        }
        else if (question == 1)
        {
            Console.Write("Entrez le pays dont la capitale de " + populations[index].Capitale + " :");
            bonne_rep = populations[index].Nom;
        }
        else if (question == 2)
        {
            Console.Write("Entrez le continent ou se trouve  " + populations[index].Nom + " :");
            bonne_rep = populations[index].Continent;
        }
        else if (question == 3)
        {
            Console.Write("Entrez le continent ou se trouve " + populations[index].Capitale + " :");
            bonne_rep = populations[index].Continent;
        }
        var reponse = Console.ReadLine();
        if (bonne_rep.ToLower() == reponse.ToLower())
        {
            Console.WriteLine("bravo");
            point++;
        }
        else
        {
            Console.WriteLine("oupse faux");
            rater++;
        }

        populations.Remove(populations[index]);
    }
    return "" + point + "-" + rater;
}
List<Pays> Tri(List<Pays> populations, params string[] list)
{
    List<Pays> population_choisis = new List<Pays>();
    foreach (var item in populations)
    {
        foreach (var tuple in list)
        {
            if (item.Continent.ToLower() == tuple.ToLower())
            {
                population_choisis.Add(item);
            }
        }
    }
    return population_choisis;
}

List<string> trois_cont_al()
{
    Random rnd = new Random();
    List<string> Continents = new List<string>()
        {
            "Afrique",
            "Asie",
            "Europe",
            "Amerique",
            "Oceanie"
        };
    List<string> vs = new List<string>();
    for (int i = 0; i < 3; i++)
    {
        int moto = int.Parse(rnd.NextInt64(Continents.Count).ToString());
        vs.Add(Continents[moto]);
        Continents.Remove(Continents[moto].ToString());
    }
    return vs;
}
List<Pays> Trenfert(List<Pays> populations)
{
    var populations_list = new List<Pays>();
    foreach (var item in populations)
    {
        populations_list.Add(item);
    }
    return populations_list;
}