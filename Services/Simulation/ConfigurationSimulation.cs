/*
╔══════════════════════════════════════════════════════════════════════╗
║                          VIGIE                                       ║
║        Centre de maintenance logicielle intelligent                  ║
║                                                                      ║
║  Module : Services.Simulation                                        ║
║  Fichier : ConfigurationSimulation.cs                                ║
║                                                                      ║
║  Rôle :                                                              ║
║  Centralise les paramètres de simulation du moteur Vigie.           ║
║                                                                      ║
║  Objectif :                                                          ║
║  Permettre d'activer ou désactiver rapidement les comportements      ║
║  simulés utilisés pendant le développement.                          ║
║                                                                      ║
║  Important :                                                         ║
║  Ce fichier n'est pas destiné à la production finale.                ║
║                                                                      ║
║  Licence : MIT                                                       ║
║  Copyright © 2026 Flo Latury                                         ║
╚══════════════════════════════════════════════════════════════════════╝
*/

#region 1. Namespace

namespace Vigie.Services.Simulation;

#endregion


#region 2. Description Générale

/*
 * Classe : ConfigurationSimulation
 *
 * Rôle :
 * Fournit des interrupteurs globaux permettant
 * d'activer ou désactiver certains comportements
 * simulés utilisés pendant le développement.
 *
 * Utilisation :
 * - Simulation des mises à jour
 * - Simulation des erreurs
 * - Simulation des gestionnaires
 * - Simulation des élévations administrateur
 */

#endregion


#region 3. Déclaration

public static class ConfigurationSimulation
{
    #region 3.1 Activation globale

    /*
     * Active ou désactive complètement
     * les comportements de simulation.
     */

    public const bool SimulationActivee = true;

    #endregion


    #region 3.2 Simulation erreurs mises à jour

    /*
     * Permet de générer des résultats aléatoires
     * pour tester la robustesse du moteur.
     */

    public const bool SimulationErreursAleatoires = true;

    #endregion


    #region 3.3 Simulation élévation administrateur

    /*
     * Simule le comportement de l'élévation UAC
     * sans déclencher réellement une demande
     * d'autorisation administrateur Windows.
     *
     * Permet de tester :
     * - les journaux
     * - les statuts
     * - le pipeline interne
     */

    public const bool SimulationElevationAdministrateur = true;

    #endregion


    #region 3.4 Paramètres statistiques

    public const int PourcentageSucces = 70;

    public const int PourcentageEchec = 20;

    public const int PourcentageTimeout = 10;

    #endregion
}

#endregion
