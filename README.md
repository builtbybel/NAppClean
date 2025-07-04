# NAppClean
This tool started as an internal helper module embedded inside my main platform, [CrapFixer](https://github.com/builtbybel/CrapFixer) but it's now fully standalone. 

Every time you deploy a Windows device, the bloat strikes again. Tired of running PowerShell scripts just to keep your endpoints clean?
Microsoft is finally rolling out a native policy in Windows 11 25H2:
Source: "[Remove Default Microsoft Store Packages](https://patchmypc.com/blog/remove-default-microsoft-store-packages/)"
Great news but limited. No custom rules, no third-party cleanup, limited UI
So heres NAppClean, the smallest possible UI tool that does more than what Microsofts policy currently offers

![NAppClean_dWMq2lrGUB](https://github.com/user-attachments/assets/3954ae91-c7b8-4cf2-be6b-482d9d00eae5)

**What It Does**
- Reads from PolicyPatterns.txt (or falls back to Plugins/CFEnhancer.txt)
-  Uninstalls pre-installed UWP apps based on match patterns
-  Supports pattern-based whitelisting
-   Can even detect all installed apps using wildcard *
-   Extendable to third-party packages — you control what gets zapped
-   GUI inspired by Group Policy Editor, but smaller than any built-in tool

**Perfect for lightweight scenarios like**
- Intune / Autopilot post-deployment
- Custom admin images
- Manual cleanup with visual feedback


