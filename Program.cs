using beadandofeladat1105;
using System.Text;

List<Versenyzo> versenyzok = [];

using StreamReader sr = new(@"..\..\..\src\forras.txt", Encoding.UTF8);
while (!sr.EndOfStream) versenyzok.Add(new(sr.ReadLine()));

Console.WriteLine($"A versenyzők száma: {versenyzok.Count}");

var f1 = versenyzok.Count(v => v.Kategoria == "elit junior");
Console.WriteLine($"Elit junior kategóriában a versenyzok száma: {f1} fő");

var f2 = versenyzok
    .Where(v => v.Nem)
    .Average(v => 2014 - v.SzulEv);
    Console.WriteLine($"A férfi versenyzők átlag életkora: {f2:0.00} ev");

var f3 = versenyzok
    .Sum(v => v.Idok["futás"].TotalHours);
Console.WriteLine($"Futással töltött összes idő: {f3:0.00} óra");

var f4 = versenyzok
    .Where(v => v.Kategoria == "20-24")
    .Average(v => v.Idok["úszás"].TotalMinutes);
Console.WriteLine($"20-24 éves kategóriában az átlagos úszás idő {f4:0.00} perc");

var f5 = versenyzok
    .Where(v => !v.Nem)
    .MinBy(v => v.OsszIdo);
Console.WriteLine($"A női győztes: {f5}");

var f6 = versenyzok.GroupBy(v => v.Nem);
Console.WriteLine("A versenyt befejezők nemek szerint:");
foreach (var grp in f6)
    Console.WriteLine($"\t{(grp.Key ? "ferfi" : "no"),5}: {grp.Count()} fő");

var f7 = versenyzok
    .GroupBy(v => v.Kategoria)
    .OrderBy(g => g.Key)
    .ToDictionary(
    g => g.Key,
    g => g.Average(v => v.Idok["I. depó"].TotalMinutes + v.Idok["II. depó"].TotalMinutes));
Console.WriteLine("Kategóriánként átlagosan a depóban töltött idő");
foreach (var kvp in f7)
{
    Console.WriteLine($"\t{kvp.Key,11}: {kvp.Value:0.00} perc");
}