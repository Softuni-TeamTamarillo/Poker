namespace Poker2.Models.Interfaces
{
    //Do we need this using?
    using System.Security.Cryptography.X509Certificates;

    public interface IBotChoiceMaker
    {
        void Chooses();
    }
}
