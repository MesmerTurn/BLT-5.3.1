# BLT 5.2.4 + RoT 8.0 Dragon/Chariot Mount Support

Fork of **BannerlordTwitch (BLT) 5.2.4** z dodaną obsługą smoków i rydwanów z moda **Realm of Thrones 8.0** jako typy monta w konfiguracji klas BLT.

## Co dodaje ten fork

W edytorze klas BLT (BLT Configure) przy tworzeniu lub edycji klasy pojawiają się dwa nowe checkboxy:

| Opcja | T1–T3 | T4–T6 |
|---|---|---|
| **Use Dragon (RoT)** | `dragon_black`, `dragon_brown`, `dragon_gold` (naziemny) | `dragon_black2`, `dragon_brown2`, `dragon_gold2` (latający) |
| **Use Chariot (RoT)** | `chariot1`, `chariot2`, `chariot3` | `chariot4`, `chariot5`, `chariot6` (zaawansowany) |

Tier jest przypisywany automatycznie na podstawie poziomu ekwipunku bohatera (T1–T6).  
Jeśli nie masz ROT 8.0 — checkboxy są widoczne, ale mount po prostu nie zostanie przypisany (żadnych crashy).

---

## Wymagania

- **Mount & Blade II Bannerlord** `e1.3.15`
- **BannerlordTwitch (BLT) 5.2.4** — [pobierz od randomchair](https://www.nexusmods.com/mountandblade2bannerlord/mods/1989)
- **Realm of Thrones 8.0** dla Bannerlord 1.3.15 (opcjonalnie — bez tego mount nie zostanie przypisany)

---

## Instalacja

### Opcja A — gotowy ZIP (zalecane)

1. Pobierz `BLT_5.2.4_RoT_Dragon.zip` z zakładki [Releases](../../releases)
2. Wypakuj zawartość do folderu:
   ```
   Mount & Blade II Bannerlord\Modules\
   ```
   Powinny pojawić się 4 foldery:
   ```
   Modules\
   ├── BannerlordTwitch\
   ├── BLTAdoptAHero\
   ├── BLTBuffet\
   └── BLTConfigure\
   ```
3. **Nie instaluj** osobno oryginalnego BLT 5.2.4 — ten ZIP go już zawiera (z modyfikacją).
4. Uruchom grę przez Launchera, włącz wszystkie 4 moduły BLT.

### Opcja B — tylko zmienione pliki (dla zaawansowanych)

Jeśli masz już zbudowany BLT 5.2.4 ze źródeł i chcesz tylko dodać wsparcie dla smoków:

1. Podmień dwa pliki w projekcie `BLTAdoptAHero`:
   - `BLTAdoptAHero/Actions/EquipHero.cs`
   - `BLTAdoptAHero/Actions/Util/HeroClassDef.cs`
2. Zbuduj projekt `BLTAdoptAHero` w trybie Release.
3. Skopiuj nowy `BLTAdoptAHero.dll` do:
   ```
   Modules\BLTAdoptAHero\bin\Win64_Shipping_Client\
   ```

---

## Użycie w grze

1. Wejdź w **BLT Configure** (ikona w lewym górnym rogu HUD podczas sesji).
2. Przejdź do **Classes**.
3. Utwórz lub edytuj klasę.
4. Zaznacz **Use Dragon (RoT)** lub **Use Chariot (RoT)**.
5. Zapisz i użyj komendy `!equip` — bohater otrzyma smoka/rydwan odpowiedni do swojego tier.

---

## Kompatybilność

- Działa z **MakeBltGreatAgain (MBGA)** — w pełni kompatybilny.
- Działa bez ROT 8.0 — checkboxy nie crashują gry, mount po prostu nie jest przypisywany.
- Nie wymaga żadnych dodatkowych addonów ani DLL-i.

---

## Źródła zmian

Zmodyfikowane pliki względem oryginalnego BLT 5.2.4:

- `HeroClassDef.cs` — dodane właściwości `UseDragon` i `UseChariot`
- `EquipHero.cs` — logika przypisywania smoka/rydwanu na podstawie tier bohatera

Oryginalny BLT 5.2.4: © randomchair — [repozytorium](https://github.com/nwilliams-kobold/Bannerlord-Twitch)
