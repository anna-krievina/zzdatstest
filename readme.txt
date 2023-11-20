Uzstādīšanas instrukcija:
Novilkt projektu no github

Izmainīt datubāzes koncekciju tā lai varētu piekļūt PostgreSQL datubāzei (izmainot serveri, lietotājvārdu, paroli pēc nepieciešamības)
ZZDatsTest.LoadDb projektā:
Program.cs failā mainīgajos serverConnectionString un databaseConnectionString
ZZDatsTest projektā:
appsettings.json un appsettings.Development.json failos "ConnectionString" vērtībā

nuget consolē izlaist komandu:
npm install date-fns

Lai izveidotu datubāzi, uzstādīt kā startup projektu ZZDatsTest.LoadDb un palaist to

Lai apskatītu mājas lapu, uzstādīt kā startup projektu ZZDatsTest un palaist to.


-------------------------------------------------------

piezīmes:
Lai notestētu api caur swagger, aiz localhost jāievada /swagger
projekts veidots uz Visual Studio 2022

-------------------------------------------------------

apraksts:
Uzdeuvumu sāku ar datu izpētīšanu. Pirms uzsāku programmēšanu izveidoju šādu plānu:
uztaisīt DB ar vienu tabulu balstītu uz CSV (plus latviskās kolonnas)
EnityFramework DB reprezentācija
uztaisīt CSV uz SQL insert klasi
pielikt klāt latviskās vērtības

programma nodrošinās šādas atskaites:
1. visi dati
2. atskaite - svina esamība sugās
3. atskaite - rādījumi pa gadiem
4. atskaite - vislielākais metālu skaits zivīs

uztaisīt procedūras kas veido atskaites
uztaisīt webapi kas sauc procedūras
front-end tabulas kas attēlo datus izsaucot webapi

(vēlāk vēlreiz pārlasot uzdevumu pieliku šo)
projekts kas ielādē skriptus datubāzē


Lai gan uzdevums vedina uz gan automātisku ielādi gan saglabāšanu, manuprāt nevar īsti iztikt bez manuālas CSV datu labošanas lai teiksim saglabātu value (kas satur arī vērtības kā "marts.10") kā real, kas nepieciešams lai varētu vieglāk veidot atskaites izmantojot teiksim SUM un AVG. Dati arī satur lieku kolonnu Project kas atkārto vienu vērtību un vieglākai datu apstrādei izdzēsu arī pirmo rindu.
Csv fails ko izmantoju insert skriptu ģenerēšanai var apskatīt ZZDatsTest.Csv projekta Csv folderī.
ZZDatsTest.Csv projekts arī atķeksē datu ielādes prasību DownloadCsv funkcijā.

Lai saglabātu datus datubāzē izvēlējos no csv uzrakstīt insert skriptu (ar ko biju saskārusies iepriekšējā darbā) ko pēc tam ar roku atkārtoti palaidu un izlaboju. Vieglāk bija šādi jo uzreiz var redzēt kura vērtība ir neatbilstoša kolonnas tipam (īpaši runājot par value kolonnu). Uzgāju arī 2 rindas kur nebija Quality (kas datubāzē ir integer) aizpildīts, tur izvēlējos ierakstīt '1', kā tas ir vairums datos. (tagad iedomājos ka iespējams lieki to izveidoju par integer kolonnu jo ar datiem nav nepieciešams veidot agregātfunkciju apstrādi).
Pārējos skriptus arī rakstīju ar roku (jo tā man bija ērtāk) un tikai pēc tam pieliku to ZZDatsTest.LoadDb projektā.

Jau sākumā zināju kad gribēšu front-end taisīt tāpēc izvēlējot balstīt risinājumu uz ASP.NET core with React.js, kas jau sākumā parāda arī piemēru kā izsaukt datus no api un attēlot tabulā, uz ko arī balstīju savu front-end. Vienīgi pārveidoju lai api tiktu saukts nevis async bet uzreiz, lai varētu visu datu tabulā izsaukt this.sortTable funkciju (kas bija jātaisa kā klases nevis static metode, lai varētu izmantot this.state (zinu ka modernāk ir veidot react ar funkcijām un UseState bet react tik labi nemāku tāpēc pieturējos pie esošās stuktūras)).
Izkārtojumu arī ņēmu esošo, tikai tiku vaļā no citām navigācijām, jo nelikās loģiski atskaites likt kā sadaļu, bet drīzāk kā lapu ar linkiem. Vienīgi to varētu taisīt kā sidebar bet par to iedomājos kad uzdevumu jau uzskatīju par pabeigtu.

Pieliku sort visu datu tabulai lai būtu vismaz kāds UX uzlabojums pie šāda datu apjoma (sort simbolam izvēlējos microsoft iebūvēto simbolu, jo bootstrap 4 vairs neatbalsta glyphicons). Atskaitēm neliku sort jo tās nāk jau sasortētas un dati ir maz. Zinu ka papildus varētu pielikt pagination un meklēšanu, bet tā kā neesmu to darījusi react un ņemot vērā kolonnu skaitu, izvēlējos iet vairāk uz MVP veidošanu. Neredzēju pamatu lietotājam iedot CRUD darbības, jo dati nav lietotāja veidoti. Ja ir vēlēšanās apskatīties manis taisītu ar EnityFramework veidotu CRUD, to var izdarīt https://github.com/anna-krievina/usertask-public/blob/main/usertask/usertask/UserTask.Db/UserDbRepository.cs klasē.

EntityFramework ģenerēju ar 'Scaffold-DbContext "Name=ConnectionString" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Models -Force' komandu. Zinu ka vēl ir iespēja izmantot ADO.NET bet tas ir novecojis un ar migrācijām bet to īsti nesaprotu un man īsti nepatīk tā doma ka krājas migrācijas. Nav arī nepieciešama validācija. Zinu ka validācijas C# veido ar anotācijām piemēram [Required(ErrorMessage = "Description is required")] un ModelState.AddModelError("UserName", "The username or password is incorrect"). Bet nezinu kāda ir labā prakse veidojot validācijas ar Scaffold-DbContext jo klases tiek pārrakstītas (pieļauju ka tiek veidotas atsevišķas klases un tad tās tiek mapotas viena uz otru).

Atskaites nedaudz atšķiras no sākotnējā plāna, jo svina vērtības faktiski visur ir 200 un nodomāju ka ja varu iztaisīt 2 atskaites kur izmantots SUM un AVG un GROUP BY, esmu pierādījusi ka varētu izveidot vēl atskaites pēc nepieciešamības. Atskaites datubāzē izvēlējos veidot ar MATERIALIZED VIEW tā, lai EntityFramework izveidotu klases ko varētu izmantot tālāk. Sākumā biju domājusi atskaites rakstīt ar procedūrām (un drīz pēc tam ar funkcijām, jo tās atgriež datus, bet prodedūras neatgriež), un pirmais tā mēģinājums ir apskatāms ZZDatsTest.LoadDb projekta Scripts folderī esošajā 05_create_materialized_views.sql failā.

Neredzēju sevišķu pielietojumu procedūrām, bet tā kā tas bija prasībās, uztaisīju to 04_update_data.sql failā, kur aizpildu latviskās vērtības. (Zinu ka pēc pareizības būtu arī Tissue kolonna jālatvisko, bet nesapratu uz kuriem audiem attiecas kuras vērtības. Latviskās vērtības tulkoju ar google translate).

Uzdevuma izpilde aizņēma 21h strādājot normālā režīmā (ar pauzēm u.tml.). Tehnoloģijas man bija daļēji jaunas un ieķeršanās netrūka.