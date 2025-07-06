# NAppClean (Native App Cleanup)
This tool started as an internal helper module embedded inside my main platform, [CrapFixer](https://github.com/builtbybel/CrapFixer) but it's now fully standalone. 

It is inspired by the upcoming Microsoft Group Policy in Windows 11 25H2 — Remove Default Microsoft Store Packages. That native policy (first seen in Insider Dev 25H2) lets you uninstall select inbox apps during new user profile creation, no scripts required. Source: "[Remove Default Microsoft Store Packages](https://patchmypc.com/blog/remove-default-microsoft-store-packages/)"

Every time you deploy a Windows device, the bloat strikes again. Tired of running PowerShell scripts just to keep your endpoints clean?
Microsoft is finally rolling out a native policy in Windows 11 25H2.
Great news but limited. No custom rules, no third-party cleanup, limited UI. The MS 25H2 GPO only covers key first-party apps (Photos, Solitaire etc.). NAppClean gives admins full control — remove whatever you want, whenever you want, with zero installation fuss.
So heres NAppClean, the smallest possible UI tool that does more than what Microsofts policy currently offers

![NAppClean_Dj7MYLLThp](https://github.com/user-attachments/assets/872fa8a6-fa54-4adb-8f8d-5a702859034a)

**What It Does**
- Reads from PolicyPatterns.txt (or falls back to [CrapFixer](https://github.com/builtbybel/CrapFixer)\Plugins\CFEnhancer.txt)
- Uninstalls pre-installed Microsoft Store apps based on match patterns
- Supports pattern-based whitelisting
- Can even detect all installed apps using wildcard *
- Extendable to third-party packages — you control what gets zapped
- GUI inspired by Group Policy Editor, but smaller than any built-in tool

**Perfect for lightweight scenarios like**
- Intune / Autopilot post-deployment
- Build-tag filters in PolicyPatterns.txt
- Custom admin images
- Manual cleanup with visual feedback
- Integration into CrapFixer as standalone module

- 🔜 Roadmap
- Intune / Autopilot hooks
- Cloud-synced presets + AI-recommendations



