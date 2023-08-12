
Algemeen:

 - Ik heb geen commits gesquashed. De commit geschiedenis geeft de historie weer zoals ik daadwerkelijk gewerkt heb. (Soms testen eerst, soms niet).
 - Ik heb in de “aanvraag” niks kunnen vinden over de tech stack. Ik heb deze opdracht dus naar eigen inzicht ingevuld.

Functioneel:

 - Ik heb een aantal expliciete en impliciete aannames gemaakt. Bijvoorbeeld dat , . en ; ook gefilterd moeten worden maar dat andere leestekens gewoon onderdeel zijn van woorden. Ook heb ik de aanname gemaakt dat een “woord” een reeks aaneengesloten karakters is. Ik heb hier niet te veel nagedacht over wat er allemaal in taal voorkomt. Je zou met een paar man een dag kunnen vullen met het discussiëren en opstellen van een feature file waarmee je beschrijft wanneer iets wel of niet een woord is. Deze test is volgens mij geen demonstratie van requirement engineering, dus heb ik dat niet gedaan.

Architectuur:
- Ik heb gekozen om .net 7 te gebruiken omdat daar de with en required keywords in zitten en het op dit moment de laatste versie is. Afhankelijk van de situatie kan .net 6 beter zijn omdat deze LTS is
- Ik heb principes van clean architectuur & clean code gebruikt .
- De ConsoleApp bevat de software die de terugkoppeling en presentatie naar de gebruiker doet. De rationale is dat de manier van presenteren sterk gekoppeld is aan het type applicatie. Wanneer je dit zou hosten als bijv. webapi zal dit er compleet anders uit zien.
- De sort gebruikt IList en geen IEnumerable. Bij het gebruik van IEnumerable zou de performance velen malen slechter worden. Onder andere omdat er continue over de lijst geïtereerd moet worden om een element m.b.v. de index op te halen (ElementAt).


Codering:
- De OrderBy i.c.m. de sort is niet super performant omdat deze nog een keer over de lijst itereert. Ik hou me niet dagelijks bezig met dit soort algoritmiek. Ik zou nog een paar uurtjes door kunnen gaan denken of googlen (of gewoon de .net implementatie half overnemen). Dit heb ik niet gedaan omdat ik transparant wil zijn over mijn krachten en dingen waar ik me ook nog verder kan ontwikkelen.
- De filtering pipeline gaat ervan uit dat er geen volgordelijkheid in de filters zit. Mocht dit nodig zijn kan dit later toegevoegd worden (YAGNI).
- De WordCounter heeft nu een exponentieel algoritme om de woorden te tellen. Wanneer er vaak hele grote documenten verwerkt worden is het efficiënter om iets met een lookup of hashset te doen.

Testen:
- De testen draaien niet in visual studio. Dat komt omdat je daar de xunit test runner nog voor nodig hebt. Ik ontwikkel zelf in rider, en met dotnet test command kun je de testen ook draaien. Mijn visual studio moest nog geüpdate worden en de licentie ververst, gezien de tijd, niet meer gedaan.
- Ik heb Moq als mocking library gebruikt. Met de situatie dat daar nu SponsorLink in zit zou ik voor productie software voortaan een alternatief (bijv. NSubstitute) gaan gebruken. Nick Chapsas geeft wel een redelijke beschouwing van de situatie. https://www.youtube.com/watch?v=A06nNjBKV7I.
- Ik heb geen specflow gebruikt. Wanneer het project SBE toepast of living documentation wilt zou ik zeker het gebruik van specflow aanbevelen. Enkel voor test automatisering ben ik er geen voorstander van.
- Ik heb enkel testen waarin de infrastructuur weggemockt is. Dat komt omdat afhankelijk zijn van het file system niet handig is, daar krijg je ook wobbly/flaky testen van. Je zou een test toe kunnen voegen met een docker image waar het bestand al op het file system staat. Afhankelijk van de situatie bij het bedrijf is dat wel of niet verstandig.
- Ik geneer nu zelf de test data, je kunt ook gebruik maken van autofixture
- Ik heb een class voor de TestEnvironment. Als dit component groot zou worden en er veel testen op component niveau komen met allerlei verschillende ingangen zou ik een complete abstractielaag schrijven om de onderhoudbaarheid van de component testen goed te houden.

Build / test / deploy
- Ik heb geen pipeline gemaakt. Ik geloof ook niet dat een simpele YAML pipeline toevoegen/kopiëren  voor deze simpele console app een goede demonstratie van mijn skills zou zijn.
- Ik heb niet nagedacht over hoe / naar wat te deployen. Met de gegeven context gaat dat niet.