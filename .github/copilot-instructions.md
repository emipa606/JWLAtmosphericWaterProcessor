# Copilot Instructions for RimWorld Desalination Plant Mod

## Mod Overview and Purpose
The Desalination Plant mod for RimWorld introduces new mechanics for water purification, allowing players to convert ocean or coastal water into usable fresh water for their colonies. This adds a new strategic layer to colony management, especially in coastal or water-scarce environments.

## Key Features and Systems
- **Desalination Plant Building**: A new structure that players can construct near coastal or ocean tiles to produce fresh water.
- **Water Source Detection**: The mod utilizes custom logic to identify suitable water bodies for desalination.
- **Resource Management**: Integrates with RimWorld's resource management systems to generate fresh water units that can be stored or consumed.

## Coding Patterns and Conventions
- **Classes and Components**: The mod is structured using components and properties via classes such as `CompDesalinationPlant` and `CompProperties_DesalinationPlant`.
  - **Component Patterns**: Follow RimWorld's common pattern of component-based design. Each building or object has its behavior encapsulated in components.
- **Naming Conventions**: Use PascalCase for class and method names, and camelCase for local variables and method parameters.

## XML Integration
- Define all game data and configuration settings in XML files.
- Utilize XML to define the building properties, such as construction cost, research requirements, and power consumption.
- Integrate XML entries with C# logic to dynamically control building behavior based on game state and environment.

## Harmony Patching
- Apply Harmony patches to modify core game functions without directly altering the game’s source code. This ensures compatibility and reduces the risk of conflicts with other mods.
- Target relevant game methods that interact with building placements and map sanitation systems to integrate the desalination logic seamlessly.

## Suggestions for Copilot
- **C# Code Generation**: Use Copilot to facilitate the creation of methods and classes that handle desalination logic, including resource conversion and environment checks.
- **XML File Suggestions**: While writing XML definition files, Copilot can assist with XML schema validation, ensuring that all necessary fields are correctly formatted and defined.
- **Harmony Patch Assistance**: Generate boilerplate code for Harmony patches and recommendations for applying patches to specific game methods core to your mod's function.
- **Error Handling and Debugging**: Implement suggestions for handling potential errors when interacting with water bodies, ensuring the mod operates smoothly under all game scenarios.

By following these guidelines and utilizing Copilot's suggestions, you can streamline the development process while maintaining code quality and mod stability.
