# Sustainability project: Unity Minigames

## Doel van project
Het primaire doel van ons Unity-project is om spelers op een interactieve en leuke manier betrokken te laten raken bij sustainability, en dit wordt gerealiseerd door middel van vier minigames.


## Storyline

In een wereld die zwaar wordt belast door milieuproblemen, beland je in het middelpunt van een beweging die vastbesloten is om de tegenwoordige milieuproblemen te verhelpen.

### Game 1 - De Koude Nacht:
De partij Groen heeft te horen gekregen dat jij s' nachts de verwarming gebruikt om jezelf warm te houden. Een radicale persoon van de partij gooide een steen door je raam. Iets waar ze niet goed over nagedacht hadden want nu moet je je verwarming aansteken anders vries je je dood. Probeer jezelf warm te houden terwijl je de boze activisten probeert te vermijden.

### Game 2 - Energie Imperium:
Na de traumatische ervaring besluit je dat het tijd is voor verandering. Je verhaal trekt de aandacht van de stadsraad, die onder de druk van het publiek op zoek is naar een nieuw gezicht voor hun duurzaamheidsbeleid. Jij, Garfield, bekend om je economisch energiegebruik, wordt benoemd tot vicepresident. Jouw missie: de stad voorzien van duurzame energiebronnen. Deze game focust op deftige planning en het leiden van een groene revolutie in de omgeving.

### Game 3 - Groene Revolutie:
Terwijl je de landschap transformeert, stuit je op weerstand van traditionele fabrieken. In deze game gebruik je tactiek en strategie om de fabrieken te forceren over te stappen op groene energie, door hun transportlijnen te saboteren en de natuur te verdedigen. Deze fase staat symbool voor de strijd tegen de bestaande machtsstructuren en de inspanningen om een nieuwe ecologische balans tot stand te brengen.

### Game 4 - Ontwaak in de Realiteit:
Na een intense strijd ontwaak je en realiseer je dat het een droom was. Maar deze droom heeft je ogen geopend voor de mogelijkheden en noodzaak van verandering. Met hernieuwde motivatie ga je naar je werk, gewapend met de kennis om in je dagelijks leven duurzame keuzes te maken. Jouw doel is om op een milieuvriendelijke manier naar je werk te reizen.

## Technisch Design
In dit deel zullen we de game design aspecten van elke game meer gedetailleerd bespreken. Er is een algemeen lobbymenu met 4 selecteerbare games, elk met zijn eigen menu. 


### Game 1:
#### Game Overview
In "De koude nacht" is het jouw taak om met behulp van camera, radiator en je houten raam jezelf warm te houden en terwijl de boze activisten niet door hebben dat je de verwarming gebruikt. Je moet dus zo efficiënt mogelijk de verwarming gebruiken als je dit niet doet kan het eens zijn dat de activisten inbreken, hou dus zeker je camera's goed in het oog.

#### Gameplay Mechanics

**Verwarming aanzetten:**
- Spelers moeten verwarming aanzetten om hun warmte meter terug omhoog te brengen zo vermijden ze een game over.
- Dit zal ook de gevaars meter verhogen.

**Gevaars meter:**
- De "enemy" zal nagelang hoe hoog de gevaars meter word agresiever worden.
- Het gevaar zal stijgen in deze 2 situaties: Waneer de radiator aan staat, Waneer de raam gesloten is.

**Camera's bekijken**
- Om te zien waar de enemy is kan je met de pijltjes toetsen omhoog & omlaag van camera veranderen.

**Raam sluiten en open doen**
- Je kan het raam sluiten en open doen maar dit zal het gevaar doen stijgen.

**Enemy komt dichter**
- Zoals gezegd komt de enemy dichter als de gevaars meter te hoog word.
- Wanneer de enemy aan het raam staat kan je deze toe doen om de enemy weg te jagen.

**Win & verlies condities**
- De speler kan winnen door langer als 5 minuten te overleven
- De speler verliest door ofterwel de warmte meter tot 0 te laten zakken, door het gevaar tot 100 te laten stijgen of door te lang te wachten als de enemy aan het raam staat.

#### Script Overzicht
**Camera_System.cs** Dit script is verantwoordelijk voor het veranderen van camera en juiste activatie en deactivatie van deze camera's
**Close windows.cs** Dit script is verantwoordelijk voor het draaien van het raam, dit heeft ook een functie voor het Freezing_System script om te kijken of het raam gesloten is of niet.
**FlashLight.cs** Dit script is verantwoordelijk om een zaklamp aan en uit te zetten, helaas heeft dit geen functie in het spel. (zie code voor meer uitleg)
**Freezing_System.cs** Dit script is verantwoordelijk voor veel dingen namelijk: Het aanpassen (stijgen en dalen van warmte & gevaars meters), De positie van de "enemy" aanpassen, Game over condities en de Game win conditie.
**MainMenu.cs** Dit script is verantwoordelijk voor het tonen van de twee panelen in het menu namelijk de orginele set knoppen met (start, hulp en quit) en ook het hulp menu met uitleg van het spel.
**PauseMenu.cs** Dit script is verantwoordelijk voor de acties van de knoppen in het pause menu zoals pauzeren maar ook de knop Give up dat de speler naar het volgend level stuurt
**SoundClick.cs** Dit script is verantwoordelijk om een geluid af te spelen wanneer er geklikt word op de radiator. Waarom ik dit appart heb gezet weet ik zelf eigenlijk niet meer sinds dit het laatste object was dat ik geluid heb gegeven en de andere twee objecten die geluid hebben gewoon deze functie in hun script hebben staan met de andere functionaliteiten.

#### User Interface (UI)

- **Tijd:** Toont hoelang je al overleeft hebt.
- **Warmte** Toont hoe dicht je bent bij de dood.
- **Gevaar** Toont hoe aggressief de enemy word.

#### Gameplay Loop

1. **Startfase:**
   - Speler begint op 100% warmte meter met 0% gevaar. Maar vanaf het spel start zal deze warmte meter onmiddelijk beginnen dalen.

2. **Spelcyclus:**
   - De speler warmt zijn eigen op met de radiator maar probeert gevaar zo laag mogelijk te houden.
   - De speler kijkt op de camera's om te zien hoe ver hij kan gaan met de gevaar meter te verhogen.

3. **Window fase:**
   - De speler sluit de raam moest de "enemy" hier staan om haar weg te jagen.

5. **Eindfase:**
   - Het spel kan eindigen als de warmte meter van de speler op 0 staat, als de gevaar meter op 100 staat of als de "enemy" lang genoeg door de raam staat te kijken.

### Game 2:


#### Game Overview

"Energie Imperium" is een first-person tycoon game waarin spelers energiecentrales bouwen en beheren, gericht op het minimaliseren van CO2-uitstoot. Spelers moeten strategisch beslissingen nemen over de verschillende type energiecentrales, terwijl ze een balans zoeken tussen energieproductie en milieubewustzijn.

#### Gameplay Mechanics

**Bouwen van energiecentrales:**

- Het primaire doel is om twee nucleaire kerncentrales te bouwen en te activeren.
- Spelers initiëren de bouw door op een drukplaat te stappen die gekoppeld is aan het '`BuyNuclearFactoryPlatform`
  ` BuyCoalFactoryPlatform``BuySolarPanelFactory `, `BuyGasFactory`script.

**Economie en Muntverwerving:**

- Spelers verdienen munten door interactie met lampen in de spelomgeving, wat geïmplementeerd wordt via het `LightSwitch` script.
- Na de activering van centrale-aankoopscripts, zoals `BuyGasFactory`, `LightSwitch` verwerkt het `GameManagerElec` script de transactie en voegt de nieuwe energiecentrale toe aan de speler zijn UI.
- Het constant genereren van inkomsten door aangekochte energiecentrales wordt bijgehouden en geregeld door het `GameManagerElec` script.

**Verkoop van Energiecentrales:**

- Spelers kunnen besluiten energiecentrales te verkopen door interactie met de `SellGasFactory`, `SellCoalFactoryPlatform`, of `SellSolarPanelFactory` scripts, waardoor ze 50% van de investering terugkrijgen.
- Deze actie wordt uitgevoerd wanneer een speler op een drukplaat stapt.

**Vijanden en Bedreigingen:**

- Vijanden volgen een pad door het script `EnemyPath` en hun aanwezigheid wordt versterkt door audio cues `EnemyAudio` en `RandomAudioPlayer`.
- Als spelers door vijanden worden geraakt wordt het spel gereset.
- Wanneer spelers contact maken met vijanden, wordt het Death script getriggerd, wat resulteert in een game-over scenario.

**Milieubeheer:**

- Het `GameManagerElec` script beheert de temperatuur in het spel, als de temperatuur te hoog wordt verlies je het spel.
- Als de temperatuur 20 graden overschrijdt, wordt de `Death` script geactiveerd
  **Spelersbeweging**
  De beweging van de speler binnen de spelwereld wordt geregeld door het `FPSController`script.

#### User Interface scoreboard(UI)

- Het scorebord, pauzescherm en de winningUI wordt beheerd door het `GameManagerElec` script.
- Het pauzescherm, dat spelers toelaat het spel te pauzeren en opties te bekijken, wordt eveneens geregeld door het GameManagerElec script.
- De `PlayScriptElectricityBuild` zorgt ervoor dat de game wordt geladen bij het startscherm
- De `PlayScriptMainmenu1` zorgt ervoor dat het homemenu wordt geladen
- De `PlayScriptMainmenu` zorgt ervoor dat je terug kan gaan naar de Level2Menu

#### Relevante Script Overzicht

- `BuyCoalFactoryPlatform.cs`: Beheert het aankopen van koolfabrieken
- `BuyGasFactory.cs`: Beheert het aankopen van GasFabrieken
- `BuyGasNuclearFactoryPlatform.cs`: Beheert het aankopen van Nucleairefabrieken
- `BuySolarPanelFactory`: Beheert het aankopen van zonnepanelen
- `Death`: Detecteert wanneer de enemy dood gaat
- `FPSController`: Zorgt voor het mouvement van de player
- `GameManagerlec`: Dit centrale script beheert diverse gameplay-elementen zoals scorebord, pauzescherm, winst- en verliesmechanismen, en de algemene spelstatus.
- `PlaySoundOnStep`: speelt geluid wanneer een speler op een drukplaat stapt (niet in gebruik)
- `SellCoalFactoryPlatForm`: beheert de verkoop van de koolfabriek
- `SellGasFactory`: beheert de verkoop van de Gasfabriek
- `SellSolarPanelFactory`: beheert de verkoop van zonnepaneel

#### GAMEPLAY LOOP

**Opstartfase:**

- Spelers laden het spel via het `PlayScriptElectricityBuild` script en worden begroet door de hoofdmenuUI geregeld door `PlayScriptMainMenu`.

**Verkenningsfase:**
- Spelers kunnen de map verkennen met de `FPSController` script.
- Spelers verkennen de omgeving, interactie met `LightSwitch` om munten te verdienen.
De `MiniMapScript` helpt spelers bij het navigeren door de wereld.
Bouwfase:

- Spelers stappen op drukplaten gekoppeld aan scripts zoals `BuyNuclearFactoryPlatform`, `BuyCoalFactoryPlatform`, `BuySolarPanelFactory`, en `BuyGasFactory` om verschillende soorten energiecentrales te kopen.
- Het `GameManagerElec` script voegt nieuwe energiecentrales toe aan de UI en begint met het genereren van inkomsten.

**Onderhouds- en Uitbreidingsfase:**

- Spelers gebruiken verdiende munten om meer energiecentrales te kopen.
- Tijdens deze fase kunnen spelers ook centrales verkopen via `SellGasFactory`, `SellCoalFactoryPlatform`, of `SellSolarPanelFactory`.

**Confrontatiefase met Vijanden:**

- Spelers moeten vermijden geraakt te worden door vijanden die navigeren via `EnemyPath`, anders wordt `Death` script getriggerd voor een gamereset.

**Milieubeheersfase:**

- Gedurende het spel houden spelers de temperatuur in de gaten, geregeld door `GameManagerElec.`
Als de temperatuur 20 graden overschrijdt, wordt het spel verloren en wordt de `Death` script geactiveerd.
**Eindscherm:**

- Bij het bouwen van 2 kerncentrale wordt de speler omgeleid naar een windscherm en kunnen ze level 3 spelen met de `PlayScriptSingyutoAbdullahScene`.
### Game 3:
#### Game Overview
"Groene Revolutie" is een first-person shooter minigame waarin spelers de taak hebben om vijandige vrachtwagens, die van fabrieken spawnen, te vernietigen. De game is gericht op het verdedigen van een milieuvriendelijke zone tegen de vervuilende krachten van industriële vrachtwagens. 

#### Gameplay Mechanics

**Vrachtwagen Vernietiging:**
- Spelers moeten vijandelijke vrachtwagens vernietigen die spawnen vanuit fabrieken.
- Er zijn drie spawnpoints, beheerd door het script `EnemySpawner`.
- Een `SpawnerController` script zorgt voor een gereguleerde spawn-timing, zodat vrachtwagens niet continu achter elkaar verschijnen.

**Vrachtwagen Kenmerken:**
- Elke vrachtwagen heeft een `Health` script.
- Bij vernietiging geeft een vrachtwagen één coin aan de speler en activeert een explosie-effect met bijbehorend geluid (`Explosion` script).

**Speler Defensie:**
- Spelers starten met een wapen (`Weapon` script) en hebben toegang tot drie turrets voor verdediging.
- Turrets (`ActivateTurret` script) zijn aanvankelijk uitgeschakeld en kunnen worden geactiveerd na het vernietigen van vrachtwagens.
- Rechterklikken op een knop stelt spelers in staat turrets in te schakelen en de schietsnelheid ervan te upgraden (`TurretController` script).

**Economie en Upgrades:**
- Spelers kunnen in de `BuyShop` bomen, windmolens en zonnepanelen kopen die passief munten genereren.
- Het vernietigen van vrachtwagens levert munten op, welke gebruikt kunnen worden voor upgrades en aankopen.

**Schade Mechanisme:**
- Een `DamageZone` script bepaalt de zone waarbinnen spelers schade ontvangen wanneer vrachtwagens deze bereiken.

#### User Interface (UI)

- **CO2 Meter (`CO2Manager` script):** Geeft de CO2-niveaus aan die stijgen wanneer vrachtwagens de `DamageZone` bereiken. Als dit niet gebeurt, zal het CO2-niveau dalen.
- **Healthbar (`Healthbar` script):** Toont de gezondheid van de speler.
- **Coins (`CoinManager` script):** Geeft het aantal munten weer dat de speler heeft verdiend.

#### Relevante Script Overzicht

- `BuyShop`: Verantwoordelijk voor de in-game winkel waar spelers items kunnen kopen.
- `CO2Manager`: Houdt het CO2-niveau in de game bij.
- `CoinManager`: Beheert de economie van de game en houdt de munten van de speler bij.
- `EnemySpawner`: Verantwoordelijk voor het spawnen van vijanden.
- `GameController`: Centrale controller voor de game logic.
- `Health`: Script gekoppeld aan vrachtwagens die hun gezondheid beheert.
- `Healthbar`: Beheert de weergave van de spelersgezondheid.
- `PlayerController`: Beheert de invoer en acties van de speler.
- `SpawnerController`: Reguleert de spawn-timing van vijanden.
#### Gameplay Loop

1. **Startfase:**
   - Spelers beginnen met een basisset van defensieve middelen: een wapen en uitgeschakelde turrets.
   - De `GameController` initialiseert de game, toont de `MainMenu`, en begeleidt de speler via het `IntroPanelController` script door de introductie.

2. **Spelcyclus:**
   - Vrachtwagens spawnen bij de `EnemySpawner` punten en bewegen zich naar de `DamageZone`.
   - Spelers gebruiken hun wapen om vrachtwagens te vernietigen, wat munten oplevert via het `CoinManager` script.
   - Spelers kunnen hun verdiensten besteden in de `BuyShop` om turrets te activeren/upgraden en om bomen, windmolens en zonnepanelen te planten.
   - De `CO2Manager` houdt de milieu-impact van de game bij, waarbij CO2-niveaus stijgen of dalen op basis van spelersacties.

3. **Upgradefase:**
   - Door het verzamelen van munten kan de speler investeren in passieve verdedigingsmechanismen en verbeteringen voor hun wapen en turrets.
   - De `WeaponSystem` en `TurretController` scripts staan centraal in het upgradeproces.

4. **Verdedigingsfase:**
   - Geactiveerde turrets helpen bij het verdedigen tegen de binnenkomende vrachtwagens.
   - De `SpawnerController` blijft vijanden spawnen met verhoogde frequentie en moeilijkheidsgraad als de tijd verstrijkt.

5. **Eindfase:**
   - Het spel kan eindigen als de health van de speler op 0.
   - Een ander eindscenario is als de spawns gestopt zijn en de speler succesvol alle vrachtwagens heeft vernietigd. Op basis van de CO2-gehalte heeft de speler gewonnen of verloren `CO2Manager`.

### Game 4:

#### Game Overview
"Ontwaak in de Realiteit" is een third-person minigame waarin de speler keuzes moet maken om zo een andere einde te krijgen. De game is gericht op de keuze tussen wandelen of de auto nemen.

#### Gameplay Mechanics

**Stamina en Boosts:**
- De speler heeft een hoeveelheid energy die omlaag gaat als hij loopt en terug omhoog gaat als hij stopt met lopen.
- De speler kan boosts oppakken in de vorm van Energydrink deze kan gebruikt worden om de hoeveelheid energie terug omhoog te doen.

**Auto:**
- De speler heeft de keuze om de auto te nemen, hij zal hierdoor sneller gaan totdat hij weer voor de auto kiest.

#### User Interface (UI)

**Stamina bar:**
- Geeft aan hoeveel stamina de player nog heeft

**Energy drinks:**
- Geeft aan hoeveel boosts the player heeft

#### Script Overzicht

- `ButtonStartGame`: Beheert de knoppen.
- `GameManager`: Beheert de game.
- `PlayerMovement`: Beheert de beweging van de player.
- `RoadSpawner`: Beheert de beweging van de weg Prefabs.
- `SpawnManager`: Beheert wanneer de weg Prefabs moeten bewogen moeten worden.

#### Gameplay Loop

**Menu:**
- De player krijgt een backstory en kan de controlles nakijken.

**Running:**
- De player loopt en kan keuzes maken om zo tot het einde te komen.

**Einde**
- De player is bij zijn werk geraakt, hij krijgt 1 van de 3 eindes en kan terug naar het menu gaan.