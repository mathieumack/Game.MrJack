namespace MrJack.Core.Interfaces.Game
{
    public interface IGameBoard
    {
        /// <summary>
        /// 5x5 table that contains Detectives or cards
        /// </summary>
        ICard[,] Board { get; set; }
    }
}
