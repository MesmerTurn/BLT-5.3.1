# BLT 5.3.1 for Bannerlord 1.3.15

A fork of **BannerlordTwitch (BLT) 5.2.4** with Dragon/Chariot mount support, T7/T8 Prestige tiers,  
and **MakeBltGreatAgain** powers fully integrated — no extra folders needed.

Maintained by **MesmerTurn** — Bannerlord streamer on Twitch.

---

## What's Included

- **BannerlordTwitch** — core Twitch integration
- **BLTAdoptAHero** — hero system with all MakeBltGreatAgain powers built in
- **BLTBuffet** — buff system
- **BLTConfigure** — in-game configuration UI

---

## What This Fork Adds

### Dragon & Chariot Mounts (RoT 8.0)

When creating or editing a class in BLT Configure, two new checkboxes appear:

| Option | T1–T3 | T4–T6 |
|---|---|---|
| **Use Dragon (RoT)** | `dragon_black`, `dragon_brown`, `dragon_gold` (ground) | `dragon_black2`, `dragon_brown2`, `dragon_gold2` (flying) |
| **Use Chariot (RoT)** | `chariot1`, `chariot2`, `chariot3` | `chariot4`, `chariot5`, `chariot6` (advanced) |

Works without RoT 8.0 — the checkboxes won't crash the game, mount is simply not assigned.

### T7 and T8 Prestige Tiers

| Tier | Cost | Effect |
|------|------|--------|
| **T7** | 600 000 gold | All equipment gets the best available ItemModifier (≈ 1.5× stats) |
| **T8** | 900 000 gold | T7 + hero HP doubled via Harmony patch |

### MakeBltGreatAgain Powers

All MBGA powers are built directly into BLTAdoptAHero — no separate mod folder needed.

Strike powers, Aura powers, Survival powers, Support powers and more.  
See [MakeBltGreatAgain](https://github.com/MesmerTurn/MakeBltGreatAgain) for the full power list.

### Other Changes

- Version watermark shows **BLTv5.3.1**
- PrestigeSpeedPatch crash fixed

---

## Installation

1. Download `BLT_5.3.1.zip` from the [Releases](../../releases) page
2. Extract into your game's Modules folder:
   ```
   Mount & Blade II Bannerlord\Modules\
   ```
   You should see 4 folders:
   ```
   Modules\
   ├── BannerlordTwitch\
   ├── BLTAdoptAHero\
   ├── BLTBuffet\
   └── BLTConfigure\
   ```
3. Launch the game and enable all 4 BLT modules in the launcher.

---

## Requirements

- **Mount & Blade II Bannerlord** `1.3.15`
- **Realm of Thrones 8.0** (optional — only needed for Dragon/Chariot mounts)

---

## Credits

### BLT — BannerlordTwitch

**billw** — the original creator of BLT who built the entire foundation this mod runs on.  
A massive, heartfelt thank you — none of this would exist without your work. 🙏

**Randomchair22** — for maintaining BLT 5.2.4, creating the Dragon fork and keeping it alive.

**kanboru201** — for support, testing and always making things better.

### Warm thanks to the community

**GeneralEddy** — for showing what BLT can truly become and always pushing for more.

**Doravaro** — the streamer who first introduced me to BLT and sparked everything that followed.

---

## License

BannerlordTwitch — original license by billw.  
MakeBltGreatAgain — MIT, free to use, modify and share.
