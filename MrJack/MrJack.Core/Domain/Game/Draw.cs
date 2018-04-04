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

        /// <summary>
        /// Contructeur de la pioche
        /// </summary>
        public Draw()
        {
            Cartes.Add(Killers.William_Gull);
            Cartes.Add(Killers.John_Smith);
            Cartes.Add(Killers.Jeremy_Bert);
            Cartes.Add(Killers.Joseph_Lane);
            Cartes.Add(Killers.Miss_Stealthy);
            Cartes.Add(Killers.Insp_Lestrade);
            Cartes.Add(Killers.Sgt_Goodley);
            Cartes.Add(Killers.Madame);
            Cartes.Add(Killers.John_Pizzer);
        }

        /// <summary>
        /// Permet de piocher un carte
        /// </summary>
        /// <returns>le tueur sur la carte</returns>
        public Killers Pioche()
        {
            Random rnd = new Random();
            int nb = rnd.Next(0, 10);
            Killers killer = Cartes[nb];
            Cartes.Remove(killer);
            return killer;
        }
    }
}
