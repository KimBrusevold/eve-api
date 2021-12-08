# eve-api

[![.NET](https://github.com/KimBrusevold/eve-api/actions/workflows/dotnet_build_and_test.yml/badge.svg?branch=main)](https://github.com/KimBrusevold/eve-api/actions/workflows/dotnet_build_and_test.yml)
[![CodeQL](https://github.com/KimBrusevold/eve-api/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/KimBrusevold/eve-api/actions/workflows/codeql-analysis.yml)

Use Official EVE Online - Rest Api to do something

Library Project -> EVE.Api

Some point there may be a website project in as well

# Current step:

## Character

 * Finish mail reading, ability to choose a mail from list and display
 * Show character's "Current Location" in the game
 * Show character's jump-clones
 * Gather and show character's assets in the game, display character's total value
 * Generate a GUI for displaying

## Economy

 * Gather a collection of materials to a list
 * Ability to choose "Region"/"System"
 * Show the average price of materials in the chosen Region/System

## Trade routes

 * Where to buy, where to sell
 * Calculate number of jumps, and estimated time/distance (based on ship warp speed and alignment time)

## Future

* Generate a "bait-protection". Expensive materials/components in a low-security system is most likely bait, and should be avoided

 * High risk/High reward trade routes.
