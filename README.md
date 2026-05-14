# Helve Hammer Extensions (Continued)

A Vintage Story mod that lets the helve hammer auto-forge most things,
not just the small handful of items vanilla allows. Works in single-player and
on dedicated servers; in multiplayer both the server and connecting clients
need the mod installed.

- **ModDB page:** https://mods.vintagestory.at/helvehammerextcontinued
- **Original mod page:** https://mods.vintagestory.at/helvehammerext
- **Forum thread:** https://www.vintagestory.at/forums/topic/3916-helve-hammer-extensions/

## About this fork

Continuation fork of [DArkHekRoMaNT/HelveHammerExtensions](https://github.com/DArkHekRoMaNT/HelveHammerExtensions),
which was last updated for Vintage Story 1.21 and is no longer being maintained.
Published under modid `helvehammerextcontinued` to coexist with the original on
ModDB.

Changes vs. upstream:

- Builds clean against VS 1.22 / .NET 10.
- No CommonLib dependency — config loading uses the native VS API, so the mod
  ships as a single self-contained DLL.
- Vanilla patches rewritten with the `addmerge` op. The original mod
  pre-allocated `/attributes: {}` on a hard-coded list of vanilla items to make
  room for the `helvehammerworkable` flag. In 1.22 every vanilla toolhead now
  ships with a populated `attributes` block, so the original `add` patch would
  silently overwrite it (clobbering transforms, handbook groupings, forgability
  flags). `addmerge` merges into the existing object instead, and works
  uniformly against every wildcard target.
- Stale-config recovery: if the existing `helvehammerext.json` on disk fails to
  deserialize, the mod logs a warning and resets to defaults instead of
  crashing.
- Harmony unpatch is scoped to `Mod.Info.ModID` so disposing the mod can never
  strip patches owned by other mods.

## Configuration

First run writes `<VS data dir>/ModConfig/helvehammerext.json` with defaults.
Edit and reload.

| Field | Default | Notes |
|---|---|---|
| `AllWorkable` | `false` | Treat every item as helve-workable, regardless of the per-recipe `helvehammerworkable` attribute. |
| `DefaultWorkable` | `true` | Fallback when a recipe output has no `helvehammerworkable` attribute. |
| `AnvilTier` | `3` | Minimum anvil tier required (1=copper, 2=bronze, 3=iron, 4=steel in vanilla). |

## License

Same as upstream — see [LICENSE](LICENSE).
