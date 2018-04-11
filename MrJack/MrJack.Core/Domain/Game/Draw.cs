using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Domain.Game
{
    class Draw
    {
        public List<Killers> Cartes { get; set; }
        public Dictionary<Killers, int> killersSabliers { get; set; }
        /// <summary>
        /// Contructeur de la pioche
        /// </summary>
        public Draw()
        {
            Cartes = new List<Killers>();
            Cartes.Add(Killers.William_Gull);
            Cartes.Add(Killers.John_Smith);
            Cartes.Add(Killers.Jeremy_Bert);
            Cartes.Add(Killers.Joseph_Lane);
            Cartes.Add(Killers.Miss_Stealthy);
            Cartes.Add(Killers.Insp_Lestrade);
            Cartes.Add(Killers.Sgt_Goodley);
            Cartes.Add(Killers.Madame);
            Cartes.Add(Killers.John_Pizzer);

            killersSabliers.Add(Killers.William_Gull, 1);
            killersSabliers.Add(Killers.John_Smith, 1);
            killersSabliers.Add(Killers.Jeremy_Bert, 1);
            killersSabliers.Add(Killers.Joseph_Lane, 1);
            killersSabliers.Add(Killers.Miss_Stealthy, 1);
            killersSabliers.Add(Killers.Insp_Lestrade, 0);
            killersSabliers.Add(Killers.Sgt_Goodley, 0);
            killersSabliers.Add(Killers.Madame, 2);
            killersSabliers.Add(Killers.John_Pizzer, 1);
        }

        /// <summary>
        /// Permet de piocher un carte (et ajouter des sabliers si MrJack)
        /// </summary>
        /// <param name="currentPlayer">Le joueur en cours</param>
        /// <returns>le tueur sur la carte</returns>
        public Killers Pioche(PlayerType currentPlayer)
        {
            Random rnd = new Random();
            int nb = rnd.Next(0, 10);
            Killers killer = Cartes[nb];
            if(currentPlayer == PlayerType.MrJack)
            {
                killersSabliers.TryGetValue(killer, out int sabliers);
                //Joueur.Sabliers += sabliers;
            }
            Cartes.Remove(killer);
            return killer;
        }
    }
}
