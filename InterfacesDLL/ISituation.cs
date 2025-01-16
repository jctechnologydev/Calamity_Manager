
/// <summary>
/// Purpose: Trabalho LP2
/// Created by: Joel Jonassi & Idelvina Fernando
/// Created on: 04/27/2021 23:41:59 PM
/// </summary>
/// <remarks></remarks>
/// <example></example>
namespace InterfacesDLL
{
    public interface ISituation
    {
        bool Morto(string name);
        bool Infetado(string name);
        bool Recover(string name);
    }
}
