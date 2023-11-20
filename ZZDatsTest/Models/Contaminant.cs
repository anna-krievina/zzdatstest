using System;
using System.Collections.Generic;

namespace ZZDatsTest.Models;

public partial class Contaminant
{
    public int Id { get; set; }

    /// <summary>
    /// Universāls paraugu ņemšanas kampaņas kods
    /// </summary>
    public string? Trip { get; set; }

    /// <summary>
    /// Ģeogrāfiskā Austrumu garuma grādu decimālskaitlis, WGS84 sistēmā
    /// </summary>
    public float? Longitude { get; set; }

    /// <summary>
    /// Ģeogrāfiskā Ziemeļu platuma grādu decimālskaitlis, WGS84 sistēmā
    /// </summary>
    public float? Latitude { get; set; }

    /// <summary>
    /// Paraugu vākšanas datums un laiks
    /// </summary>
    public DateTime? Datetime { get; set; }

    /// <summary>
    /// Unikāls stacijas kods un/vai nosaukums
    /// </summary>
    public string? Station { get; set; }

    /// <summary>
    /// Paraugu ņemšanas stacijas dziļums metros, mērot no ūdens virsmas līdz ūdenstilpes dibenam
    /// </summary>
    public float? Bottdepthm { get; set; }

    /// <summary>
    /// Unikāls parauga identifikācijas numurs, uz kuru attiecas konkrētā mērījuma vērtība
    /// </summary>
    public string? Sampleid { get; set; }

    /// <summary>
    /// Paraugam(-ā) noteiktie parametri (zivju vidējais garums, masa, vecums, ūdens saturs audos, metālu saturs audos)
    /// </summary>
    public string? Parameter { get; set; }

    /// <summary>
    /// Parametra latviskais atšifirējums
    /// </summary>
    public string? ParameterLv { get; set; }

    /// <summary>
    /// Audi, kuriem(-os) noteikts attiecīgais parametrs - viss (nepreparēts) organisms, akna, muskulis (fileja)
    /// </summary>
    public string? Tissue { get; set; }

    /// <summary>
    /// Attiecīgā zivju suga - Asaris (Perca fluviatilis), Reņģe (Clupea harengus membras)
    /// </summary>
    public string? Species { get; set; }

    /// <summary>
    /// Zivju sugu latviskais nosaukums
    /// </summary>
    public string? SpeciesLv { get; set; }

    /// <summary>
    /// Vienā paraugā apvienots attiecīgās sugas īpatņu skaits
    /// </summary>
    public int? Individuals { get; set; }

    /// <summary>
    /// Parauga testēšanā iegūtā parametra vērtība
    /// </summary>
    public float? Value { get; set; }

    /// <summary>
    /// Parametra vērtības mērvienība, DW - vērtība rēķināta uz sausa parauga masu (izžāvētam paraugam); WW - vērtība rēķināta uz mitra parauga masu (nežāvētam paraugam)
    /// </summary>
    public string? Units { get; set; }

    /// <summary>
    /// Attiecīgās mērījuma vērtības kvalitātes karogs, kas norāda - vai dati ir caurskatīti un pārbaudīti. Atbilstoši SeaDataNet konsorcija kritērijiem
    /// </summary>
    public int? Quality { get; set; }
}
