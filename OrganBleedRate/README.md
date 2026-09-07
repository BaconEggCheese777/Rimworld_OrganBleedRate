# Organ Bleed Rate x2

Doubles the bleed rate of the Brain, Heart, and Liver. Everything else is
untouched.

## How it works

`BodyPartDef` already has a plain `bleedRate` field (vanilla uses it too -
e.g. the head bleeds faster than a finger). `BleedRateInit` runs once,
right after all defs finish loading, and multiplies that field by 2 for
just those three organs. No Harmony, no XML patch - just a couple of
direct field writes.

## How to build

Same GitHub Actions flow as your other mods:

1. New **public** repo (e.g. "OrganBleedRate").
2. Upload this folder's contents, keeping `About/` and `Source/` intact.
3. Add `.github/workflows/build.yml` manually if drag-and-drop skips the
   hidden `.github` folder.
4. Check **Actions**, download the `OrganBleedRateMod-dll` artifact once
   it's green.
5. Drop `OrganBleedRateMod.dll` into `Assemblies/`.
6. Copy the whole `OrganBleedRate` folder into your RimWorld `Mods` folder,
   enable, restart.

## Verifying in-game

Dev Mode -> damage a pawn's Brain, Heart, or Liver until it's bleeding,
and check the bleeding rate shown on that injury/organ versus an equivalent
wound on, say, an arm - it should be twice as fast.

## Folder layout

```
OrganBleedRate/
  About/About.xml
  Source/OrganBleedRateMod/   - C# source + csproj
  Assemblies/                 - compiled DLL goes here
  .github/workflows/build.yml
```
