namespace Poker2.Models.Interfaces
{
    interface IBetter
    {
        void Checks();

        void Calls();

        void Raises();

        void GoesAllIn();

        void Folds();

    }
}
