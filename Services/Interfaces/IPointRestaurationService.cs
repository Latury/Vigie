/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services.Interfaces                                        ║
║  Fichier : IPointRestaurationService.cs                              ║
║                                                                      ║
║  Rôle :                                                              ║
║  Définit le contrat de création d’un point de restauration           ║
║  système avant mise à jour critique.                                 ║
║                                                                      ║
║  Licence : MIT                                                       ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Imports

using System.Threading.Tasks;

#endregion

public interface IPointRestaurationService
{
    Task<bool> CreerPointRestaurationAsync(string description);
}
