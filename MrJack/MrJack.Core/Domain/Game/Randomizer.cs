using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Domain.Game
{
    public class Randomizer
    {
        /// <summary>
        /// Création d'une variable random
        /// </summary>
        private Random random = new Random();

        /// <summary>
        /// Création du random avec comme paramètres la valeur minimum et la valeur maximum
        /// </summary>
        /// <param name="min">Valeur minimum du random</param>
        /// <param name="max">Valeur maximum du random</param>
        /// <returns></returns>
        public int Next(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
