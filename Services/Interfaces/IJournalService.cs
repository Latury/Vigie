/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services                                                   ║
║  Fichier : IJournalService.cs                                        ║
║                                                                      ║
║  Rôle :                                                              ║
║  Définit le contrat de journalisation du système.                    ║
║                                                                      ║
║  Responsabilités principales :                                       ║
║  - Journaliser les événements système                                ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

namespace Vigie.Services.Interfaces
{
    public interface IJournalService
    {
        void Info(string message);
        void Erreur(string message);
    }
}