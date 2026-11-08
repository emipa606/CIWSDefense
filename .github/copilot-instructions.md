# GitHub Copilot Instructions for CIWS_Defense (Continued) Mod

## Mod Overview and Purpose

CIWS_Defense (Continued) is an updated version of the CIWS mod, originally created by topp2000. The mod enhances the defense capabilities of the RimWorld game by adding various defensive structures and weapons. The primary goal is to provide players with a wide range of options for protecting their colonies, including advanced turrets, defensive walls, and specialized shells. The mod ensures compatibility with different versions of RimWorld and supports both English and Traditional Chinese languages.

## Key Features and Systems

- **Advanced Turrets**: Multiple types of turrets, including long-range sniper towers and rapid-fire mortars, are available for defense.
- **Defensive Walls**: Various walls are added, including bulletproof walls and high defensive walls, each requiring specific materials like cement and graphene.
- **Specialized Shells**: Different types of shells, such as 120mm shells and specialized shells for the B-type turrets, enhance the effectiveness of the turrets.
- **Research Projects**: New research projects are introduced to unlock advanced defense technologies.
- **Compatibility**: The mod is compatible with different versions of RimWorld, ensuring smooth updates and integration.

## Coding Patterns and Conventions

### C# Code

- **Namespace and Class Naming**: Use a clear and descriptive namespace and class names. For example, `CIWSDefense` and `CIWSAnesthetic`.
- **Method Naming**: Use PascalCase for method names. For example, `TryCastShot`.
- **Documentation**: Include XML documentation comments for all public and internal members to improve code readability and maintainability.
- **Error Handling**: Implement robust error handling and logging to capture any issues that may arise during runtime.

### XML Code

- **File Naming**: Use descriptive names for XML files, indicating their purpose. For example, `ResearchProjects_Tier2_Misc.xml` and `Buildings_Security.xml`.
- **Structure**: Organize XML files into logical groups, such as `ResearchProjectDefs`, `ThingDefs_Buildings`, and `ThingDefs_Items`.
- **Attributes and Elements**: Use consistent naming conventions for attributes and elements. For example, `damageDef`, `ThingDef`, and `turretGunDef`.
- **Comments**: Include comments in XML files to explain complex configurations or changes.

## XML Integration

The mod extensively uses XML files to define various game elements such as research projects, building definitions, and item definitions. These files are located in the `Defs` directory and are structured to integrate seamlessly with RimWorld's data system.

### Example XML File Structure

xml
<ResearchProjectDef>
    <defName>CIWS_Tier2_Misc</defName>
    <label>Advanced Defense Research</label>
    <description>Unlocks new defense technologies.</description>
    <prerequisites>
        <li>ResearchProjectDefOf.BasicEngineering</li>
    </prerequisites>
    <cost>5000</cost>
</ResearchProjectDef>


### XML Definitions

- **ResearchProjectDef**: Defines research projects that players can undertake to unlock new technologies.
- **ThingDef**: Defines game objects such as buildings, items, and turrets.
- **DamageDef**: Defines damage types and their properties.

## Harmony Patching

Harmony is used to patch existing RimWorld code to introduce new features or modify existing behavior without directly altering the original game files. This ensures that the mod can be updated alongside the game without conflicts.

### Example Harmony Patch

csharp
using HarmonyLib;
using Verse;

namespace CIWSDefense
{
    [HarmonyPatch(typeof(ThingDef), "SpecialDisplayStats")]
    public static class CIWSAnesthetic
    {
        public static void Postfix(ThingDef __instance, ref IEnumerable<StatDrawEntry> __result)
        {
            if (__instance == ThingDef.Named("CIWSAnesthetic"))
            {
                __result = __result.Concat(new[]
                {
                    new StatDrawEntry(StatCategoryDefOf.Basics, "SpecialEffect", "Anesthetizes enemies", 0f, ToStringNumberMode.None, true)
                });
            }
        }
    }
}


### Patching Guidelines

- **Target Method**: Clearly identify the method you want to patch using `[HarmonyPatch]`.
- **Patch Type**: Use `Postfix`, `Prefix`, or `Transpiler` based on your needs.
- **Parameter Handling**: Use `__instance` for the instance of the class and `__result` for the return value in postfix patches.
- **Error Handling**: Ensure that your patches handle potential exceptions and edge cases.

## Suggestions for Copilot

### XML Generation

When generating XML files for new game elements, Copilot should:

- Use the existing XML structure as a template.
- Ensure that all required attributes and elements are included.
- Provide comments and descriptions for new definitions.

### C# Code Generation

When generating C# code for new features, Copilot should:

- Follow the established coding patterns and conventions.
- Use XML documentation comments for all public and internal members.
- Include error handling and logging for robustness.
- Provide examples of how to integrate new code with existing game systems.

### Harmony Patches

When generating Harmony patches, Copilot should:

- Clearly identify the target method and patch type.
- Use appropriate parameter handling and return value manipulation.
- Ensure that the patch does not introduce new bugs or conflicts with existing code.

### General Guidelines

- Always test generated code in a controlled environment before integrating it into the mod.
- Review and refine generated code to ensure it meets the mod's requirements and coding standards.
- Use Copilot as a tool to assist in the development process, but ultimately rely on human judgment and testing for final verification.

By following these guidelines, you can leverage GitHub Copilot to efficiently develop and maintain the CIWS_Defense (Continued) mod for RimWorld.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

