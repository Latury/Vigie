/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services.Securite                                          ║
║  Fichier : PointRestaurationSimule.cs                                ║
║                                                                      ║
║  Rôle :                                                              ║
║  Simulation de création d’un point de restauration système.          ║
║                                                                      ║
║  Objectif :                                                          ║
║  Préparer l’architecture sans modifier le système réel.              ║
║                                                                      ║
║  Licence : MIT                                                       ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System.Threading.Tasks;

using Vigie.Services.Interfaces;

#endregion

namespace Vigie.Services.Securite
{
    public class PointRestaurationSimule : IPointRestaurationService
    {
        public async Task<bool> CreerPointRestaurationAsync(string description)
        {
            // Simulation délai réaliste
            await Task.Delay(1200);

            return true;
        }
    }
}
