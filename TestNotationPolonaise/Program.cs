using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }
        //Le fait de prendre une variable String avec un S majuscule permet de la découper plus facilement
        static float Polonaise(String formule)
        {
            //Ici on découpe le string pour enlever les espaces et mettre chaque caractère dans une case
            string[] vec = formule.Split(' ');
            int nbCases = vec.Length;

            //Ici on boucle tant qu'il reste plus d'une case
            while (nbCases > 1)
            {
                //Ici on utilise la variable "k" afin de savoir ou est la fin de notre tableau
                //On y enlève un pour faire en sorte de commencer a la dernière case
                int k = nbCases - 1;
                //Ici tant qu'on ne trouve pas de symbole a la case "k" on continue de lire le tableau en reculant de la fin vers le début
                //On arrête quand on trouve un symbole
                while (k>0 && vec[k] != "+" && vec[k] != "-" && vec[k] != "*" && vec[k] != "/")
                {
                    k--;
                }
                //Ici après avoir trouver le symbole on prend les deux nombres qui suivent afin de faire le calcul
                //On les convertis en float
                float v1 = float.Parse(vec[k + 1]);
                float v2 = float.Parse(vec[k + 2]);

                float result = 0;
                //Le switch permet de faire quelque chose en fonction de la valeur
                //Un peu comme un couloir d'hotel, quand on a la clé de la chambre 301 on vas direct a celle la pour l'ouvrir
                //Ici c pareil sauf que on lui dis que en fonction du symbole dans la case il doit ouvrir la porte avec le même symbole
                //Ex : si c la clé avec le symbole + il ouvre la porte avec le +
                switch (vec[k])
                {
                    //On a une opération par symbole donc on en a 4 différente
                    //C bien plus opti que d'utiliser des if else ou autre
                    //Car ça prend bien moins de ligne et que il va directement au bon calcul sans passer par les autres
                    case "+": result = v1 + v2; break;
                    case "-": result = v1 - v2; break;
                    case "*": result = v1 * v2; break;
                    case "/": result = v1 / v2; break;
                }
                //Ici on re transforme notre résultat en string afin de le remettre dans le tableau
                vec[k] = result.ToString();

                //Ici on décale le résultat de 2 cases vers la gauches
                //Car le résultat a était mis dans la case qui contient le symbole
                for (int j=k+1;j<nbCases-2;j++)
                {
                    vec[j] = vec[j + 2];
                }
                //La on enlève 2cases
                nbCases -= 2;
            }
            //Ici on retourne le résultat en float
            return float.Parse(vec[0]);
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
